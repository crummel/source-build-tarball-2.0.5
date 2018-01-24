﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;

namespace Ng
{
    static class CopyLucene
    {
        static void PrintUsage()
        {
            Console.WriteLine("Usage: ng copylucene -srcDirectoryType file|azure [-srcPath <file-path>] | [-srcStorageAccountName <azure-acc> -srcStorageKeyValue <azure-key> -srcStorageContainer <azure-container>] -destDirectoryType file|azure [-destPath <file-path>] | [-destStorageAccountName <azure-acc> -destStorageKeyValue <azure-key> -destStorageContainer <azure-container>]");
        }

        public static void Run(string[] args)
        {
            IDictionary<string, string> arguments = CommandHelpers.GetArguments(args, 1);
            if (arguments == null || arguments.Count == 0)
            {
                PrintUsage();
                return;
            }

            Lucene.Net.Store.Directory srcDirectory = CommandHelpers.GetCopySrcLuceneDirectory(arguments);
            if (srcDirectory == null)
            {
                Console.WriteLine("problem with src arguments");
                PrintUsage();
                return;
            }

            Lucene.Net.Store.Directory destDirectory = CommandHelpers.GetCopyDestLuceneDirectory(arguments);
            if (destDirectory == null)
            {
                Console.WriteLine("problem with dest arguments");
                PrintUsage();
                return;
            }

            Lucene.Net.Store.Directory.Copy(srcDirectory, destDirectory, true);

            Console.WriteLine("All Done");
        }
    }
}
