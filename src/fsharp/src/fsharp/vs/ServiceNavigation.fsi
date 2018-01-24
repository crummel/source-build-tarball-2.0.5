// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

//----------------------------------------------------------------------------
// API to the compiler as an incremental service for parsing,
// type checking and intellisense-like environment-reporting.
//----------------------------------------------------------------------------

namespace Microsoft.FSharp.Compiler.SourceCodeServices

open Microsoft.FSharp.Compiler 

/// Indicates a kind of item to show in an F# navigation bar
#if COMPILER_PUBLIC_API
type FSharpNavigationDeclarationItemKind =
#else
type internal FSharpNavigationDeclarationItemKind =
#endif
    | NamespaceDecl
    | ModuleFileDecl
    | ExnDecl
    | ModuleDecl
    | TypeDecl
    | MethodDecl
    | PropertyDecl
    | FieldDecl
    | OtherDecl

[<RequireQualifiedAccess>]
#if COMPILER_PUBLIC_API
type FSharpEnclosingEntityKind =
#else
type internal FSharpEnclosingEntityKind =
#endif
    | Namespace
    | Module
    | Class
    | Exception
    | Interface
    | Record
    | Enum
    | DU

/// Represents an item to be displayed in the navigation bar
[<Sealed>]
#if COMPILER_PUBLIC_API
type FSharpNavigationDeclarationItem = 
#else
type internal FSharpNavigationDeclarationItem = 
#endif
    member Name : string
    member UniqueName : string
    member Glyph : FSharpGlyph
    member Kind : FSharpNavigationDeclarationItemKind
    member Range : Range.range
    member BodyRange : Range.range
    member IsSingleTopLevel : bool
    member EnclosingEntityKind: FSharpEnclosingEntityKind
    member IsAbstract: bool
    member Access : Ast.SynAccess option

/// Represents top-level declarations (that should be in the type drop-down)
/// with nested declarations (that can be shown in the member drop-down)
[<NoEquality; NoComparison>]
#if COMPILER_PUBLIC_API
type FSharpNavigationTopLevelDeclaration = 
#else
type internal FSharpNavigationTopLevelDeclaration = 
#endif
    { Declaration : FSharpNavigationDeclarationItem
      Nested : FSharpNavigationDeclarationItem[] }
      
/// Represents result of 'GetNavigationItems' operation - this contains
/// all the members and currently selected indices. First level correspond to
/// types & modules and second level are methods etc.
[<Sealed>]
#if COMPILER_PUBLIC_API
type FSharpNavigationItems =
#else
type internal FSharpNavigationItems =
#endif
    member Declarations : FSharpNavigationTopLevelDeclaration[]

// implementation details used by other code in the compiler    
module internal NavigationImpl =
    val internal getNavigationFromImplFile : Ast.SynModuleOrNamespace list -> FSharpNavigationItems
    val internal getNavigationFromSigFile : Ast.SynModuleOrNamespaceSig list -> FSharpNavigationItems
    val internal getNavigation : Ast.ParsedInput -> FSharpNavigationItems
    val internal empty : FSharpNavigationItems

#if COMPILER_PUBLIC_API
module NavigateTo =
#else
module internal NavigateTo =
#endif
    [<RequireQualifiedAccess>]
    type NavigableItemKind =
        | Module
        | ModuleAbbreviation
        | Exception
        | Type
        | ModuleValue
        | Field
        | Property
        | Constructor
        | Member
        | EnumCase
        | UnionCase

    [<RequireQualifiedAccess>]
    type ContainerType =
        | File
        | Namespace
        | Module
        | Type
        | Exception

    type Container =
        { Type: ContainerType
          Name: string }
    
    type NavigableItem = 
        { Name: string
          Range: Range.range
          IsSignature: bool
          Kind: NavigableItemKind
          Container: Container }

    val getNavigableItems : Ast.ParsedInput -> NavigableItem []
