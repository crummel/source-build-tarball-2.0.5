// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using Microsoft.Build.Shared;
using Xunit;
using PlatformID = Xunit.PlatformID;

namespace Microsoft.Build.UnitTests
{
    /// <summary>
    /// Tests for the Exec task
    /// </summary>
    sealed public class Exec_Tests
    {
        private Exec PrepareExec(string command)
        {
            IBuildEngine2 mockEngine = new MockEngine(true);
            Exec exec = new Exec();
            exec.BuildEngine = mockEngine;
            exec.Command = command;
            return exec;
        }

        private ExecWrapper PrepareExecWrapper(string command)
        {
            IBuildEngine2 mockEngine = new MockEngine(true);
            ExecWrapper exec = new ExecWrapper();
            exec.BuildEngine = mockEngine;
            exec.Command = command;
            return exec;
        }

        /// <summary>
        /// Ensures that calling the Exec task does not leave any extra TEMP files
        /// lying around.
        /// </summary>
        [Fact]
        [Trait("Category", "mono-osx-failing")]
        public void NoTempFileLeaks()
        {
            using (var alternativeTemp = new Helpers.AlternativeTempPath())
            {
                // This test counts files in TEMP. If it uses the system TEMP, some
                // other process may interfere. Use a private TEMP instead.
                var newTempPath = alternativeTemp.Path;

                string tempPath = Path.GetTempPath();
                Assert.StartsWith(newTempPath, tempPath);

                // Get a count of how many temp files there are right now.
                string[] tempFiles = Directory.GetFiles(tempPath);

                Assert.Empty(tempFiles);

                // Now run the Exec task on a simple command.
                Exec exec = PrepareExec("echo Four days until ZBB!");
                bool result = exec.Execute();

                // Get the new count of temp files.
                tempFiles = Directory.GetFiles(tempPath);

                // Ensure that Exec succeeded.
                Assert.True(result);

                // Ensure that no files linger in TEMP.
                Assert.Empty(tempFiles);
            }
        }

        [Fact]
        public void ExitCodeCausesFailure()
        {
            Exec exec = PrepareExec(NativeMethodsShared.IsWindows ? "xcopy thisisanonexistentfile" : "cp thisisanonexistentfile thatisanonexistentfile");
            bool result = exec.Execute();

            Assert.Equal(false, result);
            Assert.Equal(NativeMethodsShared.IsWindows ? 4 : 1, exec.ExitCode);
            ((MockEngine)exec.BuildEngine).AssertLogContains("MSB3073");
            if (!NativeMethodsShared.IsWindows)
            {
                ((MockEngine)exec.BuildEngine).AssertLogContains("cp: ");
            }
        }

        [Fact]
        public void Timeout()
        {
            // On non-Windows the exit code of a killed process is SIGTERM (143)
            int expectedExitCode = NativeMethodsShared.IsWindows ? -1 : 143;

            Exec exec = PrepareExec(NativeMethodsShared.IsWindows ? ":foo \n goto foo" : "while true; do sleep 1; done");
            exec.Timeout = 5;
            bool result = exec.Execute();

            Assert.Equal(false, result);
            Assert.Equal(expectedExitCode, exec.ExitCode);
            ((MockEngine)exec.BuildEngine).AssertLogContains("MSB5002");
            Assert.Equal(1, ((MockEngine)exec.BuildEngine).Warnings);

            // ToolTask does not log an error on timeout.
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Errors);
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.AnyUnix)]
        public void WindowsNewLineCharactersInCommandOnUnix()
        {
            var exec = PrepareExec("echo hello\r\n\r\n");
            bool result = exec.Execute();

            Assert.Equal(true, result);
            Assert.Equal(0, exec.ExitCode);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Warnings);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Errors);
        }

        [Fact]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void ExitCodeGetter()
        {
            Exec exec = PrepareExec("exit 120");
            bool result = exec.Execute();

            Assert.Equal(120, exec.ExitCode);
        }

        [Fact]
        public void LoggedErrorsCauseFailureDespiteExitCode0()
        {
            var cmdLine = NativeMethodsShared.IsWindows
                              ? "echo myfile(88,37): error AB1234: thisisacanonicalerror"
                              : "echo \"myfile(88,37): error AB1234: thisisacanonicalerror\"";

            // This will return 0 exit code, but emitted a canonical error
            Exec exec = PrepareExec(cmdLine);
            bool result = exec.Execute();

            Assert.Equal(false, result);
            // Exitcode is set to -1
            Assert.Equal(-1, exec.ExitCode);
            ((MockEngine)exec.BuildEngine).AssertLogContains("MSB3073");
        }

        [Fact]
        public void IgnoreExitCodeTrueMakesTaskSucceedDespiteLoggingErrors()
        {
            var cmdLine = NativeMethodsShared.IsWindows
                              ? "echo myfile(88,37): error AB1234: thisisacanonicalerror"
                              : "echo \"myfile(88,37): error AB1234: thisisacanonicalerror\"";

            Exec exec = PrepareExec(cmdLine);
            exec.IgnoreExitCode = true;
            bool result = exec.Execute();

            Assert.Equal(true, result);
        }

        [Fact]
        public void IgnoreExitCodeTrueMakesTaskSucceedDespiteExitCode1()
        {
            Exec exec = PrepareExec("dir ||invalid||");
            exec.IgnoreExitCode = true;
            bool result = exec.Execute();

            Assert.Equal(true, result);
        }

