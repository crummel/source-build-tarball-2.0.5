// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Xunit;

namespace System.IO.Tests
{
    public abstract partial class FileSystemTest : RemoteExecutorTestBase
    {
        public static readonly byte[] TestBuffer = { 0xBA, 0x5E, 0xBA, 0x11, 0xF0, 0x07, 0xBA, 0x11 };

        protected const TestPlatforms CaseInsensitivePlatforms = TestPlatforms.Windows | TestPlatforms.OSX;
        protected const TestPlatforms CaseSensitivePlatforms = TestPlatforms.AnyUnix & ~TestPlatforms.OSX;

        public static bool AreAllLongPathsAvailable => PathFeatures.AreAllLongPathsAvailable();

        public static bool LongPathsAreNotBlocked => !PathFeatures.AreLongPathsBlocked();

        public static bool UsingNewNormalization => !PathFeatures.IsUsingLegacyPathNormalization();

        public static TheoryData<string> PathsWithInvalidColons = TestData.PathsWithInvalidColons;
        public static TheoryData<string> PathsWithInvalidCharacters = TestData.PathsWithInvalidCharacters;
        public static TheoryData<char> TrailingCharacters = TestData.TrailingCharacters;

        /// <summary>
        /// In some cases (such as when running without elevated privileges),
        /// the symbolic link may fail to create. Only run this test if it creates
        /// links successfully.
        /// </summary>
        protected static bool CanCreateSymbolicLinks
        {
            get
            {
                bool success = true;

                // Verify file symlink creation
                string path = Path.GetTempFileName();
                string linkPath = path + ".link";
                success = MountHelper.CreateSymbolicLink(linkPath, path, isDirectory: false);
                try { File.Delete(path); } catch { }
                try { File.Delete(linkPath); } catch { }

                // Verify directory symlink creation
                path = Path.GetTempFileName();
                linkPath = path + ".link";
                success = success && MountHelper.CreateSymbolicLink(linkPath, path, isDirectory: true);
                try { Directory.Delete(path); } catch { }
                try { Directory.Delete(linkPath); } catch { }

                return success;
            }
        }

        /// <summary>
        /// Runs the given command as sudo
        /// </summary>
        /// <param name="commandLine">The command line to run as sudo</param>
        /// <returns> Returns the process exit code (0 typically means it is successful)</returns>
        protected static int RunAsSudo(string commandLine)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "sudo",
                Arguments = commandLine
            };

            using (Process process = Process.Start(startInfo))
            {
                Assert.True(process.WaitForExit(3000));
                return process.ExitCode;
            }
        }

        /// <summary>
        /// Do a test action against read only file system.
        /// </summary>
        /// <param name="testAction">Test action to perform. The string argument will be read only directory.</param>
        /// <param name="subDirectoryName">Optional subdirectory to create.</param>
        protected void ReadOnly_FileSystemHelper(Action<string> testAction, string subDirectoryName = null)
        {
            // Set up read only file system
            // Set up the source directory
            string sourceDirectory = GetTestFilePath();
            if (subDirectoryName == null)
            {
                Directory.CreateDirectory(sourceDirectory);
            }
            else
            {
                string sourceSubDirectory = Path.Combine(sourceDirectory, subDirectoryName);
                Directory.CreateDirectory(sourceSubDirectory);
            }

            // Set up the target directory and mount as a read only
            string readOnlyDirectory = GetTestFilePath();
            Directory.CreateDirectory(readOnlyDirectory);

            Assert.Equal(0, RunAsSudo($"mount --bind {sourceDirectory} {readOnlyDirectory}"));

            try
            {
                Assert.Equal(0, RunAsSudo($"mount -o remount,ro,bind {sourceDirectory} {readOnlyDirectory}"));
                testAction(readOnlyDirectory);
            }
            finally
            {
                // Clean up test environment
                Assert.Equal(0, RunAsSudo($"umount {readOnlyDirectory}"));
            }
        }
    }
}