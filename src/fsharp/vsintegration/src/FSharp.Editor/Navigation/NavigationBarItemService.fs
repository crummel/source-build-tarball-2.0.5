// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.VisualStudio.FSharp.Editor

open System.Composition
open System.Collections.Generic
open System.Threading.Tasks

open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.Editor
open Microsoft.CodeAnalysis.Navigation
open Microsoft.CodeAnalysis.Host.Mef
open Microsoft.CodeAnalysis.Text
open Microsoft.CodeAnalysis.Notification

open Microsoft.FSharp.Compiler.SourceCodeServices

type internal NavigationBarSymbolItem(text, glyph, spans, childItems) =
    inherit NavigationBarItem(text, glyph, spans, childItems)

[<ExportLanguageService(typeof<INavigationBarItemService>, FSharpConstants.FSharpLanguageName); Shared>]
type internal FSharpNavigationBarItemService
    [<ImportingConstructor>]
    (
        checkerProvider: FSharpCheckerProvider,
        projectInfoManager: ProjectInfoManager
    ) =
    
    static let userOpName = "NavigationBarItem"
    static let emptyResult: IList<NavigationBarItem> = upcast [||]

    interface INavigationBarItemService with
        member __.GetItemsAsync(document, cancellationToken) : Task<IList<NavigationBarItem>> = 
            asyncMaybe {
                let! options = projectInfoManager.TryGetOptionsForEditingDocumentOrProject(document)
                let! sourceText = document.GetTextAsync(cancellationToken)
                let! parsedInput = checkerProvider.Checker.ParseDocument(document, options, sourceText=sourceText, userOpName=userOpName)
                let navItems = NavigationImpl.getNavigation parsedInput
                let rangeToTextSpan range = RoslynHelpers.TryFSharpRangeToTextSpan(sourceText, range)
                return 
                    navItems.Declarations
                    |> Array.choose (fun topLevelDecl ->
                        rangeToTextSpan(topLevelDecl.Declaration.Range)
                        |> Option.map (fun topLevelTextSpan ->
                            let childItems =
                                topLevelDecl.Nested
                                |> Array.choose (fun decl ->
                                    rangeToTextSpan(decl.Range)
                                    |> Option.map(fun textSpan ->
                                        NavigationBarSymbolItem(decl.Name, decl.RoslynGlyph, [| textSpan |], null) :> NavigationBarItem))
                            
                            NavigationBarSymbolItem(topLevelDecl.Declaration.Name, topLevelDecl.Declaration.RoslynGlyph, [| topLevelTextSpan |], childItems)
                            :> NavigationBarItem)) :> IList<_>
            } 
            |> Async.map (Option.defaultValue emptyResult)
            |> RoslynHelpers.StartAsyncAsTask(cancellationToken)
        
        member __.ShowItemGrayedIfNear (_item) : bool = false
        
        member __.NavigateToItem(document, item, _view, _cancellationToken) =
            match item.Spans |> Seq.tryHead with
            | Some span ->
                let workspace = document.Project.Solution.Workspace
                let navigationService = workspace.Services.GetService<IDocumentNavigationService>()
                
                if navigationService.CanNavigateToPosition(workspace, document.Id, span.Start) then
                    navigationService.TryNavigateToPosition(workspace, document.Id, span.Start) |> ignore
                else
                    let notificationService = workspace.Services.GetService<INotificationService>()
                    notificationService.SendNotification(EditorFeaturesResources.The_definition_of_the_object_is_hidden, severity = NotificationSeverity.Error)
            | None -> ()