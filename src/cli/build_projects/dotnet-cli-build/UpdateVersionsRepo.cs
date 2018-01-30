// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.IO;

namespace Microsoft.DotNet.Cli.Build
{
    public class UpdateVersionsRepo : Task
    {
        [Required]
        public string BranchName { get; set; }

        [Required]
        public string PackagesDirectory { get; set; }

        [Required]
        public string GitHubPassword { get; set; }

        public override bool Execute()
        {
            return true;
        }
    }
}
