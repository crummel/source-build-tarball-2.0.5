
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern FSharp.Core
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:4:1:0
}
.assembly TailCall02
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.TailCall02
{
  // Offset: 0x00000000 Length: 0x00000202
}
.mresource public FSharpOptimizationData.TailCall02
{
  // Offset: 0x00000208 Length: 0x0000007C
}
.module TailCall02.exe
// MVID: {59B19213-7D8F-CE9D-A745-03831392B159}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00E20000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed TailCall02
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .method public static int32  foo(int32& x) cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
    .line 3,3 : 24,25 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\TailCalls\\TailCall02.fs'
    IL_0000:  ldarg.0
    IL_0001:  ldobj      [mscorlib]System.Int32
    IL_0006:  ret
  } // end of method TailCall02::foo

  .method public static int32  run() cil managed
  {
    // Code size       10 (0xa)
    .maxstack  3
    .locals init ([0] int32 x)
    .line 4,4 : 13,30 ''
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    .line 4,4 : 34,41 ''
    IL_0002:  ldloca.s   x
    IL_0004:  call       int32 TailCall02::foo(int32&)
    IL_0009:  ret
  } // end of method TailCall02::run

} // end of class TailCall02

.class private abstract auto ansi sealed '<StartupCode$TailCall02>'.$TailCall02
       extends [mscorlib]System.Object
{
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method $TailCall02::main@

} // end of class '<StartupCode$TailCall02>'.$TailCall02


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
