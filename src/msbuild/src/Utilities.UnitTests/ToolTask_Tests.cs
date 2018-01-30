// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections;
using Microsoft.Build.Engine.UnitTests;
using Microsoft.Build.Framework;
using Microsoft.Build.Shared;
using Xunit;
using Microsoft.Build.Utilities;
using Shouldly;

namespace Microsoft.Build.UnitTests
{
    sealed public class ToolTask_Tests
    {
        internal class MyTool : ToolTask, IDisposable
        {
            private string _fullToolName;
            private string _responseFileCommands = String.Empty;
            private string _commandLineCommands = String.Empty;
            private string _pathToToolUsed;

            public MyTool()
                : base()
            {
                _fullToolName = Path.Combine(
#if FEATURE_SPECIAL_FOLDERS
                    Environment.GetFolderPath(Environment.SpecialFolder.System),
#else
                    FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.System),
#endif
                    NativeMethodsShared.IsUnixLike ? "sh" : "cmd.exe");
            }

            public void Dispose()
            {
            }

            public string PathToToolUsed
            {
                get { return _pathToToolUsed; }
            }

            public string MockResponseFileCommands
            {
                set { _responseFileCommands = value; }
            }

            public string MockCommandLineCommands
            {
                set { _commandLineCommands = value; }
            }

            public string FullToolName
            {
                set { _fullToolName = value; }
            }

            /// <summary>
            /// Intercepted start info
            /// </summary>
            internal ProcessStartInfo StartInfo
            {
                get;
                private set;
            }

            /// <summary>
            /// Whether execute was called
            /// </summary>
            internal bool ExecuteCalled
            {
                get;
                private set;
            }

            internal Action<ProcessStartInfo> DoProcessStartInfoMutation {get; set;}

            protected override string ToolName
            {
                get { return Path.GetFileName(_fullToolName); }
            }

            protected override string GenerateFullPathToTool()
            {
                return _fullToolName;
            }

            override protected string GenerateResponseFileCommands()
            {
                return _responseFileCommands;
            }

            override protected string GenerateCommandLineCommands()
            {
                // Default is nothing. This is useful for tools where all the parameters can go into a response file.
                return _commandLineCommands;
            }

            override protected ProcessStartInfo GetProcessStartInfo
            (
                string pathToTool,
                string commandLineCommands,
                string responseFileSwitch
            )
            {
                var basePSI = base.GetProcessStartInfo(
                    pathToTool, 
                    commandLineCommands, 
                    responseFileSwitch);
                
                if (DoProcessStartInfoMutation != null)
                {
                    DoProcessStartInfoMutation(basePSI);
                }

                return basePSI;
            }

            override protected void LogEventsFromTextOutput
                (
                string singleLine,
                MessageImportance messageImportance
                )
            {
                if (singleLine.Contains("BADTHINGHAPPENED"))
                {
                    // This is where a customer's tool task implementation could do its own
                    // parsing of the errors in the stdout/stderr output of the tool being wrapped.
                    Log.LogError(singleLine);
                }
                else
                {
                    base.LogEventsFromTextOutput(singleLine, messageImportance);
                }
            }

            override protected int ExecuteTool(string pathToTool, string responseFileCommands, string commandLineCommands)
            {
                Console.WriteLine("executetool");
                _pathToToolUsed = pathToTool;
                ExecuteCalled = true;
                if (!NativeMethodsShared.IsWindows && string.IsNullOrEmpty(responseFileCommands) && string.IsNullOrEmpty(commandLineCommands))
                {
                    // Unix makes sh interactive and it won't exit if there is nothing on the command line
                    commandLineCommands = " -c \"echo\"";
                }
                int result = base.ExecuteTool(pathToTool, responseFileCommands, commandLineCommands);
                StartInfo = GetProcessStartInfo(
                    GenerateFullPathToTool(),
                    NativeMethodsShared.IsWindows ? "/x" : string.Empty,
                    null);
                return result;
            }
        };

