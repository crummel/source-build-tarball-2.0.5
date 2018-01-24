﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace vstest.console.UnitTests.TestPlatformHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestPlatform.Client.RequestHelper;
    using Microsoft.VisualStudio.TestPlatform.CommandLine;
    using Microsoft.VisualStudio.TestPlatform.CommandLine.TestPlatformHelpers;
    using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.Common.Logging;
    using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Tracing.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using vstest.console.UnitTests.TestDoubles;

    [TestClass]
    public class TestRequestManagerTests
    {
        private DummyLoggerEvents mockLoggerEvents;
        private TestLoggerManager mockLoggerManager;
        private CommandLineOptions commandLineOptions;
        private Mock<ITestPlatform> mockTestPlatform;
        private Mock<IDiscoveryRequest> mockDiscoveryRequest;
        private Mock<ITestRunRequest> mockRunRequest;
        private ITestRequestManager testRequestManager;
        private Mock<ITestPlatformEventSource> mockTestPlatformEventSource;

        public TestRequestManagerTests()
        {
            this.mockLoggerEvents = new DummyLoggerEvents(TestSessionMessageLogger.Instance);
            this.mockLoggerManager = new DummyTestLoggerManager(this.mockLoggerEvents);
            this.commandLineOptions = new DummyCommandLineOptions();
            this.mockTestPlatform = new Mock<ITestPlatform>();
            this.mockDiscoveryRequest = new Mock<IDiscoveryRequest>();
            this.mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatformEventSource = new Mock<ITestPlatformEventSource>();
            var testRunResultAggregator = new DummyTestRunResultAggregator();

            this.testRequestManager = new TestRequestManager(this.commandLineOptions, this.mockTestPlatform.Object,
                mockLoggerManager, testRunResultAggregator, mockTestPlatformEventSource.Object);
            this.mockTestPlatform.Setup(tp => tp.CreateDiscoveryRequest(It.IsAny<DiscoveryCriteria>(), It.IsAny<ProtocolConfig>()))
                .Returns(this.mockDiscoveryRequest.Object);
            this.mockTestPlatform.Setup(tp => tp.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>()))
                .Returns(this.mockRunRequest.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            CommandLineOptions.Instance.Reset();
        }

        [TestMethod]
        public void TestRequestManagerShouldInitializeConsoleLogger()
        {
            CommandLineOptions.Instance.IsDesignMode = false;
            var requestManager = new TestRequestManager(CommandLineOptions.Instance,
                new Mock<ITestPlatform>().Object,
                this.mockLoggerManager,
                TestRunResultAggregator.Instance,
                new Mock<ITestPlatformEventSource>().Object);

            Assert.IsTrue(this.mockLoggerEvents.EventsSubscribed());
        }

        [TestMethod]
        public void TestRequestManagerShouldNotInitializeConsoleLoggerIfDesignModeIsSet()
        {
            CommandLineOptions.Instance.IsDesignMode = true;
            this.mockLoggerEvents = new DummyLoggerEvents(TestSessionMessageLogger.Instance);
            this.mockLoggerManager = new DummyTestLoggerManager(this.mockLoggerEvents);
            var requestManager = new TestRequestManager(CommandLineOptions.Instance,
                new Mock<ITestPlatform>().Object,
                this.mockLoggerManager,
                TestRunResultAggregator.Instance,
                new Mock<ITestPlatformEventSource>().Object);

            Assert.IsFalse(this.mockLoggerEvents.EventsSubscribed());
        }

        [TestMethod]
        public void InitializeExtensionsShouldCallTestPlatformToInitialize()
        {
            var paths = new List<string>() { "a", "b" };
            this.testRequestManager.InitializeExtensions(paths);

            this.mockTestPlatform.Verify(mt => mt.UpdateExtensions(paths, false), Times.Once);
        }

        [TestMethod]
        public void ResetShouldResetCommandLineOptionsInstance()
        {
            var oldInstance = CommandLineOptions.Instance;
            this.testRequestManager.ResetOptions();

            var newInstance = CommandLineOptions.Instance;

            Assert.AreNotEqual(oldInstance, newInstance, "CommandLineOptions must be cleaned up");
        }

        [TestMethod]
        public void DiscoverTestsShouldReadTheBatchSizeFromSettingsAndSetItForDiscoveryCriteria()
        {
            var payload = new DiscoveryRequestPayload()
            {
                Sources = new List<string>() { "a" },
                RunSettings =
                 @"<?xml version=""1.0"" encoding=""utf-8""?>
                <RunSettings>
                     <RunConfiguration>
                       <BatchSize>15</BatchSize>
                     </RunConfiguration>
                </RunSettings>"
            };

            DiscoveryCriteria actualDiscoveryCriteria = null;
            var mockDiscoveryRequest = new Mock<IDiscoveryRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateDiscoveryRequest(It.IsAny<DiscoveryCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (DiscoveryCriteria discoveryCriteria, ProtocolConfig config) =>
                {
                    actualDiscoveryCriteria = discoveryCriteria;
                }).Returns(mockDiscoveryRequest.Object);

            var success = this.testRequestManager.DiscoverTests(payload, new Mock<ITestDiscoveryEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());
            Assert.AreEqual(15, actualDiscoveryCriteria.FrequencyOfDiscoveredTestsEvent);
        }

        [TestMethod]
        public void DiscoverTestsShouldCallTestPlatformAndSucceed()
        {
            var payload = new DiscoveryRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            var createDiscoveryRequestCalled = 0;
            DiscoveryCriteria actualDiscoveryCriteria = null;
            var mockDiscoveryRequest = new Mock<IDiscoveryRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateDiscoveryRequest(It.IsAny<DiscoveryCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (DiscoveryCriteria discoveryCriteria, ProtocolConfig config) =>
                {
                    createDiscoveryRequestCalled++;
                    actualDiscoveryCriteria = discoveryCriteria;
                }).Returns(mockDiscoveryRequest.Object);

            var mockDiscoveryRegistrar = new Mock<ITestDiscoveryEventsRegistrar>();
            var success = this.testRequestManager.DiscoverTests(payload, mockDiscoveryRegistrar.Object, It.IsAny<ProtocolConfig>());

            Assert.IsTrue(success, "DiscoverTests call must succeed");

            Assert.AreEqual(createDiscoveryRequestCalled, 1, "CreateDiscoveryRequest must be invoked only once.");
            Assert.AreEqual(2, actualDiscoveryCriteria.Sources.Count(), "All Sources must be used for discovery request");
            Assert.AreEqual("a", actualDiscoveryCriteria.Sources.First(), "First Source in list is incorrect");
            Assert.AreEqual("b", actualDiscoveryCriteria.Sources.ElementAt(1), "Second Source in list is incorrect");

            // Default frequency is set to 10, unless specified in runsettings.
            Assert.AreEqual(10, actualDiscoveryCriteria.FrequencyOfDiscoveredTestsEvent);

            mockDiscoveryRegistrar.Verify(md => md.RegisterDiscoveryEvents(It.IsAny<IDiscoveryRequest>()), Times.Once);
            mockDiscoveryRegistrar.Verify(md => md.UnregisterDiscoveryEvents(It.IsAny<IDiscoveryRequest>()), Times.Once);

            mockDiscoveryRequest.Verify(md => md.DiscoverAsync(), Times.Once);

            mockTestPlatformEventSource.Verify(mt => mt.DiscoveryRequestStart(), Times.Once);
            mockTestPlatformEventSource.Verify(mt => mt.DiscoveryRequestStop(), Times.Once);
        }

        [TestMethod]
        [Ignore]
        public void CancelTestRunShouldWaitForCreateTestRunRequest()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            TestRunCriteria observedCriteria = null;

            var sw = new Stopwatch();
            sw.Start();

            long createRunRequestTime = 0;
            long cancelRequestTime = 0;

            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
               (TestRunCriteria runCriteria, ProtocolConfig config) =>
               {
                    Thread.Sleep(1);
                    createRunRequestTime = sw.ElapsedMilliseconds;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            mockRunRequest.Setup(mr => mr.CancelAsync()).Callback(() =>
            {
                Thread.Sleep(1);
                cancelRequestTime = sw.ElapsedMilliseconds;
            });

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            var cancelTask = Task.Run(() => this.testRequestManager.CancelTestRun());
            var runTask = Task.Run(() => this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>()));

            Task.WaitAll(cancelTask, runTask);

            Assert.IsTrue(cancelRequestTime > createRunRequestTime, "CancelRequest must execute after create run request");
        }

        [TestMethod]
        [Ignore]
        public void AbortTestRunShouldWaitForCreateTestRunRequest()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            TestRunCriteria observedCriteria = null;

            var sw = new Stopwatch();
            sw.Start();

            long createRunRequestTime = 0;
            long cancelRequestTime = 0;

            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    Thread.Sleep(1);
                    createRunRequestTime = sw.ElapsedMilliseconds;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            mockRunRequest.Setup(mr => mr.Abort()).Callback(() =>
            {
                Thread.Sleep(1);
                cancelRequestTime = sw.ElapsedMilliseconds;
            });

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            var cancelTask = Task.Run(() => this.testRequestManager.AbortTestRun());
            var runTask = Task.Run(() => this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>()));

            Task.WaitAll(cancelTask, runTask);

            Assert.IsTrue(cancelRequestTime > createRunRequestTime, "CancelRequest must execute after create run request");
        }

        [TestMethod]
        public void RunTestsShouldReadTheBatchSizeFromSettingsAndSetItForTestRunCriteria()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a" },
                RunSettings =
                 @"<?xml version=""1.0"" encoding=""utf-8""?>
                <RunSettings>
                     <RunConfiguration>
                       <BatchSize>15</BatchSize>
                     </RunConfiguration>
                </RunSettings>"
            };

            TestRunCriteria actualTestRunCriteria = null;
            var mockDiscoveryRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    actualTestRunCriteria = runCriteria;
                }).Returns(mockDiscoveryRequest.Object);

            var success = this.testRequestManager.RunTests(payload, new Mock<ITestHostLauncher>().Object, new Mock<ITestRunEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());
            Assert.AreEqual(15, actualTestRunCriteria.FrequencyOfRunStatsChangeEvent);
        }

        [TestMethod]
        public void RunTestsWithSourcesShouldCallTestPlatformAndSucceed()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            var createRunRequestCalled = 0;
            TestRunCriteria observedCriteria = null;
            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    createRunRequestCalled++;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            string testCaseFilterValue = "TestFilter";
            CommandLineOptions.Instance.TestCaseFilterValue = testCaseFilterValue;
            this.testRequestManager = new TestRequestManager(CommandLineOptions.Instance,
                this.mockTestPlatform.Object,
                TestLoggerManager.Instance,
                TestRunResultAggregator.Instance,
                this.mockTestPlatformEventSource.Object);

            var success = this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>());

            Assert.IsTrue(success, "RunTests call must succeed");

            Assert.AreEqual(testCaseFilterValue, observedCriteria.TestCaseFilter, "TestCaseFilter must be set");

            Assert.AreEqual(createRunRequestCalled, 1, "CreateRunRequest must be invoked only once.");
            Assert.AreEqual(2, observedCriteria.Sources.Count(), "All Sources must be used for discovery request");
            Assert.AreEqual("a", observedCriteria.Sources.First(), "First Source in list is incorrect");
            Assert.AreEqual("b", observedCriteria.Sources.ElementAt(1), "Second Source in list is incorrect");

            // Check for the default value for the frequency
            Assert.AreEqual(10, observedCriteria.FrequencyOfRunStatsChangeEvent);
            mockRunEventsRegistrar.Verify(md => md.RegisterTestRunEvents(It.IsAny<ITestRunRequest>()), Times.Once);
            mockRunEventsRegistrar.Verify(md => md.UnregisterTestRunEvents(It.IsAny<ITestRunRequest>()), Times.Once);

            mockRunRequest.Verify(md => md.ExecuteAsync(), Times.Once);

            mockTestPlatformEventSource.Verify(mt => mt.ExecutionRequestStart(), Times.Once);
            mockTestPlatformEventSource.Verify(mt => mt.ExecutionRequestStop(), Times.Once);
        }

        [TestMethod]
        public void RunTestsMultipleCallsShouldNotRunInParallel()
        {
            var payload1 = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a" }
            };

            var payload2 = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "b" }
            };

            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>()))
                .Returns(mockRunRequest.Object);

            var mockRunEventsRegistrar1 = new Mock<ITestRunEventsRegistrar>();
            var mockRunEventsRegistrar2 = new Mock<ITestRunEventsRegistrar>();

            // Setup the second one to wait
            var sw = new Stopwatch();
            sw.Start();

            long run1Start = 0;
            long run1Stop = 0;
            long run2Start = 0;
            long run2Stop = 0;
            mockRunEventsRegistrar1.Setup(md => md.RegisterTestRunEvents(It.IsAny<ITestRunRequest>())).Callback(() =>
            {
                Thread.Sleep(10);
                run1Start = sw.ElapsedMilliseconds;
                Thread.Sleep(1);
            });
            mockRunEventsRegistrar1.Setup(md => md.UnregisterTestRunEvents(It.IsAny<ITestRunRequest>())).Callback(() =>
            {
                Thread.Sleep(10);
                run1Stop = sw.ElapsedMilliseconds;
                Thread.Sleep(10);
            });

            mockRunEventsRegistrar2.Setup(md => md.RegisterTestRunEvents(It.IsAny<ITestRunRequest>())).Callback(() =>
            {
                Thread.Sleep(10);
                run2Start = sw.ElapsedMilliseconds;
                Thread.Sleep(10);
            });
            mockRunEventsRegistrar2.Setup(md => md.UnregisterTestRunEvents(It.IsAny<ITestRunRequest>())).Callback(() =>
            {
                Thread.Sleep(10);
                run2Stop = sw.ElapsedMilliseconds;
            });

            var mockCustomlauncher = new Mock<ITestHostLauncher>();
            var task1 = Task.Run(() =>
            {
                this.testRequestManager.RunTests(payload1, mockCustomlauncher.Object, mockRunEventsRegistrar1.Object, It.IsAny<ProtocolConfig>());
            });
            var task2 = Task.Run(() =>
            {
                this.testRequestManager.RunTests(payload2, mockCustomlauncher.Object, mockRunEventsRegistrar2.Object, It.IsAny<ProtocolConfig>());
            });

            Task.WaitAll(task1, task2);

            if (run1Start < run2Start)
            {
                Assert.IsTrue((run2Stop > run2Start)
                    && (run2Start > run1Stop)
                    && (run1Stop > run1Start));
            }
            else
            {
                Assert.IsTrue((run1Stop > run1Start)
                    && (run1Start > run2Stop)
                    && (run2Stop > run2Start));
            }
        }

        [TestMethod]
        public void RunTestsIfThrowsTestPlatformExceptionShouldNotThrowOut()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            var createRunRequestCalled = 0;
            TestRunCriteria observedCriteria = null;
            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    createRunRequestCalled++;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            mockRunRequest.Setup(mr => mr.ExecuteAsync()).Throws(new TestPlatformException("HelloWorld"));

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            var success = this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>());

            Assert.IsFalse(success, "RunTests call must fail due to exception");
        }

        [TestMethod]
        public void RunTestsIfThrowsSettingsExceptionShouldNotThrowOut()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            var createRunRequestCalled = 0;
            TestRunCriteria observedCriteria = null;
            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    createRunRequestCalled++;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            mockRunRequest.Setup(mr => mr.ExecuteAsync()).Throws(new SettingsException("HelloWorld"));

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            var success = this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>());

            Assert.IsFalse(success, "RunTests call must fail due to exception");
        }

        [TestMethod]
        public void RunTestsIfThrowsInvalidOperationExceptionShouldNotThrowOut()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            var createRunRequestCalled = 0;
            TestRunCriteria observedCriteria = null;
            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    createRunRequestCalled++;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            mockRunRequest.Setup(mr => mr.ExecuteAsync()).Throws(new InvalidOperationException("HelloWorld"));

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            var success = this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>());

            Assert.IsFalse(success, "RunTests call must fail due to exception");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void RunTestsIfThrowsExceptionShouldThrowOut()
        {
            var payload = new TestRunRequestPayload()
            {
                Sources = new List<string>() { "a", "b" }
            };

            var createRunRequestCalled = 0;
            TestRunCriteria observedCriteria = null;
            var mockRunRequest = new Mock<ITestRunRequest>();
            this.mockTestPlatform.Setup(mt => mt.CreateTestRunRequest(It.IsAny<TestRunCriteria>(), It.IsAny<ProtocolConfig>())).Callback(
                (TestRunCriteria runCriteria, ProtocolConfig config) =>
                {
                    createRunRequestCalled++;
                    observedCriteria = runCriteria;
                }).Returns(mockRunRequest.Object);

            mockRunRequest.Setup(mr => mr.ExecuteAsync()).Throws(new NotImplementedException("HelloWorld"));

            var mockRunEventsRegistrar = new Mock<ITestRunEventsRegistrar>();
            var mockCustomlauncher = new Mock<ITestHostLauncher>();

            this.testRequestManager.RunTests(payload, mockCustomlauncher.Object, mockRunEventsRegistrar.Object, It.IsAny<ProtocolConfig>());
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void DiscoverTestsShouldUpdateDesignMode(bool designModeValue)
        {
            var runsettings = "<RunSettings><RunConfiguration><TargetFrameworkVersion>.NETFramework,Version=v4.5</TargetFrameworkVersion></RunConfiguration></RunSettings>";
            var discoveryPayload = CreateDiscoveryPayload(runsettings);
            this.commandLineOptions.IsDesignMode = designModeValue;

            this.testRequestManager.DiscoverTests(discoveryPayload, new Mock<ITestDiscoveryEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());

            var designmode = $"<DesignMode>{designModeValue}</DesignMode>";
            this.mockTestPlatform.Verify(
                tp => tp.CreateDiscoveryRequest(It.Is<DiscoveryCriteria>(dc => dc.RunSettings.Contains(designmode)), It.IsAny<ProtocolConfig>()));
        }

        [TestMethod]
        public void DiscoverTestsShouldNotUpdateDesignModeIfUserHasSetDesignModeInRunSettings()
        {
            var runsettings = "<RunSettings><RunConfiguration><DesignMode>False</DesignMode><TargetFrameworkVersion>.NETFramework,Version=v4.5</TargetFrameworkVersion></RunConfiguration></RunSettings>";
            var discoveryPayload = CreateDiscoveryPayload(runsettings);
            this.commandLineOptions.IsDesignMode = true;

            this.testRequestManager.DiscoverTests(discoveryPayload, new Mock<ITestDiscoveryEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());

            var designmode = "<DesignMode>False</DesignMode>";
            this.mockTestPlatform.Verify(
                tp => tp.CreateDiscoveryRequest(It.Is<DiscoveryCriteria>(dc => dc.RunSettings.Contains(designmode)), It.IsAny<ProtocolConfig>()));
        }

        [TestMethod]
        public void DiscoverTestsShouldNotUpdateDesignModeIfTargetFrameworkIsNotSetInRunSettings()
        {
            var runsettings = "<RunSettings><RunConfiguration></RunConfiguration></RunSettings>";
            var discoveryPayload = CreateDiscoveryPayload(runsettings);

            this.testRequestManager.DiscoverTests(discoveryPayload, new Mock<ITestDiscoveryEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());

            var designmode = "DesignMode";
            this.mockTestPlatform.Verify(
                tp => tp.CreateDiscoveryRequest(It.Is<DiscoveryCriteria>(dc => !dc.RunSettings.Contains(designmode)), It.IsAny<ProtocolConfig>()));
        }

        [TestMethod]
        public void DiscoverTestsShouldNotUpdateDesignModeIfTargetFrameworkIsSetToNetCoreInRunSettings()
        {
            var runsettings = "<RunSettings><RunConfiguration><TargetFrameworkVersion>.NETCoreApp,Version=v1.0</TargetFrameworkVersion></RunConfiguration></RunSettings>";
            var discoveryPayload = CreateDiscoveryPayload(runsettings);

            this.testRequestManager.DiscoverTests(discoveryPayload, new Mock<ITestDiscoveryEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());

            var designmode = "DesignMode";
            this.mockTestPlatform.Verify(
                tp => tp.CreateDiscoveryRequest(It.Is<DiscoveryCriteria>(dc => !dc.RunSettings.Contains(designmode)), It.IsAny<ProtocolConfig>()));
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void RunTestsShouldUpdateDesignModeIfRunnerIsInDesignMode(bool designModeValue)
        {
            var runsettings =
                "<RunSettings><RunConfiguration><TargetFrameworkVersion>.NETFramework,Version=v4.5</TargetFrameworkVersion></RunConfiguration></RunSettings>";
            var payload = new TestRunRequestPayload
            {
                RunSettings = runsettings,
                Sources = new List<string> {"c:\\testproject.dll"}
            };
            this.commandLineOptions.IsDesignMode = designModeValue;

            this.testRequestManager.RunTests(payload, new Mock<ITestHostLauncher>().Object, new Mock<ITestRunEventsRegistrar>().Object, It.IsAny<ProtocolConfig>());

            var designmode = $"<DesignMode>{designModeValue}</DesignMode>";
            this.mockTestPlatform.Verify(tp => tp.CreateTestRunRequest(It.Is<TestRunCriteria>(rc => rc.TestRunSettings.Contains(designmode)), It.IsAny<ProtocolConfig>()));
        }

        private static DiscoveryRequestPayload CreateDiscoveryPayload(string runsettings)
        {
            var discoveryPayload = new DiscoveryRequestPayload
            {
                RunSettings = runsettings,
                Sources = new[] {"c:\\testproject.dll"}
            };
            return discoveryPayload;
        }
    }
}