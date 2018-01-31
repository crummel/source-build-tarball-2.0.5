// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CommunicationUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
    using CommonResources = Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources.Resources;

    /// <summary>
    /// Test request sender implementation.
    /// </summary>
    public class TestRequestSender2 : ITestRequestSender
    {
        // Time to wait for test host exit (in seconds)
        private const int CLIENTPROCESSEXITWAIT = 10 * 1000;

        private readonly ICommunicationServer communicationServer;

        private readonly IDataSerializer dataSerializer;

        private readonly ManualResetEventSlim connected;

        private readonly ManualResetEventSlim clientExited;

        private readonly int clientExitedWaitTime;

        private ICommunicationChannel channel;

        private EventHandler<MessageReceivedEventArgs> onMessageReceived;

        private Action<DisconnectedEventArgs> onDisconnected;

        // Set to 1 if Discovery/Execution is complete, i.e. complete handlers have been invoked
        private int operationCompleted;

        private ITestMessageEventHandler messageEventHandler;

        private string clientExitErrorMessage;

        // Set default to 1, if protocol version check does not happen
        // that implies host is using version 1
        private int protocolVersion = 1;

        private int highestSupportedVersion = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRequestSender2"/> class.
        /// </summary>
        /// <param name="protocolConfig">Protocol configuration.</param>
        public TestRequestSender2(ProtocolConfig protocolConfig)
            : this(new SocketServer(), JsonDataSerializer.Instance, protocolConfig, CLIENTPROCESSEXITWAIT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRequestSender2"/> class.
        /// </summary>
        /// <param name="server">Communication server implementation.</param>
        /// <param name="serializer">Serializer implementation.</param>
        /// <param name="protocolConfig">Protocol configuration.</param>
        /// <param name="clientExitedWaitTime">Time to wait for client process exit.</param>
        protected TestRequestSender2(
                ICommunicationServer server,
                IDataSerializer serializer,
                ProtocolConfig protocolConfig,
                int clientExitedWaitTime)
        {
            this.communicationServer = server;
            this.dataSerializer = serializer;
            this.connected = new ManualResetEventSlim(false);
            this.clientExited = new ManualResetEventSlim(false);
            this.clientExitedWaitTime = clientExitedWaitTime;
            this.operationCompleted = 0;

            this.highestSupportedVersion = protocolConfig.Version;
        }

        /// <inheritdoc />
        public int InitializeCommunication()
        {
            this.communicationServer.ClientConnected += (sender, args) =>
                {
                    this.channel = args.Channel;
                    this.connected.Set();
                };
            this.communicationServer.ClientDisconnected += (sender, args) =>
                {
                    // If there's an disconnected event handler, call it
                    this.onDisconnected?.Invoke(args);
                };

            // Server start returns the listener port
            return int.Parse(this.communicationServer.Start());
        }

        /// <inheritdoc />
        public bool WaitForRequestHandlerConnection(int connectionTimeout)
        {
            return this.connected.Wait(connectionTimeout);
        }

        /// <inheritdoc />
        public void CheckVersionWithTestHost()
        {
            // Negotiation follows these steps:
            // Runner sends highest supported version to Test host
            // Test host sends the version it can support (must be less than highest) to runner
            // Error case: test host can send a protocol error if it cannot find a supported version
            var protocolNegotiated = new ManualResetEvent(false);
            this.onMessageReceived = (sender, args) =>
            {
                var message = this.dataSerializer.DeserializeMessage(args.Data);

                if (message.MessageType == MessageType.VersionCheck)
                {
                    this.protocolVersion = this.dataSerializer.DeserializePayload<int>(message);

                    EqtTrace.Info(@"TestRequestSender: VersionCheck Succeeded, NegotiatedVersion = {0}", this.protocolVersion);
                }
                else if (message.MessageType == MessageType.ProtocolError)
                {
                    throw new TestPlatformException(string.Format(CultureInfo.CurrentUICulture, CommonResources.VersionCheckFailed));
                }
                else
                {
                    throw new TestPlatformException(string.Format(
                        CultureInfo.CurrentUICulture,
                        CommonResources.UnexpectedMessage,
                        MessageType.VersionCheck,
                        message.MessageType));
                }

                protocolNegotiated.Set();
            };
            this.channel.MessageReceived += this.onMessageReceived;

            try
            {
                // Send the protocol negotiation request. Note that we always serialize this data
                // without any versioning in the message itself.
                var data = this.dataSerializer.SerializePayload(MessageType.VersionCheck, this.highestSupportedVersion);
                this.channel.Send(data);

                // Wait for negotiation response
                if (!protocolNegotiated.WaitOne(60 * 1000))
                {
                    throw new TestPlatformException(string.Format(CultureInfo.CurrentUICulture, CommonResources.VersionCheckTimedout));
                }
            }
            finally
            {
                this.channel.MessageReceived -= this.onMessageReceived;
                this.onMessageReceived = null;
            }
        }

        #region Discovery Protocol

        /// <inheritdoc />
        public void InitializeDiscovery(IEnumerable<string> pathToAdditionalExtensions)
        {
            var message = this.dataSerializer.SerializePayload(
                MessageType.DiscoveryInitialize,
                pathToAdditionalExtensions,
                this.protocolVersion);
            this.channel.Send(message);
        }

        /// <inheritdoc />
        public void DiscoverTests(DiscoveryCriteria discoveryCriteria, ITestDiscoveryEventsHandler2 discoveryEventsHandler)
        {
            this.messageEventHandler = discoveryEventsHandler;
            this.onDisconnected = (disconnectedEventArgs) =>
                {
                    this.OnDiscoveryAbort(discoveryEventsHandler, disconnectedEventArgs.Error, true);
                };
            this.onMessageReceived = (sender, args) =>
                {
                    try
                    {
                        var rawMessage = args.Data;

                        // Currently each of the operations are not separate tasks since they should not each take much time. This is just a notification.
                        if (EqtTrace.IsInfoEnabled)
                        {
                            EqtTrace.Info("TestRequestSender: Received message: {0}", rawMessage);
                        }

                        // Send raw message first to unblock handlers waiting to send message to IDEs
                        discoveryEventsHandler.HandleRawMessage(rawMessage);

                        var data = this.dataSerializer.DeserializeMessage(rawMessage);
                        switch (data.MessageType)
                        {
                            case MessageType.TestCasesFound:
                                var testCases = this.dataSerializer.DeserializePayload<IEnumerable<TestCase>>(data);
                                discoveryEventsHandler.HandleDiscoveredTests(testCases);
                                break;
                            case MessageType.DiscoveryComplete:
                                var discoveryCompletePayload =
                                    this.dataSerializer.DeserializePayload<DiscoveryCompletePayload>(data);

                                var discoveryCompleteEventsArgs = new DiscoveryCompleteEventArgs(discoveryCompletePayload.TotalTests, discoveryCompletePayload.IsAborted);
                                discoveryCompleteEventsArgs.Metrics = discoveryCompletePayload.Metrics;
                                discoveryEventsHandler.HandleDiscoveryComplete(
                                    discoveryCompleteEventsArgs,
                                    discoveryCompletePayload.LastDiscoveredTests);

                                this.SetOperationComplete();
                                break;
                            case MessageType.TestMessage:
                                var testMessagePayload = this.dataSerializer.DeserializePayload<TestMessagePayload>(
                                    data);
                                discoveryEventsHandler.HandleLogMessage(
                                    testMessagePayload.MessageLevel,
                                    testMessagePayload.Message);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.OnDiscoveryAbort(discoveryEventsHandler, ex, false);
                    }
                };

            this.channel.MessageReceived += this.onMessageReceived;
            var message = this.dataSerializer.SerializePayload(
                MessageType.StartDiscovery,
                discoveryCriteria,
                this.protocolVersion);
            this.channel.Send(message);
        }

        #endregion

        #region Execution Protocol

        /// <inheritdoc />
        public void InitializeExecution(IEnumerable<string> pathToAdditionalExtensions)
        {
            var message = this.dataSerializer.SerializePayload(
                MessageType.ExecutionInitialize,
                pathToAdditionalExtensions,
                this.protocolVersion);
            this.channel.Send(message);
        }

        /// <inheritdoc />
        public void StartTestRun(TestRunCriteriaWithSources runCriteria, ITestRunEventsHandler eventHandler)
        {
            this.messageEventHandler = eventHandler;
            this.onDisconnected = (disconnectedEventArgs) =>
                {
                    this.OnTestRunAbort(eventHandler, disconnectedEventArgs.Error, true);
                };
            this.onMessageReceived = (sender, args) => this.OnExecutionMessageReceived(sender, args, eventHandler);
            this.channel.MessageReceived += this.onMessageReceived;

            var message = this.dataSerializer.SerializePayload(
                MessageType.StartTestExecutionWithSources,
                runCriteria,
                this.protocolVersion);
            this.channel.Send(message);
        }

        /// <inheritdoc />
        public void StartTestRun(TestRunCriteriaWithTests runCriteria, ITestRunEventsHandler eventHandler)
        {
            this.messageEventHandler = eventHandler;
            this.onDisconnected = (disconnectedEventArgs) =>
                {
                    this.OnTestRunAbort(eventHandler, disconnectedEventArgs.Error, true);
                };
            this.onMessageReceived = (sender, args) => this.OnExecutionMessageReceived(sender, args, eventHandler);
            this.channel.MessageReceived += this.onMessageReceived;

            var message = this.dataSerializer.SerializePayload(
                MessageType.StartTestExecutionWithTests,
                runCriteria,
                this.protocolVersion);
            this.channel.Send(message);
        }

        /// <inheritdoc />
        public void SendTestRunCancel()
        {
            this.channel?.Send(this.dataSerializer.SerializeMessage(MessageType.CancelTestRun));
        }

        /// <inheritdoc />
        public void SendTestRunAbort()
        {
            this.channel?.Send(this.dataSerializer.SerializeMessage(MessageType.AbortTestRun));
        }

        #endregion

        /// <inheritdoc />
        public void EndSession()
        {
            if (!this.IsOperationComplete())
            {
                this.channel.Send(this.dataSerializer.SerializeMessage(MessageType.SessionEnd));
            }
        }

        /// <inheritdoc />
        public void OnClientProcessExit(string stdError)
        {
            // This method is called on test host exit. If test host has any errors, stdError
            // provides the crash call stack.
            EqtTrace.Info("TestRequestSender.OnClientProcessExit: Test host process exited. Standard error: " + stdError);
            this.clientExitErrorMessage = stdError;
            this.clientExited.Set();

            // Note that we're not explicitly disconnecting the communication channel; wait for the
            // channel to determine the disconnection on its own.
        }

        /// <inheritdoc />
        public void Close()
        {
            this.Dispose();
            EqtTrace.Info("Closing the connection");
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (this.channel != null)
            {
                this.channel.MessageReceived -= this.onMessageReceived;
            }

            this.communicationServer.Stop();
        }

        private void OnExecutionMessageReceived(object sender, MessageReceivedEventArgs messageReceived, ITestRunEventsHandler testRunEventsHandler)
        {
            try
            {
                var rawMessage = messageReceived.Data;

                // Send raw message first to unblock handlers waiting to send message to IDEs
                testRunEventsHandler.HandleRawMessage(rawMessage);

                var message = this.dataSerializer.DeserializeMessage(rawMessage);
                switch (message.MessageType)
                {
                    case MessageType.TestRunStatsChange:
                        var testRunChangedArgs = this.dataSerializer.DeserializePayload<TestRunChangedEventArgs>(message);
                        testRunEventsHandler.HandleTestRunStatsChange(testRunChangedArgs);
                        break;
                    case MessageType.ExecutionComplete:
                        var testRunCompletePayload = this.dataSerializer.DeserializePayload<TestRunCompletePayload>(message);

                        testRunEventsHandler.HandleTestRunComplete(
                            testRunCompletePayload.TestRunCompleteArgs,
                            testRunCompletePayload.LastRunTests,
                            testRunCompletePayload.RunAttachments,
                            testRunCompletePayload.ExecutorUris);

                        this.SetOperationComplete();
                        break;
                    case MessageType.TestMessage:
                        var testMessagePayload = this.dataSerializer.DeserializePayload<TestMessagePayload>(message);
                        testRunEventsHandler.HandleLogMessage(testMessagePayload.MessageLevel, testMessagePayload.Message);
                        break;
                    case MessageType.LaunchAdapterProcessWithDebuggerAttached:
                        var testProcessStartInfo = this.dataSerializer.DeserializePayload<TestProcessStartInfo>(message);
                        int processId = testRunEventsHandler.LaunchProcessWithDebuggerAttached(testProcessStartInfo);

                        var data =
                            this.dataSerializer.SerializePayload(
                                MessageType.LaunchAdapterProcessWithDebuggerAttachedCallback,
                                processId,
                                this.protocolVersion);

                        this.channel.Send(data);
                        break;
                }
            }
            catch (Exception exception)
            {
                this.OnTestRunAbort(testRunEventsHandler, exception, false);
            }
        }

        private void OnTestRunAbort(ITestRunEventsHandler testRunEventsHandler, Exception exception, bool getClientError)
        {
            if (this.IsOperationComplete())
            {
                EqtTrace.Verbose("TestRequestSender: OnTestRunAbort: Operation is already complete. Skip error message.");
                return;
            }

            EqtTrace.Verbose("TestRequestSender: OnTestRunAbort: Set operation complete.");
            this.SetOperationComplete();

            var reason = this.GetAbortErrorMessage(exception, getClientError);
            EqtTrace.Error("TestRequestSender: Aborting test run because {0}", reason);
            this.LogErrorMessage(string.Format(CommonResources.AbortedTestRun, reason));

            // notify test run abort to vstest console wrapper.
            var completeArgs = new TestRunCompleteEventArgs(null, false, true, exception, null, TimeSpan.Zero);
            var payload = new TestRunCompletePayload { TestRunCompleteArgs = completeArgs };
            var rawMessage = this.dataSerializer.SerializePayload(MessageType.ExecutionComplete, payload);
            testRunEventsHandler.HandleRawMessage(rawMessage);

            // notify of a test run complete and bail out.
            testRunEventsHandler.HandleTestRunComplete(completeArgs, null, null, null);
        }

        private void OnDiscoveryAbort(ITestDiscoveryEventsHandler2 eventHandler, Exception exception, bool getClientError)
        {
            if (this.IsOperationComplete())
            {
                EqtTrace.Verbose("TestRequestSender: OnDiscoveryAbort: Operation is already complete. Skip error message.");
                return;
            }

            EqtTrace.Verbose("TestRequestSender: OnDiscoveryAbort: Set operation complete.");
            this.SetOperationComplete();

            var reason = this.GetAbortErrorMessage(exception, getClientError);
            EqtTrace.Error("TestRequestSender: Aborting test discovery because {0}", reason);
            this.LogErrorMessage(string.Format(CommonResources.AbortedTestDiscovery, reason));

            // Notify discovery abort to IDE test output
            var payload = new DiscoveryCompletePayload()
            {
                IsAborted = true,
                LastDiscoveredTests = null,
                TotalTests = -1
            };
            var rawMessage = this.dataSerializer.SerializePayload(MessageType.DiscoveryComplete, payload);
            eventHandler.HandleRawMessage(rawMessage);

            // Complete discovery
            var discoveryCompleteEventsArgs = new DiscoveryCompleteEventArgs(-1, true);

            eventHandler.HandleDiscoveryComplete(discoveryCompleteEventsArgs, null);
        }

        private string GetAbortErrorMessage(Exception exception, bool getClientError)
        {
            EqtTrace.Verbose("TestRequestSender: GetAbortErrorMessage: Exception: " + exception);

            // It is also possible for an operation to abort even if client has not
            // disconnected, e.g. if there's an error parsing the response from test host. We
            // want the exception to be available in those scenarios.
            var reason = exception?.Message;
            if (getClientError)
            {
                EqtTrace.Verbose("TestRequestSender: GetAbortErrorMessage: Client has disconnected. Wait for standard error.");

                // Set a default message and wait for test host to exit for a moment
                reason = CommonResources.UnableToCommunicateToTestHost;
                if (this.clientExited.Wait(this.clientExitedWaitTime))
                {
                    EqtTrace.Info("TestRequestSender: GetAbortErrorMessage: Received test host error message.");
                    reason = this.clientExitErrorMessage;
                }

                EqtTrace.Info("TestRequestSender: GetAbortErrorMessage: Timed out waiting for test host error message.");
            }

            return reason;
        }

        private void LogErrorMessage(string message)
        {
            if (this.messageEventHandler == null)
            {
                EqtTrace.Error("TestRequestSender.LogErrorMessage: Message event handler not set. Error: " + message);
                return;
            }

            // Log to vstest console
            this.messageEventHandler.HandleLogMessage(TestMessageLevel.Error, message);

            // Log to vs ide test output
            var testMessagePayload = new TestMessagePayload { MessageLevel = TestMessageLevel.Error, Message = message };
            var rawMessage = this.dataSerializer.SerializePayload(MessageType.TestMessage, testMessagePayload);
            this.messageEventHandler.HandleRawMessage(rawMessage);
        }

        private bool IsOperationComplete()
        {
            return this.operationCompleted == 1;
        }

        private void SetOperationComplete()
        {
            // Complete the currently ongoing operation (Discovery/Execution)
            Interlocked.CompareExchange(ref this.operationCompleted, 1, 0);
        }
    }
}
