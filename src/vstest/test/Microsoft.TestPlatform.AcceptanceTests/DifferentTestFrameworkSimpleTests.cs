﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.TestPlatform.AcceptanceTests
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DifferentTestFrameworkSimpleTests : AcceptanceTestBase
    {
        [CustomDataTestMethod]
        [NETFullTargetFramework(inIsolation: true, inProcess: true)]
        public void ChutzpahRunAllTestExecution(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);

            var testJSFileAbsolutePath = Path.Combine(this.testEnvironment.TestAssetsPath, "test.js");
            var arguments = PrepareArguments(
                testJSFileAbsolutePath,
                this.GetTestAdapterPath(UnitTestFramework.Chutzpah),
                string.Empty,
                runnerInfo.InIsolationValue);
            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 1, 0);
        }

        [CustomDataTestMethod]
        [NETFullTargetFramework(inIsolation: true, inProcess: true)]
        public void CPPRunAllTestExecution(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);
            CppRunAllTests(runnerInfo.RunnerFramework, "x86");
        }

        [CustomDataTestMethod]
        [NETFullTargetFramework]
        public void CPPRunAllTestExecutionPlatformx64(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);
            CppRunAllTests(runnerInfo.RunnerFramework, "x64");
        }

        [CustomDataTestMethod]
        [NETFullTargetFramework]
        public void WebTestRunAllTests(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);
            WebTestRunAllTests(runnerInfo.RunnerFramework);
        }

        [CustomDataTestMethod]
        [NETFullTargetFramework]
        public void CodedWebTestRunAllTests(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);
            CodedWebTestRunAllTests(runnerInfo.RunnerFramework);
        }

        [CustomDataTestMethod]
        [NETFullTargetFramework(inIsolation: true, inProcess: true)]
        public void NUnitRunAllTestExecution(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);

            var arguments = PrepareArguments(
                this.GetAssetFullPath("NUTestProject.dll"),
                this.GetTestAdapterPath(UnitTestFramework.NUnit),
                string.Empty,
                runnerInfo.InIsolationValue);
            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 1, 0);
        }

        [CustomDataTestMethod]
        [NETFullTargetFramework(inIsolation: true, inProcess: true)]
        [NETCORETargetFramework]
        public void XUnitRunAllTestExecution(RunnerInfo runnerInfo)
        {
            AcceptanceTestBase.SetTestEnvironment(this.testEnvironment, runnerInfo);
            string testAssemblyPath = null;

            // Xunit >= 2.2 won't support net451, Minimum target framework it supports is net452.
            if (this.testEnvironment.TargetFramework.Equals("net451"))
            {
                testAssemblyPath = testEnvironment.GetTestAsset("XUTestProject.dll", "net46");
            }
            else
            {
                testAssemblyPath = testEnvironment.GetTestAsset("XUTestProject.dll");
            }

            var arguments = PrepareArguments(
                testAssemblyPath,
                this.GetTestAdapterPath(UnitTestFramework.XUnit),
                string.Empty,
                runnerInfo.InIsolationValue);
            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 1, 0);
        }

        private void CppRunAllTests(string runnerFramework, string platform)
        {
            if (runnerFramework.StartsWith("netcoreapp"))
            {
                Assert.Inconclusive("CPP tests not supported with .Netcore runner.");
                return;
            }

            string assemblyRelativePathFormat =
                @"microsoft.testplatform.testasset.nativecpp\2.0.0\contentFiles\any\any\{0}\Microsoft.TestPlatform.TestAsset.NativeCPP.dll";
            var assemblyRelativePath = platform.Equals("x64", StringComparison.OrdinalIgnoreCase)
                ? string.Format(assemblyRelativePathFormat, platform)
                : string.Format(assemblyRelativePathFormat, "");
            var assemblyAbsolutePath = Path.Combine(this.testEnvironment.PackageDirectory, assemblyRelativePath);
            var arguments = PrepareArguments(
                assemblyAbsolutePath,
                string.Empty,
                string.Empty,
                this.testEnvironment.InIsolationValue);

            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 1, 0);
        }

        private void WebTestRunAllTests(string runnerFramework)
        {
            if (runnerFramework.StartsWith("netcoreapp"))
            {
                Assert.Inconclusive("WebTests tests not supported with .Netcore runner.");
                return;
            }

            string assemblyRelativePath =
                @"microsoft.testplatform.qtools.assets\2.0.0\contentFiles\any\any\WebTestAssets\WebTest1.webtest";
            var assemblyAbsolutePath = Path.Combine(this.testEnvironment.PackageDirectory, assemblyRelativePath);
            var arguments = PrepareArguments(
                assemblyAbsolutePath,
                string.Empty,
                string.Empty);

            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 0, 0);
        }

        private void CodedWebTestRunAllTests(string runnerFramework)
        {
            if (runnerFramework.StartsWith("netcoreapp"))
            {
                Assert.Inconclusive("WebTests tests not supported with .Netcore runner.");
                return;
            }

            string assemblyRelativePath =
                @"microsoft.testplatform.qtools.assets\2.0.0\contentFiles\any\any\WebTestAssets\BingWebTest.dll";
            var assemblyAbsolutePath = Path.Combine(this.testEnvironment.PackageDirectory, assemblyRelativePath);
            var arguments = PrepareArguments(
                assemblyAbsolutePath,
                string.Empty,
                string.Empty);

            this.InvokeVsTest(arguments);
            this.ValidateSummaryStatus(1, 0, 0);
        }
    }
}