        [Fact]
        public void Regress_Mutation_UserSuppliedToolPathIsLogged()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.ToolPath = NativeMethodsShared.IsWindows ? @"C:\MyAlternatePath" : "/MyAlternatePath";

                t.Execute();

                // The alternate path should be mentioned in the log.
                engine.AssertLogContains("MyAlternatePath");
            }
        }

        [Fact]
        public void Regress_Mutation_MissingExecutableIsLogged()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.ToolPath = NativeMethodsShared.IsWindows ? @"C:\MyAlternatePath" : "/MyAlternatePath";

                t.Execute().ShouldBeFalse();

                // There should be an error about invalid task location.
                engine.AssertLogContains("MSB6004");
            }
        }

        [Fact]
        public void Regress_Mutation_WarnIfCommandLineTooLong()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;

                // "cmd.exe" croaks big-time when given a very long command-line.  It pops up a message box on
                // Windows XP.  We can't have that!  So use "attrib.exe" for this exercise instead.
#if FEATURE_SPECIAL_FOLDERS
                t.FullToolName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), NativeMethodsShared.IsWindows ? "attrib.exe" : "ps");
#else
                t.FullToolName = Path.Combine(FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.System), NativeMethodsShared.IsWindows ? "attrib.exe" : "ps");
#endif

                t.MockCommandLineCommands = new String('x', 32001);

                // It's only a warning, we still succeed
                t.Execute().ShouldBeTrue();
                t.ExitCode.ShouldBe(0);
                // There should be a warning about the command-line being too long.
                engine.AssertLogContains("MSB6002");
            }
        }

        /// <summary>
        /// Exercise the code in ToolTask's default implementation of HandleExecutionErrors.
        /// </summary>
        [Fact]
        public void HandleExecutionErrorsWhenToolDoesntLogError()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.MockCommandLineCommands = NativeMethodsShared.IsWindows ? "/C garbagegarbagegarbagegarbage.exe" : "-c garbagegarbagegarbagegarbage.exe";

                t.Execute().ShouldBeFalse();
                t.ExitCode.ShouldBe(NativeMethodsShared.IsWindows ? 1 : 127); // cmd.exe error code is 1, sh error code is 127

                // We just tried to run "cmd.exe /C garbagegarbagegarbagegarbage.exe".  This should fail,
                // but since "cmd.exe" doesn't log its errors in canonical format, no errors got
                // logged by the tool itself.  Therefore, ToolTask's default implementation of 
                // HandleTaskExecutionErrors should have logged error MSB6006.
                engine.AssertLogContains("MSB6006");
            }
        }

        /// <summary>
        /// Exercise the code in ToolTask's default implementation of HandleExecutionErrors.
        /// </summary>
        [Fact]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        [Trait("Category", "mono-osx-failing")]
        public void HandleExecutionErrorsWhenToolLogsError()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                                ? "/C echo Main.cs(17,20): error CS0168: The variable 'foo' is declared but never used"
                                                : @"-c """"""echo Main.cs\(17,20\): error CS0168: The variable 'foo' is declared but never used""""""";

                t.Execute().ShouldBeFalse();

                // The above command logged a canonical error message.  Therefore ToolTask should
                // not log its own error beyond that.
                engine.AssertLogDoesntContain("MSB6006");
                engine.AssertLogContains("CS0168");
                engine.AssertLogContains("The variable 'foo' is declared but never used");
                t.ExitCode.ShouldBe(-1);
                engine.Errors.ShouldBe(1);
            }
        }

        /// <summary>
        /// ToolTask should never run String.Format on strings that are 
        /// not meant to be formatted.
        /// </summary>
        [Fact]
        public void DoNotFormatTaskCommandOrMessage()
        {
            MyTool t = new MyTool();
            MockEngine engine = new MockEngine();
            t.BuildEngine = engine;
            // Unmatched curly would crash if they did
            t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                            ? "/C echo hello world {"
                                            : @"-c """"""echo hello world {""""""";
            t.Execute();
            engine.AssertLogContains("echo hello world {");
            engine.Errors.ShouldBe(0);
        }

        /// <summary>
        /// When a message is logged to the standard error stream do not error is LogStandardErrorAsError is not true or set.
        /// </summary>
        [Fact]
        public void DoNotErrorWhenTextSentToStandardError()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                                ? "/C Echo 'Who made you king anyways' 1>&2"
                                                : @"-c """"""echo Who made you king anyways 1>&2""""""";

                t.Execute().ShouldBeTrue();

                engine.AssertLogDoesntContain("MSB");
                engine.AssertLogContains("Who made you king anyways");
                t.ExitCode.ShouldBe(0);
                engine.Errors.ShouldBe(0);
            }
        }

        /// <summary>
        /// When a message is logged to the standard output stream do not error is LogStandardErrorAsError is  true
        /// </summary>
        [Fact]
        public void DoNotErrorWhenTextSentToStandardOutput()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.LogStandardErrorAsError = true;
                t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                                ? "/C Echo 'Who made you king anyways'"
                                                : @"-c """"""echo Who made you king anyways""""""";

                t.Execute().ShouldBeTrue();

                engine.AssertLogDoesntContain("MSB");
                engine.AssertLogContains("Who made you king anyways");
                t.ExitCode.ShouldBe(0);
                engine.Errors.ShouldBe(0);
            }
        }

        /// <summary>
        /// When a message is logged to the standard error stream error if LogStandardErrorAsError is true
        /// </summary>
        [Fact]
        public void ErrorWhenTextSentToStandardError()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.LogStandardErrorAsError = true;
                t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                                ? "/C Echo 'Who made you king anyways' 1>&2"
                                                : @"-c """"""echo 'Who made you king anyways' 1>&2""""""";

                t.Execute().ShouldBeFalse();

                engine.AssertLogDoesntContain("MSB3073");
                engine.AssertLogContains("Who made you king anyways");
                t.ExitCode.ShouldBe(-1);
                engine.Errors.ShouldBe(1);
            }
        }


        /// <summary>
        /// When ToolExe is set, it is used instead of ToolName
        /// </summary>
        [Fact]
        public void ToolExeWinsOverToolName()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.FullToolName = NativeMethodsShared.IsWindows ? "c:\\baz\\foo.exe" : "/baz/foo.exe";

                t.ToolExe.ShouldBe("foo.exe");
                t.ToolExe = "bar.exe";
                t.ToolExe.ShouldBe("bar.exe");
            }
        }

        /// <summary>
        /// When ToolExe is set, it is appended to ToolPath instead
        /// of the regular tool name
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void ToolExeIsFoundOnToolPath()
        {
            string shellName = NativeMethodsShared.IsWindows ? "cmd.exe" : "sh";
            string copyName = NativeMethodsShared.IsWindows ? "xcopy.exe" : "cp";
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.FullToolName = shellName;
#if FEATURE_SPECIAL_FOLDERS
                string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
#else
                string systemPath = FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.System);
#endif
                t.ToolPath = systemPath;

                t.Execute();
                t.PathToToolUsed.ShouldBe(Path.Combine(systemPath, shellName));
                engine.AssertLogContains(shellName);
                engine.Log = String.Empty;

                t.ToolExe = copyName;
                t.Execute();
                t.PathToToolUsed.ShouldBe(Path.Combine(systemPath, copyName));
                engine.AssertLogContains(copyName);
                engine.AssertLogDoesntContain(shellName);
            }
        }

        /// <summary>
        /// Task is not found on path - regress #499196
        /// </summary>
        [Fact]
        public void TaskNotFoundOnPath()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                t.FullToolName = "doesnotexist.exe";

                t.Execute().ShouldBeFalse();
                t.ExitCode.ShouldBe(-1);
                engine.Errors.ShouldBe(1);

                // Does not throw an exception
            }
        }

        /// <summary>
        /// Task is found on path.
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void TaskFoundOnPath()
        {
            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                string toolName = NativeMethodsShared.IsWindows ? "cmd.exe" : "sh";
                t.FullToolName = toolName;

                t.Execute().ShouldBeTrue();
                t.ExitCode.ShouldBe(0);
                engine.Errors.ShouldBe(0);

                engine.AssertLogContains(
#if FEATURE_SPECIAL_FOLDERS
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), toolName));
#else
                    Path.Combine(FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.System), toolName));
#endif
            }
        }

        /// <summary>
        /// StandardOutputImportance set to Low should not show up in our log
        /// </summary>
        [Fact]
        public void OverrideStdOutImportanceToLow()
        {
            string tempFile = FileUtilities.GetTemporaryFile();
            File.WriteAllText(tempFile, @"hello world");

            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                engine.MinimumMessageImportance = MessageImportance.High;

                t.BuildEngine = engine;
                t.FullToolName = NativeMethodsShared.IsWindows ? "findstr.exe" : "grep";
                t.MockCommandLineCommands = "\"hello\" \"" + tempFile + "\"";
                t.StandardOutputImportance = "Low";

                t.Execute().ShouldBeTrue();
                t.ExitCode.ShouldBe(0);
                engine.Errors.ShouldBe(0);

                engine.AssertLogDoesntContain("hello world");
            }
            File.Delete(tempFile);
        }

        /// <summary>
        /// StandardOutputImportance set to High should show up in our log
        /// </summary>
        [Fact]
        public void OverrideStdOutImportanceToHigh()
        {
            string tempFile = FileUtilities.GetTemporaryFile();
            File.WriteAllText(tempFile, @"hello world");

            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                engine.MinimumMessageImportance = MessageImportance.High;

                t.BuildEngine = engine;
                t.FullToolName = NativeMethodsShared.IsWindows ? "findstr.exe" : "grep";
                t.MockCommandLineCommands = "\"hello\" \"" + tempFile + "\"";
                t.StandardOutputImportance = "High";

                t.Execute().ShouldBeTrue();
                t.ExitCode.ShouldBe(0);
                engine.Errors.ShouldBe(0);

                engine.AssertLogContains("hello world");
            }
            File.Delete(tempFile);
        }

        /// <summary>
        /// This is to ensure that somebody could write a task that implements ToolTask,
        /// wraps some .EXE tool, and still have the ability to parse the stdout/stderr
        /// himself.  This is so that in case the tool doesn't log its errors in canonical
        /// format, the task can still opt to do something reasonable with it.
        /// </summary>
        [Fact]
        public void ToolTaskCanChangeCanonicalErrorFormat()
        {
            string tempFile = FileUtilities.GetTemporaryFile();
            File.WriteAllText(tempFile, @"
                Main.cs(17,20): warning CS0168: The variable 'foo' is declared but never used.
                BADTHINGHAPPENED: This is my custom error format that's not in canonical error format.
                ");

            using (MyTool t = new MyTool())
            {
                MockEngine engine = new MockEngine();
                t.BuildEngine = engine;
                // The command we're giving is the command to spew the contents of the temp
                // file we created above.
                t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                                ? $"/C type \"{tempFile}\""
                                                : $"-c \"cat \'{tempFile}\'\"";

                t.Execute();

                // The above command logged a canonical warning, as well as a custom error.
                engine.AssertLogContains("CS0168");
                engine.AssertLogContains("The variable 'foo' is declared but never used");
                engine.AssertLogContains("BADTHINGHAPPENED");
                engine.AssertLogContains("This is my custom error format");

                engine.Warnings.ShouldBe(1); // "Expected one warning in log."
                engine.Errors.ShouldBe(1); // "Expected one error in log."
            }

            File.Delete(tempFile);
        }

        /// <summary>
        /// Passing env vars through the tooltask public property
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void EnvironmentVariablesToToolTask()
        {
            MyTool task = new MyTool();
            task.BuildEngine = new MockEngine();
            string userVarName = NativeMethodsShared.IsWindows ? "username" : "user";
            task.EnvironmentVariables = new string[] { "a=b", "c=d", userVarName + "=x" /* built-in */, "path=" /* blank value */};
            bool result = task.Execute();

            result.ShouldBe(true);
            task.ExecuteCalled.ShouldBe(true);

            ProcessStartInfo startInfo = task.StartInfo;

#if FEATURE_PROCESSSTARTINFO_ENVIRONMENT
            startInfo.Environment["a"].ShouldBe("b");
            startInfo.Environment["c"].ShouldBe("d");
            startInfo.Environment[userVarName].ShouldBe("x");
            startInfo.Environment["path"].ShouldBe(String.Empty);
#else
            startInfo.EnvironmentVariables["a"].ShouldBe("b");
            startInfo.EnvironmentVariables["c"].ShouldBe("d");
            startInfo.EnvironmentVariables[userVarName].ShouldBe("x");
            startInfo.EnvironmentVariables["path"].ShouldBe(String.Empty);
#endif

            if (NativeMethodsShared.IsWindows)
            {
                Assert.Equal(
#if FEATURE_SPECIAL_FOLDERS
                        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
#else
                        FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.ProgramFiles),
#endif
#if FEATURE_PROCESSSTARTINFO_ENVIRONMENT
                        startInfo.Environment["programfiles"],
#else
                        startInfo.EnvironmentVariables["programfiles"],
#endif
                        true);
            }
        }

        /// <summary>
        /// Equals sign in value
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void EnvironmentVariablesToToolTaskEqualsSign()
        {
            MyTool task = new MyTool();
            task.BuildEngine = new MockEngine();
            task.EnvironmentVariables = new string[] { "a=b=c" };
            bool result = task.Execute();

            result.ShouldBe(true);
#if FEATURE_PROCESSSTARTINFO_ENVIRONMENT
            task.StartInfo.Environment["a"].ShouldBe("b=c");
#else
            task.StartInfo.EnvironmentVariables["a"].ShouldBe("b=c");
#endif
        }

        /// <summary>
        /// No value provided
        /// </summary>
        [Fact]
        public void EnvironmentVariablesToToolTaskInvalid1()
        {
            MyTool task = new MyTool();
            task.BuildEngine = new MockEngine();
            task.EnvironmentVariables = new string[] { "x" };
            bool result = task.Execute();

            result.ShouldBe(false);
            task.ExecuteCalled.ShouldBe(false);
        }

        /// <summary>
        /// Empty string provided
        /// </summary>
        [Fact]
        public void EnvironmentVariablesToToolTaskInvalid2()
        {
            MyTool task = new MyTool();
            task.BuildEngine = new MockEngine();
            task.EnvironmentVariables = new string[] { "" };
            bool result = task.Execute();

            result.ShouldBe(false);
            task.ExecuteCalled.ShouldBe(false);
        }

        /// <summary>
        /// Empty name part provided
        /// </summary>
        [Fact]
        public void EnvironmentVariablesToToolTaskInvalid3()
        {
            MyTool task = new MyTool();
            task.BuildEngine = new MockEngine();
            task.EnvironmentVariables = new string[] { "=a;b=c" };
            bool result = task.Execute();

            result.ShouldBe(false);
            task.ExecuteCalled.ShouldBe(false);
        }

        /// <summary>
        /// Not set should not wipe out other env vars
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void EnvironmentVariablesToToolTaskNotSet()
        {
            MyTool task = new MyTool();
            task.BuildEngine = new MockEngine();
            task.EnvironmentVariables = null;
            bool result = task.Execute();

            result.ShouldBe(true);
            task.ExecuteCalled.ShouldBe(true);
            Assert.Equal(
                true,
#if FEATURE_PROCESSSTARTINFO_ENVIRONMENT
                task.StartInfo.Environment["PATH"].Length > 0);
#else
                task.StartInfo.EnvironmentVariables["PATH"].Length > 0);
#endif
        }

        /// <summary>
        /// Verifies that if a directory with the same name of the tool exists that the tool task correctly
        /// ignores the directory.
        /// </summary>
        [Fact]
        public void ToolPathIsFoundWhenDirectoryExistsWithNameOfTool()
        {
            string toolName = NativeMethodsShared.IsWindows ? "cmd" : "sh";
            string savedCurrentDirectory = Directory.GetCurrentDirectory();

            try
            {
                using (var env = TestEnvironment.Create())
                {
                    string tempDirectory = env.CreateFolder().FolderPath;
                    env.SetCurrentDirectory(tempDirectory);
                    env.SetEnvironmentVariable("PATH", $"{tempDirectory}{Path.PathSeparator}{Environment.GetEnvironmentVariable("PATH")}");
                    Directory.SetCurrentDirectory(tempDirectory);

                    string directoryNamedSameAsTool = Directory.CreateDirectory(Path.Combine(tempDirectory, toolName)).FullName;

                    MyTool task = new MyTool
                    {
                        BuildEngine = new MockEngine(),
                        FullToolName = toolName,
                    };
                    bool result = task.Execute();

                    Assert.NotEqual(directoryNamedSameAsTool, task.PathToToolUsed);

                    result.ShouldBeTrue();
                }
            }
            finally
            {
                Directory.SetCurrentDirectory(savedCurrentDirectory);
            }
        }

        /// <summary>
        /// Confirms we can find a file on the PATH.
        /// </summary>
        [Fact]
        public void FindOnPathSucceeds()
        {
            string expectedCmdPath;
            string shellName;
            if (NativeMethodsShared.IsWindows)
            {
#if FEATURE_SPECIAL_FOLDERS
                expectedCmdPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe");
#else
                expectedCmdPath = Path.Combine(FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.System), "cmd.exe");
#endif
                shellName = "cmd.exe";
            }
            else
            {
                expectedCmdPath = "/bin/sh";
                shellName = "sh";
            }

            string cmdPath = ToolTask.FindOnPath(shellName);

            cmdPath.ShouldBe(expectedCmdPath, StringCompareShould.IgnoreCase);
        }

        /// <summary>
        /// Equals sign in value
        /// </summary>
        [Fact]
        public void GetProcessStartInfoCanOverrideEnvironmentVariables()
        {
            MyTool task = new MyTool();
#if FEATURE_PROCESSSTARTINFO_ENVIRONMENT
            task.DoProcessStartInfoMutation = (p) => p.Environment.Remove("a");
#else
            task.DoProcessStartInfoMutation = (p) => p.EnvironmentVariables.Remove("a");
#endif
            
            task.BuildEngine = new MockEngine();
            task.EnvironmentVariables = new string[] { "a=b" };
            bool result = task.Execute();

            result.ShouldBe(true);
#if FEATURE_PROCESSSTARTINFO_ENVIRONMENT
            task.StartInfo.Environment.ContainsKey("a").ShouldBe(false);
#else
            task.StartInfo.EnvironmentVariables.ContainsKey("a").ShouldBe(false);
#endif
        }

        [Fact]
        public void VisualBasicLikeEscapedQuotesInCommandAreNotMadeForwardSlashes()
        {
            MyTool t = new MyTool();
            MockEngine engine = new MockEngine();
            t.BuildEngine = engine;
            t.MockCommandLineCommands = NativeMethodsShared.IsWindows
                                            ? "/C echo \"hello \\\"world\\\"\""
                                            : "-c echo \"hello \\\"world\\\"\"";
            t.Execute();
            engine.AssertLogContains("echo \"hello \\\"world\\\"\"");
            engine.Errors.ShouldBe(0);
        }
    }
}