#if FEATURE_SPECIAL_FOLDERS
        [Fact]
        public void NonUNCWorkingDirectoryUsed()
        {
            Exec exec = PrepareExec(NativeMethodsShared.IsWindows ? "echo [%cd%]" : "echo [$PWD]");
            string working = !NativeMethodsShared.IsWindows ? "/usr/lib" :
                Environment.GetFolderPath(Environment.SpecialFolder.Windows); // not desktop etc - IT redirection messes it up
            exec.WorkingDirectory = working;
            bool result = exec.Execute();

            Assert.Equal(true, result);
            ((MockEngine)exec.BuildEngine).AssertLogContains("[" + working + "]");
        }

        [Fact]
        [PlatformSpecific(Xunit.PlatformID.Windows)]   // UNC is Windows-Only
        public void UNCWorkingDirectoryUsed()
        {
            Exec exec = PrepareExec("echo [%cd%]");
            string working = @"\\" + Environment.MachineName + @"\c$";
            exec.WorkingDirectory = working;
            bool result = exec.ValidateParametersAccessor();

            Assert.Equal(true, result);
            Assert.Equal(true, exec.workingDirectoryIsUNC);
            Assert.Equal(working, exec.WorkingDirectory);
            // Should give ToolTask the system folder as the working directory, when it's a UNC
            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Assert.Equal(system, exec.GetWorkingDirectoryAccessor());
        }

        [Fact]
        public void NoWorkingDirectorySet()
        {
            var cd = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(NativeMethodsShared.IsWindows ?
                    Environment.GetFolderPath(Environment.SpecialFolder.Windows) : "/usr/lib");

                Exec exec = PrepareExec(NativeMethodsShared.IsWindows ? "echo [%cd%]" : "echo [$PWD]");
                bool result = exec.Execute();

                string expected = Directory.GetCurrentDirectory();
                Assert.Equal(true, result);
                ((MockEngine)exec.BuildEngine).AssertLogContains("[" + expected + "]");
            }
            finally
            {
                Directory.SetCurrentDirectory(cd);
            }
        }
