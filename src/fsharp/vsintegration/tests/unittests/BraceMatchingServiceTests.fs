﻿// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.
namespace Microsoft.VisualStudio.FSharp.Editor.Tests.Roslyn

open System
open System.Threading

open NUnit.Framework

open Microsoft.CodeAnalysis.Classification
open Microsoft.CodeAnalysis.Editor
open Microsoft.CodeAnalysis.Text
open Microsoft.FSharp.Compiler.SourceCodeServices
open Microsoft.VisualStudio.FSharp.Editor
open Microsoft.VisualStudio.FSharp.LanguageService
open UnitTests.TestLib.LanguageService

[<TestFixture>][<Category "Roslyn Services">]
type BraceMatchingServiceTests()  =
    let fileName = "C:\\test.fs"
    let options: FSharpProjectOptions = { 
        ProjectFileName = "C:\\test.fsproj"
        SourceFiles =  [| fileName |]
        ReferencedProjects = [| |]
        OtherOptions = [| |]
        IsIncompleteTypeCheckEnvironment = true
        UseScriptResolutionRules = false
        LoadTime = DateTime.MaxValue
        OriginalLoadReferences = []
        UnresolvedReferences = None
        ExtraProjectInfo = None
        Stamp = None
    }

    member private this.VerifyNoBraceMatch(fileContents: string, marker: string) =
        let sourceText = SourceText.From(fileContents)
        let position = fileContents.IndexOf(marker)
        Assert.IsTrue(position >= 0, "Cannot find marker '{0}' in file contents", marker)

        match FSharpBraceMatchingService.GetBraceMatchingResult(checker, sourceText, fileName, options, position) |> Async.RunSynchronously with
        | None -> ()
        | Some(left, right) -> Assert.Fail("Found match for brace '{0}'", marker)
        
    member private this.VerifyBraceMatch(fileContents: string, startMarker: string, endMarker: string) =
        let sourceText = SourceText.From(fileContents)
        let startMarkerPosition = fileContents.IndexOf(startMarker)
        let endMarkerPosition = fileContents.IndexOf(endMarker)

        Assert.IsTrue(startMarkerPosition >= 0, "Cannot find start marker '{0}' in file contents", startMarkerPosition)
        Assert.IsTrue(endMarkerPosition >= 0, "Cannot find end marker '{0}' in file contents", endMarkerPosition)
        
        match FSharpBraceMatchingService.GetBraceMatchingResult(checker, sourceText, fileName, options, startMarkerPosition) |> Async.RunSynchronously with
        | None -> Assert.Fail("Didn't find a match for start brace at position '{0}", startMarkerPosition)
        | Some(left, right) ->
            let endPositionInRange(range) = 
                let span = RoslynHelpers.FSharpRangeToTextSpan(sourceText, range)
                span.Start <= endMarkerPosition && endMarkerPosition <= span.End
            Assert.IsTrue(endPositionInRange(left) || endPositionInRange(right), "Found end match at incorrect position")
        

    // Starting Brace
    [<TestCase("(marker1", ")marker1")>]
    [<TestCase("{marker2", "}marker2")>]
    [<TestCase("(marker3", ")marker3")>]
    [<TestCase("[marker4", "]marker4")>]
    // Ending Brace
    [<TestCase(")marker1", "(marker1")>]
    [<TestCase("}marker2", "{marker2")>]
    [<TestCase(")marker3", "(marker3")>]
    [<TestCase("]marker4", "[marker4")>]
    member this.NestedBrackets(startMarker: string, endMarker: string) = 
        let code = "
            (marker1
            {marker2
            (marker3
            [marker4
            ]marker4
            )marker3
            }marker2
            )marker1"
        this.VerifyBraceMatch(code, startMarker, endMarker)

    [<Test>]
    member this.BracketInExpression() = 
        this.VerifyBraceMatch("let x = (3*5)-1", "(3*", ")-1")

    [<TestCase("[start")>]
    [<TestCase("]end")>]
    member this.BraceInMultiLineCommentShouldNotBeMatched(startMarker: string) = 
        let code = "
            let x = 3
            (* This [start
            is a multiline
            comment ]end
            *)
            printf \"%d\" x"
        this.VerifyNoBraceMatch(code, startMarker)
        
    [<Test>]
    member this.BraceInAttributesMatch() = 
        let code = "
            [<Attribute>]
            module internal name"
        this.VerifyBraceMatch(code, "[<", ">]")
        
    [<Test>]
    member this.BraceEncapsulatingACommentShouldBeMatched() = 
        let code = "
            let x = 3 + (start
            (* this  is a comment *)
            )end"
        this.VerifyBraceMatch(code, "(start", ")end")
        
    [<TestCase("(endsInComment")>]
    [<TestCase(")endsInComment")>]
    [<TestCase("<startsInComment")>]
    [<TestCase(">startsInComment")>]
    member this.BraceStartingOrEndingInCommentShouldNotBeMatched(startMarker: string) = 
        let code = "
            let x = 123 + (endsInComment
            (* )endsInComment <startsInComment *)
            >startsInComment"
        this.VerifyNoBraceMatch(code, startMarker)
        
    [<TestCase("(endsInDisabledCode")>]
    [<TestCase(")endsInDisabledCode")>]
    [<TestCase("<startsInDisabledCode")>]
    [<TestCase(">startsInDisabledCode")>]
    member this.BraceStartingOrEndingInDisabledCodeShouldNotBeMatched(startMarker: string) = 
        let code = "
            let x = 123 + (endsInDisabledCode
            #if UNDEFINED
            )endsInDisabledCode <startsInDisabledCode
            #endif
            >startsInDisabledCode"
        this.VerifyNoBraceMatch(code, startMarker)
        
    [<TestCase("(endsInString")>]
    [<TestCase(")endsInString")>]
    [<TestCase("<startsInString")>]
    [<TestCase(">startsInString")>]
    member this.BraceStartingOrEndingInStringShouldNotBeMatched(startMarker: string) = 
        let code = "
            let x = \"stringValue\" + (endsInString +
            \" )endsInString <startsInString \" +
            + >startsInString"
        this.VerifyNoBraceMatch(code, startMarker)
        
    [<Test>]
    member this.BraceMatchingAtEndOfLine_Bug1597() = 
        // https://github.com/Microsoft/visualfsharp/issues/1597
        let code = """
[<EntryPoint>]
let main argv = 
    let arg1 = ""
    let arg2 = ""
    let arg3 = ""
    (printfn "%A '%A' '%A'" (arg1) (arg2) (arg3))endBrace
    0 // return an integer exit code"""
        this.VerifyBraceMatch(code, "(printfn", ")endBrace")
