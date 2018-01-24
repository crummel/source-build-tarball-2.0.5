// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.VisualStudio.FSharp.Editor

open System
open System.Composition
open System.Collections.Immutable
open System.Threading.Tasks

open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.Editor
open Microsoft.CodeAnalysis.Host.Mef
open Microsoft.CodeAnalysis.Text

open Microsoft.FSharp.Compiler.SourceCodeServices
open Microsoft.FSharp.Compiler.Range

type internal FSharpHighlightSpan =
    { IsDefinition: bool
      TextSpan: TextSpan }
    override this.ToString() = sprintf "%+A" this

[<Shared>]
[<ExportLanguageService(typeof<IDocumentHighlightsService>, FSharpConstants.FSharpLanguageName)>]
type internal FSharpDocumentHighlightsService [<ImportingConstructor>] (checkerProvider: FSharpCheckerProvider, projectInfoManager: ProjectInfoManager) =

    static let userOpName = "DocumentHighlights"

    /// Fix invalid spans if they appear to have redundant suffix and prefix.
    static let fixInvalidSymbolSpans (sourceText: SourceText) (lastIdent: string) (spans: FSharpHighlightSpan []) =
        spans
        |> Seq.choose (fun (span: FSharpHighlightSpan) ->
            let newLastIdent = sourceText.GetSubText(span.TextSpan).ToString()
            let index = newLastIdent.LastIndexOf(lastIdent, StringComparison.Ordinal)
            if index > 0 then 
                // Sometimes FCS returns a composite identifier for a short symbol, so we truncate the prefix
                // Example: newLastIdent --> "x.Length", lastIdent --> "Length"
                Some { span with TextSpan = TextSpan(span.TextSpan.Start + index, span.TextSpan.Length - index) }
            elif index = 0 && newLastIdent.Length > lastIdent.Length then
                // The returned symbol use is too long; we truncate its redundant suffix
                // Example: newLastIdent --> "Length<'T>", lastIdent --> "Length"
                Some { span with TextSpan = TextSpan(span.TextSpan.Start, lastIdent.Length) }
            elif index = 0 then
                Some span
            else
                // In the case of attributes, a returned symbol use may be a part of original text
                // Example: newLastIdent --> "Sample", lastIdent --> "SampleAttribute"
                let index = lastIdent.LastIndexOf(newLastIdent, StringComparison.Ordinal)
                if index >= 0 then
                    Some span
                else None)
        |> Seq.distinctBy (fun span -> span.TextSpan.Start)
        |> Seq.toArray

    static member GetDocumentHighlights(checker: FSharpChecker, documentKey: DocumentId, sourceText: SourceText, filePath: string, position: int, 
                                        defines: string list, options: FSharpProjectOptions, textVersionHash: int) : Async<FSharpHighlightSpan[] option> =
        asyncMaybe {
            let textLine = sourceText.Lines.GetLineFromPosition(position)
            let textLinePos = sourceText.Lines.GetLinePosition(position)
            let fcsTextLineNumber = Line.fromZ textLinePos.Line
            let! symbol = Tokenizer.getSymbolAtPosition(documentKey, sourceText, position, filePath, defines, SymbolLookupKind.Greedy, false)
            let! _, _, checkFileResults = checker.ParseAndCheckDocument(filePath, textVersionHash, sourceText.ToString(), options, allowStaleResults = true, userOpName = userOpName)
            let! symbolUse = checkFileResults.GetSymbolUseAtLocation(fcsTextLineNumber, symbol.Ident.idRange.EndColumn, textLine.ToString(), symbol.FullIsland, userOpName=userOpName)
            let! symbolUses = checkFileResults.GetUsesOfSymbolInFile(symbolUse.Symbol) |> liftAsync
            return 
                [| for symbolUse in symbolUses do
                     match RoslynHelpers.TryFSharpRangeToTextSpan(sourceText, symbolUse.RangeAlternate) with 
                     | None -> ()
                     | Some span -> 
                         yield { IsDefinition = symbolUse.IsFromDefinition
                                 TextSpan = span } |]
                |> fixInvalidSymbolSpans sourceText symbol.Ident.idText
        }

    interface IDocumentHighlightsService with
        member __.GetDocumentHighlightsAsync(document, position, _documentsToSearch, cancellationToken) : Task<ImmutableArray<DocumentHighlights>> =
            asyncMaybe {
                let! options = projectInfoManager.TryGetOptionsForEditingDocumentOrProject(document)
                let! sourceText = document.GetTextAsync(cancellationToken)
                let! textVersion = document.GetTextVersionAsync(cancellationToken) 
                let defines = CompilerEnvironment.GetCompilationDefinesForEditing(document.Name, options.OtherOptions |> Seq.toList)
                let! spans = FSharpDocumentHighlightsService.GetDocumentHighlights(checkerProvider.Checker, document.Id, sourceText, document.FilePath, 
                                                                                   position, defines, options, textVersion.GetHashCode())
                let highlightSpans = 
                    spans 
                    |> Array.map (fun span ->
                        let kind = if span.IsDefinition then HighlightSpanKind.Definition else HighlightSpanKind.Reference
                        HighlightSpan(span.TextSpan, kind))
                    |> Seq.toImmutableArray
                
                return ImmutableArray.Create(DocumentHighlights(document, highlightSpans))
            }   
            |> Async.map (Option.defaultValue ImmutableArray<DocumentHighlights>.Empty)
            |> RoslynHelpers.StartAsyncAsTask(cancellationToken)
