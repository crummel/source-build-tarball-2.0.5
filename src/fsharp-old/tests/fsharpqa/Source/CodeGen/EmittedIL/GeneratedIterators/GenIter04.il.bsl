
//  Microsoft (R) .NET Framework IL Disassembler.  Version 3.5.30729.1
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern FSharp.Core
{
  .publickeytoken = (A1 90 89 B1 C7 4D 08 09 )                         // .....M..
  .ver 2:0:50727:0
}
.assembly GenIter04
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.GenIter04
{
  // Offset: 0x00000000 Length: 0x00000210
}
.mresource public FSharpOptimizationData.GenIter04
{
  // Offset: 0x00000218 Length: 0x0000007B
}
.module GenIter04.exe
// MVID: {4B0254B0-F79D-DC98-A745-0383B054024B}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x0000000000240000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed GenIter04
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class auto autochar sealed nested assembly beforefieldinit specialname squaresOfOneToTenD@3
         extends class [FSharp.Core]Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1<int32>
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 06 00 00 00 00 00 ) 
    .field public int32 x
    .field public class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> 'enum'
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public int32 pc
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public int32 current
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .method public specialname rtspecialname 
            instance void  .ctor(int32 x,
                                 class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> 'enum',
                                 int32 pc,
                                 int32 current) cil managed
    {
      // Code size       36 (0x24)
      .maxstack  6
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  stfld      int32 GenIter04/squaresOfOneToTenD@3::x
      IL_0007:  ldarg.0
      IL_0008:  ldarg.2
      IL_0009:  stfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_000e:  ldarg.0
      IL_000f:  ldarg.3
      IL_0010:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_0015:  ldarg.0
      IL_0016:  ldarg.s    current
      IL_0018:  stfld      int32 GenIter04/squaresOfOneToTenD@3::current
      IL_001d:  ldarg.0
      IL_001e:  call       instance void class [FSharp.Core]Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1<int32>::.ctor()
      IL_0023:  ret
    } // end of method squaresOfOneToTenD@3::.ctor

    .method public strict virtual instance int32 
            GenerateNext(class [mscorlib]System.Collections.Generic.IEnumerable`1<int32>& next) cil managed
    {
      // Code size       183 (0xb7)
      .maxstack  8
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 100001,100001 : 0,0 
      IL_0000:  ldarg.0
      IL_0001:  ldfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_0006:  ldc.i4.2
      IL_0007:  sub
      IL_0008:  switch     ( 
                            IL_001b,
                            IL_001d,
                            IL_001f)
      IL_0019:  br.s       IL_002d

      IL_001b:  br.s       IL_0021

      IL_001d:  br.s       IL_0024

      IL_001f:  br.s       IL_0027

      .line 100001,100001 : 0,0 
      .line 100001,100001 : 0,0 
      IL_0021:  nop
      IL_0022:  br.s       IL_008d

      .line 100001,100001 : 0,0 
      .line 100001,100001 : 0,0 
      IL_0024:  nop
      IL_0025:  br.s       IL_0083

      .line 100001,100001 : 0,0 
      .line 100001,100001 : 0,0 
      IL_0027:  nop
      IL_0028:  br         IL_00ae

      .line 100001,100001 : 0,0 
      .line 100001,100001 : 0,0 
      IL_002d:  nop
      .line 3,3 : 28,47 
      IL_002e:  ldarg.0
      IL_002f:  ldc.i4.0
      IL_0030:  ldc.i4.1
      IL_0031:  ldc.i4.s   10
      IL_0033:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [FSharp.Core]Microsoft.FSharp.Core.Operators/OperatorIntrinsics::RangeInt32(int32,
                                                                                                                                                                       int32,
                                                                                                                                                                       int32)
      IL_0038:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
      IL_003d:  stfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_0042:  ldarg.0
      IL_0043:  ldc.i4.2
      IL_0044:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      .line 3,3 : 28,47 
      IL_0049:  ldarg.0
      IL_004a:  ldfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_004f:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0054:  brfalse.s  IL_008d

      IL_0056:  ldarg.0
      IL_0057:  ldarg.0
      IL_0058:  ldfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_005d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>::get_Current()
      IL_0062:  stfld      int32 GenIter04/squaresOfOneToTenD@3::x
      IL_0067:  ldarg.0
      IL_0068:  ldc.i4.3
      IL_0069:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      .line 3,3 : 48,53 
      IL_006e:  ldarg.0
      IL_006f:  ldarg.0
      IL_0070:  ldfld      int32 GenIter04/squaresOfOneToTenD@3::x
      IL_0075:  ldarg.0
      IL_0076:  ldfld      int32 GenIter04/squaresOfOneToTenD@3::x
      IL_007b:  mul
      IL_007c:  stfld      int32 GenIter04/squaresOfOneToTenD@3::current
      IL_0081:  ldc.i4.1
      IL_0082:  ret

      .line 3,3 : 28,47 
      IL_0083:  ldarg.0
      IL_0084:  ldc.i4.0
      IL_0085:  stfld      int32 GenIter04/squaresOfOneToTenD@3::x
      .line 100001,100001 : 0,0 
      IL_008a:  nop
      IL_008b:  br.s       IL_0049

      IL_008d:  ldarg.0
      IL_008e:  ldc.i4.4
      IL_008f:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      .line 3,3 : 28,47 
      IL_0094:  ldarg.0
      IL_0095:  ldfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_009a:  call       void [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/IntrinsicFunctions::Dispose<class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>>(!!0)
      IL_009f:  nop
      IL_00a0:  ldarg.0
      IL_00a1:  ldnull
      IL_00a2:  stfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_00a7:  ldarg.0
      IL_00a8:  ldc.i4.4
      IL_00a9:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_00ae:  ldarg.0
      IL_00af:  ldc.i4.0
      IL_00b0:  stfld      int32 GenIter04/squaresOfOneToTenD@3::current
      IL_00b5:  ldc.i4.0
      IL_00b6:  ret
    } // end of method squaresOfOneToTenD@3::GenerateNext

    .method public strict virtual instance void 
            Close() cil managed
    {
      // Code size       89 (0x59)
      .maxstack  6
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_0007:  ldc.i4.1
      IL_0008:  sub
      IL_0009:  switch     ( 
                            IL_0020,
                            IL_0022,
                            IL_0024,
                            IL_0026)
      IL_001e:  br.s       IL_0034

      IL_0020:  br.s       IL_0028

      IL_0022:  br.s       IL_002b

      IL_0024:  br.s       IL_002e

      IL_0026:  br.s       IL_0031

      IL_0028:  nop
      IL_0029:  br.s       IL_004a

      IL_002b:  nop
      IL_002c:  br.s       IL_0036

      IL_002e:  nop
      IL_002f:  br.s       IL_0035

      IL_0031:  nop
      IL_0032:  br.s       IL_004a

      IL_0034:  nop
      IL_0035:  nop
      IL_0036:  ldarg.0
      IL_0037:  ldc.i4.4
      IL_0038:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_003d:  ldarg.0
      IL_003e:  ldfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> GenIter04/squaresOfOneToTenD@3::'enum'
      IL_0043:  call       void [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/IntrinsicFunctions::Dispose<class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>>(!!0)
      IL_0048:  nop
      IL_0049:  nop
      IL_004a:  ldarg.0
      IL_004b:  ldc.i4.4
      IL_004c:  stfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_0051:  ldarg.0
      IL_0052:  ldc.i4.0
      IL_0053:  stfld      int32 GenIter04/squaresOfOneToTenD@3::current
      IL_0058:  ret
    } // end of method squaresOfOneToTenD@3::Close

    .method public strict virtual instance bool 
            get_CheckClose() cil managed
    {
      // Code size       59 (0x3b)
      .maxstack  6
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      int32 GenIter04/squaresOfOneToTenD@3::pc
      IL_0007:  ldc.i4.1
      IL_0008:  sub
      IL_0009:  switch     ( 
                            IL_0020,
                            IL_0022,
                            IL_0024,
                            IL_0026)
      IL_001e:  br.s       IL_0034

      IL_0020:  br.s       IL_0028

      IL_0022:  br.s       IL_002b

      IL_0024:  br.s       IL_002e

      IL_0026:  br.s       IL_0031

      IL_0028:  nop
      IL_0029:  br.s       IL_0039

      IL_002b:  nop
      IL_002c:  br.s       IL_0037

      IL_002e:  nop
      IL_002f:  br.s       IL_0035

      IL_0031:  nop
      IL_0032:  br.s       IL_0039

      IL_0034:  nop
      IL_0035:  ldc.i4.1
      IL_0036:  ret

      IL_0037:  ldc.i4.1
      IL_0038:  ret

      IL_0039:  ldc.i4.0
      IL_003a:  ret
    } // end of method squaresOfOneToTenD@3::get_CheckClose

    .method public strict virtual instance int32 
            get_LastGenerated() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       8 (0x8)
      .maxstack  5
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      int32 GenIter04/squaresOfOneToTenD@3::current
      IL_0007:  ret
    } // end of method squaresOfOneToTenD@3::get_LastGenerated

    .method public strict virtual instance class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> 
            GetFreshEnumerator() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       11 (0xb)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldc.i4.0
      IL_0002:  ldnull
      IL_0003:  ldc.i4.0
      IL_0004:  ldc.i4.0
      IL_0005:  newobj     instance void GenIter04/squaresOfOneToTenD@3::.ctor(int32,
                                                                               class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>,
                                                                               int32,
                                                                               int32)
      IL_000a:  ret
    } // end of method squaresOfOneToTenD@3::GetFreshEnumerator

  } // end of class squaresOfOneToTenD@3

  .method public specialname static class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> 
          get_squaresOfOneToTenD() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  4
    IL_0000:  ldsfld     class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> '<StartupCode$GenIter04>'.$GenIter04::squaresOfOneToTenD@3
    IL_0005:  ret
  } // end of method GenIter04::get_squaresOfOneToTenD

  .property class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32>
          squaresOfOneToTenD()
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 09 00 00 00 00 00 ) 
    .get class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> GenIter04::get_squaresOfOneToTenD()
  } // end of property GenIter04::squaresOfOneToTenD
} // end of class GenIter04

.class private abstract auto ansi sealed '<StartupCode$GenIter04>'.$GenIter04
       extends [mscorlib]System.Object
{
  .field static assembly class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> squaresOfOneToTenD@3
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       23 (0x17)
    .maxstack  6
    .locals init ([0] class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> squaresOfOneToTenD)
    .line 3,3 : 1,55 
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  ldnull
    IL_0003:  ldc.i4.0
    IL_0004:  ldc.i4.0
    IL_0005:  newobj     instance void GenIter04/squaresOfOneToTenD@3::.ctor(int32,
                                                                             class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>,
                                                                             int32,
                                                                             int32)
    IL_000a:  call       class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<!!0> [FSharp.Core]Microsoft.FSharp.Collections.SeqModule::ToList<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_000f:  dup
    IL_0010:  stsfld     class [FSharp.Core]Microsoft.FSharp.Collections.FSharpList`1<int32> '<StartupCode$GenIter04>'.$GenIter04::squaresOfOneToTenD@3
    IL_0015:  stloc.0
    IL_0016:  ret
  } // end of method $GenIter04::main@

} // end of class '<StartupCode$GenIter04>'.$GenIter04


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
