// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.VisualStudio.FSharp.Editor

open System
open System.Text.RegularExpressions
open System.IO
open System.Collections.Immutable
open System.Threading
open System.Threading.Tasks
open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.Completion
open Microsoft.CodeAnalysis.Editor.Implementation.IntelliSense.Completion.FileSystem
open Microsoft.CodeAnalysis.Text
open Microsoft.CodeAnalysis.Classification

type internal Completion =
    { DirectiveRegex: Regex
      AllowableExtensions: string list
      UseIncludeDirectives: bool }
    static member Create(directiveRegex, allowableExtensions, useIncludeDirectives) =
        { DirectiveRegex = Regex(directiveRegex, RegexOptions.Compiled ||| RegexOptions.ExplicitCapture)
          AllowableExtensions = allowableExtensions
          UseIncludeDirectives = useIncludeDirectives }

type internal HashDirectiveCompletionProvider(workspace: Workspace, projectInfoManager: ProjectInfoManager, completions: Completion list) =
    inherit CommonCompletionProvider()

    let [<Literal>] NetworkPath = "\\\\"
    let commitRules = ImmutableArray.Create(CharacterSetModificationRule.Create(CharacterSetModificationKind.Replace, '"', '\\', ',', '/'))
    let rules = CompletionItemRules.Create(commitCharacterRules = commitRules)

    let getQuotedPathStart(text: SourceText, position: int, quotedPathGroup: Group) =
        text.Lines.GetLineFromPosition(position).Start + quotedPathGroup.Index

    let getPathThroughLastSlash(text: SourceText, position: int, quotedPathGroup: Group) =
        PathCompletionUtilities.GetPathThroughLastSlash(
            quotedPath = quotedPathGroup.Value,
            quotedPathStart = getQuotedPathStart(text, position, quotedPathGroup),
            position = position)
 
    let getTextChangeSpan(text: SourceText, position: int, quotedPathGroup: Group) =
        PathCompletionUtilities.GetTextChangeSpan(
            quotedPath = quotedPathGroup.Value,
            quotedPathStart = getQuotedPathStart(text, position, quotedPathGroup),
            position = position)

    let getFileGlyph (extention: string) =
        match extention with
        | ".exe" | ".dll" -> Some Glyph.Assembly
        | _ -> None

    let includeDirectiveCleanRegex = Regex("""#I\s+(@?"*(?<literal>[^"]*)"?)""", RegexOptions.Compiled ||| RegexOptions.ExplicitCapture)

    let getColorizationData(text: SourceText, position: int) : ResizeArray<ClassifiedSpan> =
        let documentId = workspace.GetDocumentIdInCurrentContext(text.Container)
        let document = workspace.CurrentSolution.GetDocument(documentId)
        let defines = projectInfoManager.GetCompilationDefinesForEditingDocument(document)
        let textLines = text.Lines
        let triggerLine = textLines.GetLineFromPosition(position)
        Tokenizer.getColorizationData(documentId, text, triggerLine.Span, Some document.FilePath, defines, CancellationToken.None)

    let isInStringLiteral(text: SourceText, position: int) : bool =
        getColorizationData(text, position)
        |> Seq.exists(fun classifiedSpan -> 
            classifiedSpan.TextSpan.IntersectsWith position &&
            classifiedSpan.ClassificationType = ClassificationTypeNames.StringLiteral)

    let getIncludeDirectives (text: SourceText, position: int) =
        let lines = text.Lines
        let caretLine = text.Lines.GetLinePosition(position).Line
        lines
        |> Seq.filter (fun x -> x.LineNumber < caretLine)
        |> Seq.choose (fun line ->
            let lineStr = line.ToString().Trim()
            // optimization: fail fast if the line does not start with "(optional spaces) #I"
            if not (lineStr.StartsWith "#I") then None
            else
                match includeDirectiveCleanRegex.Match lineStr with
                | m when m.Success ->
                    getColorizationData(text, line.Start)
                    |> Seq.tryPick (fun span -> 
                        if span.TextSpan.IntersectsWith line.Start &&
                           (span.ClassificationType <> ClassificationTypeNames.Comment &&
                            span.ClassificationType <> ClassificationTypeNames.ExcludedCode) then
                            Some (m.Groups.["literal"].Value)
                        else None)
                | _ -> None
           )
        |> Seq.toList

    override this.ProvideCompletionsAsync(context) =
        asyncMaybe {    
            let document = context.Document
            let position = context.Position
            do! let extension = Path.GetExtension document.FilePath
                Option.guard (extension = ".fsx" || extension = ".fsscript")

            let! ct = liftAsync Async.CancellationToken
            let! text = document.GetTextAsync(ct)
            do! Option.guard (isInStringLiteral(text, position))
            let line = text.Lines.GetLineFromPosition(position)
            let lineText = text.ToString(TextSpan.FromBounds(line.Start, position))
            
            let! completion, quotedPathGroup =
                completions |> List.tryPick (fun completion ->
                    match completion.DirectiveRegex.Match lineText with
                    | m when m.Success ->
                        let quotedPathGroup = m.Groups.["literal"]
                        let endsWithQuote = PathCompletionUtilities.EndsWithQuote(quotedPathGroup.Value)
                        if endsWithQuote && (position >= line.Start + m.Length) then
                            None
                        else
                            Some (completion, quotedPathGroup)
                    | _ -> None)

            let snapshot = text.FindCorrespondingEditorTextSnapshot()
            
            do! Option.guard (not (isNull snapshot))
            let fileSystem = CurrentWorkingDirectoryDiscoveryService.GetService(snapshot)
            
            let extraSearchPaths =
                if completion.UseIncludeDirectives then
                    getIncludeDirectives (text, position)
                else []
            
            let defaultSearchPath = Path.GetDirectoryName document.FilePath
            let searchPaths = defaultSearchPath :: extraSearchPaths
            
            let helper = 
                FileSystemCompletionHelper(
                    this,
                    getTextChangeSpan(text, position, quotedPathGroup),
                    fileSystem,
                    Glyph.OpenFolder,
                    completion.AllowableExtensions |> List.tryPick getFileGlyph |> Option.defaultValue Glyph.None,
                    searchPaths = Seq.toImmutableArray searchPaths,
                    allowableExtensions = completion.AllowableExtensions,
                    itemRules = rules)
     
            let pathThroughLastSlash = getPathThroughLastSlash(text, position, quotedPathGroup)
            let documentPath = if document.Project.IsSubmission then null else document.FilePath
            context.AddItems(helper.GetItems(pathThroughLastSlash, documentPath))
        } 
        |> Async.Ignore
        |> RoslynHelpers.StartAsyncUnitAsTask context.CancellationToken
 
    override __.IsInsertionTrigger(text, position, _) = 
        // Bring up completion when the user types a quote (i.e.: #r "), or if they type a slash
        // path separator character, or if they type a comma (#r "foo,version...").
        // Also, if they're starting a word.  i.e. #r "c:\W
        let ch = text.[position]
        let isTriggerChar = 
            ch = '"' || ch = '\\' || ch = ',' || ch = '/' ||
                CommonCompletionUtilities.IsStartingNewWord(text, position, (fun x -> Char.IsLetter x), (fun x -> Char.IsLetterOrDigit x))
        isTriggerChar && isInStringLiteral(text, position)
 
    override __.GetTextChangeAsync(selectedItem, ch, cancellationToken) = 
        // When we commit "\\" when the user types \ we have to adjust for the fact that the
        // controller will automatically append \ after we commit.  Because of that, we don't
        // want to actually commit "\\" as we'll end up with "\\\".  So instead we just commit
        // "\" and know that controller will append "\" and give us "\\".
        if selectedItem.DisplayText = NetworkPath && ch = Nullable '\\' then
            Task.FromResult(Nullable(TextChange(selectedItem.Span, "\\")))
        else
            base.GetTextChangeAsync(selectedItem, ch, cancellationToken)