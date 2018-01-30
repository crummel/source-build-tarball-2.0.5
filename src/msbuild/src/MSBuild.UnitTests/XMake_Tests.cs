// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

using Microsoft.Build.CommandLine;
using Microsoft.Build.Engine.UnitTests;
using Microsoft.Build.Framework;
using Microsoft.Build.Shared;
using Microsoft.Build.UnitTests.Shared;
using Xunit;
using Shouldly;

namespace Microsoft.Build.UnitTests
{
    public class XMakeAppTests
    {
#if USE_MSBUILD_DLL_EXTN
        private const string MSBuildExeName = "MSBuild.dll";
#else
        private const string MSBuildExeName = "MSBuild.exe";
#endif

        private const string AutoResponseFileName = "MSBuild.rsp";

        [Fact]
        public void GatherCommandLineSwitchesTwoProperties()
        {
            CommandLineSwitches switches = new CommandLineSwitches();

            ArrayList arguments = new ArrayList();
            arguments.AddRange(new string[] { "/p:a=b", "/p:c=d" });

            MSBuildApp.GatherCommandLineSwitches(arguments, switches);

            string[] parameters = switches[CommandLineSwitches.ParameterizedSwitch.Property];
            parameters[0].ShouldBe("a=b");
            parameters[1].ShouldBe("c=d");
        }

        [Fact]
        public void GatherCommandLineSwitchesMaxCpuCountWithArgument()
        {
            CommandLineSwitches switches = new CommandLineSwitches();

            ArrayList arguments = new ArrayList();
            arguments.AddRange(new string[] { "/m:2" });

            MSBuildApp.GatherCommandLineSwitches(arguments, switches);

            string[] parameters = switches[CommandLineSwitches.ParameterizedSwitch.MaxCPUCount];
            parameters[0].ShouldBe("2");
            parameters.Length.ShouldBe(1);

            switches.HaveErrors().ShouldBeFalse();
        }

        [Fact]
        public void GatherCommandLineSwitchesMaxCpuCountWithoutArgument()
        {
            CommandLineSwitches switches = new CommandLineSwitches();

            ArrayList arguments = new ArrayList();
            arguments.AddRange(new string[] { "/m:3", "/m" });

            MSBuildApp.GatherCommandLineSwitches(arguments, switches);

            string[] parameters = switches[CommandLineSwitches.ParameterizedSwitch.MaxCPUCount];
            parameters[1].ShouldBe(Convert.ToString(Environment.ProcessorCount));
            parameters.Length.ShouldBe(2);

            switches.HaveErrors().ShouldBeFalse();
        }

        /// <summary>
        ///  /m: should be an error, unlike /m:1 and /m
        /// </summary>
        [Fact]
        public void GatherCommandLineSwitchesMaxCpuCountWithoutArgumentButWithColon()
        {
            CommandLineSwitches switches = new CommandLineSwitches();

            ArrayList arguments = new ArrayList();
            arguments.AddRange(new string[] { "/m:" });

            MSBuildApp.GatherCommandLineSwitches(arguments, switches);

            string[] parameters = switches[CommandLineSwitches.ParameterizedSwitch.MaxCPUCount];
            parameters.Length.ShouldBe(0);

            switches.HaveErrors().ShouldBeTrue();
        }

        /*
         * Quoting Rules:
         *
         * A string is considered quoted if it is enclosed in double-quotes. A double-quote can be escaped with a backslash, or it
         * is automatically escaped if it is the last character in an explicitly terminated quoted string. A backslash itself can
         * be escaped with another backslash IFF it precedes a double-quote, otherwise it is interpreted literally.
         *
         * e.g.
         *      abc"cde"xyz         --> "cde" is quoted
         *      abc"xyz             --> "xyz" is quoted (the terminal double-quote is assumed)
         *      abc"xyz"            --> "xyz" is quoted (the terminal double-quote is explicit)
         *
         *      abc\"cde"xyz        --> "xyz" is quoted (the terminal double-quote is assumed)
         *      abc\\"cde"xyz       --> "cde" is quoted
         *      abc\\\"cde"xyz      --> "xyz" is quoted (the terminal double-quote is assumed)
         *
         *      abc"""xyz           --> """ is quoted
         *      abc""""xyz          --> """ and "xyz" are quoted (the terminal double-quote is assumed)
         *      abc"""""xyz         --> """ is quoted
         *      abc""""""xyz        --> """ and """ are quoted
         *      abc"cde""xyz        --> "cde"" is quoted
         *      abc"xyz""           --> "xyz"" is quoted (the terminal double-quote is explicit)
         *
         *      abc""xyz            --> nothing is quoted
         *      abc""cde""xyz       --> nothing is quoted
         */

        [Fact]
        public void SplitUnquotedTest()
        {
            ArrayList sa;
            int emptySplits;

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abcdxyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abcdxyz");

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abcc dxyz");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abcc");
            sa[1].ShouldBe("dxyz");

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abcc;dxyz", ';');
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abcc");
            sa[1].ShouldBe("dxyz");

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abc,c;dxyz", ';', ',');
            sa.Count.ShouldBe(3);
            sa[0].ShouldBe("abc");
            sa[1].ShouldBe("c");
            sa[2].ShouldBe("dxyz");

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abc,c;dxyz", 2, false, false, out emptySplits, ';', ',');
            emptySplits.ShouldBe(0);
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc");
            sa[1].ShouldBe("c;dxyz");

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abc,,;dxyz", int.MaxValue, false, false, out emptySplits, ';', ',');
            emptySplits.ShouldBe(2);
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc");
            sa[1].ShouldBe("dxyz");

            // nothing quoted
            sa = QuotingUtilities.SplitUnquoted("abc,,;dxyz", int.MaxValue, true, false, out emptySplits, ';', ',');
            emptySplits.ShouldBe(0);
            sa.Count.ShouldBe(4);
            sa[0].ShouldBe("abc");
            sa[1].ShouldBe(String.Empty);
            sa[2].ShouldBe(String.Empty);
            sa[3].ShouldBe("dxyz");

            // "c d" is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"c d\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"c d\"xyz");

            // "x z" is quoted (the terminal double-quote is assumed)
            sa = QuotingUtilities.SplitUnquoted("abc\"x z");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"x z");

