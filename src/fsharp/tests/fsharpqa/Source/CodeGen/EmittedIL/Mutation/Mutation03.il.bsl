
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
.assembly Mutation03
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Mutation03
{
  // Offset: 0x00000000 Length: 0x0000019A
}
.mresource public FSharpOptimizationData.Mutation03
{
  // Offset: 0x000001A0 Length: 0x0000006C
}
.module Mutation03.exe
// MVID: {59B19213-8C6A-2EEC-A745-03831392B159}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00390000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Mutation03
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .method public specialname static valuetype [mscorlib]System.DateTime 
          get_x() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldsfld     valuetype [mscorlib]System.DateTime '<StartupCode$Mutation03>'.$Mutation03::'x@4-15'
    IL_0005:  ret
  } // end of method Mutation03::get_x

  .property valuetype [mscorlib]System.DateTime
          x()
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 09 00 00 00 00 00 ) 
    .get valuetype [mscorlib]System.DateTime Mutation03::get_x()
  } // end of property Mutation03::x
} // end of class Mutation03

.class private abstract auto ansi sealed '<StartupCode$Mutation03>'.$Mutation03
       extends [mscorlib]System.Object
{
  .field static assembly valuetype [mscorlib]System.DateTime 'x@4-15'
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       27 (0x1b)
    .maxstack  4
    .locals init ([0] valuetype [mscorlib]System.DateTime x,
             [1] valuetype [mscorlib]System.DateTime V_1)
    .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
    .line 4,4 : 1,28 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\Mutation\\Mutation03.fs'
    IL_0000:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
    IL_0005:  dup
    IL_0006:  stsfld     valuetype [mscorlib]System.DateTime '<StartupCode$Mutation03>'.$Mutation03::'x@4-15'
    IL_000b:  stloc.0
    .line 5,5 : 1,6 ''
    IL_000c:  call       valuetype [mscorlib]System.DateTime Mutation03::get_x()
    IL_0011:  stloc.1
    IL_0012:  ldloca.s   V_1
    IL_0014:  call       instance int32 [mscorlib]System.DateTime::get_Day()
    IL_0019:  pop
    IL_001a:  ret
  } // end of method $Mutation03::main@

} // end of class '<StartupCode$Mutation03>'.$Mutation03


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
