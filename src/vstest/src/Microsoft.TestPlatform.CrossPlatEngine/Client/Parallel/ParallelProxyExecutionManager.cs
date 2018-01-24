// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client.Parallel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
    
    /// <summary>
    /// ParallelProxyExecutionManager that manages parallel execution
    /// </summary>
    internal class ParallelProxyExecutionManager : ParallelOperationManager<IProxyExecutionManager, ITestRunEventsHandler>, IParallelProxyExecutionManager
    {
        #region TestRunSpecificData

        private int runCompletedClients = 0;

        private TestRunCriteria actualTestRunCriteria;

        private IEnumerator<string> sourceEnumerator;

        private IEnumerator testCaseListEnumerator;

        private bool hasSpecificTestsRun = false;

        private Task lastParallelRunCleanUpTask = null;

        private ITestRunEventsHandler currentRunEventsHandler;

        private ParallelRunDataAggregator currentRunDataAggregator;
        
        /// <inheritdoc/>
        public bool IsInitialized { get; private set; } = false;

        #endregion

        #region Concurrency Keeper Objects

        /// <summary>
        /// LockObject to update execution status in parallel
        /// </summary>
        private readonly object executionStatusLockObject = new object();

        #endregion

        public ParallelProxyExecutionManager(Func<IProxyExecutionManager> actualProxyManagerCreator, int parallelLevel)
            : base(actualProxyManagerCreator, parallelLevel, true)
        {
        }

        public ParallelProxyExecutionManager(Func<IProxyExecutionManager> actualProxyManagerCreator, int parallelLevel, bool sharedHosts)
            : base(actualProxyManagerCreator, parallelLevel, sharedHosts)
        {
        }

        #region IProxyExecutionManager

        public void Initialize()
        {
            this.DoActionOnAllManagers((proxyManager) => proxyManager.Initialize(), doActionsInParallel: true);
            this.IsInitialized = true;
        }

        public int StartTestRun(TestRunCriteria testRunCriteria, ITestRunEventsHandler eventHandler)
        {
            this.hasSpecificTestsRun = testRunCriteria.HasSpecificTests;
            this.actualTestRunCriteria = testRunCriteria;

            if (this.hasSpecificTestsRun)
            {
                var testCasesBySource = new Dictionary<string, List<TestCase>>();
                foreach (var test in testRunCriteria.Tests)
                {
                    if (!testCasesBySource.ContainsKey(test.Source))
                    {
                        testCasesBySource.Add(test.Source, new List<TestCase>());
                    }

                    testCasesBySource[test.Source].Add(test);
                }

                // Do not use "Dictionary.ValueCollection.Enumerator" - it becomes undetermenstic once we go out of scope of this method
                // Use "ToArray" to copy ValueColleciton to a simple array and use it's enumerator
                // Set the enumerator for parallel yielding of testCases
                // Whenever a concurrent executor becomes free, it picks up the next set of testCases using this enumerator
                this.testCaseListEnumerator = testCasesBySource.Values.ToArray().GetEnumerator();
            }
            else
            {
                // Set the enumerator for parallel yielding of sources
                // Whenever a concurrent executor becomes free, it picks up the next source using this enumerator
                this.sourceEnumerator = testRunCriteria.Sources.GetEnumerator();
            }

            return this.StartTestRunPrivate(eventHandler);
        }

        public void Abort()
        {
            this.DoActionOnAllManagers((proxyManager) => proxyManager.Abort(), doActionsInParallel: true);
        }

        public void Cancel()
        {
            this.DoActionOnAllManagers((proxyManager) => proxyManager.Cancel(), doActionsInParallel: true);
        }

        public void Close()
        {
            this.DoActionOnAllManagers(proxyManager => proxyManager.Close(), doActionsInParallel: true);
        }

        #endregion

        #region IParallelProxyExecutionManager methods

        /// <summary>
        /// Handles Partial Run Complete event coming from a specific concurrent proxy exceution manager
        /// Each concurrent proxy execution manager will signal the parallel execution manager when its complete
        /// </summary>
        /// <param name="proxyExecutionManager">Concurrent Execution manager that completed the run</param>
        /// <param name="testRunCompleteArgs">RunCompleteArgs for the concurrent run</param>
        /// <param name="lastChunkArgs">LastChunk testresults for the concurrent run</param>
        /// <param name="runContextAttachments">RunAttachments for the concurrent run</param>
        /// <param name="executorUris">ExecutorURIs of the adapters involved in executing the tests</param>
        /// <returns>True if parallel run is complete</returns>
        public bool HandlePartialRunComplete(
            IProxyExecutionManager proxyExecutionManager,
            TestRunCompleteEventArgs testRunCompleteArgs,
            TestRunChangedEventArgs lastChunkArgs,
            ICollection<AttachmentSet> runContextAttachments,
            ICollection<string> executorUris)
        {
            var allRunsCompleted = false;

            // In case of DataCollection we only start dc.exe on initialize, & close once the TestRun is complete,
            // So instead of resuing ProxyExecutionManager, we will close it here, & create new PEMWDC
            // In Case of Abort, clean old one and create new proxyExecutionManager in place of old one.
            if (!this.SharedHosts || testRunCompleteArgs.IsAborted || (proxyExecutionManager is ProxyExecutionManagerWithDataCollection))
            {
                this.RemoveManager(proxyExecutionManager);

                proxyExecutionManager = CreateNewConcurrentManager();

                var parallelEventsHandler = proxyExecutionManager is ProxyExecutionManagerWithDataCollection
                                                ? new ParallelDataCollectionEventsHandler(
                                                    proxyExecutionManager,
                                                    this.currentRunEventsHandler,
                                                    this,
                                                this.currentRunDataAggregator) : 
                    new ParallelRunEventsHandler(
                                               proxyExecutionManager,
                                               this.currentRunEventsHandler,
                                               this,
                                               this.currentRunDataAggregator);

                this.AddManager(proxyExecutionManager, parallelEventsHandler);
            }

            // If there are no more sources/testcases, a parallel executor is truly done with execution
            if (testRunCompleteArgs.IsCanceled || !this.StartTestRunOnConcurrentManager(proxyExecutionManager))
            {
                lock (this.executionStatusLockObject)
                {
                    // Each concurrent Executor calls this method 
                    // So, we need to keep track of total runcomplete calls
                    this.runCompletedClients++;
                    allRunsCompleted = this.runCompletedClients == this.GetConcurrentManagersCount();
                }

                // verify that all executors are done with the execution and there are no more sources/testcases to execute
                if (allRunsCompleted)
                {
                    // Reset enumerators
                    this.sourceEnumerator = null;
                    this.testCaseListEnumerator = null;

                    this.currentRunDataAggregator = null;
                    this.currentRunEventsHandler = null;

                    // Dispose concurrent executors
                    // Do not do the cleanuptask in the current thread as we will unncessarily add to execution time
                    this.lastParallelRunCleanUpTask = Task.Run(() =>
                    {
                        this.UpdateParallelLevel(0);
                    });
                }
            }

            return allRunsCompleted;
        }

        #endregion

        #region ParallelOperationManager Methods

        protected override void DisposeInstance(IProxyExecutionManager managerInstance)
        {
            if (managerInstance != null)
            {
                try
                {
                    managerInstance.Close();
                }
                catch (Exception)
                {
                    // ignore any exceptions
                }
            }
        }

        #endregion

        private int StartTestRunPrivate(ITestRunEventsHandler runEventsHandler)
        {
            this.currentRunEventsHandler = runEventsHandler;

            // Cleanup Task for cleaning up the parallel executors except for the default one
            // We do not do this in Sync so that this task does not add up to execution time
            if (this.lastParallelRunCleanUpTask != null)
            {
                try
                {
                    this.lastParallelRunCleanUpTask.Wait();
                }
                catch (Exception ex)
                {
                    // if there is an exception disposing off concurrent executors ignore it
                    if (EqtTrace.IsWarningEnabled)
                    {
                        EqtTrace.Warning("ParallelTestRunnerServiceClient: Exception while invoking an action on DiscoveryManager: {0}", ex);
                    }
                }

                this.lastParallelRunCleanUpTask = null;
            }

            // Reset the runcomplete data
            this.runCompletedClients = 0;

            // One data aggregator per parallel run
            this.currentRunDataAggregator = new ParallelRunDataAggregator();

            foreach (var concurrentManager in this.GetConcurrentManagerInstances())
            {
                var parallelEventsHandler = concurrentManager is ProxyExecutionManagerWithDataCollection ? 
                    new ParallelDataCollectionEventsHandler(concurrentManager,
                                                this.currentRunEventsHandler,
                                                this,
                                                this.currentRunDataAggregator) : 
                    new ParallelRunEventsHandler(
                                               concurrentManager,
                                               this.currentRunEventsHandler,
                                               this,
                                               this.currentRunDataAggregator);

                this.UpdateHandlerForManager(concurrentManager, parallelEventsHandler);

                Task.Run(() => this.StartTestRunOnConcurrentManager(concurrentManager));
            }

            return 1;
        }

        /// <summary>
        /// Triggers the execution for the next data object on the concurrent executor
        /// Each concurrent executor calls this method, once its completed working on previous data
        /// </summary>
        /// <param name="proxyExecutionManager">Proxy execution manager instance.</param>
        /// <returns>True, if execution triggered</returns>
        private bool StartTestRunOnConcurrentManager(IProxyExecutionManager proxyExecutionManager)
        {
            TestRunCriteria testRunCriteria = null;
            if (!this.hasSpecificTestsRun)
            {
                string nextSource = null;
                if (this.TryFetchNextSource(this.sourceEnumerator, out nextSource))
                {
                    EqtTrace.Info("ProxyParallelExecutionManager: Triggering test run for next source: {0}", nextSource);

                    testRunCriteria = new TestRunCriteria(
                                          new List<string>() { nextSource },
                                          this.actualTestRunCriteria.FrequencyOfRunStatsChangeEvent,
                                          this.actualTestRunCriteria.KeepAlive,
                                          this.actualTestRunCriteria.TestRunSettings,
                                          this.actualTestRunCriteria.RunStatsChangeEventTimeout,
                                          this.actualTestRunCriteria.TestHostLauncher)
                                          {
                                              TestCaseFilter = this.actualTestRunCriteria.TestCaseFilter
                                          };
                }
            }
            else
            {
                List<TestCase> nextSetOfTests = null;
                if (this.TryFetchNextSource(this.testCaseListEnumerator, out nextSetOfTests))
                {
                    EqtTrace.Info("ProxyParallelExecutionManager: Triggering test run for next source: {0}", nextSetOfTests?.FirstOrDefault()?.Source);

                    testRunCriteria = new TestRunCriteria(
                                          nextSetOfTests,
                                          this.actualTestRunCriteria.FrequencyOfRunStatsChangeEvent,
                                          this.actualTestRunCriteria.KeepAlive,
                                          this.actualTestRunCriteria.TestRunSettings,
                                          this.actualTestRunCriteria.RunStatsChangeEventTimeout,
                                          this.actualTestRunCriteria.TestHostLauncher);
                }
            }

            if (testRunCriteria != null)
            {
                if (!proxyExecutionManager.IsInitialized)
                {
                    proxyExecutionManager.Initialize();
                }

                proxyExecutionManager.StartTestRun(testRunCriteria, this.GetHandlerForGivenManager(proxyExecutionManager));
            }

            return testRunCriteria != null;
        }
    }
}
