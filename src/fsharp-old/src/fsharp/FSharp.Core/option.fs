// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.FSharp.Core

    open Microsoft.FSharp.Core.Operators

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Option = 

        [<CompiledName("GetValue")>]
        let get option = match option with None -> invalidArg "option" (SR.GetString(SR.optionValueWasNone)) | Some x -> x

        [<CompiledName("IsSome")>]
        let inline isSome option = match option with None -> false | Some _ -> true

        [<CompiledName("IsNone")>]
        let inline isNone option = match option with None -> true | Some _ -> false

        [<CompiledName("DefaultValue")>]
        let defaultValue def option = match option with None -> def | Some v -> v

        [<CompiledName("DefaultWith")>]
        let defaultWith defThunk option = match option with None -> defThunk () | Some v -> v

        [<CompiledName("OrElse")>]
        let orElse ifNone option = match option with None -> ifNone | Some _ -> option

        [<CompiledName("OrElseWith")>]
        let orElseWith ifNoneThunk option = match option with None -> ifNoneThunk () | Some _ -> option

        [<CompiledName("Count")>]
        let count option = match option with None -> 0 | Some _ -> 1

        [<CompiledName("Fold")>]
        let fold<'T,'State> f (s:'State) (inp: option<'T>) = match inp with None -> s | Some x -> f s x

        [<CompiledName("FoldBack")>]
        let foldBack<'T,'State> f (inp: option<'T>) (s:'State) =  match inp with None -> s | Some x -> f x s

        [<CompiledName("Exists")>]
        let exists p inp = match inp with None -> false | Some x -> p x

        [<CompiledName("ForAll")>]
        let forall p inp = match inp with None -> true | Some x -> p x

        [<CompiledName("Contains")>]
        let inline contains x inp = match inp with None -> false | Some v -> v = x

        [<CompiledName("Iterate")>]
        let iter f inp = match inp with None -> () | Some x -> f x

        [<CompiledName("Map")>]
        let map f inp = match inp with None -> None | Some x -> Some (f x)

        [<CompiledName("Map2")>]
        let map2 f option1 option2 = 
            match option1, option2 with
            | Some x, Some y -> Some <| f x y
            | _ -> None

        [<CompiledName("Map3")>]
        let map3 f option1 option2 option3 = 
            match option1, option2, option3 with
            | Some x, Some y, Some z -> Some <| f x y z
            | _ -> None

        [<CompiledName("Bind")>]
        let bind f inp = match inp with None -> None | Some x -> f x

        [<CompiledName("Flatten")>]
        let flatten option = match option with None -> None | Some x -> x

        [<CompiledName("Filter")>]
        let filter f inp = match inp with None -> None | Some x -> if f x then Some x else None

        [<CompiledName("ToArray")>]
        let toArray option = match option with  None -> [| |] | Some x -> [| x |]

        [<CompiledName("ToList")>]
        let toList option = match option with  None -> [ ] | Some x -> [ x ]

        [<CompiledName("ToNullable")>]
        let toNullable option = match option with None -> System.Nullable() | Some v -> System.Nullable(v)

        [<CompiledName("OfNullable")>]
        let ofNullable (value:System.Nullable<'T>) = if value.HasValue then Some value.Value else None

        [<CompiledName("OfObj")>]
        let ofObj value = match value with null -> None | _ -> Some value

        [<CompiledName("ToObj")>]
        let toObj value = match value with None -> null | Some x -> x
