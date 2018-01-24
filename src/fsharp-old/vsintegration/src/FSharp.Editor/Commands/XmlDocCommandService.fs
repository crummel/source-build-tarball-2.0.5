﻿// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.VisualStudio.FSharp.Editor

open System
open Microsoft.VisualStudio.Text.Editor
open Microsoft.VisualStudio.OLE.Interop
open System.ComponentModel.Composition
open Microsoft.VisualStudio
open Microsoft.VisualStudio.Editor
open Microsoft.VisualStudio.Text
open Microsoft.VisualStudio.TextManager.Interop
open Microsoft.VisualStudio.Utilities
open Microsoft.VisualStudio.LanguageServices.Implementation.ProjectSystem
open Microsoft.FSharp.Compiler.SourceCodeServices
open Microsoft.VisualStudio.FSharp.LanguageService
open System.Runtime.InteropServices

type internal XmlDocCommandFilter 
     (
        wpfTextView: IWpfTextView, 
        filePath: string, 
        checkerProvider: FSharpCheckerProvider,
        projectInfoManager: ProjectInfoManager,
        workspace: VisualStudioWorkspaceImpl
     ) =

    static let userOpName = "XmlDocCommand"

    let checker = checkerProvider.Checker

    let document =
        // There may be multiple documents with the same file path.
        // However, for the purpose of generating XmlDoc comments, it is ok to keep only the first document.
        lazy(match workspace.CurrentSolution.GetDocumentIdsWithFilePath(filePath) |> Seq.toList with
             | [] -> None
             | documentId :: _ -> Some (workspace.CurrentSolution.GetDocument documentId))

    /// Get the char for a <see cref="VSConstants.VSStd2KCmdID.TYPECHAR"/> command.
    let getTypedChar(pvaIn: IntPtr) = 
        char (Marshal.GetObjectForNativeVariant(pvaIn) :?> uint16)
        
    let mutable nextTarget = null

    member this.AttachToViewAdapter (viewAdapter: IVsTextView) =
        match viewAdapter.AddCommandFilter this with
        | VSConstants.S_OK, next ->
            nextTarget <- next
        | errorCode, _ -> 
            ErrorHandler.ThrowOnFailure errorCode |> ignore

    interface IOleCommandTarget with
        member __.Exec(pguidCmdGroup: byref<Guid>, nCmdID: uint32, nCmdexecopt: uint32, pvaIn: IntPtr, pvaOut: IntPtr) =
            if pguidCmdGroup = VSConstants.VSStd2K && nCmdID = uint32 VSConstants.VSStd2KCmdID.TYPECHAR then
                match getTypedChar pvaIn with
                | ('/' | '<') as lastChar ->
                    let indexOfCaret = wpfTextView.Caret.Position.BufferPosition.Position 
                                        - wpfTextView.Caret.Position.BufferPosition.GetContainingLine().Start.Position 
                    let curLine = wpfTextView.Caret.Position.BufferPosition.GetContainingLine().GetText()
                    let lineWithLastCharInserted = curLine.Insert (indexOfCaret, string lastChar)

                    match XmlDocComment.isBlank lineWithLastCharInserted with
                    | Some i when i = indexOfCaret ->
                        asyncMaybe {
                            try
                                // XmlDocable line #1 are 1-based, editor is 0-based
                                let curLineNum = wpfTextView.Caret.Position.BufferPosition.GetContainingLine().LineNumber + 1
                                let! document = document.Value
                                let! options = projectInfoManager.TryGetOptionsForEditingDocumentOrProject(document)
                                let sourceText = wpfTextView.TextBuffer.CurrentSnapshot.GetText()
                                let! parsedInput = checker.ParseDocument(document, options, sourceText, userOpName)
                                let xmlDocables = XmlDocParser.getXmlDocables (sourceText, Some parsedInput) 
                                let xmlDocablesBelowThisLine = 
                                    // +1 because looking below current line for e.g. a 'member'
                                    xmlDocables |> List.filter (fun (XmlDocable(line,_indent,_paramNames)) -> line = curLineNum+1) 
                                match xmlDocablesBelowThisLine with
                                | [] -> ()
                                | XmlDocable(_line,indent,paramNames)::_xs ->
                                    // delete the slashes the user typed (they may be indented wrong)
                                    wpfTextView.TextBuffer.Delete(wpfTextView.Caret.Position.BufferPosition.GetContainingLine().Extent.Span) |> ignore
                                    // add the new xmldoc comment
                                    let toInsert = new System.Text.StringBuilder()
                                    toInsert.Append(' ', indent).AppendLine("/// <summary>")
                                            .Append(' ', indent).AppendLine("/// ")
                                            .Append(' ', indent).Append("/// </summary>") |> ignore
                                    paramNames
                                    |> List.iter (fun p ->
                                        toInsert.AppendLine().Append(' ', indent).Append(sprintf "/// <param name=\"%s\"></param>" p) |> ignore)
                                    let _newSS = wpfTextView.TextBuffer.Insert(wpfTextView.Caret.Position.BufferPosition.Position, toInsert.ToString())
                                    // move the caret to between the summary tags
                                    let lastLine = wpfTextView.Caret.Position.BufferPosition.GetContainingLine()
                                    let middleSummaryLine = wpfTextView.TextSnapshot.GetLineFromLineNumber(lastLine.LineNumber - 1 - paramNames.Length)
                                    wpfTextView.Caret.MoveTo(wpfTextView.GetTextViewLineContainingBufferPosition(middleSummaryLine.Start)) |> ignore
                            with ex ->
                              Assert.Exception ex
                              ()
                        }
                        |> Async.Ignore
                        |> Async.StartImmediate
                    | Some _ 
                    | None -> ()
                | _ -> ()
            if not (isNull nextTarget) then
                nextTarget.Exec(&pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut)
            else
                VSConstants.E_FAIL

        member __.QueryStatus(pguidCmdGroup: byref<Guid>, cCmds: uint32, prgCmds: OLECMD [], pCmdText: IntPtr) =
            if not (isNull nextTarget) then
                nextTarget.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText)
            else
                VSConstants.E_FAIL

[<Export(typeof<IWpfTextViewCreationListener>)>]
[<ContentType(FSharpConstants.FSharpContentTypeName)>]
[<TextViewRole(PredefinedTextViewRoles.PrimaryDocument)>]
type internal XmlDocCommandFilterProvider 
    [<ImportingConstructor>] 
    (checkerProvider: FSharpCheckerProvider,
     projectInfoManager: ProjectInfoManager,
     workspace: VisualStudioWorkspaceImpl,
     textDocumentFactoryService: ITextDocumentFactoryService,
     editorFactory: IVsEditorAdaptersFactoryService) =
    interface IWpfTextViewCreationListener with
        member __.TextViewCreated(textView) = 
            match editorFactory.GetViewAdapter(textView) with
            | null -> ()
            | textViewAdapter ->
                match textDocumentFactoryService.TryGetTextDocument(textView.TextBuffer) with
                | true, doc ->
                    let commandFilter = XmlDocCommandFilter(textView, doc.FilePath, checkerProvider, projectInfoManager, workspace)
                    commandFilter.AttachToViewAdapter textViewAdapter
                | _ -> ()