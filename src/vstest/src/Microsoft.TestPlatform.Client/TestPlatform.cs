// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.VisualStudio.TestPlatform.Client.Discovery;
    using Microsoft.VisualStudio.TestPlatform.Client.Execution;
    using Microsoft.VisualStudio.TestPlatform.Common;
    using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework;
    using Microsoft.VisualStudio.TestPlatform.Common.Hosting;
    using Microsoft.VisualStudio.TestPlatform.Common.Logging;
    using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
    using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
    using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers.Interfaces;

    /// <summary>
    /// Implementation for TestPlatform
    /// </summary>
    public class TestPlatform : ITestPlatform
    {
        private readonly TestRuntimeProviderManager testHostProviderManager;

        private readonly IFileHelper fileHelper;

        static TestPlatform()
        {
            // TODO This is not the right away to force initialization of default extensions. Test runtime providers
            // require this today. They're getting initialized even before test adapter paths are provided, which is
            // incorrect.
            AddExtensionAssembliesFromExtensionDirectory();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestPlatform"/> class.
        /// </summary>
        public TestPlatform() : this(new TestEngine(), new FileHelper(), TestRuntimeProviderManager.Instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestPlatform"/> class.
        /// </summary>
        /// <param name="testEngine">
        /// The test engine.
        /// </param>
        /// <param name="filehelper">
        /// The filehelper.
        /// </param>
        /// <param name="testHostProviderManager">
        /// The data.
        /// </param>
        protected TestPlatform(ITestEngine testEngine, IFileHelper filehelper, TestRuntimeProviderManager testHostProviderManager)
        {
            this.TestEngine = testEngine;
            this.fileHelper = filehelper;
            this.testHostProviderManager = testHostProviderManager;
        }

        /// <summary>
        /// Gets or sets Test Engine instance
        /// </summary>
        private ITestEngine TestEngine { get; set; }

        /// <summary>
        /// The create discovery request.
        /// </summary>
        /// <param name="discoveryCriteria"> The discovery criteria. </param>
        /// <param name="protocolConfig"> Protocol related information.  </param>
        /// <returns> The <see cref="IDiscoveryRequest"/>. </returns>
        /// <exception cref="ArgumentNullException"> Throws if parameter is null. </exception>
        public IDiscoveryRequest CreateDiscoveryRequest(DiscoveryCriteria discoveryCriteria, ProtocolConfig protocolConfig)
        {
            if (discoveryCriteria == null)
            {
                throw new ArgumentNullException(nameof(discoveryCriteria));
            }

            // Update cache with Extension Folder's files
            this.AddExtensionAssemblies(discoveryCriteria.RunSettings);

            var testHostManager = this.testHostProviderManager.GetTestHostManagerByRunConfiguration(discoveryCriteria.RunSettings);
            testHostManager.Initialize(TestSessionMessageLogger.Instance, discoveryCriteria.RunSettings);

            var discoveryManager = this.TestEngine.GetDiscoveryManager(testHostManager, discoveryCriteria, protocolConfig);
            discoveryManager.Initialize();

            return new DiscoveryRequest(discoveryCriteria, discoveryManager);
        }

        /// <summary>
        /// The create test run request.
        /// </summary>
        /// <param name="testRunCriteria"> The test run criteria.  </param>
        /// <param name="protocolConfig"> Protocol related information.  </param>
        /// <returns> The <see cref="ITestRunRequest"/>. </returns>
        /// <exception cref="ArgumentNullException"> Throws if parameter is null. </exception>
        public ITestRunRequest CreateTestRunRequest(TestRunCriteria testRunCriteria, ProtocolConfig protocolConfig)
        {
            if (testRunCriteria == null)
            {
                throw new ArgumentNullException(nameof(testRunCriteria));
            }

            this.AddExtensionAssemblies(testRunCriteria.TestRunSettings);

            var runConfiguration = XmlRunSettingsUtilities.GetRunConfigurationNode(testRunCriteria.TestRunSettings);

            // Update and initialize loggers only when DesignMode is false
            if (runConfiguration.DesignMode == false)
            {
                this.AddExtensionAssembliesFromSource(testRunCriteria);

                // Initialize loggers
                TestLoggerManager.Instance.InitializeLoggers();
            }

            var testHostManager = this.testHostProviderManager.GetTestHostManagerByRunConfiguration(testRunCriteria.TestRunSettings);
            testHostManager.Initialize(TestSessionMessageLogger.Instance, testRunCriteria.TestRunSettings);

            if (testRunCriteria.TestHostLauncher != null)
            {
                testHostManager.SetCustomLauncher(testRunCriteria.TestHostLauncher);
            }

            var executionManager = this.TestEngine.GetExecutionManager(testHostManager, testRunCriteria, protocolConfig);
            executionManager.Initialize();

            return new TestRunRequest(testRunCriteria, executionManager);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update extensions.
        /// </summary>
        /// <param name="pathToAdditionalExtensions"> The path to additional extensions. </param>
        /// <param name="loadOnlyWellKnownExtensions"> The load only well known extensions. </param>
        public void UpdateExtensions(IEnumerable<string> pathToAdditionalExtensions, bool loadOnlyWellKnownExtensions)
        {
            this.TestEngine.GetExtensionManager()
                   .UseAdditionalExtensions(pathToAdditionalExtensions, loadOnlyWellKnownExtensions);
        }

        /// <summary>
        /// Update the test adapter paths provided through run settings to be used by the test service
        /// </summary>
        /// <param name="runSettings">
        /// The run Settings.
        /// </param>
        private void AddExtensionAssemblies(string runSettings)
        {
            IEnumerable<string> customTestAdaptersPaths = RunSettingsUtilities.GetTestAdaptersPaths(runSettings);

            if (customTestAdaptersPaths != null)
            {
                foreach (string customTestAdaptersPath in customTestAdaptersPaths)
                {
                    var adapterPath = Path.GetFullPath(Environment.ExpandEnvironmentVariables(customTestAdaptersPath));
                    if (!Directory.Exists(adapterPath))
                    {
                        EqtTrace.Warning(string.Format("AdapterPath Not Found:", adapterPath));
                        continue;
                    }

                    var extensionAssemblies = new List<string>(this.fileHelper.EnumerateFiles(adapterPath, TestPlatformConstants.TestAdapterRegexPattern, SearchOption.AllDirectories));
                    extensionAssemblies.AddRange(this.fileHelper.EnumerateFiles(adapterPath, TestPlatformConstants.TestLoggerRegexPattern, SearchOption.AllDirectories));
                    extensionAssemblies.AddRange(this.fileHelper.EnumerateFiles(adapterPath, TestPlatformConstants.RunTimeRegexPattern, SearchOption.AllDirectories));
                    extensionAssemblies.AddRange(this.fileHelper.EnumerateFiles(adapterPath, TestPlatformConstants.SettingsProviderRegexPattern, SearchOption.AllDirectories));

                    if (extensionAssemblies.Count > 0)
                    {
                        this.UpdateExtensions(extensionAssemblies, true);
                    }
                }
            }
        }

        /// <summary>
        /// Update the test logger paths from source directory
        /// </summary>
        /// <param name="testRunCriteria">
        /// The test Run Criteria.
        /// </param>
        private void AddExtensionAssembliesFromSource(TestRunCriteria testRunCriteria)
        {
            IEnumerable<string> sources = testRunCriteria.Sources;
            if (testRunCriteria.HasSpecificTests)
            {
                // If the test execution is with a test filter, group them by sources
                sources = testRunCriteria.Tests.Select(tc => tc.Source).Distinct();
            }

            // Currently we support discovering loggers only from Source directory
            var loggersToUpdate = new List<string>();

            foreach (var source in sources)
            {
                var sourceDirectory = Path.GetDirectoryName(source);
                if (!string.IsNullOrEmpty(sourceDirectory) && this.fileHelper.DirectoryExists(sourceDirectory))
                {
                    loggersToUpdate.AddRange(this.fileHelper.EnumerateFiles(sourceDirectory, TestPlatformConstants.TestLoggerRegexPattern, SearchOption.TopDirectoryOnly).ToList());
                }
            }

            if (loggersToUpdate.Count > 0)
            {
                this.UpdateExtensions(loggersToUpdate, true);
            }
        }

        /// <summary>
        /// Find all test platform extensions from the `.\Extensions` directory. This is used to load the inbox extensions like
        /// Trx logger and legacy test extensions like mstest v1, mstest c++ etc..
        /// </summary>
        private static void AddExtensionAssembliesFromExtensionDirectory()
        {
            var fileHelper = new FileHelper();
            var extensionsFolder = Path.Combine(Path.GetDirectoryName(typeof(TestPlatform).GetTypeInfo().Assembly.Location), "Extensions");
            var defaultExtensionPaths = new List<string>();
            if (fileHelper.DirectoryExists(extensionsFolder))
            {
                var dlls = fileHelper.EnumerateFiles(extensionsFolder, ".*.dll", SearchOption.TopDirectoryOnly);
                defaultExtensionPaths.AddRange(dlls);
                var exes = fileHelper.EnumerateFiles(extensionsFolder, ".*.exe", SearchOption.TopDirectoryOnly);
                defaultExtensionPaths.AddRange(exes);
                TestPluginCache.Instance.DefaultExtensionPaths = defaultExtensionPaths;
            }
        }
    }
}
