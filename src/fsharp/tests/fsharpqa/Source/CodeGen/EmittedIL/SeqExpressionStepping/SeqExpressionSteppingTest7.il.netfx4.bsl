
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
.assembly SeqExpressionSteppingTest7
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.SeqExpressionSteppingTest7
{
  // Offset: 0x00000000 Length: 0x00000272
}
.mresource public FSharpOptimizationData.SeqExpressionSteppingTest7
{
  // Offset: 0x00000278 Length: 0x00000098
}
.module SeqExpressionSteppingTest7.exe
// MVID: {594BFA7F-2432-93C3-A745-03837FFA4B59}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x026F0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed SeqExpressionSteppingTest7
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class auto autochar serializable sealed nested assembly beforefieldinit specialname f@5<a>
         extends class [FSharp.Core]Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1<!a>
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 06 00 00 00 00 00 ) 
    .field public string message
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public int32 pc
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public !a current
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .method public specialname rtspecialname 
            instance void  .ctor(string message,
                                 int32 pc,
                                 !a current) cil managed
    {
      // Code size       28 (0x1c)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  stfld      string class SeqExpressionSteppingTest7/f@5<!a>::message
      IL_0007:  ldarg.0
      IL_0008:  ldarg.2
      IL_0009:  stfld      int32 class SeqExpressionSteppingTest7/f@5<!a>::pc
      IL_000e:  ldarg.0
      IL_000f:  ldarg.3
      IL_0010:  stfld      !0 class SeqExpressionSteppingTest7/f@5<!a>::current
      IL_0015:  ldarg.0
      IL_0016:  call       instance void class [FSharp.Core]Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1<!a>::.ctor()
      IL_001b:  ret
    } // end of method f@5::.ctor

    .method public strict virtual instance int32 
            GenerateNext(class [mscorlib]System.Collections.Generic.IEnumerable`1<!a>& next) cil managed
    {
      // Code size       137 (0x89)
      .maxstack  7
      .locals init ([0] !a V_0)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 100001,100001 : 0,0 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\SeqExpressionStepping\\SeqExpressionSteppingTest7.fs'
      IL_0000:  ldarg.0
      IL_0001:  ldfld      int32 class SeqExpressionSteppingTest7/f@5<!a>::pc
      IL_0006:  ldc.i4.1
      IL_0007:  sub
      IL_0008:  switch     ( 
                            IL_0017,
                            IL_0019)
      IL_0015:  br.s       IL_0021

      IL_0017:  br.s       IL_001b

      IL_0019:  br.s       IL_001e

      .line 100001,100001 : 0,0 ''
      .line 100001,100001 : 0,0 ''
      IL_001b:  nop
      IL_001c:  br.s       IL_0066

      .line 100001,100001 : 0,0 ''
      .line 100001,100001 : 0,0 ''
      IL_001e:  nop
      IL_001f:  br.s       IL_0078

      .line 100001,100001 : 0,0 ''
      .line 100001,100001 : 0,0 ''
      IL_0021:  nop
      .line 5,5 : 14,36 ''
      IL_0022:  nop
      .line 5,5 : 18,24 ''
      IL_0023:  call       class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> SeqExpressionSteppingTest7::get_r()
      IL_0028:  call       void [FSharp.Core]Microsoft.FSharp.Core.Operators::Increment(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>)
      IL_002d:  nop
      .line 5,5 : 26,30 ''
      IL_002e:  ldc.i4.1
      IL_002f:  brfalse.s  IL_0033

      IL_0031:  br.s       IL_0035

      IL_0033:  br.s       IL_0070

      IL_0035:  ldarg.0
      IL_0036:  ldstr      ""
      IL_003b:  stfld      string class SeqExpressionSteppingTest7/f@5<!a>::message
      IL_0040:  ldarg.0
      IL_0041:  ldc.i4.1
      IL_0042:  stfld      int32 class SeqExpressionSteppingTest7/f@5<!a>::pc
      .line 5,5 : 44,55 ''
      IL_0047:  ldarg.1
      IL_0048:  ldc.i4.0
      IL_0049:  brfalse.s  IL_0053

      IL_004b:  ldnull
      IL_004c:  unbox.any  class [mscorlib]System.Collections.Generic.IEnumerable`1<!a>
      IL_0051:  br.s       IL_005f

      IL_0053:  ldarg.0
      IL_0054:  ldfld      string class SeqExpressionSteppingTest7/f@5<!a>::message
      IL_0059:  call       class [mscorlib]System.Exception [FSharp.Core]Microsoft.FSharp.Core.Operators::Failure(string)
      IL_005e:  throw

      IL_005f:  stobj      class [mscorlib]System.Collections.Generic.IEnumerable`1<!a>
      IL_0064:  ldc.i4.2
      IL_0065:  ret

      .line 5,5 : 44,55 ''
      IL_0066:  ldarg.0
      IL_0067:  ldnull
      IL_0068:  stfld      string class SeqExpressionSteppingTest7/f@5<!a>::message
      .line 100001,100001 : 0,0 ''
      IL_006d:  nop
      IL_006e:  br.s       IL_0071

      .line 5,5 : 14,36 ''
      .line 100001,100001 : 0,0 ''
      IL_0070:  nop
      IL_0071:  ldarg.0
      IL_0072:  ldc.i4.2
      IL_0073:  stfld      int32 class SeqExpressionSteppingTest7/f@5<!a>::pc
      IL_0078:  ldarg.0
      IL_0079:  ldloca.s   V_0
      IL_007b:  initobj    !a
      IL_0081:  ldloc.0
      IL_0082:  stfld      !0 class SeqExpressionSteppingTest7/f@5<!a>::current
      IL_0087:  ldc.i4.0
      IL_0088:  ret
    } // end of method f@5::GenerateNext

    .method public strict virtual instance void 
            Close() cil managed
    {
      // Code size       9 (0x9)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldc.i4.2
      IL_0003:  stfld      int32 class SeqExpressionSteppingTest7/f@5<!a>::pc
      IL_0008:  ret
    } // end of method f@5::Close

    .method public strict virtual instance bool 
            get_CheckClose() cil managed
    {
      // Code size       47 (0x2f)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      int32 class SeqExpressionSteppingTest7/f@5<!a>::pc
      IL_0007:  switch     ( 
                            IL_001a,
                            IL_001c,
                            IL_001e)
      IL_0018:  br.s       IL_0029

      IL_001a:  br.s       IL_0020

      IL_001c:  br.s       IL_0023

      IL_001e:  br.s       IL_0026

      IL_0020:  nop
      IL_0021:  br.s       IL_002d

      IL_0023:  nop
      IL_0024:  br.s       IL_002a

      IL_0026:  nop
      IL_0027:  br.s       IL_002d

      IL_0029:  nop
      IL_002a:  ldc.i4.0
      IL_002b:  ret

      IL_002c:  nop
      IL_002d:  ldc.i4.0
      IL_002e:  ret
    } // end of method f@5::get_CheckClose

    .method public strict virtual instance !a 
            get_LastGenerated() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       8 (0x8)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      !0 class SeqExpressionSteppingTest7/f@5<!a>::current
      IL_0007:  ret
    } // end of method f@5::get_LastGenerated

    .method public strict virtual instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!a> 
            GetFreshEnumerator() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       18 (0x12)
      .maxstack  7
      .locals init (!a V_0)
      IL_0000:  nop
      IL_0001:  ldnull
      IL_0002:  ldc.i4.0
      IL_0003:  ldloca.s   V_0
      IL_0005:  initobj    !a
      IL_000b:  ldloc.0
      IL_000c:  newobj     instance void class SeqExpressionSteppingTest7/f@5<!a>::.ctor(string,
                                                                                         int32,
                                                                                         !0)
      IL_0011:  ret
    } // end of method f@5::GetFreshEnumerator

  } // end of class f@5

  .method public specialname static class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> 
          get_r() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldsfld     class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> '<StartupCode$SeqExpressionSteppingTest7>'.$SeqExpressionSteppingTest7::r@4
    IL_0005:  ret
  } // end of method SeqExpressionSteppingTest7::get_r

  .method public static class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!!a> 
          f<a>() cil managed
  {
    // Code size       25 (0x19)
    .maxstack  5
    .locals init ([0] !!a V_0)
    .line 5,5 : 12,57 ''
    IL_0000:  nop
    IL_0001:  ldnull
    IL_0002:  ldc.i4.0
    IL_0003:  ldloca.s   V_0
    IL_0005:  initobj    !!a
    IL_000b:  ldloc.0
    IL_000c:  newobj     instance void class SeqExpressionSteppingTest7/f@5<!!a>::.ctor(string,
                                                                                        int32,
                                                                                        !0)
    IL_0011:  tail.
    IL_0013:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!!0> [FSharp.Core]Microsoft.FSharp.Collections.SeqModule::ToList<!!0>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_0018:  ret
  } // end of method SeqExpressionSteppingTest7::f

  .property class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32>
          r()
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 09 00 00 00 00 00 ) 
    .get class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> SeqExpressionSteppingTest7::get_r()
  } // end of property SeqExpressionSteppingTest7::r
} // end of class SeqExpressionSteppingTest7

.class private abstract auto ansi sealed '<StartupCode$SeqExpressionSteppingTest7>'.$SeqExpressionSteppingTest7
       extends [mscorlib]System.Object
{
  .field static assembly class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> r@4
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       108 (0x6c)
    .maxstack  4
    .locals init ([0] class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> r,
             [1] class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>,class [FSharp.Core]Microsoft.FSharp.Core.Unit> V_1,
             [2] class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> V_2,
             [3] class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> V_3,
             [4] class [mscorlib]System.Exception V_4,
             [5] class [FSharp.Core]Microsoft.FSharp.Core.FSharpOption`1<string> V_5)
    .line 4,4 : 1,14 ''
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  call       class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<!!0> [FSharp.Core]Microsoft.FSharp.Core.Operators::Ref<int32>(!!0)
    IL_0007:  dup
    IL_0008:  stsfld     class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> '<StartupCode$SeqExpressionSteppingTest7>'.$SeqExpressionSteppingTest7::r@4
    IL_000d:  stloc.0
    IL_000e:  ldstr      "res = %A"
    IL_0013:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>,class [FSharp.Core]Microsoft.FSharp.Core.Unit>,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>>::.ctor(string)
    IL_0018:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatLine<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>,class [FSharp.Core]Microsoft.FSharp.Core.Unit>>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>)
    IL_001d:  stloc.1
    .line 6,6 : 21,24 ''
    .try
    {
      IL_001e:  nop
      .line 6,6 : 25,29 ''
      IL_001f:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!!0> SeqExpressionSteppingTest7::f<int32>()
      IL_0024:  stloc.3
      IL_0025:  leave.s    IL_0061

      .line 6,6 : 30,34 ''
    }  // end .try
    catch [mscorlib]System.Object 
    {
      IL_0027:  castclass  [mscorlib]System.Exception
      IL_002c:  stloc.s    V_4
      IL_002e:  ldloc.s    V_4
      IL_0030:  call       class [FSharp.Core]Microsoft.FSharp.Core.FSharpOption`1<string> [FSharp.Core]Microsoft.FSharp.Core.Operators::FailurePattern(class [mscorlib]System.Exception)
      IL_0035:  stloc.s    V_5
      IL_0037:  ldloc.s    V_5
      IL_0039:  brfalse.s  IL_003d

      IL_003b:  br.s       IL_003f

      IL_003d:  br.s       IL_0056

      .line 6,6 : 48,52 ''
      IL_003f:  call       class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<int32> SeqExpressionSteppingTest7::get_r()
      IL_0044:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.Operators::op_Dereference<int32>(class [FSharp.Core]Microsoft.FSharp.Core.FSharpRef`1<!!0>)
      IL_0049:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!0> class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>::get_Empty()
      IL_004e:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!0> class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>::Cons(!0,
                                                                                                                                                                      class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!0>)
      IL_0053:  stloc.3
      IL_0054:  leave.s    IL_0061

      .line 100001,100001 : 0,0 ''
      IL_0056:  rethrow
      IL_0058:  ldnull
      IL_0059:  unbox.any  class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>
      IL_005e:  stloc.3
      IL_005f:  leave.s    IL_0061

      .line 100001,100001 : 0,0 ''
    }  // end handler
    IL_0061:  ldloc.3
    IL_0062:  stloc.2
    IL_0063:  ldloc.1
    IL_0064:  ldloc.2
    IL_0065:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::Invoke(!0)
    IL_006a:  pop
    IL_006b:  ret
  } // end of method $SeqExpressionSteppingTest7::main@

} // end of class '<StartupCode$SeqExpressionSteppingTest7>'.$SeqExpressionSteppingTest7


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
