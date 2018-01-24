// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CommunicationUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.EventHandlers;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.TesthostProtocol;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
    using Microsoft.VisualStudio.TestPlatform.Utilities;
    using CrossPlatResources = Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Resources.Resources;

    /// <summary>
    /// Utility class to fecilitate the IPC comunication. Acts as Client.
    /// </summary>
    public class TestRequestHandler : IDisposable, ITestRequestHandler
    {
        private ICommunicationManager communicationManager;

        private IDataSerializer dataSerializer;

        private Action<Message> onAckMessageRecieved;

        private int highestSupportedVersion = 2;

        // Set default to 1, if protocol version check does not happen
        // that implies runner is using version 1
        private int protocolVersion = 1;

        /// <summary>
        /// The timeout for the client to connect to the server.
        /// </summary>
        private const int LaunchProcessWithDebuggerTimeout = 5 * 1000;

        public TestRequestHandler()
            : this(new SocketCommunicationManager(), JsonDataSerializer.Instance)
        {
        }

        internal TestRequestHandler(ICommunicationManager communicationManager, IDataSerializer dataSerializer)
        {
            this.communicationManager = communicationManager;
            this.dataSerializer = dataSerializer;
        }

        /// <summary>
        /// Setups client based on port
        /// </summary>
        /// <param name="port">port number to connect</param>
        public void InitializeCommunication(int port)
        {
            this.communicationManager.SetupClientAsync(port);
        }

        public bool WaitForRequestSenderConnection(int connectionTimeout)
        {
            return this.communicationManager.WaitForServerConnection(connectionTimeout);
        }

        /// <summary>
        /// Listens to the commands from server
        /// </summary>
        /// <param name="testHostManagerFactory">the test host manager.</param>
        public void ProcessRequests(ITestHostManagerFactory testHostManagerFactory)
        {
            bool isSessionEnd = false;

            var jobQueue = new JobQueue<Action>(
                (action) => { action(); },
                "TestHostOperationQueue",
                500,
                25000000,
                true,
                (message) => EqtTrace.Error(message));

            do
            {
                var message = this.communicationManager.ReceiveMessage();

                switch (message.MessageType)
                {
                    case MessageType.VersionCheck:
                        var version = this.dataSerializer.DeserializePayload<int>(message);
                        this.protocolVersion = Math.Min(version, highestSupportedVersion);
                        this.communicationManager.SendMessage(MessageType.VersionCheck, this.protocolVersion);

                        // Can only do this after InitializeCommunication because TestHost cannot "Send Log" unless communications are initialized
                        if (!string.IsNullOrEmpty(EqtTrace.LogFile))
                        {
                            this.SendLog(TestMessageLevel.Informational, string.Format(CrossPlatResources.TesthostDiagLogOutputFile, EqtTrace.LogFile));
                        }
                        else if(!string.IsNullOrEmpty(EqtTrace.ErrorOnInitialization))
                        {
                            this.SendLog(TestMessageLevel.Warning, EqtTrace.ErrorOnInitialization);
                        }
                        break;

                    case MessageType.DiscoveryInitialize:
                        {
                            EqtTrace.Info("Discovery Session Initialize.");
                            var pathToAdditionalExtensions = message.Payload.ToObject<IEnumerable<string>>();
                            jobQueue.QueueJob(
                                () =>
                                testHostManagerFactory.GetDiscoveryManager().Initialize(pathToAdditionalExtensions), 0);
                            break;
                        }

                    case MessageType.StartDiscovery:
                        {
                            EqtTrace.Info("Discovery started.");

                            var discoveryEventsHandler = new TestDiscoveryEventHandler(this);
                            var discoveryCriteria = message.Payload.ToObject<DiscoveryCriteria>();
                            jobQueue.QueueJob(
                                () =>
                                testHostManagerFactory.GetDiscoveryManager()
                                    .DiscoverTests(discoveryCriteria, discoveryEventsHandler), 0);

                            break;
                        }

                    case MessageType.ExecutionInitialize:
                        {
                            EqtTrace.Info("Discovery Session Initialize.");
                            var pathToAdditionalExtensions = message.Payload.ToObject<IEnumerable<string>>();
                            jobQueue.QueueJob(
                                () =>
                                testHostManagerFactory.GetExecutionManager().Initialize(pathToAdditionalExtensions), 0);
                            break;
                        }

                    case MessageType.StartTestExecutionWithSources:
                        {
                            EqtTrace.Info("Execution started.");
                            var testRunEventsHandler = new TestRunEventsHandler(this);

                            var testRunCriteriaWithSources = message.Payload.ToObject<TestRunCriteriaWithSources>();
                            jobQueue.QueueJob(
                                () =>
                                testHostManagerFactory.GetExecutionManager()
                                    .StartTestRun(
                                        testRunCriteriaWithSources.AdapterSourceMap,
                                        testRunCriteriaWithSources.RunSettings,
                                        testRunCriteriaWithSources.TestExecutionContext,
                                        this.GetTestCaseEventsHandler(testRunCriteriaWithSources.RunSettings),
                                        testRunEventsHandler),
                                0);

                            break;
                        }

                    case MessageType.StartTestExecutionWithTests:
                        {
                            EqtTrace.Info("Execution started.");
                            var testRunEventsHandler = new TestRunEventsHandler(this);

                            var testRunCriteriaWithTests =
                                this.communicationManager.DeserializePayload<TestRunCriteriaWithTests>(message);

                            jobQueue.QueueJob(
                                () =>
                                testHostManagerFactory.GetExecutionManager()
                                    .StartTestRun(
                                        testRunCriteriaWithTests.Tests,
                                        testRunCriteriaWithTests.RunSettings,
                                        testRunCriteriaWithTests.TestExecutionContext, 
                                        this.GetTestCaseEventsHandler(testRunCriteriaWithTests.RunSettings),
                                        testRunEventsHandler),
                                0);

                            break;
                        }

                    case MessageType.CancelTestRun:
                        jobQueue.Pause();
                        testHostManagerFactory.GetExecutionManager().Cancel();
                        break;

                    case MessageType.LaunchAdapterProcessWithDebuggerAttachedCallback:
                        this.onAckMessageRecieved?.Invoke(message);
                        break;

                    case MessageType.AbortTestRun:
                        jobQueue.Pause();
                        testHostManagerFactory.GetExecutionManager().Abort();
                        break;

                    case MessageType.SessionEnd:
                        {
                            EqtTrace.Info("Session End message received from server. Closing the connection.");
                            isSessionEnd = true;
                            this.Close();
                            break;
                        }

                    case MessageType.SessionAbort:
                        {
                            // Dont do anything for now.
                            break;
                        }

                    default:
                        {
                            EqtTrace.Info("Invalid Message types");
                            break;
                        }
                }
            }
            while (!isSessionEnd);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.communicationManager?.StopClient();
        }

        /// <inheritdoc/>
        public void Close()
        {
            this.Dispose();
            EqtTrace.Info("Closing the connection !");
        }

        /// <inheritdoc/>
        public void SendTestCases(IEnumerable<TestCase> discoveredTestCases)
        {
            this.communicationManager.SendMessage(MessageType.TestCasesFound, discoveredTestCases, this.protocolVersion);
        }

        /// <inheritdoc/>
        public void SendTestRunStatistics(TestRunChangedEventArgs testRunChangedArgs)
        {
            this.communicationManager.SendMessage(MessageType.TestRunStatsChange, testRunChangedArgs, this.protocolVersion);
        }

        /// <inheritdoc/>
        public void SendLog(TestMessageLevel messageLevel, string message)
        {
            var testMessagePayload = new TestMessagePayload {MessageLevel = messageLevel,Message = message};
            this.communicationManager.SendMessage(MessageType.TestMessage, testMessagePayload, this.protocolVersion);
        }

        /// <inheritdoc/>
        public void SendExecutionComplete(
            TestRunCompleteEventArgs testRunCompleteArgs,
            TestRunChangedEventArgs lastChunkArgs,
            ICollection<AttachmentSet> runContextAttachments,
            ICollection<string> executorUris)
        {
            var payload = new TestRunCompletePayload
            {
                TestRunCompleteArgs = testRunCompleteArgs,
                LastRunTests = lastChunkArgs,
                RunAttachments = runContextAttachments,
                ExecutorUris = executorUris
            };

            this.communicationManager.SendMessage(MessageType.ExecutionComplete, payload, this.protocolVersion);
        }

        /// <inheritdoc/>
        public void DiscoveryComplete(long totalTests, IEnumerable<TestCase> lastChunk, bool isAborted)
        {
            var discoveryCompletePayload = new DiscoveryCompletePayload
            {
                TotalTests = totalTests,
                LastDiscoveredTests = isAborted ? null : lastChunk,
                IsAborted = isAborted
            };

            this.communicationManager.SendMessage(MessageType.DiscoveryComplete, discoveryCompletePayload, this.protocolVersion);
        }

        /// <inheritdoc/>
        public int LaunchProcessWithDebuggerAttached(TestProcessStartInfo testProcessStartInfo)
        {
            var waitHandle = new AutoResetEvent(false);
            Message ackMessage = null;
            this.onAckMessageRecieved = (ackRawMessage) =>
            {
                ackMessage = ackRawMessage;
                waitHandle.Set();
            };

            this.communicationManager.SendMessage(MessageType.LaunchAdapterProcessWithDebuggerAttached, testProcessStartInfo, this.protocolVersion);

            waitHandle.WaitOne();
            this.onAckMessageRecieved = null;
            return this.dataSerializer.DeserializePayload<int>(ackMessage);
        }

        private ITestCaseEventsHandler GetTestCaseEventsHandler(string runSettings)
        {
            ITestCaseEventsHandler testCaseEventsHandler = null;

            if ((XmlRunSettingsUtilities.IsDataCollectionEnabled(runSettings) && DataCollectionTestCaseEventSender.Instance != null) || XmlRunSettingsUtilities.IsInProcDataCollectionEnabled(runSettings))
            {
                testCaseEventsHandler = new TestCaseEventsHandler();
                var testEventsPublisher = testCaseEventsHandler as ITestEventsPublisher;
            }

            return testCaseEventsHandler;
        }
    }
}