// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace Microsoft.VisualStudio.FSharp.Editor

open System.Composition
open System.Collections.Immutable
open System.Threading.Tasks

open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.Diagnostics
open Microsoft.CodeAnalysis.Text
open Microsoft.CodeAnalysis.CodeFixes
open SymbolHelpers

[<ExportCodeFixProvider(FSharpConstants.FSharpLanguageName, Name = PredefinedCodeFixProviderNames.SimplifyNames); Shared>]
type internal FSharpSimplifyNameCodeFixProvider() =
    inherit CodeFixProvider()
    let fixableDiagnosticId = IDEDiagnosticIds.SimplifyNamesDiagnosticId
        
    override __.FixableDiagnosticIds = ImmutableArray.Create(fixableDiagnosticId)

    override __.RegisterCodeFixesAsync(context: CodeFixContext) : Task =
       async {
           for diagnostic in context.Diagnostics |> Seq.filter (fun x -> x.Id = fixableDiagnosticId) do
               let title =
                   match diagnostic.Properties.TryGetValue(SimplifyNameDiagnosticAnalyzer.LongIdentPropertyKey) with
                   | true, longIdent -> sprintf "%s '%s'" (SR.SimplifyName()) longIdent
                   | _ -> SR.SimplifyName()

               let codefix = createTextChangeCodeFix(title, context, (fun () -> asyncMaybe.Return [| TextChange(context.Span, "") |]))

               context.RegisterCodeFix(codefix,  ImmutableArray.Create(diagnostic))
       } 
       |> RoslynHelpers.StartAsyncUnitAsTask(context.CancellationToken)