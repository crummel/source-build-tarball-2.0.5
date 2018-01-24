﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.NET.Sdk.Publish.Tasks;
using Xunit;

// Some of the tests Copied from https://raw.githubusercontent.com/aspnet/IISIntegration/50f066579a96c6f2b2a4c47524c684e1ef3dfdf0/test/Microsoft.AspNetCore.Server.IISIntegration.Tools.Tests/WebConfigTransformFacts.cs

namespace Microsoft.Net.Sdk.Publish.Tasks.Tests
{
    public class WebConfigTransformTests
    {
        private XDocument WebConfigTemplate => XDocument.Parse(
@"<configuration>
  <system.webServer>
    <handlers>
      <add name=""aspNetCore"" path=""*"" verb=""*"" modules=""AspNetCoreModule"" resourceType=""Unspecified""/>
    </handlers>
    <aspNetCore processPath="".\test.exe"" stdoutLogEnabled=""false"" stdoutLogFile="".\logs\stdout"" />
  </system.webServer>
</configuration>");

        private XDocument WebConfigTemplateWithOutExe => XDocument.Parse(
@"<configuration>
  <system.webServer>
    <handlers>
      <add name=""aspNetCore"" path=""*"" verb=""*"" modules=""AspNetCoreModule"" resourceType=""Unspecified""/>
    </handlers>
    <aspNetCore processPath="".\test"" stdoutLogEnabled=""false"" stdoutLogFile="".\logs\stdout"" />
  </system.webServer>
</configuration>");

        private XDocument WebConfigTemplatePortable => XDocument.Parse(
@"<configuration>
  <system.webServer>
    <handlers>
      <add name=""aspNetCore"" path=""*"" verb=""*"" modules=""AspNetCoreModule"" resourceType=""Unspecified""/>
    </handlers>
    <aspNetCore processPath=""dotnet"" arguments="".\test.dll"" stdoutLogEnabled=""false"" stdoutLogFile="".\logs\stdout"" />
  </system.webServer>
</configuration>");

        private XDocument WebConfigTemplateWithProjectGuid => XDocument.Parse(
@"<configuration>
  <system.webServer>
    <handlers>
      <add name=""aspNetCore"" path=""*"" verb=""*"" modules=""AspNetCoreModule"" resourceType=""Unspecified""/>
    </handlers>
    <aspNetCore processPath="".\test.exe"" stdoutLogEnabled=""false"" stdoutLogFile="".\logs\stdout"" />
  </system.webServer>
</configuration>
<!--ProjectGuid: A535E3E2-737D-422D-A529-D79D43FB4F5E-->");

        [Fact]
        public void WebConfigTransform_creates_new_config_if_one_does_not_exist()
        {
            Assert.True(XNode.DeepEquals(WebConfigTemplate,
                    WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")));

            Assert.True(XNode.DeepEquals(WebConfigTemplatePortable,
                    WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: true, extension: null)));
        }

        [Fact]
        public void WebConfigTransform_creates_ProcessPath_WithCorrectExtension()
        {
            Assert.True(XNode.DeepEquals(WebConfigTemplate,
                    WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")));

            Assert.True(XNode.DeepEquals(WebConfigTemplateWithOutExe,
                    WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: false, extension: null)));
        }

        [Fact]
        public void WebConfigTransform_creates_new_config_if_one_has_unexpected_format()
        {
            Assert.True(XNode.DeepEquals(WebConfigTemplate,
                WebConfigTransform.Transform(XDocument.Parse("<unexpected />"), "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")));
        }

        [Theory]
        [InlineData(new object[] { new[] { "system.webServer" } })]
        [InlineData(new object[] { new[] { "add" } })]
        [InlineData(new object[] { new[] { "handlers" } })]
        [InlineData(new object[] { new[] { "aspNetCore" } })]
        [InlineData(new object[] { new[] { "environmentVariables" } })]
        [InlineData(new object[] { new[] { "environmentVariable" } })]
        [InlineData(new object[] { new[] { "handlers", "aspNetCore", "environmentVariables" } })]
        public void WebConfigTransform_adds_missing_elements(string[] elementNames)
        {
            var input = WebConfigTemplate;
            foreach (var elementName in elementNames)
            {
                input.Descendants(elementName).Remove();
            }

            Assert.True(XNode.DeepEquals(WebConfigTemplate,
                WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")));
        }

        [Theory]
        [InlineData("add", "path", "test")]
        [InlineData("add", "verb", "test")]
        [InlineData("add", "modules", "mods")]
        [InlineData("add", "resourceType", "Either")]
        [InlineData("aspNetCore", "stdoutLogEnabled", "true")]
        [InlineData("aspNetCore", "startupTimeLimit", "1200")]
        [InlineData("aspNetCore", "arguments", "arg1")]
        [InlineData("aspNetCore", "stdoutLogFile", "logfile")]
        public void WebConfigTransform_wont_override_custom_values(string elementName, string attributeName, string attributeValue)
        {
            var input = WebConfigTemplate;
            input.Descendants(elementName).Single().SetAttributeValue(attributeName, attributeValue);

            var output = WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe");
            Assert.Equal(attributeValue, (string)output.Descendants(elementName).Single().Attribute(attributeName));
        }

        [Fact]
        public void WebConfigTransform_overwrites_processPath()
        {
            var newProcessPath =
                (string)WebConfigTransform.Transform(WebConfigTemplate, "app.exe", configureForAzure: false, isPortable: false, extension: ".exe")
                    .Descendants("aspNetCore").Single().Attribute("processPath");

            Assert.Equal(@".\app.exe", newProcessPath);
        }

        [Fact]
        public void WebConfigTransform_fixes_aspnetcore_casing()
        {
            var input = WebConfigTemplate;
            input.Descendants("add").Single().SetAttributeValue("name", "aspnetcore");

            Assert.True(XNode.DeepEquals(WebConfigTemplate,
                WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")));
        }

        [Fact]
        public void WebConfigTransform_does_not_remove_children_of_aspNetCore_element()
        {
            var envVarElement =
                new XElement("environmentVariable", new XAttribute("name", "ENVVAR"), new XAttribute("value", "123"));

            var input = WebConfigTemplate;
            input.Descendants("aspNetCore").Single().Add(envVarElement);

            Assert.True(XNode.DeepEquals(envVarElement,
                WebConfigTransform.Transform(input, "app.exe", configureForAzure: false, isPortable: false, extension: ".exe")
                    .Descendants("environmentVariable").SingleOrDefault(e => (string)e.Attribute("name") == "ENVVAR")));
        }

        [Fact]
        public void WebConfigTransform_adds_stdoutLogEnabled_if_attribute_is_missing()
        {
            var input = WebConfigTemplate;
            input.Descendants("aspNetCore").Attributes("stdoutLogEnabled").Remove();

            Assert.Equal(
                "false",
                (string)WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")
                    .Descendants().Attributes("stdoutLogEnabled").Single());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("false")]
        [InlineData("true")]
        public void WebConfigTransform_adds_stdoutLogFile_if_attribute_is_missing(string stdoutLogFile)
        {
            var input = WebConfigTemplate;

            var aspNetCoreElement = input.Descendants("aspNetCore").Single();
            aspNetCoreElement.Attribute("stdoutLogEnabled").Remove();
            if (stdoutLogFile != null)
            {
                aspNetCoreElement.SetAttributeValue("stdoutLogEnabled", stdoutLogFile);
            }

            Assert.Equal(
                @".\logs\stdout",
                (string)WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")
                    .Descendants().Attributes("stdoutLogFile").Single());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("true")]
        [InlineData("false")]
        public void WebConfigTransform_does_not_change_existing_stdoutLogEnabled(string stdoutLogEnabledValue)
        {
            var input = WebConfigTemplate;
            var aspNetCoreElement = input.Descendants("aspNetCore").Single();

            aspNetCoreElement.SetAttributeValue("stdoutLogFile", "mylog.txt");
            aspNetCoreElement.Attributes("stdoutLogEnabled").Remove();
            if (stdoutLogEnabledValue != null)
            {
                input.Descendants("aspNetCore").Single().SetAttributeValue("stdoutLogEnabled", stdoutLogEnabledValue);
            }

            Assert.Equal(
                "mylog.txt",
                (string)WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")
                    .Descendants().Attributes("stdoutLogFile").Single());
        }

        [Fact]
        public void WebConfigTransform_correctly_configures_for_Azure()
        {
            var input = WebConfigTemplate;
            input.Descendants("aspNetCore").Attributes().Remove();

            var aspNetCoreElement = WebConfigTransform.Transform(input, "test.dll", configureForAzure: true, isPortable: false, extension: ".exe")
                .Descendants("aspNetCore").Single();
            aspNetCoreElement.Elements().Remove();

            Assert.True(XNode.DeepEquals(
                XDocument.Parse(@"<aspNetCore processPath="".\test.exe"" stdoutLogEnabled=""false""
                    stdoutLogFile=""\\?\%home%\LogFiles\stdout"" />").Root,
                aspNetCoreElement));
        }

        [Fact]
        public void WebConfigTransform_overwrites_stdoutLogPath_for_Azure()
        {
            var input = WebConfigTemplate;
            var output = WebConfigTransform.Transform(input, "test.dll", configureForAzure: true, isPortable: false, extension: ".exe");

            Assert.Equal(
                @"\\?\%home%\LogFiles\stdout",
                (string)output.Descendants("aspNetCore").Single().Attribute("stdoutLogFile"));
        }

        [Fact]
        public void WebConfigTransform_configures_portable_apps_correctly()
        {
            var aspNetCoreElement =
                WebConfigTransform.Transform(WebConfigTemplate, "test.dll", configureForAzure: false, isPortable: true, extension: ".exe")
                    .Descendants("aspNetCore").Single();

            Assert.True(XNode.DeepEquals(
                XDocument.Parse(@"<aspNetCore processPath=""dotnet"" arguments="".\test.dll"" stdoutLogEnabled=""false""
                     stdoutLogFile="".\logs\stdout"" />").Root,
                aspNetCoreElement));
        }

        [Theory]
        [InlineData("%LAUNCHER_ARGS%", "")]
        [InlineData(" %launcher_ARGS%", "")]
        [InlineData("%LAUNCHER_args% ", "")]
        [InlineData("%LAUNCHER_ARGS% %launcher_args%", "")]
        [InlineData(" %LAUNCHER_ARGS% %launcher_args% ", "")]
        [InlineData(" %launcher_args% -my-switch", "-my-switch")]
        [InlineData("-my-switch %LaUnChEr_ArGs%", "-my-switch")]
        [InlineData("-switch-1 %LAUNCHER_ARGS% -switch-2", "-switch-1  -switch-2")]
        [InlineData("%LAUNCHER_ARGS% -switch %launcher_args%", "-switch")]
        public void WebConfigTransform_removes_LAUNCHER_ARGS_from_arguments_for_standalone_apps(string inputArguments, string outputArguments)
        {
            var input = WebConfigTemplate;
            input.Descendants("aspNetCore").Single().SetAttributeValue("arguments", inputArguments);

            var aspNetCoreElement =
                WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe")
                    .Descendants("aspNetCore").Single();

            Assert.Equal(outputArguments, (string)aspNetCoreElement.Attribute("arguments"));
        }

        [Theory]
        [InlineData("", ".\\myapp.dll")]
        [InlineData("%LAUNCHER_ARGS%", ".\\myapp.dll")]
        [InlineData("%LAUNCHER_ARGS% %launcher_args%", ".\\myapp.dll")]
        [InlineData("-my-switch", ".\\myapp.dll -my-switch")]
        [InlineData(" %launcher_args% -my-switch", ".\\myapp.dll -my-switch")]
        [InlineData("-my-switch %LaUnChEr_ArGs%", ".\\myapp.dll -my-switch")]
        [InlineData("-switch-1 -switch-2", ".\\myapp.dll -switch-1 -switch-2")]
        [InlineData("-switch-1 %LAUNCHER_ARGS% -switch-2", ".\\myapp.dll -switch-1  -switch-2")]
        [InlineData("%LAUNCHER_ARGS% -switch %launcher_args%", ".\\myapp.dll -switch")]
        public void WebConfigTransform_wont_override_existing_args_for_portable_apps(string inputArguments, string outputArguments)
        {
            var input = WebConfigTemplate;
            input.Descendants("aspNetCore").Single().SetAttributeValue("arguments", inputArguments);

            var aspNetCoreElement =
                WebConfigTransform.Transform(input, "myapp.dll", configureForAzure: false, isPortable: true, extension: ".exe")
                    .Descendants("aspNetCore").Single();

            Assert.Equal(outputArguments, (string)aspNetCoreElement.Attribute("arguments"));
        }


        private bool VerifyMissingElementCreated(params string[] elementNames)
        {
            var input = WebConfigTemplate;
            foreach (var elementName in elementNames)
            {
                input.Descendants(elementName).Remove();
            }

            return XNode.DeepEquals(WebConfigTemplate,
                WebConfigTransform.Transform(input, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe"));
        }

        [Theory]
        [InlineData("A535E3E2-737D-422D-A529-D79D43FB4F5E")]
        [InlineData("  A535E3E2-737D-422D-A529-D79D43FB4F5E  ")]
        [InlineData("{ A535E3E2-737D-422D-A529-D79D43FB4F5E }")]
        [InlineData("{A535E3E2-737D-422D-A529-D79D43FB4F5E}")]
        [InlineData("( A535E3E2-737D-422D-A529-D79D43FB4F5E )")]
        [InlineData("(A535E3E2-737D-422D-A529-D79D43FB4F5E)")]

        public void WebConfigTransform_Adds_ProjectGuid_IfNotPresent(string projectGuid)
        {
            // Arrange
            XDocument transformedWebConfig = WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe");
            Assert.True(XNode.DeepEquals(WebConfigTemplate, transformedWebConfig));

            // Act
            XDocument transformedWebConfigWithGuid = WebConfigTransform.AddProjectGuidToWebConfig(transformedWebConfig, projectGuid, false);

            // Assert
            Assert.True(XNode.DeepEquals(WebConfigTemplateWithProjectGuid, transformedWebConfigWithGuid));
        }

        [Theory]
        [InlineData("A535E3E2-737D-422D-A529-D79D43FB4F5E")]
        [InlineData(" A535E3E2-737D-422D-A529-D79D43FB4F5E ")]
        [InlineData("{ A535E3E2-737D-422D-A529-D79D43FB4F5E }")]
        [InlineData("{A535E3E2-737D-422D-A529-D79D43FB4F5E}")]
        [InlineData("( A535E3E2-737D-422D-A529-D79D43FB4F5E )")]
        [InlineData("(A535E3E2-737D-422D-A529-D79D43FB4F5E)")]

        public void WebConfigTransform_Removes_ProjectGuid_IfIgnorePropertyIsSet(string projectGuid)
        {
            // Arrange
            XDocument transformedWebConfig = WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe");
            Assert.True(XNode.DeepEquals(WebConfigTemplate, transformedWebConfig));
            XDocument transformedWebConfigWithGuid = WebConfigTransform.AddProjectGuidToWebConfig(transformedWebConfig, projectGuid, false);
            Assert.True(XNode.DeepEquals(WebConfigTemplateWithProjectGuid, transformedWebConfigWithGuid));

            // Act
            transformedWebConfigWithGuid = WebConfigTransform.AddProjectGuidToWebConfig(transformedWebConfig, projectGuid, true);

            //Assert
            Assert.True(XNode.DeepEquals(WebConfigTemplate, transformedWebConfigWithGuid));

        }

        [Fact]
        public void WebConfigTransform_DoesNothingWithProjectGuid_IfAbsent()
        {
            // Arrange
            XDocument transformedWebConfig = WebConfigTransform.Transform(null, "test.dll", configureForAzure: false, isPortable: false, extension: ".exe");
            Assert.True(XNode.DeepEquals(WebConfigTemplate, transformedWebConfig));

            // Act
            XDocument transformedWebConfigWithGuid = WebConfigTransform.AddProjectGuidToWebConfig(transformedWebConfig, null, false);

            // Assert
            Assert.True(XNode.DeepEquals(WebConfigTemplate, transformedWebConfigWithGuid));
        }
    }
}