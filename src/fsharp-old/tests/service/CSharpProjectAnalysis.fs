﻿
#if INTERACTIVE
#r "../../Debug/net40/bin/FSharp.Compiler.Service.dll" // note, run 'build fcs' to generate this, this DLL has a public API so can be used from F# Interactive
#r "../../bin/v4.5/CSharp_Analysis.dll"
#r "../../packages/NUnit.3.5.0/lib/net45/nunit.framework.dll"
#load "FsUnit.fs"
#load "Common.fs"
#else
module FSharp.Compiler.Service.Tests.CSharpProjectAnalysis
#endif


open NUnit.Framework
open FsUnit
open System
open System.IO
open System.Collections.Generic

open Microsoft.FSharp.Compiler
open FSharp.Compiler.Service.Tests
open Microsoft.FSharp.Compiler.SourceCodeServices

open FSharp.Compiler.Service.Tests.Common

let internal getProjectReferences (content, dllFiles, libDirs, otherFlags) = 
    let otherFlags = defaultArg otherFlags []
    let libDirs = defaultArg libDirs []
    let base1 = Path.GetTempFileName()
    let dllName = Path.ChangeExtension(base1, ".dll")
    let fileName1 = Path.ChangeExtension(base1, ".fs")
    let projFileName = Path.ChangeExtension(base1, ".fsproj")
    File.WriteAllText(fileName1, content)
    let options =
        checker.GetProjectOptionsFromCommandLineArgs(projFileName,
            [| yield "--debug:full" 
               yield "--define:DEBUG" 
               yield "--optimize-" 
               yield "--out:" + dllName
               yield "--doc:test.xml" 
               yield "--warn:3" 
               yield "--fullpaths" 
               yield "--flaterrors" 
               yield "--target:library" 
               for dllFile in dllFiles do
                 yield "-r:"+dllFile
               for libDir in libDirs do
                 yield "-I:"+libDir
               yield! otherFlags
               yield fileName1 |])
    let results = checker.ParseAndCheckProject(options) |> Async.RunSynchronously
    if results.HasCriticalErrors then
        let builder = new System.Text.StringBuilder()
        for err in results.Errors do
            builder.AppendLine(sprintf "**** %s: %s" (if err.Severity = FSharpErrorSeverity.Error then "error" else "warning") err.Message)
            |> ignore
        failwith (builder.ToString())
    let assemblies =
        results.ProjectContext.GetReferencedAssemblies()
        |> List.map(fun x -> x.SimpleName, x)
        |> dict
    results, assemblies

[<Test>]
let ``Test that csharp references are recognized as such`` () = 
    let csharpAssembly = PathRelativeToTestAssembly "CSharp_Analysis.dll"
    let _, table = getProjectReferences("""module M""", [csharpAssembly], None, None)
    let ass = table.["CSharp_Analysis"]
    let search = ass.Contents.Entities |> Seq.tryFind (fun e -> e.DisplayName = "CSharpClass") 
    Assert.True search.IsSome
    let found = search.Value
    // this is no F# thing
    found.IsFSharp |> shouldEqual false
        
    // Check that we have members
    let members = found.MembersFunctionsAndValues |> Seq.map (fun e -> e.CompiledName, e) |> dict
    members.ContainsKey ".ctor" |> shouldEqual true
    members.ContainsKey "Method" |> shouldEqual true
    members.ContainsKey "Property" |> shouldEqual true
    members.ContainsKey "Event" |> shouldEqual true
    members.ContainsKey "InterfaceMethod" |> shouldEqual true
    members.ContainsKey "InterfaceProperty" |> shouldEqual true
    members.ContainsKey "InterfaceEvent" |> shouldEqual true
    members.["Event"].IsEvent |> shouldEqual true
    members.["Event"].EventIsStandard |> shouldEqual true
    members.["Event"].EventAddMethod.DisplayName |> shouldEqual "add_Event"
    members.["Event"].EventRemoveMethod.DisplayName |> shouldEqual "remove_Event"
    members.["Event"].EventDelegateType.ToString() |> shouldEqual "type System.EventHandler"

    //// Check that we get xml docs
    members.[".ctor"].XmlDocSig |> shouldEqual "M:FSharp.Compiler.Service.Tests.CSharpClass.#ctor(System.Int32,System.String)"
    members.["Method"].XmlDocSig |> shouldEqual "M:FSharp.Compiler.Service.Tests.CSharpClass.Method(System.String)"
    members.["Property"].XmlDocSig |> shouldEqual "P:FSharp.Compiler.Service.Tests.CSharpClass.Property"
    members.["Event"].XmlDocSig |> shouldEqual "E:FSharp.Compiler.Service.Tests.CSharpClass.Event"
    members.["InterfaceMethod"].XmlDocSig |> shouldEqual "M:FSharp.Compiler.Service.Tests.CSharpClass.InterfaceMethod(System.String)"
    members.["InterfaceProperty"].XmlDocSig |> shouldEqual "P:FSharp.Compiler.Service.Tests.CSharpClass.InterfaceProperty"
    members.["InterfaceEvent"].XmlDocSig |> shouldEqual "E:FSharp.Compiler.Service.Tests.CSharpClass.InterfaceEvent"

[<Test>]
let ``Test that symbols of csharp inner classes/enums are reported`` () = 
    let csharpAssembly = PathRelativeToTestAssembly "CSharp_Analysis.dll"
    let content = """
module NestedEnumClass
open FSharp.Compiler.Service.Tests

let _ = CSharpOuterClass.InnerEnum.Case1
let _ = CSharpOuterClass.InnerClass.StaticMember()
"""

    let results, _ = getProjectReferences(content, [csharpAssembly], None, None)
    results.GetAllUsesOfAllSymbols()
    |> Async.RunSynchronously
    |> Array.map (fun su -> su.Symbol.ToString())
    |> shouldEqual 
          [|"InnerEnum"; "CSharpOuterClass"; "field Case1"; "InnerClass";
            "CSharpOuterClass"; "member StaticMember"; "NestedEnumClass"|]