#endif

        /// <summary>
        /// Tests that Exec still executes properly when there's an '&' in the temp directory path
        /// </summary>
        [Fact]
        public void TempPathContainsAmpersand1()
        {
            string directoryWithAmpersand = "nospace&nospace";
            string newTmp = Path.Combine(Path.GetTempPath(), directoryWithAmpersand);
            string oldTmp = Environment.GetEnvironmentVariable("TMP");

            try
            {
                Directory.CreateDirectory(newTmp);

                if (NativeMethodsShared.GetShortFilePath(newTmp) == newTmp)
                {
                    // Short file paths not supported, this test will fail.
                    // See: https://github.com/Microsoft/msbuild/issues/1803
                    return;
                }

                Environment.SetEnvironmentVariable("TMP", newTmp);
                Exec exec = PrepareExec("echo [hello]");

                Assert.True(exec.Execute()); // "Task should have succeeded"
                ((MockEngine)exec.BuildEngine).AssertLogContains("[hello]");
            }
            finally
            {
                Environment.SetEnvironmentVariable("TMP", oldTmp);
                if (Directory.Exists(newTmp)) FileUtilities.DeleteWithoutTrailingBackslash(newTmp);
            }
        }

        /// <summary>
        /// Tests that Exec still executes properly when there's an ' &' in the temp directory path
        /// </summary>
        [Fact]
        public void TempPathContainsAmpersand2()
        {
            string directoryWithAmpersand = "space &nospace";
            string newTmp = Path.Combine(Path.GetTempPath(), directoryWithAmpersand);
            string oldTmp = Environment.GetEnvironmentVariable("TMP");

            try
            {
                Directory.CreateDirectory(newTmp);

                if (NativeMethodsShared.GetShortFilePath(newTmp) == newTmp)
                {
                    // Short file paths not supported, this test will fail.
                    // See: https://github.com/Microsoft/msbuild/issues/1803
                    return;
                }

                Environment.SetEnvironmentVariable("TMP", newTmp);
                Exec exec = PrepareExec("echo [hello]");

                bool taskSucceeded = exec.Execute();
                Assert.True(taskSucceeded); // "Task should have succeeded"
                ((MockEngine)exec.BuildEngine).AssertLogContains("[hello]");
            }
            finally
            {
                Environment.SetEnvironmentVariable("TMP", oldTmp);
                if (Directory.Exists(newTmp)) FileUtilities.DeleteWithoutTrailingBackslash(newTmp);
            }
        }

        /// <summary>
        /// Tests that Exec still executes properly when there's an '& ' in the temp directory path
        /// </summary>
        [Fact]
        public void TempPathContainsAmpersand3()
        {
            string directoryWithAmpersand = "nospace& space";
            string newTmp = Path.Combine(Path.GetTempPath(), directoryWithAmpersand);
            string oldTmp = Environment.GetEnvironmentVariable("TMP");

            try
            {
                Directory.CreateDirectory(newTmp);

                if (NativeMethodsShared.GetShortFilePath(newTmp) == newTmp)
                {
                    // Short file paths not supported, this test will fail.
                    // See: https://github.com/Microsoft/msbuild/issues/1803
                    return;
                }

                Environment.SetEnvironmentVariable("TMP", newTmp);
                Exec exec = PrepareExec("echo [hello]");

                Assert.True(exec.Execute()); // "Task should have succeeded"
                ((MockEngine)exec.BuildEngine).AssertLogContains("[hello]");
            }
            finally
            {
                Environment.SetEnvironmentVariable("TMP", oldTmp);
                if (Directory.Exists(newTmp)) FileUtilities.DeleteWithoutTrailingBackslash(newTmp);
            }
        }

        /// <summary>
        /// Tests that Exec still executes properly when there's an ' & ' in the temp directory path
        /// </summary>
        [Fact]
        public void TempPathContainsAmpersand4()
        {
            string directoryWithAmpersand = "space & space";
            string newTmp = Path.Combine(Path.GetTempPath(), directoryWithAmpersand);
            string oldTmp = Environment.GetEnvironmentVariable("TMP");

            try
            {
                Directory.CreateDirectory(newTmp);

                if (NativeMethodsShared.GetShortFilePath(newTmp) == newTmp)
                {
                    // Short file paths not supported, this test will fail.
                    // See: https://github.com/Microsoft/msbuild/issues/1803
                    return;
                }

                Environment.SetEnvironmentVariable("TMP", newTmp);
                Exec exec = PrepareExec("echo [hello]");

                Assert.True(exec.Execute()); // "Task should have succeeded"
                ((MockEngine)exec.BuildEngine).AssertLogContains("[hello]");
            }
            finally
            {
                Environment.SetEnvironmentVariable("TMP", oldTmp);
                if (Directory.Exists(newTmp)) FileUtilities.DeleteWithoutTrailingBackslash(newTmp);
            }
        }

        /// <summary>
        /// Tests that Exec still executes properly when there's a non-ANSI character in the command
        /// </summary>
#if RUNTIME_TYPE_NETCORE
        [Fact(Skip = "https://github.com/Microsoft/msbuild/issues/623")]
#else
        [Fact]