            // "x z" is quoted (the terminal double-quote is explicit)
            sa = QuotingUtilities.SplitUnquoted("abc\"x z\"");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"x z\"");

            // "x z" is quoted (the terminal double-quote is assumed)
            sa = QuotingUtilities.SplitUnquoted("abc\\\"cde\"x z");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\\\"cde\"x z");

            // "x z" is quoted (the terminal double-quote is assumed)
            // "c e" is not quoted
            sa = QuotingUtilities.SplitUnquoted("abc\\\"c e\"x z");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\\\"c");
            sa[1].ShouldBe("e\"x z");

            // "c e" is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\\\\\"c e\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\\\\\"c e\"xyz");

            // "c e" is quoted
            // "x z" is not quoted
            sa = QuotingUtilities.SplitUnquoted("abc\\\\\"c e\"x z");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\\\\\"c e\"x");
            sa[1].ShouldBe("z");

            // "x z" is quoted (the terminal double-quote is assumed)
            sa = QuotingUtilities.SplitUnquoted("abc\\\\\\\"cde\"x z");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\\\\\\\"cde\"x z");

            // "xyz" is quoted (the terminal double-quote is assumed)
            // "c e" is not quoted
            sa = QuotingUtilities.SplitUnquoted("abc\\\\\\\"c e\"x z");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\\\\\\\"c");
            sa[1].ShouldBe("e\"x z");

            // """ is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"\"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"\"\"xyz");

            // " "" is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\" \"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\" \"\"xyz");

            // "x z" is quoted (the terminal double-quote is assumed)
            sa = QuotingUtilities.SplitUnquoted("abc\"\" \"x z");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\"\"");
            sa[1].ShouldBe("\"x z");

            // " "" and "xyz" are quoted (the terminal double-quote is assumed)
            sa = QuotingUtilities.SplitUnquoted("abc\" \"\"\"x z");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\" \"\"\"x z");

            // """ is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"\"\"\"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"\"\"\"\"xyz");

            // """ is quoted
            // "x z" is not quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"\"\"\"\"x z");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\"\"\"\"\"x");
            sa[1].ShouldBe("z");

            // " "" is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\" \"\"\"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\" \"\"\"\"xyz");

            // """ and """ are quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"\"\"\"\"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"\"\"\"\"\"xyz");

            // " "" and " "" are quoted
            sa = QuotingUtilities.SplitUnquoted("abc\" \"\"\" \"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\" \"\"\" \"\"xyz");

            // """ and """ are quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"\"\" \"\"\"xyz");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\"\"\"");
            sa[1].ShouldBe("\"\"\"xyz");

            // """ and """ are quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"\"\" \"\"\"x z");
            sa.Count.ShouldBe(3);
            sa[0].ShouldBe("abc\"\"\"");
            sa[1].ShouldBe("\"\"\"x");
            sa[2].ShouldBe("z");

            // "c e"" is quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"c e\"\"xyz");
            sa.Count.ShouldBe(1);
            sa[0].ShouldBe("abc\"c e\"\"xyz");

            // "c e"" is quoted
            // "x z" is not quoted
            sa = QuotingUtilities.SplitUnquoted("abc\"c e\"\"x z");
            sa.Count.ShouldBe(2);
            sa[0].ShouldBe("abc\"c e\"\"x");
            sa[1].ShouldBe("z");

            // nothing is quoted
            sa = QuotingUtilities.SplitUnquoted("a c\"\"x z");
            sa.Count.ShouldBe(3);
            sa[0].ShouldBe("a");
            sa[1].ShouldBe("c\"\"x");
            sa[2].ShouldBe("z");

            // nothing is quoted
            sa = QuotingUtilities.SplitUnquoted("a c\"\"c e\"\"x z");
            sa.Count.ShouldBe(4);
            sa[0].ShouldBe("a");
            sa[1].ShouldBe("c\"\"c");
            sa[2].ShouldBe("e\"\"x");
            sa[3].ShouldBe("z");
        }

        [Fact]
        public void UnquoteTest()
        {
            int doubleQuotesRemoved;

            // "cde" is quoted
            QuotingUtilities.Unquote("abc\"cde\"xyz", out doubleQuotesRemoved).ShouldBe("abccdexyz");
            doubleQuotesRemoved.ShouldBe(2);

            // "xyz" is quoted (the terminal double-quote is assumed)
            QuotingUtilities.Unquote("abc\"xyz", out doubleQuotesRemoved).ShouldBe("abcxyz");
            doubleQuotesRemoved.ShouldBe(1);

            // "xyz" is quoted (the terminal double-quote is explicit)
            QuotingUtilities.Unquote("abc\"xyz\"", out doubleQuotesRemoved).ShouldBe("abcxyz");
            doubleQuotesRemoved.ShouldBe(2);

            // "xyz" is quoted (the terminal double-quote is assumed)
            QuotingUtilities.Unquote("abc\\\"cde\"xyz", out doubleQuotesRemoved).ShouldBe("abc\"cdexyz");
            doubleQuotesRemoved.ShouldBe(1);

            // "cde" is quoted
            QuotingUtilities.Unquote("abc\\\\\"cde\"xyz", out doubleQuotesRemoved).ShouldBe("abc\\cdexyz");
            doubleQuotesRemoved.ShouldBe(2);

            // "xyz" is quoted (the terminal double-quote is assumed)
            QuotingUtilities.Unquote("abc\\\\\\\"cde\"xyz", out doubleQuotesRemoved).ShouldBe("abc\\\"cdexyz");
            doubleQuotesRemoved.ShouldBe(1);

            // """ is quoted
            QuotingUtilities.Unquote("abc\"\"\"xyz", out doubleQuotesRemoved).ShouldBe("abc\"xyz");
            doubleQuotesRemoved.ShouldBe(2);

            // """ and "xyz" are quoted (the terminal double-quote is assumed)
            QuotingUtilities.Unquote("abc\"\"\"\"xyz", out doubleQuotesRemoved).ShouldBe("abc\"xyz");
            doubleQuotesRemoved.ShouldBe(3);

            // """ is quoted
            QuotingUtilities.Unquote("abc\"\"\"\"\"xyz", out doubleQuotesRemoved).ShouldBe("abc\"xyz");
            doubleQuotesRemoved.ShouldBe(4);

            // """ and """ are quoted
            QuotingUtilities.Unquote("abc\"\"\"\"\"\"xyz", out doubleQuotesRemoved).ShouldBe("abc\"\"xyz");
            doubleQuotesRemoved.ShouldBe(4);

            // "cde"" is quoted
            QuotingUtilities.Unquote("abc\"cde\"\"xyz", out doubleQuotesRemoved).ShouldBe("abccde\"xyz");
            doubleQuotesRemoved.ShouldBe(2);

            // "xyz"" is quoted (the terminal double-quote is explicit)
            QuotingUtilities.Unquote("abc\"xyz\"\"", out doubleQuotesRemoved).ShouldBe("abcxyz\"");
            doubleQuotesRemoved.ShouldBe(2);

            // nothing is quoted
            QuotingUtilities.Unquote("abc\"\"xyz", out doubleQuotesRemoved).ShouldBe("abcxyz");
            doubleQuotesRemoved.ShouldBe(2);

            // nothing is quoted
            QuotingUtilities.Unquote("abc\"\"cde\"\"xyz", out doubleQuotesRemoved).ShouldBe("abccdexyz");
            doubleQuotesRemoved.ShouldBe(4);
        }

        [Fact]
        public void ExtractSwitchParametersTest()
        {
            string commandLineArg = "\"/p:foo=\"bar";
            int doubleQuotesRemovedFromArg;
            string unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "p", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":\"foo=\"bar");
            doubleQuotesRemovedFromArg.ShouldBe(2);

            commandLineArg = "\"/p:foo=bar\"";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "p", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":foo=bar");
            doubleQuotesRemovedFromArg.ShouldBe(2);

            commandLineArg = "/p:foo=bar";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "p", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":foo=bar");
            doubleQuotesRemovedFromArg.ShouldBe(0);

            commandLineArg = "\"\"/p:foo=bar\"";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "p", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":foo=bar\"");
            doubleQuotesRemovedFromArg.ShouldBe(3);

            // this test is totally unreal -- we'd never attempt to extract switch parameters if the leading character is not a
            // switch indicator (either '-' or '/') -- here the leading character is a double-quote
            commandLineArg = "\"\"\"/p:foo=bar\"";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "/p", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":foo=bar\"");
            doubleQuotesRemovedFromArg.ShouldBe(3);

            commandLineArg = "\"/pr\"operty\":foo=bar";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "property", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":foo=bar");
            doubleQuotesRemovedFromArg.ShouldBe(3);

            commandLineArg = "\"/pr\"op\"\"erty\":foo=bar\"";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "property", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":foo=bar");
            doubleQuotesRemovedFromArg.ShouldBe(6);

            commandLineArg = "/p:\"foo foo\"=\"bar bar\";\"baz=onga\"";
            unquotedCommandLineArg = QuotingUtilities.Unquote(commandLineArg, out doubleQuotesRemovedFromArg);
            MSBuildApp.ExtractSwitchParameters(commandLineArg, unquotedCommandLineArg, doubleQuotesRemovedFromArg, "p", unquotedCommandLineArg.IndexOf(':')).ShouldBe(":\"foo foo\"=\"bar bar\";\"baz=onga\"");
            doubleQuotesRemovedFromArg.ShouldBe(6);
        }

        [Fact]
        public void Help()
        {
                MSBuildApp.Execute(
#if FEATURE_GET_COMMANDLINE
                    @"c:\bin\msbuild.exe -? "
#else
                    new [] {@"c:\bin\msbuild.exe", "-?"}
#endif
                ).ShouldBe(MSBuildApp.ExitType.Success);
        }

        [Fact]
        public void ErrorCommandLine()
        {
#if FEATURE_GET_COMMANDLINE
            MSBuildApp.Execute(@"c:\bin\msbuild.exe -junk").ShouldBe(MSBuildApp.ExitType.SwitchError);

            MSBuildApp.Execute(@"msbuild.exe -t").ShouldBe(MSBuildApp.ExitType.SwitchError);

            MSBuildApp.Execute(@"msbuild.exe @bogus.rsp").ShouldBe(MSBuildApp.ExitType.InitializationError);
#else
            MSBuildApp.Execute(new[] { @"c:\bin\msbuild.exe", "-junk" }).ShouldBe(MSBuildApp.ExitType.SwitchError);

            MSBuildApp.Execute(new[] { @"msbuild.exe", "-t" }).ShouldBe(MSBuildApp.ExitType.SwitchError);

            MSBuildApp.Execute(new[] { @"msbuild.exe", "@bogus.rsp" }).ShouldBe(MSBuildApp.ExitType.InitializationError);
#endif
        }

        [Fact]
        public void ValidVerbosities()
        {
            MSBuildApp.ProcessVerbositySwitch("Q").ShouldBe(LoggerVerbosity.Quiet);
            MSBuildApp.ProcessVerbositySwitch("quiet").ShouldBe(LoggerVerbosity.Quiet);
            MSBuildApp.ProcessVerbositySwitch("m").ShouldBe(LoggerVerbosity.Minimal);
            MSBuildApp.ProcessVerbositySwitch("minimal").ShouldBe(LoggerVerbosity.Minimal);
            MSBuildApp.ProcessVerbositySwitch("N").ShouldBe(LoggerVerbosity.Normal);
            MSBuildApp.ProcessVerbositySwitch("normal").ShouldBe(LoggerVerbosity.Normal);
            MSBuildApp.ProcessVerbositySwitch("d").ShouldBe(LoggerVerbosity.Detailed);
            MSBuildApp.ProcessVerbositySwitch("detailed").ShouldBe(LoggerVerbosity.Detailed);
            MSBuildApp.ProcessVerbositySwitch("diag").ShouldBe(LoggerVerbosity.Diagnostic);
            MSBuildApp.ProcessVerbositySwitch("DIAGNOSTIC").ShouldBe(LoggerVerbosity.Diagnostic);
        }

        [Fact]
        public void InvalidVerbosity()
        {
            Should.Throw<CommandLineSwitchException>(() =>
            {
                MSBuildApp.ProcessVerbositySwitch("loquacious");
            }
           );
        }
        [Fact]
        public void ValidMaxCPUCountSwitch()
        {
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "1" }).ShouldBe(1);
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "2" }).ShouldBe(2);
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "3" }).ShouldBe(3);
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "4" }).ShouldBe(4);
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "8" }).ShouldBe(8);
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "63" }).ShouldBe(63);

            // Should pick last value
            MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "8", "4" }).ShouldBe(4);
        }

        [Fact]
        public void InvalidMaxCPUCountSwitch1()
        {
            Should.Throw<CommandLineSwitchException>(() =>
            {
                MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "-1" });
            }
           );
        }

        [Fact]
        public void InvalidMaxCPUCountSwitch2()
        {
            Should.Throw<CommandLineSwitchException>(() =>
            {
                MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "0" });
            }
           );
        }

        [Fact]
        public void InvalidMaxCPUCountSwitch3()
        {
            Should.Throw<CommandLineSwitchException>(() =>
            {
                // Too big
                MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "foo" });
            }
           );
        }

        [Fact]
        public void InvalidMaxCPUCountSwitch4()
        {
            Should.Throw<CommandLineSwitchException>(() =>
            {
                MSBuildApp.ProcessMaxCPUCountSwitch(new string[] { "1025" });
            }
           );
        }

