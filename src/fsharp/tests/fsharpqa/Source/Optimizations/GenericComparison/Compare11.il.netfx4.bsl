
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
.assembly Compare11
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Compare11
{
  // Offset: 0x00000000 Length: 0x00000230
}
.mresource public FSharpOptimizationData.Compare11
{
  // Offset: 0x00000238 Length: 0x000000B1
}
.module Compare11.dll
// MVID: {578C9985-04A0-1753-A745-038385998C57}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x005E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Compare11
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public EqualsMicroPerfAndCodeGenerationTests
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .method public static bool  f4() cil managed
    {
      // Code size       23 (0x17)
      .maxstack  4
      .locals init ([0] bool x,
               [1] int32 i)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 5,5 : 8,29 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\Optimizations\\GenericComparison\\Compare11.fsx'
      IL_0000:  nop
      IL_0001:  ldc.i4.0
      IL_0002:  stloc.0
      .line 9,9 : 8,32 ''
      IL_0003:  ldc.i4.0
      IL_0004:  stloc.1
      IL_0005:  br.s       IL_000d

      .line 10,10 : 12,26 ''
      IL_0007:  ldc.i4.0
      IL_0008:  stloc.0
      IL_0009:  ldloc.1
      IL_000a:  ldc.i4.1
      IL_000b:  add
      IL_000c:  stloc.1
      .line 9,9 : 8,32 ''
      IL_000d:  ldloc.1
      IL_000e:  ldc.i4     0x989681
      IL_0013:  blt.s      IL_0007

      .line 11,11 : 8,9 ''
      IL_0015:  ldloc.0
      IL_0016:  ret
    } // end of method EqualsMicroPerfAndCodeGenerationTests::f4

  } // end of class EqualsMicroPerfAndCodeGenerationTests

} // end of class Compare11

.class private abstract auto ansi sealed '<StartupCode$Compare11>'.$Compare11$fsx
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$Compare11>'.$Compare11$fsx


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
