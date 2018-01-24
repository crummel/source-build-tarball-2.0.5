﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.DotNet.Cli.Utils;
using Microsoft.DotNet.Tools.MSBuild;
using Microsoft.DotNet.Tools;
using Microsoft.DotNet.Cli;
using Microsoft.DotNet.Tools.Restore;
using Parser = Microsoft.DotNet.Cli.Parser;

namespace Microsoft.DotNet.Tools.Build
{
    public class BuildCommand : RestoringCommand
    {
        public BuildCommand(
            IEnumerable<string> msbuildArgs,
            IEnumerable<string> userDefinedArguments,
            IEnumerable<string> trailingArguments,
            bool noRestore,
            string msbuildPath = null)
            : base(msbuildArgs, userDefinedArguments, trailingArguments, noRestore, msbuildPath)
        {
        }

        public static BuildCommand FromArgs(string[] args, string msbuildPath = null)
        {
            var msbuildArgs = new List<string>();

            var parser = Parser.Instance;

            var result = parser.ParseFrom("dotnet build", args);

            result.ShowHelpOrErrorIfAppropriate();

            var appliedBuildOptions = result["dotnet"]["build"];

            if (appliedBuildOptions.HasOption("--no-incremental"))
            {
                msbuildArgs.Add("/t:Rebuild");
            }
            else
            {
                msbuildArgs.Add("/t:Build");
            }

            msbuildArgs.AddRange(appliedBuildOptions.OptionValuesToBeForwarded());

            msbuildArgs.AddRange(appliedBuildOptions.Arguments);

            msbuildArgs.Add($"/clp:Summary");

            bool noRestore = appliedBuildOptions.HasOption("--no-restore");

            return new BuildCommand(
                msbuildArgs,
                appliedBuildOptions.OptionValuesToBeForwarded(),
                appliedBuildOptions.Arguments,
                noRestore,
                msbuildPath);
        }

        public static int Run(string[] args)
        {
            DebugHelper.HandleDebugSwitch(ref args);

            BuildCommand cmd;
            
            try
            {
                cmd = FromArgs(args);
            }
            catch (CommandCreationException e)
            {
                return e.ExitCode;
            }

            return cmd.Execute();
        }
    }
}