#if FEATURE_CULTUREINFO_CONSOLE_FALLBACK
        /// <summary>
        /// Regression test for bug where the MSBuild.exe command-line app
        /// would sometimes set the UI culture to just "en" which is considered a "neutral" UI
        /// culture, which didn't allow for certain kinds of string formatting/parsing.
        /// </summary>
        /// <remarks>
        /// fr-FR, de-DE, and fr-CA are guaranteed to be available on all BVTs, so we must use one of these
        /// </remarks>
        [Fact]
        public void SetConsoleUICulture()
        {
            Thread thisThread = Thread.CurrentThread;

            // Save the current UI culture, so we can restore it at the end of this unit test.
            CultureInfo originalUICulture = thisThread.CurrentUICulture;

            thisThread.CurrentUICulture = new CultureInfo("fr-FR");
            MSBuildApp.SetConsoleUI();

            // Make sure this doesn't throw an exception.
            string bar = String.Format(CultureInfo.CurrentUICulture, "{0}", (int)1);

            // Restore the current UI culture back to the way it was at the beginning of this unit test.
            thisThread.CurrentUICulture = originalUICulture;
        }
#endif

#if FEATURE_SYSTEM_CONFIGURATION
        /// <summary>
        /// Invalid configuration file should not dump stack.
        /// </summary>
        [Fact]
        public void ConfigurationInvalid()
        {
            string startDirectory = null;
            string output = null;
            string oldValueForMSBuildOldOM = null;

            try
            {
                oldValueForMSBuildOldOM = Environment.GetEnvironmentVariable("MSBuildOldOM");
                Environment.SetEnvironmentVariable("MSBuildOldOM", "");

                startDirectory = CopyMSBuild();
                var msbuildExeName = Path.GetFileName(RunnerUtilities.PathToCurrentlyRunningMsBuildExe);
                var newPathToMSBuildExe = Path.Combine(startDirectory, msbuildExeName);
                var pathToConfigFile = Path.Combine(startDirectory, msbuildExeName + ".config");

                string configContent = @"<?xml version =""1.0""?>
                                            <configuration>
                                                <configSections>
                                                    <section name=""msbuildToolsets"" type=""Microsoft.Build.Evaluation.ToolsetConfigurationSection, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" />
                                                    <foo/>
                                                </configSections>
                                                <startup>
                                                    <supportedRuntime version=""v4.0""/>
                                                </startup>
                                                <foo/>
                                                <msbuildToolsets default=""X"">
                                                <foo/>
                                                    <toolset toolsVersion=""X"">
                                                        <foo/>
                                                    <property name=""MSBuildBinPath"" value=""Y""/>
                                                    <foo/>
                                                    </toolset>
                                                <foo/>
                                                </msbuildToolsets>
                                                <foo/>
                                            </configuration>";
                File.WriteAllText(pathToConfigFile, configContent);

                var pathToProjectFile = Path.Combine(startDirectory, "foo.proj");
                string projectString =
                   "<?xml version='1.0' encoding='utf-8'?>" +
                    "<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003' ToolsVersion='X'>" +
                    "<Target Name='t'></Target>" +
                    "</Project>";
                File.WriteAllText(pathToProjectFile, projectString);

                var msbuildParameters = "\"" + pathToProjectFile + "\"";

                bool successfulExit;
                output = RunnerUtilities.ExecMSBuild(newPathToMSBuildExe, msbuildParameters, out successfulExit);
                successfulExit.ShouldBeFalse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                if (output != null)
                {
                    Console.WriteLine(output);
                }

                try
                {
                    // Process does not let go its lock on the exe file until about 1 millisecond after
                    // p.WaitForExit() returns. Do I know why? No I don't.
                    RobustDelete(startDirectory);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("MSBuildOldOM", oldValueForMSBuildOldOM);
                }
            }

            // If there's a space in the %TEMP% path, the config file is read in the static constructor by the URI class and we catch there;
            // if there's not, we will catch when we try to read the toolsets. Either is fine; we just want to not crash.
            (output.Contains("MSB1043") || output.Contains("MSB4136")).ShouldBeTrue("Output should contain 'MSB1043' or 'MSB4136'");


        }
