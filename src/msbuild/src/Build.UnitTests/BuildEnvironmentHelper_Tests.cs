﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Shared;
using Xunit;

namespace Microsoft.Build.Engine.UnitTests
{
    public class BuildEnvironmentHelper_Tests
    {
#if USE_MSBUILD_DLL_EXTN
        private const string MSBuildExeName = "MSBuild.dll";
#else
        private const string MSBuildExeName = "MSBuild.exe";
#endif
        [Fact]
        public void GetExecutablePath()
        {
            var msbuildPath = Path.GetDirectoryName(FileUtilities.ExecutingAssemblyPath);
            string expectedMSBuildPath = Path.Combine(msbuildPath, MSBuildExeName).ToLowerInvariant();

            string configFilePath = BuildEnvironmentHelper.Instance.CurrentMSBuildConfigurationFile.ToLowerInvariant();
            string toolsDirectoryPath = BuildEnvironmentHelper.Instance.CurrentMSBuildToolsDirectory.ToLowerInvariant();
            string actualMSBuildPath = BuildEnvironmentHelper.Instance.CurrentMSBuildExePath.ToLowerInvariant();

            Assert.Equal(configFilePath, actualMSBuildPath + ".config");
            Assert.Equal(expectedMSBuildPath, actualMSBuildPath);
            Assert.Equal(toolsDirectoryPath, Path.GetDirectoryName(expectedMSBuildPath));
            Assert.Equal(BuildEnvironmentMode.Standalone, BuildEnvironmentHelper.Instance.Mode);
        }

