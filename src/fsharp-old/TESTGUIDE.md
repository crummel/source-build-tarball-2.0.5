# F# Compiler, Core Library and Visual F# Tools Tests

## Quick start: Running Tests

To run tests, use variations such as the following, depending on which test suite and build configuration you want:

    build.cmd test
    build.cmd net40 test
    build.cmd coreclr test
    build.cmd vs test
    build.cmd all test

## Prerequisites

In order to run the FSharpQA suite, you will need to install [Perl](http://www.perl.org/get.html) (ActiveState Perl 5.16.3 is known to work fine).
Perl must be included in the `%PATH%` for the below steps to work. It is also recommended that you run tests from an elevated command prompt, as there are a couple of test cases which require administrative privileges.

The Perl requirement is gradually being removed.

## Test Suites

The F# tests are split as follows:

* [FSharp Suite](tests/fsharp) - Older suite with broad coverage of mainline compiler and runtime scenarios.

* [FSharpQA Suite](tests/fsharpqa/Source) - Broad and deep coverage of a variety of compiler, runtime, and syntax scenarios.

* [FSharp.Core.Unittests](src/fsharp/FSharp.Core.Unittests) - Validation of the core F# types and the public surface area of `FSharp.Core.dll`.

* [FSharp.Compiler.Unittests](src/fsharp/FSharp.Compiler.Unittests) - Validation of compiler internals.

* [VisualFSharp.UnitTests](vsintegration/tests/unittests) - Visual F# Tools IDE Unit Test Suite
  This suite exercises a wide range of behaviors in the F# Visual Studio project system and language service.

## More Details

### FSharp Suite

This is compiled using [tests\fsharp\FSharp.Tests.FSharpSuite.fsproj](tests/fsharp/FSharp.Tests.FSharpSuite.fsproj) to a unit test DLL which acts as a driver script. Each individual test is an NUnit test case, and so you can run it like any other NUnit test.

Tests are grouped in folders per area. Each test compiles and executes a `test.fsx|fs` file in its folder using some combination of compiler or FSI flags specified in the FSharpSuite test project.  
If the compilation and execution encounter no errors, the test is considered to have passed.

### FSharpQA Suite

These tests use the `RunAll.pl` framework to execute, however the easiest way to run them is via the `build.cmd` script, see [usage examples](https://github.com/Microsoft/visualfsharp/blob/master/build.cmd#L31).

Tests are grouped in folders per area. Each folder contains a number of source code files and a single `env.lst` file. The `env.lst` file defines a series of test cases, one per line.
Each test case runs an optional "pre command," compiles a given set of source files using given flags, optionally runs the resulting binary, then optionally runs a final "post command." 
If all of these steps complete without issue, the test is considered to have passed.

#### Test lists

For the FSharpQA suite, the list of test areas and their associated "tags" is stored at

    tests\fsharpqa\source\test.lst   // FSharpQA suite

Tags are in the left column, paths to to corresponding test folders are in the right column.  If no tags are specifie, all tests will be run.

If you want to re-run a particular test area, the easiest way to do so is to set a temporary tag for that area in test.lst (e.g. "RERUN") and then pass that as an argument to `build.cmd`: `build.cmd test-net40-fsharpqa include RERUN`.

### FSharp.Compiler.Unittests, FSharp.Core.Unittests, VisualFSharp.Unittests

These are all NUnit tests. You can execute these tests individually via the Visual Studio NUnit3 runner 
extension or the command line via `nunit3-console.exe`.

Note that for compatibility reasons, the IDE unit tests should be run in a 32-bit process, 
using the '--x86' flag to `nunit3-console.exe`



### Logs and output

All test execution logs and result files will be dropped into the `tests\TestResults` folder, and have file names matching

    net40-fsharp-suite-*.*
    net40-fsharpqa-suite-*.*
    net40-compilerunit-suite-*.*
    net40-coreunit-suite-*.*
    vs-ideunit-suite-*.*

### Other Tips

* Run as Administrator, or a handful of tests will fail

* Making the tests run faster
  * NGen-ing the F# bits (fsc, fsi, FSharp.Core, etc) will result in tests executing much faster. Make sure you run `src\update.cmd` with the `-ngen` flag before running tests.
  * The FSharp and FSharpQA suites will run test cases in parallel by default. You can comment out the relevant line (look for `PARALLEL_ARG`) to disable this.
  * By default, tests from the FSharpQA suite are run using a persistent, hosted version of the compiler. This speeds up test execution, as there is no need for the `fsc.exe` process to spin up repeatedly. To disable this, uncomment the relevant line (look for `HOSTED_COMPILER`).
