
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
.assembly Compare04
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Compare04
{
  // Offset: 0x00000000 Length: 0x00000237
}
.mresource public FSharpOptimizationData.Compare04
{
  // Offset: 0x00000240 Length: 0x000000B9
}
.module Compare04.dll
// MVID: {578C9975-053B-F88E-A745-038375998C57}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x012E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Compare04
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public CompareMicroPerfAndCodeGenerationTests
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .method public static int32  f4_tuple5() cil managed
    {
      // Code size       209 (0xd1)
      .maxstack  5
      .locals init ([0] int32 x,
               [1] int32 i,
               [2] int32 V_2,
               [3] int32 V_3,
               [4] int32 V_4,
               [5] int32 V_5)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 5,5 : 8,25 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\Optimizations\\GenericComparison\\Compare04.fsx'
      IL_0000:  nop
      IL_0001:  ldc.i4.1
      IL_0002:  stloc.0
      .line 8,8 : 8,32 ''
      IL_0003:  ldc.i4.0
      IL_0004:  stloc.1
      IL_0005:  br         IL_00c4

      .line 9,9 : 12,30 ''
      IL_000a:  ldc.i4.1
      IL_000b:  ldc.i4.1
      IL_000c:  cgt
      IL_000e:  stloc.2
      IL_000f:  ldloc.2
      IL_0010:  brfalse.s  IL_0019

      IL_0012:  ldloc.2
      IL_0013:  nop
      IL_0014:  br         IL_00bf

      IL_0019:  ldc.i4.2
      IL_001a:  ldc.i4.2
      IL_001b:  cgt
      IL_001d:  stloc.3
      IL_001e:  ldloc.3
      IL_001f:  brfalse.s  IL_0028

      IL_0021:  ldloc.3
      IL_0022:  nop
      IL_0023:  br         IL_00bf

      IL_0028:  ldc.i4.4
      IL_0029:  ldc.i4.4
      IL_002a:  cgt
      IL_002c:  stloc.s    V_4
      IL_002e:  ldloc.s    V_4
      IL_0030:  brfalse.s  IL_003a

      IL_0032:  ldloc.s    V_4
      IL_0034:  nop
      IL_0035:  br         IL_00bf

      IL_003a:  ldstr      "5"
      IL_003f:  ldstr      "5"
      IL_0044:  call       int32 [mscorlib]System.String::CompareOrdinal(string,
                                                                         string)
      IL_0049:  stloc.s    V_5
      IL_004b:  ldloc.s    V_5
      IL_004d:  brfalse.s  IL_0054

      IL_004f:  ldloc.s    V_5
      IL_0051:  nop
      IL_0052:  br.s       IL_00bf

      IL_0054:  ldc.r8     6.
      IL_005d:  ldc.r8     7.
      IL_0066:  clt
      IL_0068:  brfalse.s  IL_006e

      IL_006a:  ldc.i4.m1
      IL_006b:  nop
      IL_006c:  br.s       IL_00bf

      IL_006e:  ldc.r8     6.
      IL_0077:  ldc.r8     7.
      IL_0080:  cgt
      IL_0082:  brfalse.s  IL_0088

      IL_0084:  ldc.i4.1
      IL_0085:  nop
      IL_0086:  br.s       IL_00bf

      IL_0088:  ldc.r8     6.
      IL_0091:  ldc.r8     7.
      IL_009a:  ceq
      IL_009c:  brfalse.s  IL_00a2

      IL_009e:  ldc.i4.0
      IL_009f:  nop
      IL_00a0:  br.s       IL_00bf

      IL_00a2:  call       class [mscorlib]System.Collections.IComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericComparer()
      IL_00a7:  ldc.r8     6.
      IL_00b0:  ldc.r8     7.
      IL_00b9:  call       int32 [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/HashCompare::GenericComparisonWithComparerIntrinsic<float64>(class [mscorlib]System.Collections.IComparer,
                                                                                                                                                    !!0,
                                                                                                                                                    !!0)
      IL_00be:  nop
      IL_00bf:  stloc.0
      IL_00c0:  ldloc.1
      IL_00c1:  ldc.i4.1
      IL_00c2:  add
      IL_00c3:  stloc.1
      .line 8,8 : 8,32 ''
      IL_00c4:  ldloc.1
      IL_00c5:  ldc.i4     0x989681
      IL_00ca:  blt        IL_000a

      .line 10,10 : 8,9 ''
      IL_00cf:  ldloc.0
      IL_00d0:  ret
    } // end of method CompareMicroPerfAndCodeGenerationTests::f4_tuple5

  } // end of class CompareMicroPerfAndCodeGenerationTests

} // end of class Compare04

.class private abstract auto ansi sealed '<StartupCode$Compare04>'.$Compare04$fsx
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$Compare04>'.$Compare04$fsx


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
