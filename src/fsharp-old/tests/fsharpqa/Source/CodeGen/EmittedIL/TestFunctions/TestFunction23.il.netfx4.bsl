
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
.assembly TestFunction23
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 00 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.TestFunction23
{
  // Offset: 0x00000000 Length: 0x00000346
}
.mresource public FSharpOptimizationData.TestFunction23
{
  // Offset: 0x00000350 Length: 0x000000E3
}
.module TestFunction23.exe
// MVID: {5775B1AC-A643-451C-A745-0383ACB17557}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00CD0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed TestFunction23
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class auto ansi serializable nested public C
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 03 00 00 00 00 00 ) 
    .field assembly string x
    .field assembly string x@8
    .method public specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       32 (0x20)
      .maxstack  8
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 6,6 : 5,38 'C:\\GitHub\\dsyme\\visualfsharp\\tests\\fsharpqa\\Source\\CodeGen\\EmittedIL\\TestFunctions\\TestFunction23.fs'
      IL_0000:  ldarg.0
      IL_0001:  callvirt   instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  pop
      IL_0008:  nop
      IL_0009:  ldarg.0
      IL_000a:  call       string [mscorlib]System.Console::ReadLine()
      IL_000f:  stfld      string TestFunction23/C::x
      .line 8,8 : 5,38
      IL_0014:  ldarg.0
      IL_0015:  call       string [mscorlib]System.Console::ReadLine()
      IL_001a:  stfld      string TestFunction23/C::x@8
      .line 5,5 : 6,7
      IL_001f:  ret
    } // end of method C::.ctor

    .method public hidebysig instance string 
            M() cil managed
    {
      // Code size       19 (0x13)
      .maxstack  8
      .line 9,9 : 23,30
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      string TestFunction23/C::x@8
      IL_0007:  ldarg.0
      IL_0008:  callvirt   instance string TestFunction23/C::g()
      IL_000d:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_0012:  ret
    } // end of method C::M

    .method assembly hidebysig instance string 
            g() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       8 (0x8)
      .maxstack  8
      .line 7,7 : 15,16
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  ldfld      string TestFunction23/C::x
      IL_0007:  ret
    } // end of method C::g

  } // end of class C

  .class auto ansi serializable sealed nested assembly beforefieldinit g@13
         extends class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>
  {
    .method assembly specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::.ctor()
      IL_0006:  ret
    } // end of method g@13::.ctor

    .method public strict virtual instance class [FSharp.Core]Microsoft.FSharp.Core.Unit 
            Invoke(class [FSharp.Core]Microsoft.FSharp.Core.Unit unitVar0) cil managed
    {
      // Code size       35 (0x23)
      .maxstack  8
      .line 13,13 : 9,24
      IL_0000:  nop
      IL_0001:  ldstr      "Hello"
      IL_0006:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::.ctor(string)
      IL_000b:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatLine<class [FSharp.Core]Microsoft.FSharp.Core.Unit>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>)
      IL_0010:  pop
      .line 14,14 : 9,24
      IL_0011:  ldstr      "Hello"
      IL_0016:  newobj     instance void class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`5<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::.ctor(string)
      IL_001b:  tail.
      IL_001d:  call       !!0 [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::PrintFormatLine<class [FSharp.Core]Microsoft.FSharp.Core.Unit>(class [FSharp.Core]Microsoft.FSharp.Core.PrintfFormat`4<!!0,class [mscorlib]System.IO.TextWriter,class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>)
      IL_0022:  ret
    } // end of method g@13::Invoke

  } // end of class g@13

  .method public static class [mscorlib]System.Tuple`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit> 
          f<a>(!!a x) cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  5
    .locals init ([0] class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit> g)
    .line 15,15 : 5,13
    IL_0000:  nop
    IL_0001:  newobj     instance void TestFunction23/g@13::.ctor()
    IL_0006:  stloc.0
    .line 15,15 : 5,13
    IL_0007:  ldloc.0
    IL_0008:  ldnull
    IL_0009:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::Invoke(!0)
    IL_000e:  ldloc.0
    IL_000f:  ldnull
    IL_0010:  callvirt   instance !1 class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::Invoke(!0)
    IL_0015:  newobj     instance void class [mscorlib]System.Tuple`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit,class [FSharp.Core]Microsoft.FSharp.Core.Unit>::.ctor(!0,
                                                                                                                                                                          !1)
    IL_001a:  ret
  } // end of method TestFunction23::f

} // end of class TestFunction23

.class private abstract auto ansi sealed '<StartupCode$TestFunction23>'.$TestFunction23
       extends [mscorlib]System.Object
{
  .method public static void  main@() cil managed
  {
    .entrypoint
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ret
  } // end of method $TestFunction23::main@

} // end of class '<StartupCode$TestFunction23>'.$TestFunction23


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
