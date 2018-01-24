// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CommandLine.UnitTests.Processors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestPlatform.CommandLine.Processors;
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestPlatform.CommandLine.Processors.Utilities;
    using vstest.console.UnitTests.Processors;

    [TestClass]
    public class ResultsDirectoryArgumentProcessorTests
    {
        private ResultsDirectoryArgumentExecutor executor;
        private TestableRunSettingsProvider runSettingsProvider;

        [TestInitialize]
        public void Init()
        {
            this.runSettingsProvider = new TestableRunSettingsProvider();
            this.executor = new ResultsDirectoryArgumentExecutor(CommandLineOptions.Instance, this.runSettingsProvider);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CommandLineOptions.Instance.Reset();
        }

        [TestMethod]
        public void GetMetadataShouldReturnResultsDirectoryArgumentProcessorCapabilities()
        {
            var processor = new ResultsDirectoryArgumentProcessor();
            Assert.IsTrue(processor.Metadata.Value is ResultsDirectoryArgumentProcessorCapabilities);
        }

        [TestMethod]
        public void GetExecuterShouldReturnResultsDirectoryArgumentExecutor()
        {
            var processor = new ResultsDirectoryArgumentProcessor();
            Assert.IsTrue(processor.Executor.Value is ResultsDirectoryArgumentExecutor);
        }

        #region ResultsDirectoryArgumentProcessorCapabilities tests

        [TestMethod]
        public void CapabilitiesShouldReturnAppropriateProperties()
        {
            var capabilities = new ResultsDirectoryArgumentProcessorCapabilities();
            Assert.AreEqual("/ResultsDirectory", capabilities.CommandName);
            Assert.AreEqual("--ResultsDirectory|/ResultsDirectory\n      Test results directory will be created in specified path if not exists.\n      Example  /ResultsDirectory:<pathToResultsDirectory>", capabilities.HelpContentResourceName);

            Assert.AreEqual(HelpContentPriority.ResultsDirectoryArgumentProcessorHelpPriority, capabilities.HelpPriority);
            Assert.AreEqual(false, capabilities.IsAction);
            Assert.AreEqual(ArgumentProcessorPriority.AutoUpdateRunSettings, capabilities.Priority);

            Assert.AreEqual(false, capabilities.AllowMultiple);
            Assert.AreEqual(false, capabilities.AlwaysExecute);
            Assert.AreEqual(false, capabilities.IsSpecialCommand);
        }

        #endregion

        #region ResultsDirectoryArgumentExecutor Initialize tests

        [TestMethod]
        public void InitializeShouldThrowIfArgumentIsNull()
        {
            string folder = null;
            var message =
                @"The /ResultsDirectory parameter requires a value, where the test results should be saved. Example:  /ResultsDirectory:c:\MyTestResultsDirectory";
            this.InitializeExceptionTestTemplate(folder, message);
        }

        [TestMethod]
        public void InitializeShouldThrowIfArgumentIsAWhiteSpace()
        {
            var folder = " ";
            var message =
                @"The /ResultsDirectory parameter requires a value, where the test results should be saved. Example:  /ResultsDirectory:c:\MyTestResultsDirectory";
            this.InitializeExceptionTestTemplate(folder, message);
        }

        [TestMethod]
        public void InitializeShouldThrowIfGivenPathisIllegal()
        {
            var folder = @"c:\som<\illegal\path\";
            var message = string.Format(
                @"The path '{0}' specified in the 'ResultsDirectory' is invalid. Error: {1}",
                folder,
                "Illegal characters in path.");
            this.InitializeExceptionTestTemplate(folder, message);
        }

        [TestMethod]
        public void InitializeShouldThrowIfPathIsNotSupported()
        {

            var folder = @"c:\path\to\in:valid";

            var message = string.Format(
                @"The path '{0}' specified in the 'ResultsDirectory' is invalid. Error: {1}",
                folder,
                "The given path's format is not supported.");
            this.InitializeExceptionTestTemplate(folder, message);
        }

        private void InitializeExceptionTestTemplate(string folder, string message)
        {
            var isExceptionThrown = false;

            try
            {
                this.executor.Initialize(folder);
            }
            catch (Exception ex)
            {
                isExceptionThrown = true;
                Assert.IsTrue(ex is CommandLineException);
                Assert.AreEqual(message, ex.Message);
            }

            Assert.IsTrue(isExceptionThrown);
        }

        [TestMethod]
        public void InitializeShouldSetCommandLineOptionsAndRunSettingsForRelativePathValue()
        {
            var relativePath = @".\relative\path";
            var absolutePath = Path.GetFullPath(relativePath);
            this.executor.Initialize(relativePath);
            Assert.AreEqual(absolutePath, CommandLineOptions.Instance.ResultsDirectory);
            Assert.AreEqual(absolutePath, this.runSettingsProvider.QueryRunSettingsNode(ResultsDirectoryArgumentExecutor.RunSettingsPath));
        }

        [TestMethod]
        public void InitializeShouldSetCommandLineOptionsAndRunSettingsForAbsolutePathValue()
        {
            var absolutePath = @"c:\Users\someone\testresults";
            this.executor.Initialize(absolutePath);
            Assert.AreEqual(absolutePath, CommandLineOptions.Instance.ResultsDirectory);
            Assert.AreEqual(absolutePath, this.runSettingsProvider.QueryRunSettingsNode(ResultsDirectoryArgumentExecutor.RunSettingsPath));
        }

        #endregion

        #region ResultsDirectoryArgumentExecutor Execute tests

        [TestMethod]
        public void ExecuteShouldReturnSuccess()
        {
            Assert.AreEqual(ArgumentProcessorResult.Success, executor.Execute());
        }

        #endregion
    }
}
