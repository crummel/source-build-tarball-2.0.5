﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.TestPlatform.AcceptanceTests
{
    using System;
    using System.IO;
    using System.Threading;

    using global::TestPlatform.TestUtilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExecutionTests : AcceptanceTestBase
    {
        [CustomDataTestMethod]
        [NET46TargetFramework]
        [NETCORETargetFramework]
        public void RunMultipleTestAssemblies(string runnerFramework, string targetFramework, string targetRuntime)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerFramework, targetFramework, targetRuntime);

            var assemblyPaths =
                this.BuildMultipleAssemblyPath("SimpleTestProject.dll", "SimpleTestProject2.dll").Trim('\"');
            this.InvokeVsTestForExecution(assemblyPaths, this.GetTestAdapterPath(), string.Empty, this.FrameworkArgValue);
            this.ValidateSummaryStatus(2, 2, 2);
        }

        // Randomly failing with error "The active test run was aborted. Reason: Destination array was not long enough.
        // Check destIndex and length, and the array's lower bounds. Test Run Failed."
        // Issue: https://github.com/Microsoft/vstest/issues/292
        [Ignore]
        [CustomDataTestMethod]
        [NET46TargetFramework]
        [NETCORETargetFramework]
        public void RunMultipleTestAssembliesInParallel(string runnerFramework, string targetFramework, string targetRuntime)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerFramework, targetFramework, targetRuntime);
            var assemblyPaths =
                this.BuildMultipleAssemblyPath("SimpleTestProject.dll", "SimpleTestProject2.dll").Trim('\"');
            var arguments = PrepareArguments(assemblyPaths, this.GetTestAdapterPath(), string.Empty, this.FrameworkArgValue);
            arguments = string.Concat(arguments, " /Parallel");
            arguments = string.Concat(arguments, " /Platform:x86");
            string testhostProcessName = string.Empty;
            int expectedNumOfProcessCreated = 0;
            if (this.IsDesktopTargetFramework())
            {
                testhostProcessName = "testhost.x86";
                expectedNumOfProcessCreated = 2;
            }
            else
            {
                testhostProcessName = "dotnet";
                if (this.IsDesktopRunner())
                {
                    expectedNumOfProcessCreated = 2;
                }
                else
                {
                    // Include launcher dotnet.exe
                    expectedNumOfProcessCreated = 3;
                }
            }

            var cts = new CancellationTokenSource();
            var numOfProcessCreatedTask = NumberOfProcessLaunchedUtility.NumberOfProcessCreated(
                cts,
                testhostProcessName);

            this.InvokeVsTest(arguments);
            cts.Cancel();

            Assert.AreEqual(
                expectedNumOfProcessCreated,
                numOfProcessCreatedTask.Result,
                $"Number of {testhostProcessName} process created, expected: {expectedNumOfProcessCreated} actual: {numOfProcessCreatedTask.Result}");
            this.ValidateSummaryStatus(2, 2, 2);
        }

        [CustomDataTestMethod]
        [NET46TargetFramework]
        [NETCORETargetFramework]
        public void WorkingDirectoryIsSourceDirectory(string runnerFramework, string targetFramework, string targetRuntime)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerFramework, targetFramework, targetRuntime);

            var assemblyPaths =
                this.BuildMultipleAssemblyPath("SimpleTestProject3.dll").Trim('\"');
            var arguments = PrepareArguments(assemblyPaths, this.GetTestAdapterPath(), string.Empty, this.FrameworkArgValue);
            arguments = string.Concat(arguments, " /tests:WorkingDirectoryTest");
            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 0, 0);
        }

        [CustomDataTestMethod]
        [NET46TargetFramework]
        [NETCORETargetFramework]
        public void StackOverflowExceptionShouldBeLoggedToConsoleAndDiagLogFile(string runnerFramework, string targetFramework, string targetRuntime)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerFramework, targetFramework, targetRuntime);

            if (this.testEnvironment.BuildConfiguration.Equals("release", StringComparison.OrdinalIgnoreCase)
                && targetFramework.StartsWith("netcoreapp"))
            {
                Assert.Inconclusive("On StackOverflowException testhost not exited in release configuration.");
                return;
            }

            var diagLogFilePath = Path.Combine(Path.GetTempPath(), $"std_error_log_{Guid.NewGuid()}.txt");
            File.Delete(diagLogFilePath);

            var assemblyPaths =
                this.BuildMultipleAssemblyPath("SimpleTestProject3.dll").Trim('\"');
            var arguments = PrepareArguments(assemblyPaths, this.GetTestAdapterPath(), string.Empty, this.FrameworkArgValue);
            arguments = string.Concat(arguments, " /tests:ExitWithStackoverFlow");
            arguments = string.Concat(arguments, $" /diag:{diagLogFilePath}");

            this.InvokeVsTest(arguments);
            var errorMessage = string.Empty;

            if (targetFramework.StartsWith("netcoreapp2."))
            {
                errorMessage = "Process is terminating due to StackOverflowException.";
            }
            else
            {
                errorMessage = "Process is terminated due to StackOverflowException.";
            }

            FileAssert.Contains(diagLogFilePath, errorMessage);
            this.StdErrorContains(errorMessage);
            File.Delete(diagLogFilePath);
        }

        [CustomDataTestMethod]
        [NET46TargetFramework]
        [NETCORETargetFramework]
        public void UnhandleExceptionExceptionShouldBeLoggedToDiagLogFile(string runnerFramework, string targetFramework, string targetRuntime)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerFramework, targetFramework, targetRuntime);

            var diagLogFilePath = Path.Combine(Path.GetTempPath(), $"std_error_log_{Guid.NewGuid()}.txt");
            File.Delete(diagLogFilePath);

            var assemblyPaths =
                this.BuildMultipleAssemblyPath("SimpleTestProject3.dll").Trim('\"');
            var arguments = PrepareArguments(assemblyPaths, this.GetTestAdapterPath(), string.Empty, this.FrameworkArgValue);
            arguments = string.Concat(arguments, " /tests:ExitwithUnhandleException");
            arguments = string.Concat(arguments, $" /diag:{diagLogFilePath}");

            this.InvokeVsTest(arguments);
            var errorFirstLine = "Test host standard error line: Unhandled Exception: System.InvalidOperationException: Operation is not valid due to the current state of the object.";
            FileAssert.Contains(diagLogFilePath, errorFirstLine);
            File.Delete(diagLogFilePath);
        }
    }
}