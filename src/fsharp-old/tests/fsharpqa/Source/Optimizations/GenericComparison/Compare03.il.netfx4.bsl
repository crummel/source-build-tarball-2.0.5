
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
.assembly Compare03
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Compare03
{
  // Offset: 0x00000000 Length: 0x00000237
}
.mresource public FSharpOptimizationData.Compare03
{
  // Offset: 0x00000240 Length: 0x000000B9
}
.module Compare03.dll
// MVID: {578C9973-0562-F88E-A745-038373998C57}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x007B0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Compare03
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public CompareMicroPerfAndCodeGenerationTests
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .method public static int32  f4_tuple4() cil managed
    {
      // Code size       77 (0x4d)
      .maxstack  4
      .locals init ([0] int32 x,
               [1] int32 i,
               [2] int32 V_2,
               [3] int32 V_3,
               [4] int32 V_4)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 5,5 : 8,25 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\Optimizations\\GenericComparison\\Compare03.fsx'
      IL_0000:  nop
      IL_0001:  ldc.i4.1
      IL_0002:  stloc.0
      .line 8,8 : 8,32 ''
      IL_0003:  ldc.i4.0
      IL_0004:  stloc.1
      IL_0005:  br.s       IL_0043

      .line 9,9 : 12,30 ''
      IL_0007:  ldc.i4.1
      IL_0008:  ldc.i4.1
      IL_0009:  cgt
      IL_000b:  stloc.2
      IL_000c:  ldloc.2
      IL_000d:  brfalse.s  IL_0013

      IL_000f:  ldloc.2
      IL_0010:  nop
      IL_0011:  br.s       IL_003e

      IL_0013:  ldc.i4.2
      IL_0014:  ldc.i4.2
      IL_0015:  cgt
      IL_0017:  stloc.3
      IL_0018:  ldloc.3
      IL_0019:  brfalse.s  IL_001f

      IL_001b:  ldloc.3
      IL_001c:  nop
      IL_001d:  br.s       IL_003e

      IL_001f:  ldc.i4.4
      IL_0020:  ldc.i4.4
      IL_0021:  cgt
      IL_0023:  stloc.s    V_4
      IL_0025:  ldloc.s    V_4
      IL_0027:  brfalse.s  IL_002e

      IL_0029:  ldloc.s    V_4
      IL_002b:  nop
      IL_002c:  br.s       IL_003e

      IL_002e:  ldstr      "five"
      IL_0033:  ldstr      "5"
      IL_0038:  call       int32 [mscorlib]System.String::CompareOrdinal(string,
                                                                         string)
      IL_003d:  nop
      IL_003e:  stloc.0
      IL_003f:  ldloc.1
      IL_0040:  ldc.i4.1
      IL_0041:  add
      IL_0042:  stloc.1
      .line 8,8 : 8,32 ''
      IL_0043:  ldloc.1
      IL_0044:  ldc.i4     0x989681
      IL_0049:  blt.s      IL_0007

      .line 10,10 : 8,9 ''
      IL_004b:  ldloc.0
      IL_004c:  ret
    } // end of method CompareMicroPerfAndCodeGenerationTests::f4_tuple4

  } // end of class CompareMicroPerfAndCodeGenerationTests

} // end of class Compare03

.class private abstract auto ansi sealed '<StartupCode$Compare03>'.$Compare03$fsx
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$Compare03>'.$Compare03$fsx


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
