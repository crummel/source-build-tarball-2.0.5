// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.Common.Utilities
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Xml;

    using Microsoft.VisualStudio.TestPlatform.Utilities;
    using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
    using Microsoft.VisualStudio.TestPlatform.Common;

    /// <summary>
    /// Utilities to get the run settings from the provider and the commandline options specified.
    /// </summary>
    internal static class RunSettingsProviderExtensions
    {
        public const string EmptyRunSettings = @"<RunSettings><RunConfiguration></RunConfiguration></RunSettings>";

        public static void UpdateRunSettings(this IRunSettingsProvider runSettingsProvider, string runsettingsXml)
        {
            ValidateArg.NotNull(runSettingsProvider, nameof(runSettingsProvider));
            ValidateArg.NotNullOrWhiteSpace(runsettingsXml, nameof(runsettingsXml));

            var runSettings = new RunSettings();
            runSettings.LoadSettingsXml(runsettingsXml);
            runSettingsProvider.SetActiveRunSettings(runSettings);
        }

        public static void AddDefaultRunSettings(this IRunSettingsProvider runSettingsProvider)
        {
            ValidateArg.NotNull(runSettingsProvider, nameof(runSettingsProvider));

            var runSettingsXml = runSettingsProvider.ActiveRunSettings?.SettingsXml;

            if (string.IsNullOrWhiteSpace(runSettingsXml))
            {
                runSettingsXml = EmptyRunSettings;
            }

            runSettingsXml = AddDefaultRunSettings(runSettingsXml);
            runSettingsProvider.UpdateRunSettings(runSettingsXml);
        }

        public static void UpdateRunSettingsNode(this IRunSettingsProvider runSettingsProvider, string key, string data)
        {
            ValidateArg.NotNull(runSettingsProvider, nameof(runSettingsProvider));
            ValidateArg.NotNullOrWhiteSpace(key, nameof(key));
            ValidateArg.NotNull(data, nameof(data));

            var xmlDocument = runSettingsProvider.GetRunSettingXmlDocument();
            RunSettingsProviderExtensions.UpdateRunSettingsXmlDocument(xmlDocument, key, data);
            runSettingsProvider.UpdateRunSettings(xmlDocument.OuterXml);
        }

        public static void UpdateRunSettingsNodeInnerXml(this IRunSettingsProvider runSettingsProvider, string key, string xml)
        {
            ValidateArg.NotNull(runSettingsProvider, nameof(runSettingsProvider));
            ValidateArg.NotNullOrWhiteSpace(key, nameof(key));
            ValidateArg.NotNull(xml, nameof(xml));

            var xmlDocument = runSettingsProvider.GetRunSettingXmlDocument();
            RunSettingsProviderExtensions.UpdateRunSettingsXmlDocumentInnerXml(xmlDocument, key, xml);
            runSettingsProvider.UpdateRunSettings(xmlDocument.OuterXml);
        }

        public static string QueryRunSettingsNode(this IRunSettingsProvider runSettingsProvider, string key)
        {
            ValidateArg.NotNull(runSettingsProvider, nameof(runSettingsProvider));
            ValidateArg.NotNullOrWhiteSpace(key, nameof(key));

            var xmlDocument = runSettingsProvider.GetRunSettingXmlDocument();
            var node = GetXmlNode(xmlDocument, key);
            return node?.InnerText;
        }

        internal static XmlNode GetXmlNode(XmlDocument xmlDocument, string key)
        {
            var xPath = key.Replace('.', '/');
            var node = xmlDocument.SelectSingleNode(string.Format("//RunSettings/{0}", xPath));
            return node;
        }

        internal static void UpdateRunSettingsXmlDocument(XmlDocument xmlDocument, string key, string data)
        {
            var node = GetXmlNode(xmlDocument, key) ?? RunSettingsProviderExtensions.CreateNode(xmlDocument, key);
            node.InnerText = data;
        }

        /// <summary>
        /// Gets the effective run settings adding the default run settings if not already present.
        /// </summary>
        /// <param name="runSettings"> The run settings XML. </param>
        /// <returns> Effective run settings. </returns>
        [SuppressMessage("Microsoft.Security.Xml", "CA3053:UseXmlSecureResolver",
            Justification = "XmlDocument.XmlResolver is not available in core. Suppress until fxcop issue is fixed.")]
        private static string AddDefaultRunSettings(string runSettings)
        {
            var architecture = Constants.DefaultPlatform;
            var framework = Framework.DefaultFramework;
            var defaultResultsDirectory = Path.Combine(Directory.GetCurrentDirectory(), Constants.ResultsDirectoryName);

            using (var stream = new StringReader(runSettings))
            using (var reader = XmlReader.Create(stream, XmlRunSettingsUtilities.ReaderSettings))
            {
                var document = new XmlDocument();
                document.Load(reader);

                var navigator = document.CreateNavigator();

                InferRunSettingsHelper.UpdateRunSettingsWithUserProvidedSwitches(navigator, architecture, framework, defaultResultsDirectory);
                return navigator.OuterXml;
            }
        }

        private static XmlNode CreateNode(XmlDocument doc, string xPath)
        {
            var path = xPath.Split('.');
            XmlNode node = null;
            XmlNode parent = doc.DocumentElement;

            for (var i = 0; i < path.Length; i++)
            {
                node = parent.SelectSingleNode(path[i]) ?? parent.AppendChild(doc.CreateElement(path[i]));
                parent = node;
            }

            return node;
        }        

        private static XmlDocument GetRunSettingXmlDocument(this IRunSettingsProvider runSettingsProvider)
        {
            ValidateArg.NotNull(runSettingsProvider, nameof(runSettingsProvider));

            var doc = new XmlDocument();

            if (runSettingsProvider.ActiveRunSettings != null &&
                !string.IsNullOrEmpty(runSettingsProvider.ActiveRunSettings.SettingsXml))
            {
                var settingsXml = runSettingsProvider.ActiveRunSettings.SettingsXml;

#if NET451
                using (var reader = XmlReader.Create(new StringReader(settingsXml), new XmlReaderSettings() { XmlResolver = null, CloseInput = true, DtdProcessing = DtdProcessing.Prohibit }))
                {
#else
                using (
                    var reader = XmlReader.Create(new StringReader(settingsXml),
                        new XmlReaderSettings() { CloseInput = true, DtdProcessing = DtdProcessing.Prohibit }))
                {
#endif
                    doc.Load(reader);
                }
            }
            else
            {
#if NET451
                doc = (XmlDocument) XmlRunSettingsUtilities.CreateDefaultRunSettings();
#else
                using (
                    var reader =
                        XmlReader.Create(
                            new StringReader(
                                XmlRunSettingsUtilities.CreateDefaultRunSettings().CreateNavigator().OuterXml),
                            new XmlReaderSettings() { CloseInput = true, DtdProcessing = DtdProcessing.Prohibit }))
                {
                    doc.Load(reader);
                }
#endif
            }
            return doc;
        }
         
        private static void UpdateRunSettingsXmlDocumentInnerXml(XmlDocument xmlDocument, string key, string data)
        {
            var node = GetXmlNode(xmlDocument, key) ?? RunSettingsProviderExtensions.CreateNode(xmlDocument, key);
            node.InnerXml = data;
        }
    }
}
