﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.TestHost
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.TesthostProtocol;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
    using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
    using Microsoft.VisualStudio.TestPlatform.Utilities;

    internal class DefaultEngineInvoker :
#if NET46
        MarshalByRefObject,
#endif
        IEngineInvoker
    {
        /// <summary>
        /// The timeout for the client to connect to the server.
        /// </summary>
        private const int ClientListenTimeOut = 5 * 1000;

        private const string PortArgument = "--port";

        private const string ParentProcessIdArgument = "--parentprocessid";

        private const string LogFileArgument = "--diag";

        private const string DataCollectionPortArgument = "--datacollectionport";

        public void Invoke(IDictionary<string, string> argsDictionary)
        {
            // Setup logging if enabled
            string logFile;
            if (argsDictionary.TryGetValue(LogFileArgument, out logFile))
            {
                EqtTrace.InitializeVerboseTrace(logFile);
            }

#if NET46
            if (EqtTrace.IsInfoEnabled)
            {
                var appConfigText = System.IO.File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                EqtTrace.Info("DefaultEngineInvoker: Using Application Configuration: '{0}'", appConfigText);
            }
#endif

            // Get port number and initialize communication
            var portNumber = CommandLineArgumentsHelper.GetIntArgFromDict(argsDictionary, PortArgument);

            // Start Processing of requests
            using (var requestHandler = new TestRequestHandler())
            {
                // Attach to exit of parent process
                var parentProcessId = CommandLineArgumentsHelper.GetIntArgFromDict(argsDictionary, ParentProcessIdArgument);
                EqtTrace.Info("DefaultEngineInvoker: Monitoring parent process with id: '{0}'", parentProcessId);
                var processHelper = new ProcessHelper();
                processHelper.SetExitCallback(
                    parentProcessId,
                    () =>
                        {
                            EqtTrace.Info("DefaultEngineInvoker: ParentProcess '{0}' Exited.", parentProcessId);
                            Environment.Exit(1);
                        });

                // Initialize Communication
                EqtTrace.Info("DefaultEngineInvoker: Initialize communication on port number: '{0}'", portNumber);
                requestHandler.InitializeCommunication(portNumber);

                // Initialize DataCollection Communication if data collection port is provided.
                var dcPort = CommandLineArgumentsHelper.GetIntArgFromDict(argsDictionary, DataCollectionPortArgument);
                if (dcPort > 0)
                {
                    var dataCollectionTestCaseEventSender = DataCollectionTestCaseEventSender.Create();
                    dataCollectionTestCaseEventSender.InitializeCommunication(dcPort);
                    dataCollectionTestCaseEventSender.WaitForRequestSenderConnection(ClientListenTimeOut);
                }

                // Start processing async in a different task
                EqtTrace.Info("DefaultEngineInvoker: Start Request Processing.");
                var processingTask = this.StartProcessingAsync(requestHandler, new TestHostManagerFactory());

                // Wait for processing to complete.
                Task.WaitAny(processingTask);

                if (dcPort > 0)
                {
                    // Close socket communication connection.
                    DataCollectionTestCaseEventSender.Instance.Close();
                }
            }
        }

        private Task StartProcessingAsync(ITestRequestHandler requestHandler, ITestHostManagerFactory managerFactory)
        {
            return Task.Run(() =>
            {
                // Wait for the connection to the sender and start processing requests from sender
                if (requestHandler.WaitForRequestSenderConnection(ClientListenTimeOut))
                {
                    requestHandler.ProcessRequests(managerFactory);
                }
                else
                {
                    EqtTrace.Info("DefaultEngineInvoker: RequestHandler timed out while connecting to the Sender.");
                    throw new TimeoutException();
                }
            });
        }
    }
}
