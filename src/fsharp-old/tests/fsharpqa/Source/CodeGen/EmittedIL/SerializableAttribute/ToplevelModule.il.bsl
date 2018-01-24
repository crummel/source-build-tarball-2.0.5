
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.81.0
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
.assembly TopLevelModule
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 00 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.TopLevelModule
{
  // Offset: 0x00000000 Length: 0x0000114D
}
.mresource public FSharpOptimizationData.TopLevelModule
{
  // Offset: 0x00001158 Length: 0x000003FD
}
.module TopLevelModule.dll
// MVID: {576266DB-37F5-C118-A745-0383DB666257}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x01090000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed ABC
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class auto autochar serializable sealed nested public beforefieldinit Expr
         extends [mscorlib]System.Object
         implements class [mscorlib]System.IEquatable`1<class ABC/Expr>,
                    [mscorlib]System.Collections.IStructuralEquatable,
                    class [mscorlib]System.IComparable`1<class ABC/Expr>,
                    [mscorlib]System.IComparable,
                    [mscorlib]System.Collections.IStructuralComparable
  {
    .custom instance void [mscorlib]System.Diagnostics.DebuggerDisplayAttribute::.ctor(string) = ( 01 00 15 7B 5F 5F 44 65 62 75 67 44 69 73 70 6C   // ...{__DebugDispl
                                                                                                   61 79 28 29 2C 6E 71 7D 00 00 )                   // ay(),nq}..
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 01 00 00 00 00 00 ) 
    .field assembly initonly int32 item
    .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .method public static class ABC/Expr 
            NewNum(int32 item) cil managed
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags,
                                                                                                  int32) = ( 01 00 08 00 00 00 00 00 00 00 00 00 ) 
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  newobj     instance void ABC/Expr::.ctor(int32)
      IL_0006:  ret
    } // end of method Expr::NewNum

    .method assembly specialname rtspecialname 
            instance void  .ctor(int32 item) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       14 (0xe)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldarg.1
      IL_0008:  stfld      int32 ABC/Expr::item
      IL_000d:  ret
    } // end of method Expr::.ctor

    .method public hidebysig instance int32 
            get_Item() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      int32 ABC/Expr::item
      IL_0006:  ret
    } // end of method Expr::get_Item

    .method public hidebysig instance int32 
            get_Tag() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       4 (0x4)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  pop
      IL_0002:  ldc.i4.0
      IL_0003:  ret
    } // end of method Expr::get_Tag

    .method assembly hidebysig specialname 
            instance object  __DebugDisplay() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       22 (0x16)
      .maxstack  8
      IL_0000:  ldstr      "%+0.8A"
      IL_0005:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/Expr,string>,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string,string>::.ctor(string)
      IL_000a:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatToString<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/Expr,string>>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string>)
      IL_000f:  ldarg.0
      IL_0010:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/Expr,string>::Invoke(!0)
      IL_0015:  ret
    } // end of method Expr::__DebugDisplay

    .method public strict virtual instance string 
            ToString() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       22 (0x16)
      .maxstack  8
      IL_0000:  ldstr      "%+A"
      IL_0005:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/Expr,string>,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string,class ABC/Expr>::.ctor(string)
      IL_000a:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatToString<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/Expr,string>>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string>)
      IL_000f:  ldarg.0
      IL_0010:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/Expr,string>::Invoke(!0)
      IL_0015:  ret
    } // end of method Expr::ToString

    .method public hidebysig virtual final 
            instance int32  CompareTo(class ABC/Expr obj) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       81 (0x51)
      .maxstack  4
      .locals init (class ABC/Expr V_0,
               class ABC/Expr V_1,
               class [mscorlib]System.Collections.IComparer V_2,
               int32 V_3,
               int32 V_4)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_0043

      IL_000b:  ldarg.1
      IL_000c:  ldnull
      IL_000d:  cgt.un
      IL_000f:  brfalse.s  IL_0013

      IL_0011:  br.s       IL_0015

      IL_0013:  br.s       IL_0041

      IL_0015:  ldarg.0
      IL_0016:  pop
      IL_0017:  ldarg.0
      IL_0018:  stloc.0
      IL_0019:  ldarg.1
      IL_001a:  stloc.1
      IL_001b:  call       class [mscorlib]System.Collections.IComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericComparer()
      IL_0020:  stloc.2
      IL_0021:  ldloc.0
      IL_0022:  ldfld      int32 ABC/Expr::item
      IL_0027:  stloc.3
      IL_0028:  ldloc.1
      IL_0029:  ldfld      int32 ABC/Expr::item
      IL_002e:  stloc.s    V_4
      IL_0030:  ldloc.3
      IL_0031:  ldloc.s    V_4
      IL_0033:  bge.s      IL_0037

      IL_0035:  br.s       IL_0039

      IL_0037:  br.s       IL_003b

      IL_0039:  ldc.i4.m1
      IL_003a:  ret

      IL_003b:  ldloc.3
      IL_003c:  ldloc.s    V_4
      IL_003e:  cgt
      IL_0040:  ret

      IL_0041:  ldc.i4.1
      IL_0042:  ret

      IL_0043:  ldarg.1
      IL_0044:  ldnull
      IL_0045:  cgt.un
      IL_0047:  brfalse.s  IL_004b

      IL_0049:  br.s       IL_004d

      IL_004b:  br.s       IL_004f

      IL_004d:  ldc.i4.m1
      IL_004e:  ret

      IL_004f:  ldc.i4.0
      IL_0050:  ret
    } // end of method Expr::CompareTo

    .method public hidebysig virtual final 
            instance int32  CompareTo(object obj) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       14 (0xe)
      .maxstack  8
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 6,6 : 14,18 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\SerializableAttribute\\ToplevelModule.fs'
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldarg.1
      IL_0003:  unbox.any  ABC/Expr
      IL_0008:  callvirt   instance int32 ABC/Expr::CompareTo(class ABC/Expr)
      IL_000d:  ret
    } // end of method Expr::CompareTo

    .method public hidebysig virtual final 
            instance int32  CompareTo(object obj,
                                      class [mscorlib]System.Collections.IComparer comp) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       97 (0x61)
      .maxstack  4
      .locals init ([0] class ABC/Expr V_0,
               [1] class ABC/Expr V_1,
               [2] class ABC/Expr V_2,
               [3] class [mscorlib]System.Collections.IComparer V_3,
               [4] int32 V_4,
               [5] int32 V_5)
      .line 6,6 : 14,18
      IL_0000:  nop
      IL_0001:  ldarg.1
      IL_0002:  unbox.any  ABC/Expr
      IL_0007:  stloc.0
      IL_0008:  ldarg.0
      IL_0009:  ldnull
      IL_000a:  cgt.un
      IL_000c:  brfalse.s  IL_0010

      IL_000e:  br.s       IL_0012

      IL_0010:  br.s       IL_004e

      .line 100001,100001 : 0,0
      IL_0012:  ldarg.1
      IL_0013:  unbox.any  ABC/Expr
      IL_0018:  ldnull
      IL_0019:  cgt.un
      IL_001b:  brfalse.s  IL_001f

      IL_001d:  br.s       IL_0021

      IL_001f:  br.s       IL_004c

      .line 100001,100001 : 0,0
      IL_0021:  ldarg.0
      IL_0022:  pop
      .line 100001,100001 : 0,0
      IL_0023:  ldarg.0
      IL_0024:  stloc.1
      IL_0025:  ldloc.0
      IL_0026:  stloc.2
      IL_0027:  ldarg.2
      IL_0028:  stloc.3
      IL_0029:  ldloc.1
      IL_002a:  ldfld      int32 ABC/Expr::item
      IL_002f:  stloc.s    V_4
      IL_0031:  ldloc.2
      IL_0032:  ldfld      int32 ABC/Expr::item
      IL_0037:  stloc.s    V_5
      IL_0039:  ldloc.s    V_4
      IL_003b:  ldloc.s    V_5
      IL_003d:  bge.s      IL_0041

      IL_003f:  br.s       IL_0043

      IL_0041:  br.s       IL_0045

      .line 100001,100001 : 0,0
      IL_0043:  ldc.i4.m1
      IL_0044:  ret

      .line 100001,100001 : 0,0
      IL_0045:  ldloc.s    V_4
      IL_0047:  ldloc.s    V_5
      IL_0049:  cgt
      IL_004b:  ret

      .line 100001,100001 : 0,0
      IL_004c:  ldc.i4.1
      IL_004d:  ret

      .line 100001,100001 : 0,0
      IL_004e:  ldarg.1
      IL_004f:  unbox.any  ABC/Expr
      IL_0054:  ldnull
      IL_0055:  cgt.un
      IL_0057:  brfalse.s  IL_005b

      IL_0059:  br.s       IL_005d

      IL_005b:  br.s       IL_005f

      .line 100001,100001 : 0,0
      IL_005d:  ldc.i4.m1
      IL_005e:  ret

      .line 100001,100001 : 0,0
      IL_005f:  ldc.i4.0
      IL_0060:  ret
    } // end of method Expr::CompareTo

    .method public hidebysig virtual final 
            instance int32  GetHashCode(class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       46 (0x2e)
      .maxstack  7
      .locals init (int32 V_0,
               class ABC/Expr V_1,
               class [mscorlib]System.Collections.IEqualityComparer V_2)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_002c

      IL_000b:  ldc.i4.0
      IL_000c:  stloc.0
      IL_000d:  ldarg.0
      IL_000e:  pop
      IL_000f:  ldarg.0
      IL_0010:  stloc.1
      IL_0011:  ldc.i4.0
      IL_0012:  stloc.0
      IL_0013:  ldc.i4     0x9e3779b9
      IL_0018:  ldarg.1
      IL_0019:  stloc.2
      IL_001a:  ldloc.1
      IL_001b:  ldfld      int32 ABC/Expr::item
      IL_0020:  ldloc.0
      IL_0021:  ldc.i4.6
      IL_0022:  shl
      IL_0023:  ldloc.0
      IL_0024:  ldc.i4.2
      IL_0025:  shr
      IL_0026:  add
      IL_0027:  add
      IL_0028:  add
      IL_0029:  stloc.0
      IL_002a:  ldloc.0
      IL_002b:  ret

      IL_002c:  ldc.i4.0
      IL_002d:  ret
    } // end of method Expr::GetHashCode

    .method public hidebysig virtual final 
            instance int32  GetHashCode() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       13 (0xd)
      .maxstack  8
      .line 6,6 : 14,18
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  call       class [mscorlib]System.Collections.IEqualityComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericEqualityComparer()
      IL_0007:  callvirt   instance int32 ABC/Expr::GetHashCode(class [mscorlib]System.Collections.IEqualityComparer)
      IL_000c:  ret
    } // end of method Expr::GetHashCode

    .method public hidebysig virtual final 
            instance bool  Equals(object obj,
                                  class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       61 (0x3d)
      .maxstack  4
      .locals init (class ABC/Expr V_0,
               class ABC/Expr V_1,
               class ABC/Expr V_2,
               class ABC/Expr V_3,
               class [mscorlib]System.Collections.IEqualityComparer V_4)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_0035

      IL_000b:  ldarg.1
      IL_000c:  isinst     ABC/Expr
      IL_0011:  stloc.0
      IL_0012:  ldloc.0
      IL_0013:  brfalse.s  IL_0017

      IL_0015:  br.s       IL_0019

      IL_0017:  br.s       IL_0033

      IL_0019:  ldloc.0
      IL_001a:  stloc.1
      IL_001b:  ldarg.0
      IL_001c:  pop
      IL_001d:  ldarg.0
      IL_001e:  stloc.2
      IL_001f:  ldloc.1
      IL_0020:  stloc.3
      IL_0021:  ldarg.2
      IL_0022:  stloc.s    V_4
      IL_0024:  ldloc.2
      IL_0025:  ldfld      int32 ABC/Expr::item
      IL_002a:  ldloc.3
      IL_002b:  ldfld      int32 ABC/Expr::item
      IL_0030:  ceq
      IL_0032:  ret

      IL_0033:  ldc.i4.0
      IL_0034:  ret

      IL_0035:  ldarg.1
      IL_0036:  ldnull
      IL_0037:  cgt.un
      IL_0039:  ldc.i4.0
      IL_003a:  ceq
      IL_003c:  ret
    } // end of method Expr::Equals

    .method public hidebysig virtual final 
            instance bool  Equals(class ABC/Expr obj) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       52 (0x34)
      .maxstack  4
      .locals init (class ABC/Expr V_0,
               class ABC/Expr V_1)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_002c

      IL_000b:  ldarg.1
      IL_000c:  ldnull
      IL_000d:  cgt.un
      IL_000f:  brfalse.s  IL_0013

      IL_0011:  br.s       IL_0015

      IL_0013:  br.s       IL_002a

      IL_0015:  ldarg.0
      IL_0016:  pop
      IL_0017:  ldarg.0
      IL_0018:  stloc.0
      IL_0019:  ldarg.1
      IL_001a:  stloc.1
      IL_001b:  ldloc.0
      IL_001c:  ldfld      int32 ABC/Expr::item
      IL_0021:  ldloc.1
      IL_0022:  ldfld      int32 ABC/Expr::item
      IL_0027:  ceq
      IL_0029:  ret

      IL_002a:  ldc.i4.0
      IL_002b:  ret

      IL_002c:  ldarg.1
      IL_002d:  ldnull
      IL_002e:  cgt.un
      IL_0030:  ldc.i4.0
      IL_0031:  ceq
      IL_0033:  ret
    } // end of method Expr::Equals

    .method public hidebysig virtual final 
            instance bool  Equals(object obj) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       25 (0x19)
      .maxstack  4
      .locals init (class ABC/Expr V_0)
      IL_0000:  nop
      IL_0001:  ldarg.1
      IL_0002:  isinst     ABC/Expr
      IL_0007:  stloc.0
      IL_0008:  ldloc.0
      IL_0009:  brfalse.s  IL_000d

      IL_000b:  br.s       IL_000f

      IL_000d:  br.s       IL_0017

      IL_000f:  ldarg.0
      IL_0010:  ldloc.0
      IL_0011:  callvirt   instance bool ABC/Expr::Equals(class ABC/Expr)
      IL_0016:  ret

      IL_0017:  ldc.i4.0
      IL_0018:  ret
    } // end of method Expr::Equals

    .property instance int32 Tag()
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
      .get instance int32 ABC/Expr::get_Tag()
    } // end of property Expr::Tag
    .property instance int32 Item()
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags,
                                                                                                  int32,
                                                                                                  int32) = ( 01 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      .get instance int32 ABC/Expr::get_Item()
    } // end of property Expr::Item
  } // end of class Expr

  .class auto ansi serializable nested public beforefieldinit MyExn
         extends [mscorlib]System.Exception
         implements [mscorlib]System.Collections.IStructuralEquatable
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 05 00 00 00 00 00 ) 
    .field assembly int32 Data0@
    .method public specialname rtspecialname 
            instance void  .ctor(int32 data0) cil managed
    {
      // Code size       14 (0xe)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Exception::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldarg.1
      IL_0008:  stfld      int32 ABC/MyExn::Data0@
      IL_000d:  ret
    } // end of method MyExn::.ctor

    .method public specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Exception::.ctor()
      IL_0006:  ret
    } // end of method MyExn::.ctor

    .method family specialname rtspecialname 
            instance void  .ctor(class [mscorlib]System.Runtime.Serialization.SerializationInfo info,
                                 valuetype [mscorlib]System.Runtime.Serialization.StreamingContext context) cil managed
    {
      // Code size       9 (0x9)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  ldarg.2
      IL_0003:  call       instance void [mscorlib]System.Exception::.ctor(class [mscorlib]System.Runtime.Serialization.SerializationInfo,
                                                                           valuetype [mscorlib]System.Runtime.Serialization.StreamingContext)
      IL_0008:  ret
    } // end of method MyExn::.ctor

    .method public hidebysig specialname 
            instance int32  get_Data0() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      int32 ABC/MyExn::Data0@
      IL_0006:  ret
    } // end of method MyExn::get_Data0

    .method public hidebysig virtual instance int32 
            GetHashCode(class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       45 (0x2d)
      .maxstack  7
      .locals init (int32 V_0,
               class [mscorlib]System.Collections.IEqualityComparer V_1)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_002b

      IL_000b:  ldc.i4.0
      IL_000c:  stloc.0
      IL_000d:  ldc.i4     0x9e3779b9
      IL_0012:  ldarg.1
      IL_0013:  stloc.1
      IL_0014:  ldarg.0
      IL_0015:  castclass  ABC/MyExn
      IL_001a:  call       instance int32 ABC/MyExn::get_Data0()
      IL_001f:  ldloc.0
      IL_0020:  ldc.i4.6
      IL_0021:  shl
      IL_0022:  ldloc.0
      IL_0023:  ldc.i4.2
      IL_0024:  shr
      IL_0025:  add
      IL_0026:  add
      IL_0027:  add
      IL_0028:  stloc.0
      IL_0029:  ldloc.0
      IL_002a:  ret

      IL_002b:  ldc.i4.0
      IL_002c:  ret
    } // end of method MyExn::GetHashCode

    .method public hidebysig virtual instance int32 
            GetHashCode() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       13 (0xd)
      .maxstack  8
      .line 7,7 : 19,24
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  call       class [mscorlib]System.Collections.IEqualityComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericEqualityComparer()
      IL_0007:  callvirt   instance int32 ABC/MyExn::GetHashCode(class [mscorlib]System.Collections.IEqualityComparer)
      IL_000c:  ret
    } // end of method MyExn::GetHashCode

    .method public hidebysig virtual instance bool 
            Equals(object obj,
                   class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       76 (0x4c)
      .maxstack  4
      .locals init (class [mscorlib]System.Exception V_0,
               class [mscorlib]System.Exception V_1,
               class [mscorlib]System.Collections.IEqualityComparer V_2)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_0044

      IL_000b:  ldarg.1
      IL_000c:  isinst     [mscorlib]System.Exception
      IL_0011:  stloc.0
      IL_0012:  ldloc.0
      IL_0013:  brfalse.s  IL_0017

      IL_0015:  br.s       IL_0019

      IL_0017:  br.s       IL_0042

      IL_0019:  ldloc.0
      IL_001a:  stloc.1
      IL_001b:  ldloc.0
      IL_001c:  call       bool [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/IntrinsicFunctions::TypeTestGeneric<class ABC/MyExn>(object)
      IL_0021:  brtrue.s   IL_0025

      IL_0023:  br.s       IL_0040

      IL_0025:  ldarg.2
      IL_0026:  stloc.2
      IL_0027:  ldarg.0
      IL_0028:  castclass  ABC/MyExn
      IL_002d:  call       instance int32 ABC/MyExn::get_Data0()
      IL_0032:  ldloc.1
      IL_0033:  castclass  ABC/MyExn
      IL_0038:  call       instance int32 ABC/MyExn::get_Data0()
      IL_003d:  ceq
      IL_003f:  ret

      IL_0040:  ldc.i4.0
      IL_0041:  ret

      IL_0042:  ldc.i4.0
      IL_0043:  ret

      IL_0044:  ldarg.1
      IL_0045:  ldnull
      IL_0046:  cgt.un
      IL_0048:  ldc.i4.0
      IL_0049:  ceq
      IL_004b:  ret
    } // end of method MyExn::Equals

    .method public hidebysig instance bool 
            Equals(class [mscorlib]System.Exception obj) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       68 (0x44)
      .maxstack  4
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldnull
      IL_0003:  cgt.un
      IL_0005:  brfalse.s  IL_0009

      IL_0007:  br.s       IL_000b

      IL_0009:  br.s       IL_003c

      IL_000b:  ldarg.1
      IL_000c:  ldnull
      IL_000d:  cgt.un
      IL_000f:  brfalse.s  IL_0013

      IL_0011:  br.s       IL_0015

      IL_0013:  br.s       IL_003a

      IL_0015:  ldarg.1
      IL_0016:  call       bool [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/IntrinsicFunctions::TypeTestGeneric<class ABC/MyExn>(object)
      IL_001b:  brtrue.s   IL_001f

      IL_001d:  br.s       IL_0038

      IL_001f:  ldarg.0
      IL_0020:  castclass  ABC/MyExn
      IL_0025:  call       instance int32 ABC/MyExn::get_Data0()
      IL_002a:  ldarg.1
      IL_002b:  castclass  ABC/MyExn
      IL_0030:  call       instance int32 ABC/MyExn::get_Data0()
      IL_0035:  ceq
      IL_0037:  ret

      IL_0038:  ldc.i4.0
      IL_0039:  ret

      IL_003a:  ldc.i4.0
      IL_003b:  ret

      IL_003c:  ldarg.1
      IL_003d:  ldnull
      IL_003e:  cgt.un
      IL_0040:  ldc.i4.0
      IL_0041:  ceq
      IL_0043:  ret
    } // end of method MyExn::Equals

    .method public hidebysig virtual instance bool 
            Equals(object obj) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       25 (0x19)
      .maxstack  4
      .locals init (class [mscorlib]System.Exception V_0)
      IL_0000:  nop
      IL_0001:  ldarg.1
      IL_0002:  isinst     [mscorlib]System.Exception
      IL_0007:  stloc.0
      IL_0008:  ldloc.0
      IL_0009:  brfalse.s  IL_000d

      IL_000b:  br.s       IL_000f

      IL_000d:  br.s       IL_0017

      IL_000f:  ldarg.0
      IL_0010:  ldloc.0
      IL_0011:  callvirt   instance bool ABC/MyExn::Equals(class [mscorlib]System.Exception)
      IL_0016:  ret

      IL_0017:  ldc.i4.0
      IL_0018:  ret
    } // end of method MyExn::Equals

    .property instance int32 Data0()
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags,
                                                                                                  int32) = ( 01 00 04 00 00 00 00 00 00 00 00 00 ) 
      .get instance int32 ABC/MyExn::get_Data0()
    } // end of property MyExn::Data0
  } // end of class MyExn

  .class auto ansi serializable nested public A
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 03 00 00 00 00 00 ) 
    .field assembly string x
    .method public specialname rtspecialname 
            instance void  .ctor(string x) cil managed
    {
      // Code size       17 (0x11)
      .maxstack  8
      .line 8,8 : 16,17
      IL_0000:  ldarg.0
      IL_0001:  callvirt   instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  pop
      IL_0008:  nop
      IL_0009:  ldarg.0
      IL_000a:  ldarg.1
      IL_000b:  stfld      string ABC/A::x
      .line 8,8 : 14,15
      IL_0010:  ret
    } // end of method A::.ctor

    .method public hidebysig specialname 
            instance string  get_X() cil managed
    {
      // Code size       8 (0x8)
      .maxstack  8
      .line 8,8 : 42,43
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      string ABC/A::x
      IL_0007:  ret
    } // end of method A::get_X

    .property instance string X()
    {
      .get instance string ABC/A::get_X()
    } // end of property A::X
  } // end of class A

  .class abstract auto ansi sealed nested public ABC
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .class auto autochar serializable sealed nested public beforefieldinit Expr
           extends [mscorlib]System.Object
           implements class [mscorlib]System.IEquatable`1<class ABC/ABC/Expr>,
                      [mscorlib]System.Collections.IStructuralEquatable,
                      class [mscorlib]System.IComparable`1<class ABC/ABC/Expr>,
                      [mscorlib]System.IComparable,
                      [mscorlib]System.Collections.IStructuralComparable
    {
      .custom instance void [mscorlib]System.Diagnostics.DebuggerDisplayAttribute::.ctor(string) = ( 01 00 15 7B 5F 5F 44 65 62 75 67 44 69 73 70 6C   // ...{__DebugDispl
                                                                                                     61 79 28 29 2C 6E 71 7D 00 00 )                   // ay(),nq}..
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 01 00 00 00 00 00 ) 
      .field assembly initonly int32 item
      .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      .method public static class ABC/ABC/Expr 
              NewNum(int32 item) cil managed
      {
        .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags,
                                                                                                    int32) = ( 01 00 08 00 00 00 00 00 00 00 00 00 ) 
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  newobj     instance void ABC/ABC/Expr::.ctor(int32)
        IL_0006:  ret
      } // end of method Expr::NewNum

      .method assembly specialname rtspecialname 
              instance void  .ctor(int32 item) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       14 (0xe)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
        IL_0006:  ldarg.0
        IL_0007:  ldarg.1
        IL_0008:  stfld      int32 ABC/ABC/Expr::item
        IL_000d:  ret
      } // end of method Expr::.ctor

      .method public hidebysig instance int32 
              get_Item() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldfld      int32 ABC/ABC/Expr::item
        IL_0006:  ret
      } // end of method Expr::get_Item

      .method public hidebysig instance int32 
              get_Tag() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       4 (0x4)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  pop
        IL_0002:  ldc.i4.0
        IL_0003:  ret
      } // end of method Expr::get_Tag

      .method assembly hidebysig specialname 
              instance object  __DebugDisplay() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       22 (0x16)
        .maxstack  8
        IL_0000:  ldstr      "%+0.8A"
        IL_0005:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/ABC/Expr,string>,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string,string>::.ctor(string)
        IL_000a:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatToString<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/ABC/Expr,string>>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string>)
        IL_000f:  ldarg.0
        IL_0010:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/ABC/Expr,string>::Invoke(!0)
        IL_0015:  ret
      } // end of method Expr::__DebugDisplay

      .method public strict virtual instance string 
              ToString() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       22 (0x16)
        .maxstack  8
        IL_0000:  ldstr      "%+A"
        IL_0005:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/ABC/Expr,string>,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string,class ABC/ABC/Expr>::.ctor(string)
        IL_000a:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatToString<class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/ABC/Expr,string>>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [FSharp.Core]Microsoft.FSharp.Core.Unit,string,string>)
        IL_000f:  ldarg.0
        IL_0010:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class ABC/ABC/Expr,string>::Invoke(!0)
        IL_0015:  ret
      } // end of method Expr::ToString

      .method public hidebysig virtual final 
              instance int32  CompareTo(class ABC/ABC/Expr obj) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       81 (0x51)
        .maxstack  4
        .locals init (class ABC/ABC/Expr V_0,
                 class ABC/ABC/Expr V_1,
                 class [mscorlib]System.Collections.IComparer V_2,
                 int32 V_3,
                 int32 V_4)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_0043

        IL_000b:  ldarg.1
        IL_000c:  ldnull
        IL_000d:  cgt.un
        IL_000f:  brfalse.s  IL_0013

        IL_0011:  br.s       IL_0015

        IL_0013:  br.s       IL_0041

        IL_0015:  ldarg.0
        IL_0016:  pop
        IL_0017:  ldarg.0
        IL_0018:  stloc.0
        IL_0019:  ldarg.1
        IL_001a:  stloc.1
        IL_001b:  call       class [mscorlib]System.Collections.IComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericComparer()
        IL_0020:  stloc.2
        IL_0021:  ldloc.0
        IL_0022:  ldfld      int32 ABC/ABC/Expr::item
        IL_0027:  stloc.3
        IL_0028:  ldloc.1
        IL_0029:  ldfld      int32 ABC/ABC/Expr::item
        IL_002e:  stloc.s    V_4
        IL_0030:  ldloc.3
        IL_0031:  ldloc.s    V_4
        IL_0033:  bge.s      IL_0037

        IL_0035:  br.s       IL_0039

        IL_0037:  br.s       IL_003b

        IL_0039:  ldc.i4.m1
        IL_003a:  ret

        IL_003b:  ldloc.3
        IL_003c:  ldloc.s    V_4
        IL_003e:  cgt
        IL_0040:  ret

        IL_0041:  ldc.i4.1
        IL_0042:  ret

        IL_0043:  ldarg.1
        IL_0044:  ldnull
        IL_0045:  cgt.un
        IL_0047:  brfalse.s  IL_004b

        IL_0049:  br.s       IL_004d

        IL_004b:  br.s       IL_004f

        IL_004d:  ldc.i4.m1
        IL_004e:  ret

        IL_004f:  ldc.i4.0
        IL_0050:  ret
      } // end of method Expr::CompareTo

      .method public hidebysig virtual final 
              instance int32  CompareTo(object obj) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       14 (0xe)
        .maxstack  8
        .line 16,16 : 18,22
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldarg.1
        IL_0003:  unbox.any  ABC/ABC/Expr
        IL_0008:  callvirt   instance int32 ABC/ABC/Expr::CompareTo(class ABC/ABC/Expr)
        IL_000d:  ret
      } // end of method Expr::CompareTo

      .method public hidebysig virtual final 
              instance int32  CompareTo(object obj,
                                        class [mscorlib]System.Collections.IComparer comp) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       97 (0x61)
        .maxstack  4
        .locals init ([0] class ABC/ABC/Expr V_0,
                 [1] class ABC/ABC/Expr V_1,
                 [2] class ABC/ABC/Expr V_2,
                 [3] class [mscorlib]System.Collections.IComparer V_3,
                 [4] int32 V_4,
                 [5] int32 V_5)
        .line 16,16 : 18,22
        IL_0000:  nop
        IL_0001:  ldarg.1
        IL_0002:  unbox.any  ABC/ABC/Expr
        IL_0007:  stloc.0
        IL_0008:  ldarg.0
        IL_0009:  ldnull
        IL_000a:  cgt.un
        IL_000c:  brfalse.s  IL_0010

        IL_000e:  br.s       IL_0012

        IL_0010:  br.s       IL_004e

        .line 100001,100001 : 0,0
        IL_0012:  ldarg.1
        IL_0013:  unbox.any  ABC/ABC/Expr
        IL_0018:  ldnull
        IL_0019:  cgt.un
        IL_001b:  brfalse.s  IL_001f

        IL_001d:  br.s       IL_0021

        IL_001f:  br.s       IL_004c

        .line 100001,100001 : 0,0
        IL_0021:  ldarg.0
        IL_0022:  pop
        .line 100001,100001 : 0,0
        IL_0023:  ldarg.0
        IL_0024:  stloc.1
        IL_0025:  ldloc.0
        IL_0026:  stloc.2
        IL_0027:  ldarg.2
        IL_0028:  stloc.3
        IL_0029:  ldloc.1
        IL_002a:  ldfld      int32 ABC/ABC/Expr::item
        IL_002f:  stloc.s    V_4
        IL_0031:  ldloc.2
        IL_0032:  ldfld      int32 ABC/ABC/Expr::item
        IL_0037:  stloc.s    V_5
        IL_0039:  ldloc.s    V_4
        IL_003b:  ldloc.s    V_5
        IL_003d:  bge.s      IL_0041

        IL_003f:  br.s       IL_0043

        IL_0041:  br.s       IL_0045

        .line 100001,100001 : 0,0
        IL_0043:  ldc.i4.m1
        IL_0044:  ret

        .line 100001,100001 : 0,0
        IL_0045:  ldloc.s    V_4
        IL_0047:  ldloc.s    V_5
        IL_0049:  cgt
        IL_004b:  ret

        .line 100001,100001 : 0,0
        IL_004c:  ldc.i4.1
        IL_004d:  ret

        .line 100001,100001 : 0,0
        IL_004e:  ldarg.1
        IL_004f:  unbox.any  ABC/ABC/Expr
        IL_0054:  ldnull
        IL_0055:  cgt.un
        IL_0057:  brfalse.s  IL_005b

        IL_0059:  br.s       IL_005d

        IL_005b:  br.s       IL_005f

        .line 100001,100001 : 0,0
        IL_005d:  ldc.i4.m1
        IL_005e:  ret

        .line 100001,100001 : 0,0
        IL_005f:  ldc.i4.0
        IL_0060:  ret
      } // end of method Expr::CompareTo

      .method public hidebysig virtual final 
              instance int32  GetHashCode(class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       46 (0x2e)
        .maxstack  7
        .locals init (int32 V_0,
                 class ABC/ABC/Expr V_1,
                 class [mscorlib]System.Collections.IEqualityComparer V_2)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_002c

        IL_000b:  ldc.i4.0
        IL_000c:  stloc.0
        IL_000d:  ldarg.0
        IL_000e:  pop
        IL_000f:  ldarg.0
        IL_0010:  stloc.1
        IL_0011:  ldc.i4.0
        IL_0012:  stloc.0
        IL_0013:  ldc.i4     0x9e3779b9
        IL_0018:  ldarg.1
        IL_0019:  stloc.2
        IL_001a:  ldloc.1
        IL_001b:  ldfld      int32 ABC/ABC/Expr::item
        IL_0020:  ldloc.0
        IL_0021:  ldc.i4.6
        IL_0022:  shl
        IL_0023:  ldloc.0
        IL_0024:  ldc.i4.2
        IL_0025:  shr
        IL_0026:  add
        IL_0027:  add
        IL_0028:  add
        IL_0029:  stloc.0
        IL_002a:  ldloc.0
        IL_002b:  ret

        IL_002c:  ldc.i4.0
        IL_002d:  ret
      } // end of method Expr::GetHashCode

      .method public hidebysig virtual final 
              instance int32  GetHashCode() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       13 (0xd)
        .maxstack  8
        .line 16,16 : 18,22
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  call       class [mscorlib]System.Collections.IEqualityComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericEqualityComparer()
        IL_0007:  callvirt   instance int32 ABC/ABC/Expr::GetHashCode(class [mscorlib]System.Collections.IEqualityComparer)
        IL_000c:  ret
      } // end of method Expr::GetHashCode

      .method public hidebysig virtual final 
              instance bool  Equals(object obj,
                                    class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       61 (0x3d)
        .maxstack  4
        .locals init (class ABC/ABC/Expr V_0,
                 class ABC/ABC/Expr V_1,
                 class ABC/ABC/Expr V_2,
                 class ABC/ABC/Expr V_3,
                 class [mscorlib]System.Collections.IEqualityComparer V_4)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_0035

        IL_000b:  ldarg.1
        IL_000c:  isinst     ABC/ABC/Expr
        IL_0011:  stloc.0
        IL_0012:  ldloc.0
        IL_0013:  brfalse.s  IL_0017

        IL_0015:  br.s       IL_0019

        IL_0017:  br.s       IL_0033

        IL_0019:  ldloc.0
        IL_001a:  stloc.1
        IL_001b:  ldarg.0
        IL_001c:  pop
        IL_001d:  ldarg.0
        IL_001e:  stloc.2
        IL_001f:  ldloc.1
        IL_0020:  stloc.3
        IL_0021:  ldarg.2
        IL_0022:  stloc.s    V_4
        IL_0024:  ldloc.2
        IL_0025:  ldfld      int32 ABC/ABC/Expr::item
        IL_002a:  ldloc.3
        IL_002b:  ldfld      int32 ABC/ABC/Expr::item
        IL_0030:  ceq
        IL_0032:  ret

        IL_0033:  ldc.i4.0
        IL_0034:  ret

        IL_0035:  ldarg.1
        IL_0036:  ldnull
        IL_0037:  cgt.un
        IL_0039:  ldc.i4.0
        IL_003a:  ceq
        IL_003c:  ret
      } // end of method Expr::Equals

      .method public hidebysig virtual final 
              instance bool  Equals(class ABC/ABC/Expr obj) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       52 (0x34)
        .maxstack  4
        .locals init (class ABC/ABC/Expr V_0,
                 class ABC/ABC/Expr V_1)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_002c

        IL_000b:  ldarg.1
        IL_000c:  ldnull
        IL_000d:  cgt.un
        IL_000f:  brfalse.s  IL_0013

        IL_0011:  br.s       IL_0015

        IL_0013:  br.s       IL_002a

        IL_0015:  ldarg.0
        IL_0016:  pop
        IL_0017:  ldarg.0
        IL_0018:  stloc.0
        IL_0019:  ldarg.1
        IL_001a:  stloc.1
        IL_001b:  ldloc.0
        IL_001c:  ldfld      int32 ABC/ABC/Expr::item
        IL_0021:  ldloc.1
        IL_0022:  ldfld      int32 ABC/ABC/Expr::item
        IL_0027:  ceq
        IL_0029:  ret

        IL_002a:  ldc.i4.0
        IL_002b:  ret

        IL_002c:  ldarg.1
        IL_002d:  ldnull
        IL_002e:  cgt.un
        IL_0030:  ldc.i4.0
        IL_0031:  ceq
        IL_0033:  ret
      } // end of method Expr::Equals

      .method public hidebysig virtual final 
              instance bool  Equals(object obj) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       25 (0x19)
        .maxstack  4
        .locals init (class ABC/ABC/Expr V_0)
        IL_0000:  nop
        IL_0001:  ldarg.1
        IL_0002:  isinst     ABC/ABC/Expr
        IL_0007:  stloc.0
        IL_0008:  ldloc.0
        IL_0009:  brfalse.s  IL_000d

        IL_000b:  br.s       IL_000f

        IL_000d:  br.s       IL_0017

        IL_000f:  ldarg.0
        IL_0010:  ldloc.0
        IL_0011:  callvirt   instance bool ABC/ABC/Expr::Equals(class ABC/ABC/Expr)
        IL_0016:  ret

        IL_0017:  ldc.i4.0
        IL_0018:  ret
      } // end of method Expr::Equals

      .property instance int32 Tag()
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
        .get instance int32 ABC/ABC/Expr::get_Tag()
      } // end of property Expr::Tag
      .property instance int32 Item()
      {
        .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags,
                                                                                                    int32,
                                                                                                    int32) = ( 01 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
        .get instance int32 ABC/ABC/Expr::get_Item()
      } // end of property Expr::Item
    } // end of class Expr

    .class auto ansi serializable nested public beforefieldinit MyExn
           extends [mscorlib]System.Exception
           implements [mscorlib]System.Collections.IStructuralEquatable
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 05 00 00 00 00 00 ) 
      .field assembly int32 Data0@
      .method public specialname rtspecialname 
              instance void  .ctor(int32 data0) cil managed
      {
        // Code size       14 (0xe)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  call       instance void [mscorlib]System.Exception::.ctor()
        IL_0006:  ldarg.0
        IL_0007:  ldarg.1
        IL_0008:  stfld      int32 ABC/ABC/MyExn::Data0@
        IL_000d:  ret
      } // end of method MyExn::.ctor

      .method public specialname rtspecialname 
              instance void  .ctor() cil managed
      {
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  call       instance void [mscorlib]System.Exception::.ctor()
        IL_0006:  ret
      } // end of method MyExn::.ctor

      .method family specialname rtspecialname 
              instance void  .ctor(class [mscorlib]System.Runtime.Serialization.SerializationInfo info,
                                   valuetype [mscorlib]System.Runtime.Serialization.StreamingContext context) cil managed
      {
        // Code size       9 (0x9)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldarg.1
        IL_0002:  ldarg.2
        IL_0003:  call       instance void [mscorlib]System.Exception::.ctor(class [mscorlib]System.Runtime.Serialization.SerializationInfo,
                                                                             valuetype [mscorlib]System.Runtime.Serialization.StreamingContext)
        IL_0008:  ret
      } // end of method MyExn::.ctor

      .method public hidebysig specialname 
              instance int32  get_Data0() cil managed
      {
        // Code size       7 (0x7)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldfld      int32 ABC/ABC/MyExn::Data0@
        IL_0006:  ret
      } // end of method MyExn::get_Data0

      .method public hidebysig virtual instance int32 
              GetHashCode(class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       45 (0x2d)
        .maxstack  7
        .locals init (int32 V_0,
                 class [mscorlib]System.Collections.IEqualityComparer V_1)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_002b

        IL_000b:  ldc.i4.0
        IL_000c:  stloc.0
        IL_000d:  ldc.i4     0x9e3779b9
        IL_0012:  ldarg.1
        IL_0013:  stloc.1
        IL_0014:  ldarg.0
        IL_0015:  castclass  ABC/ABC/MyExn
        IL_001a:  call       instance int32 ABC/ABC/MyExn::get_Data0()
        IL_001f:  ldloc.0
        IL_0020:  ldc.i4.6
        IL_0021:  shl
        IL_0022:  ldloc.0
        IL_0023:  ldc.i4.2
        IL_0024:  shr
        IL_0025:  add
        IL_0026:  add
        IL_0027:  add
        IL_0028:  stloc.0
        IL_0029:  ldloc.0
        IL_002a:  ret

        IL_002b:  ldc.i4.0
        IL_002c:  ret
      } // end of method MyExn::GetHashCode

      .method public hidebysig virtual instance int32 
              GetHashCode() cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       13 (0xd)
        .maxstack  8
        .line 17,17 : 23,28
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  call       class [mscorlib]System.Collections.IEqualityComparer [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives::get_GenericEqualityComparer()
        IL_0007:  callvirt   instance int32 ABC/ABC/MyExn::GetHashCode(class [mscorlib]System.Collections.IEqualityComparer)
        IL_000c:  ret
      } // end of method MyExn::GetHashCode

      .method public hidebysig virtual instance bool 
              Equals(object obj,
                     class [mscorlib]System.Collections.IEqualityComparer comp) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       76 (0x4c)
        .maxstack  4
        .locals init (class [mscorlib]System.Exception V_0,
                 class [mscorlib]System.Exception V_1,
                 class [mscorlib]System.Collections.IEqualityComparer V_2)
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_0044

        IL_000b:  ldarg.1
        IL_000c:  isinst     [mscorlib]System.Exception
        IL_0011:  stloc.0
        IL_0012:  ldloc.0
        IL_0013:  brfalse.s  IL_0017

        IL_0015:  br.s       IL_0019

        IL_0017:  br.s       IL_0042

        IL_0019:  ldloc.0
        IL_001a:  stloc.1
        IL_001b:  ldloc.0
        IL_001c:  call       bool [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/IntrinsicFunctions::TypeTestGeneric<class ABC/ABC/MyExn>(object)
        IL_0021:  brtrue.s   IL_0025

        IL_0023:  br.s       IL_0040

        IL_0025:  ldarg.2
        IL_0026:  stloc.2
        IL_0027:  ldarg.0
        IL_0028:  castclass  ABC/ABC/MyExn
        IL_002d:  call       instance int32 ABC/ABC/MyExn::get_Data0()
        IL_0032:  ldloc.1
        IL_0033:  castclass  ABC/ABC/MyExn
        IL_0038:  call       instance int32 ABC/ABC/MyExn::get_Data0()
        IL_003d:  ceq
        IL_003f:  ret

        IL_0040:  ldc.i4.0
        IL_0041:  ret

        IL_0042:  ldc.i4.0
        IL_0043:  ret

        IL_0044:  ldarg.1
        IL_0045:  ldnull
        IL_0046:  cgt.un
        IL_0048:  ldc.i4.0
        IL_0049:  ceq
        IL_004b:  ret
      } // end of method MyExn::Equals

      .method public hidebysig instance bool 
              Equals(class [mscorlib]System.Exception obj) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       68 (0x44)
        .maxstack  4
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldnull
        IL_0003:  cgt.un
        IL_0005:  brfalse.s  IL_0009

        IL_0007:  br.s       IL_000b

        IL_0009:  br.s       IL_003c

        IL_000b:  ldarg.1
        IL_000c:  ldnull
        IL_000d:  cgt.un
        IL_000f:  brfalse.s  IL_0013

        IL_0011:  br.s       IL_0015

        IL_0013:  br.s       IL_003a

        IL_0015:  ldarg.1
        IL_0016:  call       bool [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/IntrinsicFunctions::TypeTestGeneric<class ABC/ABC/MyExn>(object)
        IL_001b:  brtrue.s   IL_001f

        IL_001d:  br.s       IL_0038

        IL_001f:  ldarg.0
        IL_0020:  castclass  ABC/ABC/MyExn
        IL_0025:  call       instance int32 ABC/ABC/MyExn::get_Data0()
        IL_002a:  ldarg.1
        IL_002b:  castclass  ABC/ABC/MyExn
        IL_0030:  call       instance int32 ABC/ABC/MyExn::get_Data0()
        IL_0035:  ceq
        IL_0037:  ret

        IL_0038:  ldc.i4.0
        IL_0039:  ret

        IL_003a:  ldc.i4.0
        IL_003b:  ret

        IL_003c:  ldarg.1
        IL_003d:  ldnull
        IL_003e:  cgt.un
        IL_0040:  ldc.i4.0
        IL_0041:  ceq
        IL_0043:  ret
      } // end of method MyExn::Equals

      .method public hidebysig virtual instance bool 
              Equals(object obj) cil managed
      {
        .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
        // Code size       25 (0x19)
        .maxstack  4
        .locals init (class [mscorlib]System.Exception V_0)
        IL_0000:  nop
        IL_0001:  ldarg.1
        IL_0002:  isinst     [mscorlib]System.Exception
        IL_0007:  stloc.0
        IL_0008:  ldloc.0
        IL_0009:  brfalse.s  IL_000d

        IL_000b:  br.s       IL_000f

        IL_000d:  br.s       IL_0017

        IL_000f:  ldarg.0
        IL_0010:  ldloc.0
        IL_0011:  callvirt   instance bool ABC/ABC/MyExn::Equals(class [mscorlib]System.Exception)
        IL_0016:  ret

        IL_0017:  ldc.i4.0
        IL_0018:  ret
      } // end of method MyExn::Equals

      .property instance int32 Data0()
      {
        .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags,
                                                                                                    int32) = ( 01 00 04 00 00 00 00 00 00 00 00 00 ) 
        .get instance int32 ABC/ABC/MyExn::get_Data0()
      } // end of property MyExn::Data0
    } // end of class MyExn

    .class auto ansi serializable nested public A
           extends [mscorlib]System.Object
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 03 00 00 00 00 00 ) 
      .field assembly string x
      .method public specialname rtspecialname 
              instance void  .ctor(string x) cil managed
      {
        // Code size       17 (0x11)
        .maxstack  8
        .line 18,18 : 20,21
        IL_0000:  ldarg.0
        IL_0001:  callvirt   instance void [mscorlib]System.Object::.ctor()
        IL_0006:  ldarg.0
        IL_0007:  pop
        IL_0008:  nop
        IL_0009:  ldarg.0
        IL_000a:  ldarg.1
        IL_000b:  stfld      string ABC/ABC/A::x
        .line 18,18 : 18,19
        IL_0010:  ret
      } // end of method A::.ctor

      .method public hidebysig specialname 
              instance string  get_X() cil managed
      {
        // Code size       8 (0x8)
        .maxstack  8
        .line 18,18 : 46,47
        IL_0000:  nop
        IL_0001:  ldarg.0
        IL_0002:  ldfld      string ABC/ABC/A::x
        IL_0007:  ret
      } // end of method A::get_X

      .property instance string X()
      {
        .get instance string ABC/ABC/A::get_X()
      } // end of property A::X
    } // end of class A

    .method public static int32  'add'(int32 x,
                                       int32 y) cil managed
    {
      .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationArgumentCountsAttribute::.ctor(int32[]) = ( 01 00 02 00 00 00 01 00 00 00 01 00 00 00 00 00 ) 
      // Code size       5 (0x5)
      .maxstack  8
      .line 21,21 : 27,32
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldarg.1
      IL_0003:  add
      IL_0004:  ret
    } // end of method ABC::'add'

    .method public specialname static string 
            get_greeting() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldstr      "hello"
      IL_0006:  ret
    } // end of method ABC::get_greeting

    .property string greeting()
    {
      .get string ABC/ABC::get_greeting()
    } // end of property ABC::greeting
  } // end of class ABC

  .method public static int32  'add'(int32 x,
                                     int32 y) cil managed
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationArgumentCountsAttribute::.ctor(int32[]) = ( 01 00 02 00 00 00 01 00 00 00 01 00 00 00 00 00 ) 
    // Code size       5 (0x5)
    .maxstack  8
    .line 11,11 : 23,28
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.1
    IL_0003:  add
    IL_0004:  ret
  } // end of method ABC::'add'

  .method public specialname static string 
          get_greeting() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "hello"
    IL_0006:  ret
  } // end of method ABC::get_greeting

  .property string greeting()
  {
    .get string ABC::get_greeting()
  } // end of property ABC::greeting
} // end of class ABC

.class private abstract auto ansi sealed '<StartupCode$TopLevelModule>'.$ABC
       extends [mscorlib]System.Object
{
  .field static assembly int32 init@
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .method private specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       14 (0xe)
    .maxstack  3
    .locals init ([0] string greeting,
             [1] string V_1)
    .line 12,12 : 9,31 ''
    IL_0000:  nop
    IL_0001:  call       string ABC::get_greeting()
    IL_0006:  stloc.0
    .line 22,22 : 13,35 ''
    IL_0007:  call       string ABC/ABC::get_greeting()
    IL_000c:  stloc.1
    IL_000d:  ret
  } // end of method $ABC::.cctor
} // end of class '<StartupCode$TopLevelModule>'.$ABC

// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