#endif
        public void ExecTaskUnicodeCharacterInCommand()
        {
            RunExec(true, new UTF8Encoding(false).EncodingName);
        }

        /// <summary>
        /// Tests that Exec task will choose the default code page when UTF8 is not needed.
        /// </summary>
        [Fact]
        public void ExecTaskWithoutUnicodeCharacterInCommand()
        {
            RunExec(false, EncodingUtilities.CurrentSystemOemEncoding.EncodingName);
        }

        /// <summary>
        /// Exec task will use UTF8 when UTF8 Always is specified (with non-ANSI characters in the Command)
        /// </summary>
#if RUNTIME_TYPE_NETCORE
        [Fact(Skip = "https://github.com/Microsoft/msbuild/issues/623")]
#else
        [Fact]
#endif
        public void ExecTaskUtf8AlwaysWithNonAnsi()
        {
            RunExec(true, new UTF8Encoding(false).EncodingName, "Always");
        }

        /// <summary>
        /// Exec task will use UTF8 when UTF8 Always is specified (without non-ANSI characters in the Command)
        /// </summary>
        [Fact]
        public void ExecTaskUtf8AlwaysWithAnsi()
        {
            RunExec(false, new UTF8Encoding(false).EncodingName, "Always");
        }

        /// <summary>
        /// Exec task will NOT use UTF8 when UTF8 Never is specified and non-ANSI characters are in the Command
        /// <remarks>Exec task will fail as the cmd processor will not be able to run the command.</remarks>
        /// </summary>
#if RUNTIME_TYPE_NETCORE
        [Fact(Skip = "https://github.com/Microsoft/msbuild/issues/623")]
#else
        [Fact]
