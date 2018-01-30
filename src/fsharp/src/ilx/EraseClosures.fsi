// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

/// Compiler use only.  Erase closures
module internal Microsoft.FSharp.Compiler.AbstractIL.Extensions.ILX.EraseClosures

open Microsoft.FSharp.Compiler.AbstractIL
open Microsoft.FSharp.Compiler.AbstractIL.IL 
open Microsoft.FSharp.Compiler.AbstractIL.Extensions.ILX 
open Microsoft.FSharp.Compiler.AbstractIL.Extensions.ILX.Types

type cenv
val mkCallFunc : cenv -> allocLocal:(ILType -> uint16) -> numThisGenParams:int -> ILTailcall -> IlxClosureApps -> ILInstr list

val mkILFuncTy : cenv -> ILType -> ILType -> ILType
val mkILTyFuncTy : cenv -> ILType
val newIlxPubCloEnv : ILGlobals * addMethodGeneratedAttrs: (ILMethodDef -> ILMethodDef) * addFieldGeneratedAttrs: (ILFieldDef -> ILFieldDef) * addFieldNeverAttrs: (ILFieldDef -> ILFieldDef) -> cenv
val mkTyOfLambdas: cenv -> IlxClosureLambdas -> ILType

val convIlxClosureDef : cenv -> encl: string list -> ILTypeDef -> IlxClosureInfo -> ILTypeDef list

