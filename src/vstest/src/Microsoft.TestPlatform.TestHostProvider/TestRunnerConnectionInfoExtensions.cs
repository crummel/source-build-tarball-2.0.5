// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Hosting
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;

    /// <summary>
    /// Extension methods for <see cref="TestRunnerConnectionInfo"/>.
    /// </summary>
    internal static class TestRunnerConnectionInfoExtensions
    {
        /// <summary>
        /// Creates a default command line options string from <see cref="TestRunnerConnectionInfo"/>.
        /// </summary>
        /// <param name="connectionInfo">Connection info for the test host.</param>
        /// <returns>Command line option string.</returns>
        public static string ToCommandLineOptions(this TestRunnerConnectionInfo connectionInfo)
        {
            var options = "--port " + connectionInfo.Port + " --parentprocessid " + connectionInfo.RunnerProcessId;
            if (!string.IsNullOrEmpty(connectionInfo.LogFile))
            {
                options += " --diag " + connectionInfo.LogFile;
            }

            return options;
        }
    }
}