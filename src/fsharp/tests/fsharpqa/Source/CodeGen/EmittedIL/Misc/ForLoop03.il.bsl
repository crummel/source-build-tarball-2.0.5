
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
.assembly ForLoop03
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.ForLoop03
{
  // Offset: 0x00000000 Length: 0x000001FA
}
.mresource public FSharpOptimizationData.ForLoop03
{
  // Offset: 0x00000200 Length: 0x0000007B
}
.module ForLoop03.exe
// MVID: {59B19213-1757-791C-A745-03831392B159}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00680000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed ForLoop03
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .method public specialname static class [mscorlib]System.Collections.Generic.List`1<int32> 
          get_ra() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldsfld     class [mscorlib]System.Collections.Generic.List`1<int32> '<StartupCode$ForLoop03>'.$ForLoop03::ra@5
    IL_0005:  ret
  } // end of method ForLoop03::get_ra

  .method public static void  test1() cil managed
  {
    // Code size       113 (0x71)
    .maxstack  5
    .locals init ([0] int32 z,
             [1] int32 i,
             [2] class [mscorlib]System.Collections.Generic.List`1<int32> V_2,
             [3] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32> V_3,
             [4] class [FSharp.Core]Microsoft.FSharp.Core.Unit V_4,
             [5] int32 x,
             [6] class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<int32,class [FSharp.Core]Microsoft.FSharp.Core.Unit> V_6,
             [7] int32 V_7)
    .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
    .line 10,10 : 4,21 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\Misc\\ForLoop03.fs'
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    .line 11,11 : 4,28 ''
    IL_0002:  ldc.i4.0
    IL_0003:  stloc.1
    IL_0004:  br.s       IL_0048

    .line 12,12 : 6,20 ''
    IL_0006:  call       class [mscorlib]System.Collections.Generic.List`1<int32> ForLoop03::get_ra()
    IL_000b:  stloc.2
    .line 12,12 : 6,20 ''
    IL_000c:  ldloc.2
    IL_000d:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<int32>::GetEnumerator()
    IL_0012:  stloc.3
    .try
    {
      IL_0013:  ldloca.s   V_3
      IL_0015:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::MoveNext()
      IL_001a:  brfalse.s  IL_002c

      .line 12,12 : 6,20 ''
      IL_001c:  ldloca.s   V_3
      IL_001e:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::get_Current()
      IL_0023:  stloc.s    x
      IL_0025:  ldloc.0
      IL_0026:  ldc.i4.1
      IL_0027:  add
      IL_0028:  stloc.0
      .line 100001,100001 : 0,0 ''
      IL_0029:  nop
      IL_002a:  br.s       IL_0013

      IL_002c:  ldnull
      IL_002d:  stloc.s    V_4
      IL_002f:  leave.s    IL_0041

    }  // end .try
    finally
    {
      IL_0031:  ldloca.s   V_3
      IL_0033:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>
      IL_0039:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_003e:  ldnull
      IL_003f:  pop
      IL_0040:  endfinally
      .line 100001,100001 : 0,0 ''
    }  // end handler
    IL_0041:  ldloc.s    V_4
    IL_0043:  pop
    IL_0044:  ldloc.1
    IL_0045:  ldc.i4.1
    IL_0046:  add
    IL_0047:  stloc.1
    .line 11,11 : 4,28 ''
    IL_0048:  ldloc.1
    IL_0049:  ldc.i4.1
    IL_004a:  ldc.i4     0x989680
    IL_004f:  add
    IL_0050:  blt.s      IL_0006

    .line 14,14 : 4,20 ''
    IL_0052:  ldstr      "z = %d"
    IL_0057:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<int32,class [FSharp.Core]Microsoft.FSharp.Core.Unit>,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit,int32>::.ctor(string)
    IL_005c:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatLine<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<int32,class [FSharp.Core]Microsoft.FSharp.Core.Unit>>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>)
    IL_0061:  stloc.s    V_6
    IL_0063:  ldloc.0
    IL_0064:  stloc.s    V_7
    IL_0066:  ldloc.s    V_6
    IL_0068:  ldloc.s    V_7
    IL_006a:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<int32,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::Invoke(!0)
    IL_006f:  pop
    IL_0070:  ret
  } // end of method ForLoop03::test1

  .property class [mscorlib]System.Collections.Generic.List`1<int32>
          ra()
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 09 00 00 00 00 00 ) 
    .get class [mscorlib]System.Collections.Generic.List`1<int32> ForLoop03::get_ra()
  } // end of property ForLoop03::ra
} // end of class ForLoop03

.class private abstract auto ansi sealed '<StartupCode$ForLoop03>'.$ForLoop03
       extends [mscorlib]System.Object
{
  .field static assembly class [mscorlib]System.Collections.Generic.List`1<int32> ra@5
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       41 (0x29)
    .maxstack  5
    .locals init ([0] class [mscorlib]System.Collections.Generic.List`1<int32> ra,
             [1] int32 i)
    .line 5,5 : 1,35 ''
    IL_0000:  ldc.i4.s   100
    IL_0002:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor(int32)
    IL_0007:  dup
    IL_0008:  stsfld     class [mscorlib]System.Collections.Generic.List`1<int32> '<StartupCode$ForLoop03>'.$ForLoop03::ra@5
    IL_000d:  stloc.0
    .line 6,6 : 1,20 ''
    IL_000e:  ldc.i4.0
    IL_000f:  stloc.1
    IL_0010:  br.s       IL_0021

    .line 6,6 : 21,30 ''
    IL_0012:  call       class [mscorlib]System.Collections.Generic.List`1<int32> ForLoop03::get_ra()
    IL_0017:  ldloc.1
    IL_0018:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0)
    IL_001d:  ldloc.1
    IL_001e:  ldc.i4.1
    IL_001f:  add
    IL_0020:  stloc.1
    .line 6,6 : 1,20 ''
    IL_0021:  ldloc.1
    IL_0022:  ldc.i4.1
    IL_0023:  ldc.i4.s   100
    IL_0025:  add
    IL_0026:  blt.s      IL_0012

    IL_0028:  ret
  } // end of method $ForLoop03::main@

} // end of class '<StartupCode$ForLoop03>'.$ForLoop03


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