        [Fact]
        public void FindBuildEnvironmentByEnvironmentVariable()
        {
            using (var env = new EmptyStandaloneEnviroment(MSBuildExeName))
            {
                var path = env.BuildDirectory;
                var msBuildPath = Path.Combine(path, MSBuildExeName);
                var msBuildConfig = Path.Combine(path, $"{MSBuildExeName}.config");

                env.WithEnvironment("MSBUILD_EXE_PATH", env.MSBuildExePath);
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(path, BuildEnvironmentHelper.Instance.CurrentMSBuildToolsDirectory);
                Assert.Equal(msBuildPath, BuildEnvironmentHelper.Instance.CurrentMSBuildExePath);
                Assert.Equal(msBuildConfig, BuildEnvironmentHelper.Instance.CurrentMSBuildConfigurationFile);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.Null(BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.Standalone, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void FindBuildEnvironmentFromCommandLineVisualStudio()
        {
            using (var env = new EmptyVSEnviroment())
            {
                // All we know about is path to msbuild.exe as the command-line arg[0]
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.MSBuildExePath, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory64, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        public void FindBuildEnvironmentFromCommandLineStandalone()
        {
            // Path will not be under a Visual Studio install like path.
            using (var env = new EmptyStandaloneEnviroment(MSBuildExeName))
            {
                // All we know about is path to msbuild.exe as the command-line arg[0]
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.MSBuildExePath, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.Standalone, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void FindBuildEnvironmentFromRunningProcessVisualStudio()
        {
            using (var env = new EmptyVSEnviroment())
            {
                // All we know about is path to msbuild.exe as the current process
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, () => env.MSBuildExePath, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory64, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        public void FindBuildEnvironmentFromRunningProcessStandalone()
        {
            // Path will not be under a Visual Studio install like path.
            using (var env = new EmptyStandaloneEnviroment(MSBuildExeName))
            {
                // All we know about is path to msbuild.exe as the current process
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, () => env.MSBuildExePath, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.Standalone, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        public void FindBuildEnvironmentFromExecutingAssemblyAsDll()
        {
            // Ensure the correct file is found (.dll not .exe)
            using (var env = new EmptyStandaloneEnviroment("MSBuild.dll"))
            {
                // All we know about is path to msbuild.exe as the current process
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, () => env.MSBuildExePath, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.Standalone, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        public void FindBuildEnvironmentFromAppContextDirectory()
        {
            using (var env = new EmptyStandaloneEnviroment(MSBuildExeName))
            {
                // Only the app base directory will be available
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, ReturnNull, () => env.BuildDirectory, env.VsInstanceMock, env.EnvironmentMock);

                // Make sure we get the right MSBuild entry point. On .NET Core this will be MSBuild.dll, otherwise MSBuild.exe
                Assert.Equal(MSBuildExeName, Path.GetFileName(BuildEnvironmentHelper.Instance.CurrentMSBuildExePath));

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.Standalone, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void FindBuildEnvironmentFromVisualStudioRoot()
        {
            using (var env = new EmptyVSEnviroment())
            {
                // All we know about is path to DevEnv.exe
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.DevEnvPath, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory64, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.True(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.False(BuildEnvironmentHelper.Instance.RunningTests);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentDetectsVisualStudioByEnvironment()
        {
            using (var env = new EmptyVSEnviroment())
            {
                env.WithEnvironment("VSINSTALLDIR", env.TempFolderRoot);
                env.WithEnvironment("VisualStudioVersion", "15.0");
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentDetectsVisualStudioByMSBuildProcess()
        {
            using (var env = new EmptyVSEnviroment())
            {
                // We only know we're in msbuild.exe, we should still be able to attempt to find Visual Studio
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.MSBuildExePath, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentDetectsVisualStudioByMSBuildProcessAmd64()
        {
            using (var env = new EmptyVSEnviroment())
            {
                // We only know we're in amd64\msbuild.exe, we should still be able to attempt to find Visual Studio
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.MSBuildExePath64, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Theory]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        [InlineData("15.0")]
        [InlineData("15.3")]
        public void BuildEnvironmentDetectsVisualStudioFromSetupInstance(string visualStudioVersion)
        {
            using (var env = new EmptyVSEnviroment())
            {
                env.WithVsInstance(new VisualStudioInstance("Invalid path", @"c:\_doesnotexist", new Version(visualStudioVersion)));
                env.WithVsInstance(new VisualStudioInstance("VS", env.TempFolderRoot, new Version(visualStudioVersion)));

                // This test has no context to find MSBuild other than Visual Studio root.
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        public void BuildEnvironmentVisualStudioNotFoundWhenVersionMismatch()
        {
            using (var env = new EmptyVSEnviroment())
            {
                env.WithVsInstance(new VisualStudioInstance("Invalid path", @"c:\_doesnotexist", new Version("15.0")));
                env.WithVsInstance(new VisualStudioInstance("VS", env.TempFolderRoot, new Version("14.0")));

                // This test has no context to find MSBuild other than Visual Studio root.
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(ReturnNull, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Null(BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.None, BuildEnvironmentHelper.Instance.Mode);
            }
        }

#if RUNTIME_TYPE_NETCORE
        [Fact(Skip = "https://github.com/Microsoft/msbuild/issues/669")]
#else
        [Fact]
#endif
        public void BuildEnvironmentDetectsRunningTests()
        {
            Assert.True(BuildEnvironmentHelper.Instance.RunningTests);
            Assert.False(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentDetectsVisualStudioByProcessName()
        {
            using (var env = new EmptyVSEnviroment())
            {
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.DevEnvPath, () => env.MSBuildExePath, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.True(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentDetectsVisualStudioByBlendProcess()
        {
            using (var env = new EmptyVSEnviroment())
            {
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.BlendPath, () => env.MSBuildExePath, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.True(BuildEnvironmentHelper.Instance.RunningInVisualStudio);
                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentFindsAmd64()
        {
            using (var env = new EmptyVSEnviroment())
            {
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => env.DevEnvPath, ReturnNull,
                    ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory64, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        [Trait("Category", "nonlinuxtests")]
        [Trait("Category", "nonosxtests")]
        public void BuildEnvironmentFindsAmd64RunningInAmd64()
        {
            using (var env = new EmptyVSEnviroment())
            {
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(()=>env.MSBuildExePath64, ReturnNull, ReturnNull, env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(env.BuildDirectory, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory32);
                Assert.Equal(env.BuildDirectory64, BuildEnvironmentHelper.Instance.MSBuildToolsDirectory64);
                Assert.Equal(env.TempFolderRoot, BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.VisualStudio, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        [Fact]
        public void BuildEnvironmentNoneWhenNotAvailable()
        {
            using (var env = new EmptyStandaloneEnviroment(MSBuildExeName))
            {
                var entryProcess = Path.Combine(Path.GetTempPath(), "foo.exe");
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly(() => entryProcess, ReturnNull, ReturnNull,
                    env.VsInstanceMock, env.EnvironmentMock);

                Assert.Equal(entryProcess, BuildEnvironmentHelper.Instance.CurrentMSBuildExePath);
                Assert.Equal(Path.GetDirectoryName(entryProcess), BuildEnvironmentHelper.Instance.CurrentMSBuildToolsDirectory);
                Assert.Null(BuildEnvironmentHelper.Instance.VisualStudioInstallRootDirectory);
                Assert.Equal(BuildEnvironmentMode.None, BuildEnvironmentHelper.Instance.Mode);
            }
        }

        private static string ReturnNull()
        {
            return null;
        }

        private class EmptyVSEnviroment : EmptyStandaloneEnviroment
        {
            public string DevEnvPath { get; }

            public string BlendPath { get; }

            public string BuildDirectory64 { get; }

            public string MSBuildExePath64 => Path.Combine(BuildDirectory64, MSBuildExeName);

            public EmptyVSEnviroment() : base("msbuild.exe", false)
            {
                try
                {
                    var files = new[] { "msbuild.exe", "msbuild.exe.config" };
                    BuildDirectory = Path.Combine(TempFolderRoot, "MSBuild", "15.0", "Bin");
                    BuildDirectory64 = Path.Combine(BuildDirectory, "amd64");
                    DevEnvPath = Path.Combine(TempFolderRoot, "Common7", "IDE", "devenv.exe");
                    BlendPath = Path.Combine(TempFolderRoot, "Common7", "IDE", "blend.exe");

                    Directory.CreateDirectory(BuildDirectory);
                    foreach (var file in files)
                    {
                        File.WriteAllText(Path.Combine(BuildDirectory, file), string.Empty);
                    }

                    Directory.CreateDirectory(BuildDirectory64);
                    foreach (var file in files)
                    {
                        File.WriteAllText(Path.Combine(BuildDirectory64, file), string.Empty);
                    }

                    Directory.CreateDirectory(Path.Combine(TempFolderRoot, "Common7", "IDE"));
                    File.WriteAllText(DevEnvPath, string.Empty);
                }
                catch (Exception)
                {
                    FileUtilities.DeleteDirectoryNoThrow(BuildDirectory, true);
                    throw;
                }
            }
        }

        private class EmptyStandaloneEnviroment : IDisposable
        {
            public string TempFolderRoot { get; }

            public string BuildDirectory { get; protected set; }

            public string MSBuildExeName { get; }

            public string MSBuildExePath => Path.Combine(BuildDirectory, MSBuildExeName);

            private readonly Dictionary<string, string> _mockEnvironment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            private readonly List<VisualStudioInstance> _mockInstances = new List<VisualStudioInstance>();

            public EmptyStandaloneEnviroment(string msBuildExeName, bool writeFakeFiles = true)
            {
                try
                {
                    MSBuildExeName = msBuildExeName;
                    TempFolderRoot = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
                    BuildDirectory = Path.Combine(TempFolderRoot, "MSBuild");

                    Directory.CreateDirectory(BuildDirectory);
                    if (writeFakeFiles)
                    {
                        File.WriteAllText(MSBuildExePath, string.Empty);
                        File.WriteAllText($"{MSBuildExePath}.config", string.Empty);
                    }
                }
                catch (Exception)
                {
                    FileUtilities.DeleteDirectoryNoThrow(BuildDirectory, true);
                    throw;
                }
            }

            public void WithEnvironment(string variable, string value)
            {
                _mockEnvironment.Add(variable, value);
            }

            public void WithVsInstance(VisualStudioInstance instance)
            {
                _mockInstances.Add(instance);
            }

            public string EnvironmentMock(string variable)
            {
                return _mockEnvironment.ContainsKey(variable) ? _mockEnvironment[variable] : null;
            }

            public IEnumerable<VisualStudioInstance> VsInstanceMock()
            {
                return _mockInstances;
            }

            public void Dispose()
            {
                FileUtilities.DeleteDirectoryNoThrow(TempFolderRoot, true);
                BuildEnvironmentHelper.ResetInstance_ForUnitTestsOnly();
            }
        }
    }
}
