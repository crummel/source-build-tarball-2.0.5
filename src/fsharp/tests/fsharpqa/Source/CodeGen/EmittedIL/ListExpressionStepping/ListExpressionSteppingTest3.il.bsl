
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
.assembly ListExpressionSteppingTest3
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.ListExpressionSteppingTest3
{
  // Offset: 0x00000000 Length: 0x0000027D
}
.mresource public FSharpOptimizationData.ListExpressionSteppingTest3
{
  // Offset: 0x00000288 Length: 0x000000AF
}
.module ListExpressionSteppingTest3.exe
// MVID: {59B1920C-AE45-39B4-A745-03830C92B159}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00FF0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed ListExpressionSteppingTest3
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public ListExpressionSteppingTest3
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .class auto autochar serializable sealed nested assembly beforefieldinit specialname f2@7
           extends class [FSharp.Core]Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>>
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 06 00 00 00 00 00 ) 
      .field public class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> x
      .field public int32 pc
      .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      .field public class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> current
      .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      .method public specialname rtspecialname 
              instance void  .ctor(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> x,
                                   int32 pc,
                                   class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> current) cil managed
      {
        // Code size       28 (0x1c)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldarg.1
        IL_0002:  stfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::x
        IL_0007:  ldarg.0
        IL_0008:  ldarg.2
        IL_0009:  stfld      int32 ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::pc
        IL_000e:  ldarg.0
        IL_000f:  ldarg.3
        IL_0010:  stfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::current
        IL_0015:  ldarg.0
        IL_0016:  call       instance void class [FSharp.Core]Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>>::.ctor()
        IL_001b:  ret
      } // end of method f2@7::.ctor

      .method public strict virtual instance int32 
              GenerateNext(class [mscorlib]System.Collections.Generic.IEnumerable`1<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>>& next) cil managed
      {
        // Code size       116 (0x74)
        .maxstack  6
        .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
        .line 100001,100001 : 0,0 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\ListExpressionStepping\\ListExpressionSteppingTest3.fs'
        IL_0000:  ldarg.0
        IL_0001:  ldfld      int32 ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::pc
        IL_0006:  ldc.i4.1
        IL_0007:  sub
        IL_0008:  switch     ( 
                              IL_0017,
                              IL_0019)
        IL_0015:  br.s       IL_0021

        IL_0017:  br.s       IL_001b

        IL_0019:  br.s       IL_001e

        .line 100001,100001 : 0,0 ''
        IL_001b:  nop
        IL_001c:  br.s       IL_0061

        .line 100001,100001 : 0,0 ''
        IL_001e:  nop
        IL_001f:  br.s       IL_006b

        .line 100001,100001 : 0,0 ''
        IL_0021:  nop
        .line 7,7 : 17,23 ''
        IL_0022:  ldarg.0
        IL_0023:  ldfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::x
        IL_0028:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.Operators::op_Dereference<int32>(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<!!0>)
        IL_002d:  ldc.i4.4
        IL_002e:  bge.s      IL_0064

        .line 8,8 : 14,20 ''
        IL_0030:  ldarg.0
        IL_0031:  ldfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::x
        IL_0036:  call       void [FSharp.Core]Microsoft.FSharp.Core.Operators::Increment(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>)
        IL_003b:  nop
        .line 9,9 : 14,29 ''
        IL_003c:  ldstr      "hello"
        IL_0041:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::.ctor(string)
        IL_0046:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatLine<class [FSharp.Core]Microsoft.FSharp.Core.Unit>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>)
        IL_004b:  pop
        IL_004c:  ldarg.0
        IL_004d:  ldc.i4.1
        IL_004e:  stfld      int32 ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::pc
        .line 10,10 : 14,21 ''
        IL_0053:  ldarg.0
        IL_0054:  ldarg.0
        IL_0055:  ldfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::x
        IL_005a:  stfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::current
        IL_005f:  ldc.i4.1
        IL_0060:  ret

        .line 100001,100001 : 0,0 ''
        IL_0061:  nop
        IL_0062:  br.s       IL_0022

        IL_0064:  ldarg.0
        IL_0065:  ldc.i4.2
        IL_0066:  stfld      int32 ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::pc
        IL_006b:  ldarg.0
        IL_006c:  ldnull
        IL_006d:  stfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::current
        IL_0072:  ldc.i4.0
        IL_0073:  ret
      } // end of method f2@7::GenerateNext

      .method public strict virtual instance void 
              Close() cil managed
      {
        // Code size       8 (0x8)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldc.i4.2
        IL_0002:  stfld      int32 ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::pc
        IL_0007:  ret
      } // end of method f2@7::Close

      .method public strict virtual instance bool 
              get_CheckClose() cil managed
      {
        // Code size       45 (0x2d)
        .maxstack  8
        .line 100001,100001 : 0,0 ''
        IL_0000:  ldarg.0
        IL_0001:  ldfld      int32 ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::pc
        IL_0006:  switch     ( 
                              IL_0019,
                              IL_001b,
                              IL_001d)
        IL_0017:  br.s       IL_0028

        IL_0019:  br.s       IL_001f

        IL_001b:  br.s       IL_0022

        IL_001d:  br.s       IL_0025

        .line 100001,100001 : 0,0 ''
        IL_001f:  nop
        IL_0020:  br.s       IL_002b

        .line 100001,100001 : 0,0 ''
        IL_0022:  nop
        IL_0023:  br.s       IL_0029

        .line 100001,100001 : 0,0 ''
        IL_0025:  nop
        IL_0026:  br.s       IL_002b

        .line 100001,100001 : 0,0 ''
        IL_0028:  nop
        IL_0029:  ldc.i4.0
        IL_002a:  ret

        IL_002b:  ldc.i4.0
        IL_002c:  ret
      } // end of method f2@7::get_CheckClose

      .method public strict virtual instance class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> 
              get_LastGenerated() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::current
        IL_0006:  ret
      } // end of method f2@7::get_LastGenerated

      .method public strict virtual instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>> 
              GetFreshEnumerator() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       14 (0xe)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldfld      class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::x
        IL_0006:  ldc.i4.0
        IL_0007:  ldnull
        IL_0008:  newobj     instance void ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::.ctor(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>,
                                                                                                               int32,
                                                                                                               class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>)
        IL_000d:  ret
      } // end of method f2@7::GetFreshEnumerator

    } // end of class f2@7

    .method public static class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>> 
            f2() cil managed
    {
      // Code size       23 (0x17)
      .maxstack  5
      .locals init ([0] class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> x)
      .line 6,6 : 9,22 ''
      IL_0000:  ldc.i4.0
      IL_0001:  call       class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<!!0> [FSharp.Core]Microsoft.FSharp.Core.Operators::Ref<int32>(!!0)
      IL_0006:  stloc.0
      .line 7,10 : 9,23 ''
      IL_0007:  ldloc.0
      IL_0008:  ldc.i4.0
      IL_0009:  ldnull
      IL_000a:  newobj     instance void ListExpressionSteppingTest3/ListExpressionSteppingTest3/f2@7::.ctor(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>,
                                                                                                             int32,
                                                                                                             class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>)
      IL_000f:  tail.
      IL_0011:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!!0> [FSharp.Core]Microsoft.FSharp.Collections.SeqModule::ToList<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0016:  ret
    } // end of method ListExpressionSteppingTest3::f2

  } // end of class ListExpressionSteppingTest3

} // end of class ListExpressionSteppingTest3

.class private abstract auto ansi sealed '<StartupCode$ListExpressionSteppingTest3>'.$ListExpressionSteppingTest3
       extends [mscorlib]System.Object
{
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       7 (0x7)
    .maxstack  8
    .line 12,12 : 13,17 ''
    IL_0000:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>> ListExpressionSteppingTest3/ListExpressionSteppingTest3::f2()
    IL_0005:  pop
    IL_0006:  ret
  } // end of method $ListExpressionSteppingTest3::main@

} // end of class '<StartupCode$ListExpressionSteppingTest3>'.$ListExpressionSteppingTest3


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
