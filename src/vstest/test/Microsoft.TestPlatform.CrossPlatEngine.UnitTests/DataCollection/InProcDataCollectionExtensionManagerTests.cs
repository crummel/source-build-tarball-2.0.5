﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TestPlatform.CrossPlatEngine.UnitTests.DataCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Execution;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Constants = Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection.Constants;
    using TestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;

    [TestClass]
    public class InProcDataCollectionExtensionManagerTests
    {
        private string settingsXml = @"<RunSettings>
                                    <InProcDataCollectionRunSettings>
                                        <InProcDataCollectors>
                                            <InProcDataCollector friendlyName='Test Impact' uri='InProcDataCollector://Microsoft/TestImpact/1.0' assemblyQualifiedName='TestImpactListener.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a'  codebase='E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests.dll'>
                                                <Configuration>
                                                    <Port>4312</Port>
                                                </Configuration>
                                            </InProcDataCollector>
                                        </InProcDataCollectors>
                                    </InProcDataCollectionRunSettings>
                                </RunSettings>";
        private Mock<ITestEventsPublisher> mockTestEventsPublisher;
        private TestableInProcDataCollectionExtensionManager inProcDataCollectionManager;

        public InProcDataCollectionExtensionManagerTests()
        {
            this.mockTestEventsPublisher = new Mock<ITestEventsPublisher>();
            this.inProcDataCollectionManager = new TestableInProcDataCollectionExtensionManager(this.settingsXml, this.mockTestEventsPublisher.Object);
        }

        [TestMethod]
        public void InProcDataCollectionExtensionManagerShouldLoadsDataCollectorsFromRunSettings()
        {
            var dataCollectorSettings = (inProcDataCollectionManager.InProcDataCollectors.First().Value as MockDataCollector).DataCollectorSettings;

            Assert.IsTrue(inProcDataCollectionManager.IsInProcDataCollectionEnabled, "InProcDataCollection must be enabled if runsettings contains inproc datacollectors.");
            Assert.AreEqual(inProcDataCollectionManager.InProcDataCollectors.Count, 1, "One Datacollector must be registered");

            Assert.IsTrue(string.Equals(dataCollectorSettings.AssemblyQualifiedName, "TestImpactListener.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(dataCollectorSettings.CodeBase, @"E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests.dll", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(dataCollectorSettings.Configuration.OuterXml.ToString(), @"<Configuration><Port>4312</Port></Configuration>", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void InProcDataCollectorIsReadingMultipleDataCollector()
        {
            var multiSettingsXml = @"<RunSettings>
                                    <InProcDataCollectionRunSettings>
                                        <InProcDataCollectors>
                                            <InProcDataCollector friendlyName='Test Impact' uri='InProcDataCollector://Microsoft/TestImpact/1.0' assemblyQualifiedName='TestImpactListener.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a'  codebase='E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests1.dll'>
                                                <Configuration>
                                                    <Port>4312</Port>
                                                </Configuration>
                                            </InProcDataCollector>
                                            <InProcDataCollector friendlyName='InProcDataCol' uri='InProcDataCollector://Microsoft/InProcDataCol/2.0' assemblyQualifiedName='TestImpactListener.Tests, Version=2.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a'  codebase='E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests2.dll'>
                                                <Configuration>
                                                    <Port>4313</Port>
                                                </Configuration>
                                            </InProcDataCollector>
                                        </InProcDataCollectors>
                                    </InProcDataCollectionRunSettings>
                                </RunSettings>";

            this.inProcDataCollectionManager = new TestableInProcDataCollectionExtensionManager(multiSettingsXml, this.mockTestEventsPublisher.Object);
            bool secondOne = false;
            DataCollectorSettings dataCollectorSettings1 = null;
            DataCollectorSettings dataCollectorSettings2 = null;

            foreach (var inProcDC in inProcDataCollectionManager.InProcDataCollectors.Values)
            {
                if (secondOne)
                {
                    dataCollectorSettings2 = (inProcDC as MockDataCollector).DataCollectorSettings;
                }
                else
                {
                    dataCollectorSettings1 = (inProcDC as MockDataCollector).DataCollectorSettings;
                    secondOne = true;
                }
            }

            Assert.IsTrue(string.Equals(dataCollectorSettings1.AssemblyQualifiedName, "TestImpactListener.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(dataCollectorSettings1.CodeBase, @"E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests1.dll", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(dataCollectorSettings1.Configuration.OuterXml.ToString(), @"<Configuration><Port>4312</Port></Configuration>", StringComparison.OrdinalIgnoreCase));

            Assert.IsTrue(string.Equals(dataCollectorSettings2.AssemblyQualifiedName, "TestImpactListener.Tests, Version=2.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(dataCollectorSettings2.CodeBase, @"E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests2.dll", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(string.Equals(dataCollectorSettings2.Configuration.OuterXml.ToString(), @"<Configuration><Port>4313</Port></Configuration>", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void InProcDataCollectionExtensionManagerWillNotEnableDataCollectionForInavlidSettingsXml()
        {
            var invalidSettingsXml = @"<RunSettings>
                                    <InProcDataCollectionRunSettings>
                                        <InProcDataCollectors>
                                            <InProcDataCollector friendlyName='Test Impact' uri='InProcDataCollector://Microsoft/TestImpact/1.0' assemblyQualifiedName='TestImpactListener.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7ccb7239ffde675a'  codebase='E:\repos\MSTest\src\managed\TestPlatform\TestImpactListener.Tests\bin\Debug\TestImpactListener.Tests.dll' value='Invalid'>
                                                <Configuration>
                                                    <Port>4312</Port>
                                                </Configuration>
                                            </InProcDataCollector>
                                        </InProcDataCollectors>
                                    </InProcDataCollectionRunSettings>
                                </RunSettings>";

            var manager = new InProcDataCollectionExtensionManager(invalidSettingsXml, this.mockTestEventsPublisher.Object);
            Assert.IsFalse(manager.IsInProcDataCollectionEnabled, "InProcDataCollection must be disabled on invalid settings.");
        }

        [TestMethod]
        public void TriggerSessionStartShouldCallInProcDataCollector()
        {
            this.mockTestEventsPublisher.Raise(x => x.SessionStart += null, new SessionStartEventArgs());

            var mockDataCollector = inProcDataCollectionManager.InProcDataCollectors.Values.FirstOrDefault() as MockDataCollector;
            Assert.IsTrue((mockDataCollector.TestSessionStartCalled == 1), "TestSessionStart must be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestSessionEndCalled == 0), "TestSessionEnd must NOT be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestCaseStartCalled == 0), "TestCaseStart must NOT be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestCaseEndCalled == 0), "TestCaseEnd must NOT be called on datacollector");
        }

        [TestMethod]
        public void TriggerSessionEndShouldCallInProcDataCollector()
        {
            this.mockTestEventsPublisher.Raise(x => x.SessionEnd += null, new SessionEndEventArgs());

            var mockDataCollector = inProcDataCollectionManager.InProcDataCollectors.Values.FirstOrDefault() as MockDataCollector;
            Assert.IsTrue((mockDataCollector.TestSessionStartCalled == 0), "TestSessionEnd must NOT be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestSessionEndCalled == 1), "TestSessionStart must be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestCaseStartCalled == 0), "TestCaseStart must NOT be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestCaseEndCalled == 0), "TestCaseEnd must NOT be called on datacollector");
        }

        [TestMethod]
        public void TriggerTestCaseStartShouldCallInProcDataCollector()
        {
            var testCase = new TestCase("x.y.z", new Uri("uri://dummy"), "x.dll");
            // random guid
            testCase.Id = new Guid("3871B3B0-2853-406B-BB61-1FE1764116FD");
            this.mockTestEventsPublisher.Raise(x => x.TestCaseStart += null, new TestCaseStartEventArgs(testCase));

            var mockDataCollector = inProcDataCollectionManager.InProcDataCollectors.Values.FirstOrDefault() as MockDataCollector;

            Assert.IsTrue((mockDataCollector.TestCaseStartCalled == 1), "TestCaseStart must be called on datacollector");
            Assert.IsTrue((mockDataCollector.TestCaseEndCalled == 0), "TestCaseEnd must NOT be called on datacollector");
        }

        [TestMethod]
        public void TriggerTestCaseEndShouldtBeCalledMultipleTimesInDataDrivenScenario()
        {
            var testCase = new TestCase("x.y.z", new Uri("uri://dummy"), "x.dll");
            // random guid
            testCase.Id = new Guid("3871B3B0-2853-406B-BB61-1FE1764116FD");
            this.mockTestEventsPublisher.Raise(x => x.TestCaseStart += null, new TestCaseStartEventArgs(testCase));
            this.mockTestEventsPublisher.Raise(x => x.TestCaseEnd += null, new TestCaseEndEventArgs(testCase, TestOutcome.Passed));
            this.mockTestEventsPublisher.Raise(x => x.TestCaseStart += null, new TestCaseStartEventArgs(testCase));
            this.mockTestEventsPublisher.Raise(x => x.TestCaseEnd += null, new TestCaseEndEventArgs(testCase, TestOutcome.Failed));

            var mockDataCollector = inProcDataCollectionManager.InProcDataCollectors.Values.FirstOrDefault() as MockDataCollector;
            Assert.IsTrue((mockDataCollector.TestCaseStartCalled == 2), "TestCaseStart must only be called once");
            Assert.IsTrue((mockDataCollector.TestCaseEndCalled == 2), "TestCaseEnd must only be called once");
        }

        internal class TestableInProcDataCollectionExtensionManager : InProcDataCollectionExtensionManager
        {
            public TestableInProcDataCollectionExtensionManager(string runSettings, ITestEventsPublisher mockTestEventsPublisher) : base(runSettings, mockTestEventsPublisher)
            {
            }

            protected override IInProcDataCollector CreateDataCollector(DataCollectorSettings dataCollectorSettings, TypeInfo interfaceTypeInfo)
            {
                return new MockDataCollector(dataCollectorSettings);
            }
        }

        public class MockDataCollector : IInProcDataCollector
        {
            public MockDataCollector(DataCollectorSettings dataCollectorSettings)
            {
                this.DataCollectorSettings = dataCollectorSettings;
            }

            public string AssemblyQualifiedName => this.DataCollectorSettings.AssemblyQualifiedName;

            public DataCollectorSettings DataCollectorSettings
            {
                get;
                private set;
            }

            public int TestSessionStartCalled { get; private set; }
            public int TestSessionEndCalled { get; private set; }
            public int TestCaseStartCalled { get; private set; }
            public int TestCaseEndCalled { get; private set; }

            public void LoadDataCollector(IDataCollectionSink inProcDataCollectionSink)
            {
                // Do Nothing
            }

            public void TriggerInProcDataCollectionMethod(string methodName, InProcDataCollectionArgs methodArg)
            {
                switch (methodName)
                {
                    case Constants.TestSessionStartMethodName: TestSessionStartCalled++; break;
                    case Constants.TestSessionEndMethodName: TestSessionEndCalled++; break;
                    case Constants.TestCaseStartMethodName: TestCaseStartCalled++; break;
                    case Constants.TestCaseEndMethodName: TestCaseEndCalled++; break;
                    default: break;
                }
            }
        }
    }
}
