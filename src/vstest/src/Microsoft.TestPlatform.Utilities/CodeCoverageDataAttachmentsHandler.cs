﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
    using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;

    public class CodeCoverageDataAttachmentsHandler : IDataCollectorAttachments
    {
        private const string CoverageUri = "datacollector://microsoft/CodeCoverage/2.0";
        private const string CoverageFileExtension = ".coverage";
        private const string CoverageFriendlyName = "Code Coverage";

        private const string CodeCoverageAnalysisAssemblyName = "Microsoft.VisualStudio.Coverage.Analysis";
        private const string MergeMethodName = "MergeCoverageFiles";
        private const string CoverageInfoTypeName = "CoverageInfo";

        private static readonly Uri CodeCoverageDataCollectorUri = new Uri(CoverageUri);

        public Uri GetExtensionUri()
        {
            return CodeCoverageDataCollectorUri;
        }

        public ICollection<AttachmentSet> HandleDataCollectionAttachmentSets(ICollection<AttachmentSet> dataCollectionAttachments)
        {
            if (dataCollectionAttachments != null && dataCollectionAttachments.Any())
            {
                var codeCoverageFiles = dataCollectionAttachments.Select(coverageAttachment => coverageAttachment.Attachments[0].Uri.LocalPath).ToArray();
                var outputFile = MergeCodeCoverageFiles(codeCoverageFiles);
                var attachmentSet = new AttachmentSet(CodeCoverageDataCollectorUri, CoverageFriendlyName);

                if (!string.IsNullOrEmpty(outputFile))
                {
                    attachmentSet.Attachments.Add(new UriDataAttachment(new Uri(outputFile), CoverageFriendlyName));
                    return new Collection<AttachmentSet> { attachmentSet };
                }

                // In case merging fails(esp in dotnet core we cannot merge), so return filtered list of Code Coverage Attachments
                return dataCollectionAttachments;
            }

            return new Collection<AttachmentSet>();
        }

        private string MergeCodeCoverageFiles(IList<string> files)
        {
            string fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + CoverageFileExtension);
            string outputfileName = files[0];

            File.Create(fileName).Dispose();
            var assemblyPath = Path.Combine(Path.GetDirectoryName(typeof(CodeCoverageDataAttachmentsHandler).GetTypeInfo().Assembly.GetAssemblyLocation()), CodeCoverageAnalysisAssemblyName + ".dll");

            try
            {
                Assembly assembly = new PlatformAssemblyLoadContext().LoadAssemblyFromPath(assemblyPath);
                var type = assembly.GetType(CodeCoverageAnalysisAssemblyName + "." + CoverageInfoTypeName);

                var methodInfo = type?.GetMethod(MergeMethodName);

                if (methodInfo != null)
                {
                    for (int i = 1; i < files.Count; i++)
                    {
                        methodInfo.Invoke(null, new object[] { files[i], outputfileName, fileName, true });
                        File.Copy(fileName, outputfileName, true);

                        File.Delete(files[i]);
                    }

                    File.Delete(fileName);
                }

                return outputfileName;
            }
            catch (Exception ex)
            {
                if (EqtTrace.IsErrorEnabled)
                {
                    EqtTrace.Error("CodeCoverageDataCollectorAttachmentsHandler: Failed to load datacollector of type : {0} from location : {1}. Error : ", CodeCoverageAnalysisAssemblyName, assemblyPath, ex.Message);
                }
            }

            return string.Empty;
        }
    }
}
