
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
.assembly Equals02
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Equals02
{
  // Offset: 0x00000000 Length: 0x00000234
}
.mresource public FSharpOptimizationData.Equals02
{
  // Offset: 0x00000238 Length: 0x000000B6
}
.module Equals02.dll
// MVID: {578C9989-0759-B6D8-A745-038389998C57}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x011F0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Equals02
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public EqualsMicroPerfAndCodeGenerationTests
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .method public static bool  f4_tuple4() cil managed
    {
      // Code size       45 (0x2d)
      .maxstack  4
      .locals init ([0] bool x,
               [1] int32 i)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 5,5 : 8,29 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\Optimizations\\GenericComparison\\Equals02.fsx'
      IL_0000:  nop
      IL_0001:  ldc.i4.0
      IL_0002:  stloc.0
      .line 8,8 : 8,32 ''
      IL_0003:  ldc.i4.0
      IL_0004:  stloc.1
      IL_0005:  br.s       IL_0023

      .line 9,9 : 12,26 ''
      IL_0007:  ldc.i4.1
      IL_0008:  brfalse.s  IL_001c

      IL_000a:  ldstr      "five"
      IL_000f:  ldstr      "5"
      IL_0014:  call       bool [mscorlib]System.String::Equals(string,
                                                                string)
      IL_0019:  nop
      IL_001a:  br.s       IL_001e

      IL_001c:  ldc.i4.0
      IL_001d:  nop
      IL_001e:  stloc.0
      IL_001f:  ldloc.1
      IL_0020:  ldc.i4.1
      IL_0021:  add
      IL_0022:  stloc.1
      .line 8,8 : 8,32 ''
      IL_0023:  ldloc.1
      IL_0024:  ldc.i4     0x989681
      IL_0029:  blt.s      IL_0007

      .line 10,10 : 8,9 ''
      IL_002b:  ldloc.0
      IL_002c:  ret
    } // end of method EqualsMicroPerfAndCodeGenerationTests::f4_tuple4

  } // end of class EqualsMicroPerfAndCodeGenerationTests

} // end of class Equals02

.class private abstract auto ansi sealed '<StartupCode$Equals02>'.$Equals02$fsx
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$Equals02>'.$Equals02$fsx


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