#endif

        /// <summary>
        /// Try hard to delete a file or directory specified
        /// </summary>
        private void RobustDelete(string path)
        {
            if (path != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (Directory.Exists(path))
                        {
                            FileUtilities.DeleteWithoutTrailingBackslash(path, true /*and files*/);
                        }
                        else if (File.Exists(path))
                        {
                            File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly); // make writable
                            File.Delete(path);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Thread.Sleep(10);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Tests that the environment gets passed on to the node during build.
        /// </summary>
        [Fact]
        public void TestEnvironment()
        {
            string projectString = ObjectModelHelpers.CleanupFileContents(
                   @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <Project ToolsVersion=""msbuilddefaulttoolsversion"" xmlns=""msbuildnamespace"">
                    <Target Name=""t""><Error Text='Error' Condition=""'$(MyEnvVariable)' == ''""/></Target>
                    </Project>");
            string tempdir = Path.GetTempPath();
            string projectFileName = Path.Combine(tempdir, "msbEnvironmenttest.proj");
            string quotedProjectFileName = "\"" + projectFileName + "\"";

            try
            {
                Environment.SetEnvironmentVariable("MyEnvVariable", "1");
                using (StreamWriter sw = FileUtilities.OpenWrite(projectFileName, false))
                {
                    sw.WriteLine(projectString);
                }
                //Should pass
#if FEATURE_GET_COMMANDLINE
                MSBuildApp.Execute(@"c:\bin\msbuild.exe " + quotedProjectFileName).ShouldBe(MSBuildApp.ExitType.Success);
#else
                MSBuildApp.Execute(new[] { @"c:\bin\msbuild.exe", quotedProjectFileName }).ShouldBe(MSBuildApp.ExitType.Success);
#endif
            }
            finally
            {
                Environment.SetEnvironmentVariable("MyEnvVariable", null);
                File.Delete(projectFileName);
            }
        }

        [Fact]
        public void MSBuildEngineLogger()
        {
            string projectString =
                   "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<Project ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">" +
                    "<Target Name=\"t\"><Message Text=\"Hello\"/></Target>" +
                    "</Project>";
            string tempdir = Path.GetTempPath();
            string projectFileName = Path.Combine(tempdir, "msbLoggertest.proj");
            string quotedProjectFileName = "\"" + projectFileName + "\"";

            try
            {
                using (StreamWriter sw = FileUtilities.OpenWrite(projectFileName, false))
                {
                    sw.WriteLine(projectString);
                }
#if FEATURE_GET_COMMANDLINE
                //Should pass
                MSBuildApp.Execute(@"c:\bin\msbuild.exe /logger:FileLogger,""Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" " + quotedProjectFileName).ShouldBe(MSBuildApp.ExitType.Success);

                //Should fail as we are not changing existing lines
                MSBuildApp.Execute(@"c:\bin\msbuild.exe /logger:FileLogger,Microsoft.Build,Version=11111 " + quotedProjectFileName).ShouldBe(MSBuildApp.ExitType.InitializationError);
#else
                //Should pass
                MSBuildApp.Execute(
                    new[]
                        {
                            NativeMethodsShared.IsWindows ? @"c:\bin\msbuild.exe" : "/msbuild.exe",
                            @"/logger:FileLogger,""Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a""",
                            quotedProjectFileName
                        }).ShouldBe(MSBuildApp.ExitType.Success);

                //Should fail as we are not changing existing lines
                MSBuildApp.Execute(
                    new[]
                        {
                            NativeMethodsShared.IsWindows ? @"c:\bin\msbuild.exe" : "/msbuild.exe",
                            "/logger:FileLogger,Microsoft.Build,Version=11111", quotedProjectFileName
                        }).ShouldBe(MSBuildApp.ExitType.InitializationError);
#endif
            }
            finally
            {
                File.Delete(projectFileName);
            }
        }

#if FEATURE_SPECIAL_FOLDERS
        private string _pathToArbitraryBogusFile = NativeMethodsShared.IsWindows // OK on 64 bit as well
                                                        ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe")
                                                        : "/bin/cat";
#else
        private string _pathToArbitraryBogusFile = NativeMethodsShared.IsWindows // OK on 64 bit as well
                                                        ? Path.Combine(FileUtilities.GetFolderPath(FileUtilities.SpecialFolder.System), "notepad.exe")
                                                        : "/bin/cat";
#endif

        /// <summary>
        /// Basic case
        /// </summary>
        [Fact]
        public void GetCommandLine()
        {
            var msbuildParameters = "\"" + _pathToArbitraryBogusFile + "\"" + (NativeMethodsShared.IsWindows ? " /v:diag" : " -v:diag");
            File.Exists(_pathToArbitraryBogusFile).ShouldBeTrue();

            bool successfulExit;
            string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
            successfulExit.ShouldBeFalse();

            output.ShouldContain(RunnerUtilities.PathToCurrentlyRunningMsBuildExe + (NativeMethodsShared.IsWindows ? " /v:diag " : " -v:diag ") + _pathToArbitraryBogusFile, Case.Insensitive);
        }

        /// <summary>
        /// Quoted path
        /// </summary>
        [Fact]
        public void GetCommandLineQuotedExe()
        {
            var msbuildParameters = "\"" + _pathToArbitraryBogusFile + "\"" + (NativeMethodsShared.IsWindows ? " /v:diag" : " -v:diag");
            File.Exists(_pathToArbitraryBogusFile).ShouldBeTrue();

            bool successfulExit;
            string pathToMSBuildExe = RunnerUtilities.PathToCurrentlyRunningMsBuildExe;
            // This @pathToMSBuildExe is used directly with Process, so don't quote it on
            // Unix
            if (NativeMethodsShared.IsWindows)
            {
                pathToMSBuildExe = "\"" + pathToMSBuildExe + "\"";
            }

            string output = RunnerUtilities.ExecMSBuild(pathToMSBuildExe, msbuildParameters, out successfulExit);
            successfulExit.ShouldBeFalse();

            output.ShouldContain(RunnerUtilities.PathToCurrentlyRunningMsBuildExe + (NativeMethodsShared.IsWindows ? " /v:diag " : " -v:diag ") + _pathToArbitraryBogusFile, Case.Insensitive);
        }

        /// <summary>
        /// On path
        /// </summary>
        [Fact]
        public void GetCommandLineQuotedExeOnPath()
        {
            string output = null;
            string current = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(RunnerUtilities.PathToCurrentlyRunningMsBuildExe));

                var msbuildParameters = "\"" + _pathToArbitraryBogusFile + "\"" + (NativeMethodsShared.IsWindows ? " /v:diag" : " -v:diag");

                bool successfulExit;
                output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeFalse();
            }
            finally
            {
                Directory.SetCurrentDirectory(current);
            }

            output.ShouldContain(RunnerUtilities.PathToCurrentlyRunningMsBuildExe + (NativeMethodsShared.IsWindows ? " /v:diag " : " -v:diag ") + _pathToArbitraryBogusFile, Case.Insensitive);
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read, and should
        /// take priority over any other response files.
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryFoundImplicitly()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");
            string rspPath = Path.Combine(directory, AutoResponseFileName);

            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                string rspContent = "/p:A=1";
                File.WriteAllText(rspPath, rspContent);

                // Find the project in the current directory
                Directory.SetCurrentDirectory(directory);

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(String.Empty, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=1]");
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
                File.Delete(projectPath);
                File.Delete(rspPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read, and should
        /// take priority over any other response files.
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryExplicit()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");
            string rspPath = Path.Combine(directory, AutoResponseFileName);

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                string rspContent = "/p:A=1";
                File.WriteAllText(rspPath, rspContent);

                var msbuildParameters = "\"" + projectPath + "\"";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=1]");
            }
            finally
            {
                File.Delete(projectPath);
                File.Delete(rspPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read, and not any random .rsp
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryRandomName()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");
            string rspPath = Path.Combine(directory, "foo.rsp");

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                string rspContent = "/p:A=1";
                File.WriteAllText(rspPath, rspContent);

                var msbuildParameters = "\"" + projectPath + "\"";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=]");
            }
            finally
            {
                File.Delete(projectPath);
                File.Delete(rspPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read,
        /// but lower precedence than the actual command line
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryCommandLineWins()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");
            string rspPath = Path.Combine(directory, AutoResponseFileName);

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                string rspContent = "/p:A=1";
                File.WriteAllText(rspPath, rspContent);

                var msbuildParameters = "\"" + projectPath + "\"" + " /p:A=2";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=2]");
            }
            finally
            {
                File.Delete(projectPath);
                File.Delete(rspPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read,
        /// but lower precedence than the actual command line and higher than the msbuild.rsp next to msbuild.exe
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryWinsOverMainMSBuildRsp()
        {
            string directory = null;
            string exeDirectory = null;

            try
            {
                directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(directory);
                string projectPath = Path.Combine(directory, "my.proj");
                string rspPath = Path.Combine(directory, AutoResponseFileName);

                exeDirectory = CopyMSBuild();
                string exePath = Path.Combine(exeDirectory, MSBuildExeName);
                string mainRspPath = Path.Combine(exeDirectory, AutoResponseFileName);

                Directory.CreateDirectory(exeDirectory);

                File.WriteAllText(mainRspPath, "/p:A=0");

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                File.WriteAllText(rspPath, "/p:A=1");

                var msbuildParameters = "\"" + projectPath + "\"";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(exePath, msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=1]");
            }
            finally
            {
                RobustDelete(directory);
                RobustDelete(exeDirectory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read,
        /// but not if it's the same as the msbuild.exe directory
        /// </summary>
        [Fact]
        public void ProjectDirectoryIsMSBuildExeDirectory()
        {
            string directory = null;

            try
            {
                directory = CopyMSBuild();
                string projectPath = Path.Combine(directory, "my.proj");
                string rspPath = Path.Combine(directory, AutoResponseFileName);
                string exePath = Path.Combine(directory, MSBuildExeName);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                File.WriteAllText(rspPath, "/p:A=1");

                var msbuildParameters = "\"" + projectPath + "\"";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(exePath, msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=1]");
            }
            finally
            {
                RobustDelete(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution with /noautoresponse in, is an error
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryItselfWithNoAutoResponseSwitch()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");
            string rspPath = Path.Combine(directory, AutoResponseFileName);

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                string rspContent = "/p:A=1 /noautoresponse";
                File.WriteAllText(rspPath, rspContent);

                var msbuildParameters = "\"" + projectPath + "\"";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeFalse();

                output.ShouldContain("MSB1027"); // msbuild.rsp cannot have /noautoresponse in it
            }
            finally
            {
                File.Delete(projectPath);
                File.Delete(rspPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be ignored if cmd line has /noautoresponse
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryButCommandLineNoAutoResponseSwitch()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");
            string rspPath = Path.Combine(directory, AutoResponseFileName);

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                string rspContent = "/p:A=1 /noautoresponse";
                File.WriteAllText(rspPath, rspContent);

                var msbuildParameters = "\"" + projectPath + "\" /noautoresponse";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=]");
            }
            finally
            {
                File.Delete(projectPath);
                File.Delete(rspPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

        /// <summary>
        /// Any msbuild.rsp in the directory of the specified project/solution should be read, and should
        /// take priority over any other response files. Sanity test when there isn't one.
        /// </summary>
        [Fact]
        public void ResponseFileInProjectDirectoryNullCase()
        {
            string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            string projectPath = Path.Combine(directory, "my.proj");

            try
            {
                Directory.CreateDirectory(directory);

                string content = ObjectModelHelpers.CleanupFileContents("<Project ToolsVersion='msbuilddefaulttoolsversion' xmlns='msbuildnamespace'><Target Name='t'><Warning Text='[A=$(A)]'/></Target></Project>");
                File.WriteAllText(projectPath, content);

                var msbuildParameters = "\"" + projectPath + "\"";

                bool successfulExit;
                string output = RunnerUtilities.ExecMSBuild(msbuildParameters, out successfulExit);
                successfulExit.ShouldBeTrue();

                output.ShouldContain("[A=]");
            }
            finally
            {
                File.Delete(projectPath);
                FileUtilities.DeleteWithoutTrailingBackslash(directory);
            }
        }

#region IgnoreProjectExtensionTests

        /// <summary>
        /// Test the case where the extension is a valid extension but is not a project
        /// file extension. In this case no files should be ignored
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchOneProjNotFoundExtension()
        {
            string[] projects = new string[] { "my.proj" };
            string[] extensionsToIgnore = new string[] { ".phantomextension" };
            IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"
        }

        /// <summary>
        /// Test the case where two identical extensions are asked to be ignored
        /// </summary>
        [Fact]
        public void TestTwoIdenticalExtensionsToIgnore()
        {
            string[] projects = new string[] { "my.proj" };
            string[] extensionsToIgnore = new string[] { ".phantomextension", ".phantomextension" };
            IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"
        }
        /// <summary>
        /// Pass a null and an empty list of project extensions to ignore, this simulates the switch not being set on the commandline
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchNullandEmptyProjectsToIgnore()
        {
            string[] projects = new string[] { "my.proj" };
            string[] extensionsToIgnore = (string[])null;
            IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"

            extensionsToIgnore = new string[] { };
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"
        }

        /// <summary>
        /// Pass in one extension and a null value
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchNullInList()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "my.proj" };
                string[] extensionsToIgnore = new string[] { ".phantomextension", null };
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"
            }
           );
        }
        /// <summary>
        /// Pass in one extension and an empty string
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchEmptyInList()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "my.proj" };
                string[] extensionsToIgnore = new string[] { ".phantomextension", string.Empty };
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"
            }
           );
        }
        /// <summary>
        /// If only a dot is specified then the extension is invalid
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchExtensionWithoutDot()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "my.proj" };
                string[] extensionsToIgnore = new string[] { "phantomextension" };
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase);
            }
           );
        }
        /// <summary>
        /// Put some junk into the extension, in this case there should be an exception
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchMalformed()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "my.proj" };
                string[] extensionsToIgnore = new string[] { ".C:\\boocatmoo.a" };
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("my.proj", StringCompareShould.IgnoreCase); // "Expected my.proj to be only project found"
            }
           );
        }
        /// <summary>
        /// Test what happens if there are no project or solution files in the directory
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchWildcards()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "my.proj" };
                string[] extensionsToIgnore = new string[] { ".proj*", ".nativeproj?" };
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        [Fact]
        public void TestProcessProjectSwitch()
        {
            string[] projects = new string[] { "test.nativeproj", "test.vcproj" };
            string[] extensionsToIgnore = new string[] { ".phantomextension", ".vcproj" };
            IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.nativeproj", StringCompareShould.IgnoreCase); // "Expected test.nativeproj to be only project found"

            projects = new string[] { "test.nativeproj", "test.vcproj", "test.proj" };
            extensionsToIgnore = new string[] { ".phantomextension", ".vcproj" };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.proj", StringCompareShould.IgnoreCase); // "Expected test.proj to be only project found"

            projects = new string[] { "test.nativeproj", "test.vcproj" };
            extensionsToIgnore = new string[] { ".vcproj" };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.nativeproj", StringCompareShould.IgnoreCase); // "Expected test.nativeproj to be only project found"

            projects = new string[] { "test.proj", "test.sln" };
            extensionsToIgnore = new string[] { ".vcproj" };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.sln", StringCompareShould.IgnoreCase); // "Expected test.sln to be only solution found"

            projects = new string[] { "test.proj", "test.sln", "test.proj~", "test.sln~" };
            extensionsToIgnore = new string[] { };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.sln", StringCompareShould.IgnoreCase); // "Expected test.sln to be only solution found"

            projects = new string[] { "test.proj" };
            extensionsToIgnore = new string[] { };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.proj", StringCompareShould.IgnoreCase); // "Expected test.proj to be only project found"

            projects = new string[] { "test.proj", "test.proj~" };
            extensionsToIgnore = new string[] { };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.proj", StringCompareShould.IgnoreCase); // "Expected test.proj to be only project found"

            projects = new string[] { "test.sln" };
            extensionsToIgnore = new string[] { };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.sln", StringCompareShould.IgnoreCase); // "Expected test.sln to be only solution found"

            projects = new string[] { "test.sln", "test.sln~" };
            extensionsToIgnore = new string[] { };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.sln", StringCompareShould.IgnoreCase); // "Expected test.sln to be only solution found"


            projects = new string[] { "test.sln~", "test.sln" };
            extensionsToIgnore = new string[] { };
            projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.sln", StringCompareShould.IgnoreCase); // "Expected test.sln to be only solution found"
        }


        /// <summary>
        /// Ignore .sln and .vcproj files to replicate Building_DF_LKG functionality
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchReplicateBuildingDFLKG()
        {
            string[] projects = new string[] { "test.proj", "test.sln", "Foo.vcproj" };
            string[] extensionsToIgnore = { ".sln", ".vcproj" };
            IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
            MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles).ShouldBe("test.proj"); // "Expected test.proj to be only project found"
        }


        /// <summary>
        /// Test the case where we remove all of the project extensions that exist in the directory
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchRemovedAllprojects()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects;
                string[] extensionsToIgnore = null;
                projects = new string[] { "test.nativeproj", "test.vcproj" };
                extensionsToIgnore = new string[] { ".nativeproj", ".vcproj" };
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Test the case where there is a solution and a project in the same directory but they have different names
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchSlnProjDifferentNames()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "test.proj", "Different.sln" };
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Test the case where we have two proj files in the same directory
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchTwoProj()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "test.proj", "Different.proj" };
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Test the case where we have two native project files in the same directory
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchTwoNative()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "test.nativeproj", "Different.nativeproj" };
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Test when there are two solutions in the same directory
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchTwoSolutions()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "test.sln", "Different.sln" };
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Check the case where there are more than two projects in the directory and one is a proj file
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchMoreThenTwoProj()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { "test.nativeproj", "Different.csproj", "Another.proj" };
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Test what happens if there are no project or solution files in the directory
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchNoProjectOrSolution()
        {
            Should.Throw<InitializationException>(() =>
            {
                string[] projects = new string[] { };
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(projects);
                MSBuildApp.ProcessProjectSwitch(new string[0] { }, extensionsToIgnore, projectHelper.GetFiles);
            }
           );
        }
        /// <summary>
        /// Helper class to simulate directory work for ignore project extensions
        /// </summary>
        internal class IgnoreProjectExtensionsHelper
        {
            private List<string> _directoryFileNameList;

            /// <summary>
            /// Takes in a list of file names to simulate as being in a directory
            /// </summary>
            /// <param name="filesInDirectory"></param>
            internal IgnoreProjectExtensionsHelper(string[] filesInDirectory)
            {
                _directoryFileNameList = new List<string>();
                foreach (string file in filesInDirectory)
                {
                    _directoryFileNameList.Add(file);
                }
            }

            /// <summary>
            /// Mocks System.IO.GetFiles. Takes in known search patterns and returns files which
            /// are provided through the constructor
            /// </summary>
            /// <param name="path">not used</param>
            /// <param name="searchPattern">Pattern of files to return</param>
            /// <returns></returns>
            internal string[] GetFiles(string path, string searchPattern)
            {
                List<string> fileNamesToReturn = new List<string>();
                foreach (string file in _directoryFileNameList)
                {
                    if (String.Compare(searchPattern, "*.sln", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (String.Compare(Path.GetExtension(file), ".sln", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            fileNamesToReturn.Add(file);
                        }
                    }
                    else if (String.Compare(searchPattern, "*.*proj", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (Path.GetExtension(file).Contains("proj"))
                        {
                            fileNamesToReturn.Add(file);
                        }
                    }
                }
                return fileNamesToReturn.ToArray();
            }
        }

        /// <summary>
        /// Verifies that when a directory is specified that a project can be found.
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchDirectory()
        {
            string projectDirectory = Directory.CreateDirectory(Path.Combine(ObjectModelHelpers.TempProjectDir, Guid.NewGuid().ToString("N"))).FullName;

            try
            {
                string expectedProject = "project1.proj";
                string[] extensionsToIgnore = null;
                IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(new[] { expectedProject });
                string actualProject = MSBuildApp.ProcessProjectSwitch(new[] { projectDirectory }, extensionsToIgnore, projectHelper.GetFiles);

                actualProject.ShouldBe(expectedProject);
            }
            finally
            {
                RobustDelete(projectDirectory);
            }
        }

        /// <summary>
        /// Verifies that when a directory is specified and there are multiple projects that the correct error is thrown.
        /// </summary>
        [Fact]
        public void TestProcessProjectSwitchDirectoryMultipleProjects()
        {
            string projectDirectory = Directory.CreateDirectory(Path.Combine(ObjectModelHelpers.TempProjectDir, Guid.NewGuid().ToString("N"))).FullName;

            try
            {
                InitializationException exception = Should.Throw<InitializationException>(() =>
                {
                    string[] extensionsToIgnore = null;
                    IgnoreProjectExtensionsHelper projectHelper = new IgnoreProjectExtensionsHelper(new[] { "project1.proj", "project2.proj" });
                    MSBuildApp.ProcessProjectSwitch(new[] { projectDirectory }, extensionsToIgnore, projectHelper.GetFiles);
                });

                exception.Message.ShouldBe(ResourceUtilities.FormatResourceString("AmbiguousProjectDirectoryError", projectDirectory));
            }
            finally
            {
                RobustDelete(projectDirectory);
            }
        }
#endregion

#region ProcessFileLoggerSwitches
        /// <summary>
        /// Test the case where no file logger switches are given, should be no file loggers attached
        /// </summary>
        [Fact]
        public void TestProcessFileLoggerSwitch1()
        {
            bool distributedFileLogger = false;
            string[] fileLoggerParameters = null;
            List<DistributedLoggerRecord> distributedLoggerRecords = new List<DistributedLoggerRecord>();

            ArrayList loggers = new ArrayList();
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            distributedLoggerRecords.Count.ShouldBe(0); // "Expected no distributed loggers to be attached"
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
        }

        /// <summary>
        /// Test the case where a central logger and distributed logger are attached
        /// </summary>
        [Fact]
        public void TestProcessFileLoggerSwitch2()
        {
            bool distributedFileLogger = true;
            string[] fileLoggerParameters = null;
            List<DistributedLoggerRecord> distributedLoggerRecords = new List<DistributedLoggerRecord>();

            ArrayList loggers = new ArrayList();
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected one distributed loggers to be attached"
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
        }

        /// <summary>
        /// Test the case where a central file logger is attached but no distributed logger
        /// </summary>
        [Fact]
        public void TestProcessFileLoggerSwitch3()
        {
            bool distributedFileLogger = false;
            string[] fileLoggerParameters = null;
            List<DistributedLoggerRecord> distributedLoggerRecords = new List<DistributedLoggerRecord>();

            ArrayList loggers = new ArrayList();
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            distributedLoggerRecords.Count.ShouldBe(0); // "Expected no distributed loggers to be attached"
            loggers.Count.ShouldBe(0); // "Expected a central loggers to be attached"

            // add a set of parameters and make sure the logger has those parameters
            distributedLoggerRecords = new List<DistributedLoggerRecord>();

            loggers = new ArrayList();
            fileLoggerParameters = new string[1] { "Parameter" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            distributedLoggerRecords.Count.ShouldBe(0); // "Expected no distributed loggers to be attached"
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"

            distributedLoggerRecords = new List<DistributedLoggerRecord>();

            loggers = new ArrayList();
            fileLoggerParameters = new string[2] { "Parameter1", "Parameter" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            distributedLoggerRecords.Count.ShouldBe(0); // "Expected no distributed loggers to be attached"
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
        }

        /// <summary>
        /// Test the case where a distributed file logger is attached but no central logger
        /// </summary>
        [Fact]
        public void TestProcessFileLoggerSwitch4()
        {
            bool distributedFileLogger = true;
            string[] fileLoggerParameters = null;
            List<DistributedLoggerRecord> distributedLoggerRecords = new List<DistributedLoggerRecord>();

            ArrayList loggers = new ArrayList();
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe($"logFile={Path.Combine(Directory.GetCurrentDirectory(), "MSBuild.log")}", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"

            // Not add a set of parameters and make sure the logger has those parameters
            distributedLoggerRecords = new List<DistributedLoggerRecord>();

            loggers = new ArrayList();
            fileLoggerParameters = new string[1] { "verbosity=Normal;" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe($"{fileLoggerParameters[0]};logFile={Path.Combine(Directory.GetCurrentDirectory(), "MSBuild.log")}", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"

            // Not add a set of parameters and make sure the logger has those parameters
            distributedLoggerRecords = new List<DistributedLoggerRecord>();

            loggers = new ArrayList();
            fileLoggerParameters = new string[2] { "verbosity=Normal", "" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe($"{fileLoggerParameters[0]};logFile={Path.Combine(Directory.GetCurrentDirectory(), "MSBuild.log")}", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"

            // Not add a set of parameters and make sure the logger has those parameters
            distributedLoggerRecords = new List<DistributedLoggerRecord>();

            loggers = new ArrayList();
            fileLoggerParameters = new string[2] { "", "Parameter1" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe($";Parameter1;logFile={Path.Combine(Directory.GetCurrentDirectory(), "MSBuild.log")}", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"

            // Not add a set of parameters and make sure the logger has those parameters
            distributedLoggerRecords = new List<DistributedLoggerRecord>();

            loggers = new ArrayList();
            fileLoggerParameters = new string[2] { "Parameter1", "verbosity=Normal;logfile=" + (NativeMethodsShared.IsWindows ? "c:\\temp\\cat.log" : "/tmp/cat.log") };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe(fileLoggerParameters[0] + ";" + fileLoggerParameters[1], StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"

            distributedLoggerRecords = new List<DistributedLoggerRecord>();
            loggers = new ArrayList();
            fileLoggerParameters = new string[2] { "Parameter1", "verbosity=Normal;logfile=" + Path.Combine("..", "cat.log") + ";Parameter1" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe($"Parameter1;verbosity=Normal;logFile={Path.Combine(Directory.GetCurrentDirectory(), "..", "cat.log")};Parameter1", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"

            loggers = new ArrayList();
            distributedLoggerRecords = new List<DistributedLoggerRecord>();
            fileLoggerParameters = new string[6] { "Parameter1", ";Parameter;", "", ";", ";Parameter", "Parameter;" };
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           2
                       );
            distributedLoggerRecords[0].ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe($"Parameter1;Parameter;;;Parameter;Parameter;logFile={Path.Combine(Directory.GetCurrentDirectory(), "msbuild.log")}", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"
        }

        /// <summary>
        /// Verify when in single proc mode the file logger enables mp logging and does not show eventId
        /// </summary>
        [Fact]
        public void TestProcessFileLoggerSwitch5()
        {
            bool distributedFileLogger = false;
            string[] fileLoggerParameters = null;
            List<DistributedLoggerRecord> distributedLoggerRecords = new List<DistributedLoggerRecord>();

            ArrayList loggers = new ArrayList();
            MSBuildApp.ProcessDistributedFileLogger
                       (
                           distributedFileLogger,
                           fileLoggerParameters,
                           distributedLoggerRecords,
                           loggers,
                           1
                       );
            distributedLoggerRecords.Count.ShouldBe(0); // "Expected no distributed loggers to be attached"
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
        }
#endregion

#region ProcessConsoleLoggerSwitches
        [Fact]
        public void ProcessConsoleLoggerSwitches()
        {
            ArrayList loggers = new ArrayList();
            LoggerVerbosity verbosity = LoggerVerbosity.Normal;
            List<DistributedLoggerRecord> distributedLoggerRecords = new List<DistributedLoggerRecord>(); ;
            string[] consoleLoggerParameters = new string[6] { "Parameter1", ";Parameter;", "", ";", ";Parameter", "Parameter;" };

            MSBuildApp.ProcessConsoleLoggerSwitch
                       (
                           true,
                           consoleLoggerParameters,
                           distributedLoggerRecords,
                           verbosity,
                           1,
                           loggers
                       );
            loggers.Count.ShouldBe(0); // "Expected no central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(0); // "Expected no distributed loggers to be attached"

            MSBuildApp.ProcessConsoleLoggerSwitch
                       (
                           false,
                           consoleLoggerParameters,
                           distributedLoggerRecords,
                           verbosity,
                           1,
                           loggers
                       );
            loggers.Count.ShouldBe(1); // "Expected a central loggers to be attached"
            ((ILogger)loggers[0]).Parameters.ShouldBe("EnableMPLogging;SHOWPROJECTFILE=TRUE;Parameter1;Parameter;;;parameter;Parameter", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameters passed in"

            MSBuildApp.ProcessConsoleLoggerSwitch
                       (
                          false,
                          consoleLoggerParameters,
                          distributedLoggerRecords,
                          verbosity,
                          2,
                          loggers
                      );
            loggers.Count.ShouldBe(1); // "Expected a central loggers to be attached"
            distributedLoggerRecords.Count.ShouldBe(1); // "Expected a distributed logger to be attached"
            DistributedLoggerRecord distributedLogger = ((DistributedLoggerRecord)distributedLoggerRecords[0]);
            distributedLogger.CentralLogger.Parameters.ShouldBe("SHOWPROJECTFILE=TRUE;Parameter1;Parameter;;;parameter;Parameter", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameters passed in"
            distributedLogger.ForwardingLoggerDescription.LoggerSwitchParameters.ShouldBe("SHOWPROJECTFILE=TRUE;Parameter1;Parameter;;;Parameter;Parameter", StringCompareShould.IgnoreCase); // "Expected parameter in logger to match parameter passed in"
        }
#endregion

        [Fact]
        public void RestoreFirstReevaluatesImportGraph()
        {
            string guid = Guid.NewGuid().ToString("N");

            string projectContents = ObjectModelHelpers.CleanupFileContents($@"<Project xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">

  <PropertyGroup>
    <RestoreFirstProps>{Guid.NewGuid():N}.props</RestoreFirstProps>
  </PropertyGroup>
  
  <Import Project=""$(RestoreFirstProps)"" Condition=""Exists($(RestoreFirstProps))""/>

  <Target Name=""Build"">
    <Error Text=""PropertyA does not have a value defined"" Condition="" '$(PropertyA)' == '' "" />
    <Message Text=""PropertyA's value is &quot;$(PropertyA)&quot;"" />
  </Target>

  <Target Name=""Restore"">
    <ItemGroup>
      <Lines Include=""&lt;Project ToolsVersion=&quot;15.0&quot; xmlns=&quot;http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;&lt;PropertyGroup&gt;&lt;PropertyA&gt;{guid}&lt;/PropertyA&gt;&lt;/PropertyGroup&gt;&lt;/Project&gt;"" />
    </ItemGroup>
    
    <WriteLinesToFile File=""$(RestoreFirstProps)"" Lines=""@(Lines)"" Overwrite=""true"" />
  </Target>
  
</Project>");

            string logContents = ExecuteMSBuildExeExpectSuccess(projectContents, arguments: "/restore");

            logContents.ShouldContain(guid);
        }

        [Fact]
        public void RestoreFirstClearsProjectRootElementCache()
        {
            string guid1 = Guid.NewGuid().ToString("N");
            string guid2 = Guid.NewGuid().ToString("N");
            string restoreFirstProps = $"{Guid.NewGuid():N}.props";

            string projectContents = ObjectModelHelpers.CleanupFileContents($@"<Project xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">

  <PropertyGroup>
    <RestoreFirstProps>{restoreFirstProps}</RestoreFirstProps>
  </PropertyGroup>
  
  <Import Project=""$(RestoreFirstProps)"" Condition=""Exists($(RestoreFirstProps))""/>

  <Target Name=""Build"">
    <Error Text=""PropertyA does not have a value defined"" Condition="" '$(PropertyA)' == '' "" />
    <Message Text=""PropertyA's value is &quot;$(PropertyA)&quot;"" />
  </Target>

  <Target Name=""Restore"">
    <Message Text=""PropertyA's value is &quot;$(PropertyA)&quot;"" />
    <ItemGroup>
      <Lines Include=""&lt;Project ToolsVersion=&quot;15.0&quot; xmlns=&quot;http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;&lt;PropertyGroup&gt;&lt;PropertyA&gt;{guid2}&lt;/PropertyA&gt;&lt;/PropertyGroup&gt;&lt;/Project&gt;"" />
    </ItemGroup>
    
    <WriteLinesToFile File=""$(RestoreFirstProps)"" Lines=""@(Lines)"" Overwrite=""true"" />
  </Target>
  
</Project>");

            IDictionary<string, string> preExistingProps = new Dictionary<string, string>
            {
                { restoreFirstProps, $@"<Project ToolsVersion=""15.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup>
    <PropertyA>{guid1}</PropertyA>
  </PropertyGroup>
</Project>"
                }
            };

            string logContents = ExecuteMSBuildExeExpectSuccess(projectContents, preExistingProps, "/restore");

            logContents.ShouldContain(guid1);
            logContents.ShouldContain(guid2);
        }

        private string CopyMSBuild()
        {
            string dest = null;
            try
            {
                string source = Path.GetDirectoryName(RunnerUtilities.PathToCurrentlyRunningMsBuildExe);
                dest = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));

                Directory.CreateDirectory(dest);

                // Copy MSBuild.exe & dependent files (they will not be in the GAC so they must exist next to msbuild.exe)
                var filesToCopy = Directory
                    .EnumerateFiles(source)
                    .Where(f=> f.EndsWith(".dll") || f.EndsWith(".tasks") || f.EndsWith(".exe") || f.EndsWith(".exe.config") || f.EndsWith(".dll.config") || f.EndsWith(".runtimeconfig.json"));

                var directoriesToCopy = Directory
                    .EnumerateDirectories(source)
                    .Where(d => Directory.EnumerateFiles(d).Any(f => f.EndsWith("resources.dll")));  // Copy satellite assemblies

                foreach (var file in filesToCopy)
                {
                    File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
                }

                foreach (var directory in directoriesToCopy)
                {
                    foreach (var sourceFile in Directory.EnumerateFiles(directory, "*"))
                    {
                        var destinationFile = sourceFile.Replace(source, dest);

                        var directoryName = Path.GetDirectoryName(destinationFile);
                        Directory.CreateDirectory(directoryName);

                        File.Copy(sourceFile, destinationFile);
                    }
                }

                return dest;
            }
            catch (Exception)
            {
                RobustDelete(dest);
                throw;
            }
        }

        private string ExecuteMSBuildExeExpectSuccess(string projectContents, IDictionary<string, string> filesToCreate = null, params string[] arguments)
        {
            using (TestEnvironment testEnvironment = Engine.UnitTests.TestEnvironment.Create())
            {
                TransientTestProjectWithFiles testProject = testEnvironment.CreateTestProjectWithFiles(projectContents, new string[0]);

                if (filesToCreate != null)
                {
                    foreach (var item in filesToCreate)
                    {
                        File.WriteAllText(Path.Combine(testProject.TestRoot, item.Key), item.Value);
                    }
                }

                bool success;

                string output = RunnerUtilities.ExecMSBuild($"\"{testProject.ProjectFile}\" {String.Join(" ", arguments)}", out success);

                success.ShouldBeTrue();

                return output;
            }
        }
    }
}