#endif
        [Trait("Category", "mono-osx-failing")]
        public void ExecTaskUtf8NeverWithNonAnsi()
        {
            RunExec(true, EncodingUtilities.CurrentSystemOemEncoding.EncodingName, "Never", false);
        }

        /// <summary>
        /// Exec task will NOT use UTF8 when UTF8 Never is specified and only ANSI characters are in the Command
        /// </summary>
        [Fact]
        public void ExecTaskUtf8NeverWithAnsi()
        {
            RunExec(false, EncodingUtilities.CurrentSystemOemEncoding.EncodingName, "Never");
        }


        /// <summary>
        /// Helper function to run the Exec task with or without ANSI characters in the Command and check for an expected encoding.
        /// </summary>
        /// <param name="includeNonAnsiInCommand">True to include non-ANSI characters in the Command</param>
        /// <param name="expectedEncoding">Expected EncodingName</param>
        /// <param name="useUtf8">Optional parameter to specify the UseUtf8Encoding on the Exec task</param>
        /// <param name="expectSuccess">Optional parameter if the Exec task should succeed or not. Default true.</param>
        /// <returns></returns>
        private void RunExec(bool includeNonAnsiInCommand, string expectedEncoding, string useUtf8 = null, bool expectSuccess = true)
        {
            string ansiCharacters = "test";
            string nonAnsiCharacters = "\u521B\u5EFA";
            string folder = Path.Combine(Path.GetTempPath(), includeNonAnsiInCommand ? nonAnsiCharacters : ansiCharacters);
            string command = Path.Combine(folder, "test.cmd");

            Exec exec;

            try
            {
                Directory.CreateDirectory(folder);
                File.WriteAllText(command, "echo [hello]");

                if (!NativeMethodsShared.IsWindows)
                {
                    command = ". " + command;
                }

                exec = PrepareExec(command);

                if (!string.IsNullOrEmpty(useUtf8))
                {
                    exec.UseUtf8Encoding = useUtf8;
                }

                Assert.Equal(expectSuccess, exec.Execute());

                if (expectSuccess)
                {
                    ((MockEngine) exec.BuildEngine).AssertLogContains("[hello]");
                }

                Assert.Equal(expectedEncoding, exec.StdOutEncoding);
                Assert.Equal(expectedEncoding, exec.StdErrEncoding);
            }
            finally
            {
                if (Directory.Exists(folder))
                    FileUtilities.DeleteWithoutTrailingBackslash(folder, true);
            }

            return;
        }

        [Fact]
        public void InvalidUncDirectorySet()
        {
            Exec exec = PrepareExec("echo [%cd%]");
            exec.WorkingDirectory = @"\\thiscomputerdoesnotexistxyz\thiscomputerdoesnotexistxyz";
            bool result = exec.Execute();

            Assert.Equal(false, result);
            ((MockEngine)exec.BuildEngine).AssertLogContains("MSB6003");
        }

        [Fact]
        [Trait("Category", "netcore-osx-failing")]
        [Trait("Category", "netcore-linux-failing")]
        public void InvalidWorkingDirectorySet()
        {
            Exec exec = PrepareExec("echo [%cd%]");
            exec.WorkingDirectory = @"||invalid||";
            bool result = exec.Execute();

            Assert.Equal(false, result);
            ((MockEngine)exec.BuildEngine).AssertLogContains("MSB6003");
        }

        [Fact]
        public void BogusCustomRegexesCauseOneErrorEach()
        {
            Exec exec;
            if (NativeMethodsShared.IsWindows)
                exec = PrepareExec("echo Some output & echo Some output & echo Some output & echo Some output ");
            else
                exec = PrepareExec("echo Some output ; echo Some output ; echo Some output ; echo Some output ");

            exec.CustomErrorRegularExpression = "~!@#$%^_)(*&^%$#@@#XF &%^%T$REd((((([[[[";
            exec.CustomWarningRegularExpression = "*";
            bool result = exec.Execute();

            MockEngine e = (MockEngine)exec.BuildEngine;
            Console.WriteLine(e.Log);
            Assert.Equal(3, e.Errors);
            e.AssertLogContains("MSB3076");
        }

        [Fact]
        public void CustomErrorRegexSupplied()
        {
            string cmdLine;
            if (NativeMethodsShared.IsWindows)
                cmdLine = "echo Some output & echo ALERT:This is an error & echo Some more output";
            else
                cmdLine = "echo Some output ; echo ALERT:This is an error ; echo Some more output";
            Exec exec = PrepareExec(cmdLine);
            bool result = exec.Execute();

            MockEngine e = (MockEngine)exec.BuildEngine;
            Console.WriteLine(e.Log);
            Assert.Equal(0, e.Errors);
            e.AssertLogContains("ALERT:This is an error");

            exec = PrepareExec(cmdLine);
            exec.CustomErrorRegularExpression = ".*ALERT.*";
            result = exec.Execute();

            e = (MockEngine)exec.BuildEngine;
            Console.WriteLine(e.Log);
            Assert.Equal(2, e.Errors);
            e.AssertLogContains("ALERT:This is an error");
        }

        [Fact]
        public void CustomWarningRegexSupplied()
        {
            string cmdLine;
            if (NativeMethodsShared.IsWindows)
                cmdLine = "echo Some output & echo YOOHOO:This is a warning & echo Some more output";
            else
                cmdLine = "echo Some output ; echo YOOHOO:This is a warning ; echo Some more output";

            Exec exec = PrepareExec(cmdLine);
            bool result = exec.Execute();

            MockEngine e = (MockEngine)exec.BuildEngine;
            Console.WriteLine(e.Log);
            Assert.Equal(0, e.Errors);
            Assert.Equal(0, e.Warnings);
            e.AssertLogContains("YOOHOO:This is a warning");

            exec = PrepareExec(cmdLine);
            exec.CustomWarningRegularExpression = ".*YOOHOO.*";
            result = exec.Execute();

            e = (MockEngine)exec.BuildEngine;
            Console.WriteLine(e.Log);
            Assert.Equal(0, e.Errors);
            Assert.Equal(1, e.Warnings);
            e.AssertLogContains("YOOHOO:This is a warning");
        }

        [Fact]
        public void ErrorsAndWarningsWithIgnoreStandardErrorWarningFormatTrue()
        {
            var cmdLine = NativeMethodsShared.IsWindows
                              ? "echo myfile(88,37): error AB1234: thisisacanonicalerror & echo foo: warning CDE1234: thisisacanonicalwarning"
                              : "echo \"myfile(88,37): error AB1234: thisisacanonicalerror\" ; echo foo: warning CDE1234: thisisacanonicalwarning";

            Exec exec = PrepareExec(cmdLine);
            exec.IgnoreStandardErrorWarningFormat = true;
            bool result = exec.Execute();

            Assert.Equal(true, result);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Errors);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Warnings);
        }

        [Fact]
        public void CustomAndStandardErrorsAndWarnings()
        {
            var cmdLine = NativeMethodsShared.IsWindows
                              ? "echo myfile(88,37): error AB1234: thisisacanonicalerror & echo foo: warning CDE1234: thisisacanonicalwarning & echo YOGI & echo BEAR & echo some content"
                              : "echo \"myfile(88,37): error AB1234: thisisacanonicalerror\" ; echo foo: warning CDE1234: thisisacanonicalwarning ; echo YOGI ; echo BEAR ; echo some content";

            Exec exec = PrepareExec(cmdLine);
            exec.CustomWarningRegularExpression = ".*BEAR.*";
            exec.CustomErrorRegularExpression = ".*YOGI.*";
            bool result = exec.Execute();

            Assert.Equal(false, result);
            Assert.Equal(3, ((MockEngine)exec.BuildEngine).Errors);
            Assert.Equal(2, ((MockEngine)exec.BuildEngine).Warnings);
        }

        /// <summary>
        /// Nobody should try to run a string emitted from the task through String.Format.
        /// Firstly that's unnecessary and secondly if there's eg an unmatched curly it will throw.
        /// </summary>
        [Fact]
        public void DoNotAttemptToFormatTaskOutput()
        {
            Exec exec = PrepareExec("echo unmatched curly {");
            bool result = exec.Execute();

            Assert.Equal(true, result);
            ((MockEngine)exec.BuildEngine).AssertLogContains("unmatched curly {");
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Errors);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Warnings);
        }

        /// <summary>
        /// Nobody should try to run a string emitted from the task through String.Format.
        /// Firstly that's unnecessary and secondly if there's eg an unmatched curly it will throw.
        /// </summary>
        [Fact]
        public void DoNotAttemptToFormatTaskOutput2()
        {
            Exec exec = PrepareExec("echo unmatched curly {");
            exec.IgnoreStandardErrorWarningFormat = true;
            bool result = exec.Execute();

            Assert.Equal(true, result);
            ((MockEngine)exec.BuildEngine).AssertLogContains("unmatched curly {");
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Errors);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Warnings);
        }

        [Fact]
        public void NoDuplicateMessagesWhenCustomRegexAndRegularRegexBothMatch()
        {
            var cmdLine = NativeMethodsShared.IsWindows
                              ? "echo myfile(88,37): error AB1234: thisisacanonicalerror & echo foo: warning CDE1234: thisisacanonicalwarning "
                              : "echo \"myfile(88,37): error AB1234: thisisacanonicalerror\" ; echo foo: warning CDE1234: thisisacanonicalwarning ";

            Exec exec = PrepareExec(cmdLine);
            exec.CustomErrorRegularExpression = ".*canonicale.*";
            exec.CustomWarningRegularExpression = ".*canonicalw.*";
            bool result = exec.Execute();

            Assert.Equal(false, result);
            Assert.Equal(2, ((MockEngine)exec.BuildEngine).Errors);
            Assert.Equal(1, ((MockEngine)exec.BuildEngine).Warnings);
        }

        [Fact]
        public void OnlySingleErrorWhenCustomWarningAndCustomErrorRegexesBothMatch()
        {
            Exec exec = PrepareExec("echo YOGI BEAR ");
            exec.CustomErrorRegularExpression = ".*YOGI.*";
            exec.CustomWarningRegularExpression = ".*BEAR.*";
            bool result = exec.Execute();

            Assert.Equal(false, result);
            Assert.Equal(2, ((MockEngine)exec.BuildEngine).Errors);
            Assert.Equal(0, ((MockEngine)exec.BuildEngine).Warnings);
        }

        [Fact]
        public void GettersSetters()
        {
            Exec exec = PrepareExec("echo [%cd%]");
            exec.WorkingDirectory = "foo";
            Assert.Equal("foo", exec.WorkingDirectory);
            exec.IgnoreExitCode = true;
            Assert.Equal(true, exec.IgnoreExitCode);
            exec.Outputs = null;
            Assert.Equal(0, exec.Outputs.Length);

            ITaskItem[] items = { new TaskItem("hi"), new TaskItem("ho") };
            exec.Outputs = items;
            Assert.Equal(items, exec.Outputs);
        }

        [Fact]
        public void StdEncodings()
        {
            ExecWrapper exec = PrepareExecWrapper("echo [%cd%]");

            exec.StdErrEncoding = "US-ASCII";
            Assert.Equal(true, exec.StdErrEncoding.Contains("US-ASCII"));
            Assert.Equal(true, exec.StdErrorEncoding.EncodingName.Contains("US-ASCII"));

            exec.StdOutEncoding = "US-ASCII";
            Assert.Equal(true, exec.StdOutEncoding.Contains("US-ASCII"));
            Assert.Equal(true, exec.StdOutputEncoding.EncodingName.Contains("US-ASCII"));
        }

        [Fact]
        public void AnyExistingEnvVarCalledErrorLevelIsIgnored()
        {
            string oldValue = Environment.GetEnvironmentVariable("errorlevel");

            try
            {
                Exec exec = PrepareExec("echo this is an innocuous successful command");
                Environment.SetEnvironmentVariable("errorlevel", "1");
                bool result = exec.Execute();

                Assert.Equal(true, result);
            }
            finally
            {
                Environment.SetEnvironmentVariable("errorlevel", oldValue);
            }
        }

        [Fact]
        public void ValidateParametersNoCommand()
        {
            Exec exec = PrepareExec("   ");

            bool result = exec.Execute();

            Assert.Equal(false, result);
            ((MockEngine)exec.BuildEngine).AssertLogContains("MSB3072");
        }

        /// <summary>
        /// Verify that the EnvironmentVariables parameter exposed publicly
        /// by ToolTask can be used to modify the environment of the cmd.exe spawned.
        /// </summary>
        [Fact]
        public void SetEnvironmentVariableParameter()
        {
            Exec exec = new Exec();
            exec.BuildEngine = new MockEngine();
            exec.Command = NativeMethodsShared.IsWindows ? "echo [%MYENVVAR%]" : "echo [$myenvvar]";
            exec.EnvironmentVariables = new[] { "myenvvar=myvalue" };
            exec.Execute();

            ((MockEngine)exec.BuildEngine).AssertLogContains("[myvalue]");
        }

        /// <summary>
        /// Execute return output as an Item
        /// Test include ConsoleToMSBuild, StandardOutput
        /// </summary>
        [Fact]
        public void ConsoleToMSBuild()
        {
            //Exec with no output
            Exec exec = PrepareExec("set foo=blah");
            //Test Set and Get of ConsoleToMSBuild
            exec.ConsoleToMSBuild = true;
            Assert.Equal(true, exec.ConsoleToMSBuild);

            bool result = exec.Execute();
            Assert.Equal(true, result);

            //Nothing to run, so the list should be empty
            Assert.Equal(0, exec.ConsoleOutput.Length);


            //first echo prints "Hello stderr" to stderr, second echo prints to stdout
            string testString = "echo Hello stderr 1>&2\necho Hello stdout";
            exec = PrepareExec(testString);

            //Test Set and Get of ConsoleToMSBuild
            exec.ConsoleToMSBuild = true;
            Assert.Equal(true, exec.ConsoleToMSBuild);

            result = exec.Execute();
            Assert.Equal(true, result);

            //Both two lines should had gone to stdout
            Assert.Equal(2, exec.ConsoleOutput.Length);
        }

        /// <summary>
        /// Test the CanEncode method with and without ANSI characters to determine if they can be encoded 
        /// in the current system encoding.
        /// </summary>
#if RUNTIME_TYPE_NETCORE
        [Fact(Skip = "https://github.com/Microsoft/msbuild/issues/623")]
#else
        [Fact]
        [Trait("Category", "mono-osx-failing")]
#endif
        public void CanEncodeTest()
        {
            var defaultEncoding = EncodingUtilities.CurrentSystemOemEncoding;

            string nonAnsiCharacters = "\u521B\u5EFA";
            string pathWithAnsiCharacters = @"c:\windows\system32\cmd.exe";

            Assert.False(Exec.CanEncodeString(defaultEncoding.CodePage, nonAnsiCharacters));
            Assert.True(Exec.CanEncodeString(defaultEncoding.CodePage, pathWithAnsiCharacters));
        }
    }

    internal class ExecWrapper : Exec
    {
        public Encoding StdOutputEncoding
        {
            get
            {
                return StandardOutputEncoding;
            }
        }

        public Encoding StdErrorEncoding
        {
            get
            {
                return StandardErrorEncoding;
            }
        }
    }
}



