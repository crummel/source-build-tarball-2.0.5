﻿
#if INTERACTIVE
#r "../../Debug/net40/bin/FSharp.Compiler.Service.dll" // note, run 'build fcs' to generate this, this DLL has a public API so can be used from F# Interactive
#r "../../packages/NUnit.3.5.0/lib/net45/nunit.framework.dll"
#load "FsUnit.fs"
#load "Common.fs"
#else
module FSharp.Compiler.Service.Tests.InteractiveChecker
#endif

open NUnit.Framework
open FsUnit
open System
open Microsoft.FSharp.Compiler
open Microsoft.FSharp.Compiler.SourceCodeServices
open FSharp.Compiler.Service.Tests.Common

let internal longIdentToString (longIdent: Ast.LongIdent) =
    String.Join(".", longIdent |> List.map (fun ident -> ident.ToString()))
let internal longIdentWithDotsToString (Ast.LongIdentWithDots (longIdent, _)) = longIdentToString longIdent

let internal posToTuple (pos: Range.pos) = (pos.Line, pos.Column)
let internal rangeToTuple (range: Range.range) = (posToTuple range.Start, posToTuple range.End)

let internal identsAndRanges (input: Ast.ParsedInput) =
    let identAndRange ident (range: Range.range) =
        (ident, rangeToTuple range)
    let extractFromComponentInfo (componentInfo: Ast.SynComponentInfo) =
        let ((Ast.SynComponentInfo.ComponentInfo(_attrs, _typarDecls, _typarConstraints, longIdent, _, _, _, range))) = componentInfo
        // TODO : attrs, typarDecls and typarConstraints
        [identAndRange (longIdentToString longIdent) range]
    let extractFromTypeDefn (typeDefn: Ast.SynTypeDefn) =
        let (Ast.SynTypeDefn.TypeDefn(componentInfo, _repr, _members, _)) = typeDefn
        // TODO : repr and members
        extractFromComponentInfo componentInfo
    let rec extractFromModuleDecl (moduleDecl: Ast.SynModuleDecl) =
        match moduleDecl with
        | Ast.SynModuleDecl.Types(typeDefns, _) -> (typeDefns |> List.collect extractFromTypeDefn)
        | Ast.SynModuleDecl.ModuleAbbrev(ident, _, range) -> [ identAndRange (ident.ToString()) range ]
        | Ast.SynModuleDecl.NestedModule(componentInfo, _, decls, _, _) -> (extractFromComponentInfo componentInfo) @ (decls |> List.collect extractFromModuleDecl)
        | Ast.SynModuleDecl.Let(_, _, _) -> failwith "Not implemented yet"
        | Ast.SynModuleDecl.DoExpr(_, _, _range) -> failwith "Not implemented yet"
        | Ast.SynModuleDecl.Exception(_, _range) -> failwith "Not implemented yet"
        | Ast.SynModuleDecl.Open(longIdentWithDots, range) -> [ identAndRange (longIdentWithDotsToString longIdentWithDots) range ]
        | Ast.SynModuleDecl.Attributes(_attrs, _range) -> failwith "Not implemented yet"
        | Ast.SynModuleDecl.HashDirective(_, _range) -> failwith "Not implemented yet"
        | Ast.SynModuleDecl.NamespaceFragment(moduleOrNamespace) -> extractFromModuleOrNamespace moduleOrNamespace
    and extractFromModuleOrNamespace (Ast.SynModuleOrNamespace(longIdent, _, _, moduleDecls, _, _, _, range)) =
        (identAndRange (longIdentToString longIdent) range) :: (moduleDecls |> List.collect extractFromModuleDecl)

    match input with
    | Ast.ParsedInput.ImplFile(Ast.ParsedImplFileInput(_, _, _, _, _, modulesOrNamespaces, _)) ->
         modulesOrNamespaces |> List.collect extractFromModuleOrNamespace
    | Ast.ParsedInput.SigFile _ -> []

let internal parseAndExtractRanges code =
    let file = "Test"
    let result = parseSourceCode (file, code)
    match result with
    | Some tree -> tree |> identsAndRanges
    | None -> failwith "fail to parse..."

let input =
    """
    namespace N

    type Sample () = class end
    """

[<Test>]
let ``Test ranges - namespace`` () =
    let res = parseAndExtractRanges input 
    printfn "Test ranges - namespace, res = %A" res
    res |> shouldEqual [("N", ((4, 4), (6, 0))); ("Sample", ((4, 9), (4, 15)))]

let input2 =
    """
    module M

    type Sample () = class end
    """
    
[<Test>]
let ``Test ranges - module`` () =
    let res = parseAndExtractRanges input2
    printfn "Test ranges - module, res = %A" res
    res |> shouldEqual [("M", ((2, 4), (4, 26))); ("Sample", ((4, 9), (4, 15)))]

let input3 =
    """
    namespace global

    type Sample () = class end
    """

[<Test>]
let ``Test ranges - global namespace`` () =
    let res = parseAndExtractRanges input3 
    printfn "Test ranges - global namespace, res = %A" res
    res |> shouldEqual [("", ((4, 4), (6, 0))); ("Sample", ((4, 9), (4, 15)))]
