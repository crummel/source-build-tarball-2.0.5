﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using Xunit;

namespace Microsoft.Build.UnitTests
{
    public class BuildEventArgsSerializationTests
    {
        [Fact]
        public void RoundtripBuildStartedEventArgs()
        {
            var args = new BuildStartedEventArgs(
                "Message",
                "HelpKeyword",
                DateTime.Parse("3/1/2017 11:11:56 AM"));
            Roundtrip(args,
                e => e.Message,
                e => e.HelpKeyword,
                e => e.Timestamp.ToString());

            args = new BuildStartedEventArgs(
                "M",
                null,
                new Dictionary<string, string>
                {
                    { "SampleName", "SampleValue" }
                });
            Roundtrip(args,
                e => ToString(e.BuildEnvironment),
                e => e.HelpKeyword,
                e => e.ThreadId.ToString(),
                e => e.SenderName);
        }

        [Fact]
        public void RoundtripBuildFinishedEventArgs()
        {
            var args = new BuildFinishedEventArgs(
                "Message",
                null,
                succeeded: true,
                eventTimestamp: DateTime.Parse("12/12/2015 06:11:56 PM"));
            args.BuildEventContext = new BuildEventContext(1, 2, 3, 4, 5, 6);

            Roundtrip(args,
                e => ToString(e.BuildEventContext),
                e => e.Succeeded.ToString());
        }

        [Fact]
        public void RoundtripProjectStartedEventArgs()
        {
            var args = new ProjectStartedEventArgs(
                projectId: 42,
                message: "Project started message",
                helpKeyword: "help",
                projectFile: "C:\\test.proj",
                targetNames: "Build",
                properties: new List<DictionaryEntry>() { new DictionaryEntry("Key", "Value") },
                items: new List<DictionaryEntry>() { new DictionaryEntry("Key", new MyTaskItem() { ItemSpec = "TestItemSpec" }) },
                parentBuildEventContext: new BuildEventContext(7, 8, 9, 10, 11, 12),
                globalProperties: null, // we do not serialize GlobalProperties
                toolsVersion: "15.0");
            args.BuildEventContext = new BuildEventContext(1, 2, 3, 4, 5, 6);

            Roundtrip(args,
                e => ToString(e.BuildEventContext),
                e => ToString(e.GlobalProperties),
                e => ToString(e.Items.OfType<DictionaryEntry>().ToDictionary(d => d.Key.ToString(), d => ((ITaskItem)d.Value).ItemSpec.ToString())),
                e => e.Message,
                e => ToString(e.ParentProjectBuildEventContext),
                e => e.ProjectFile,
                e => e.ProjectId.ToString(),
                e => ToString(e.Properties.OfType<DictionaryEntry>().ToDictionary(d => d.Key.ToString(), d => d.Value.ToString())),
                e => e.TargetNames,
                e => e.ThreadId.ToString(),
                e => e.Timestamp.ToString(),
                e => e.ToolsVersion);
        }

        [Fact]
        public void RoundtripProjectFinishedEventArgs()
        {
            var args = new ProjectFinishedEventArgs(
                "Message",
                null,
                "C:\\projectfile.proj",
                true,
                DateTime.Parse("12/12/2015 06:11:56 PM"));

            Roundtrip(args,
                e => e.ProjectFile,
                e => e.Succeeded.ToString());
        }

        [Fact]
        public void RoundtripTargetStartedEventArgs()
        {
            var args = new TargetStartedEventArgs(
                "Message",
                "Help",
                "Build",
                "C:\\projectfile.proj",
                "C:\\Common.targets",
                "ParentTarget",
                DateTime.Parse("12/12/2015 06:11:56 PM"));

            Roundtrip(args,
                e => e.ParentTarget,
                e => e.ProjectFile,
                e => e.TargetFile,
                e => e.TargetName,
                e => e.Timestamp.ToString());
        }

        [Fact]
        public void RoundtripTargetFinishedEventArgs()
        {
            var args = new TargetFinishedEventArgs(
                "Message",
                null,
                "TargetName",
                "C:\\Project.proj",
                "C:\\TargetFile.targets",
                true,
                new List<ITaskItem> { new MyTaskItem() });

            Roundtrip(args,
                e => e.ProjectFile,
                e => e.Succeeded.ToString(),
                e => e.TargetFile,
                e => e.TargetName,
                e => ToString(e.TargetOutputs.OfType<ITaskItem>()));
        }

        [Fact]
        public void RoundtripTaskStartedEventArgs()
        {
            var args = new TaskStartedEventArgs(
                "Message",
                null,
                projectFile: "C:\\project.proj",
                taskFile: "C:\\common.targets",
                taskName: "Csc");

            Roundtrip(args,
                e => e.ProjectFile,
                e => e.TaskFile,
                e => e.TaskName);
        }

        [Fact]
        public void RoundtripTaskFinishedEventArgs()
        {
            var args = new TaskFinishedEventArgs(
                "Message",
                null,
                "C:\\project.proj",
                "C:\\common.tasks",
                "Csc",
                succeeded: false);

            Roundtrip(args,
                e => e.ProjectFile,
                e => e.TaskFile,
                e => e.TaskName,
                e => e.ThreadId.ToString());
        }

        [Fact]
        public void RoundtripBuildErrorEventArgs()
        {
            var args = new BuildErrorEventArgs(
                "Subcategory",
                "Code",
                "File",
                1,
                2,
                3,
                4,
                "Message",
                "Help",
                "SenderName");

            Roundtrip(args,
                e => e.Code,
                e => e.ColumnNumber.ToString(),
                e => e.EndColumnNumber.ToString(),
                e => e.EndLineNumber.ToString(),
                e => e.File,
                e => e.LineNumber.ToString(),
                e => e.Message,
                e => e.ProjectFile,
                e => e.Subcategory);
        }

        [Fact]
        public void RoundtripBuildWarningEventArgs()
        {
            var args = new BuildWarningEventArgs(
                "Subcategory",
                "Code",
                "File",
                1,
                2,
                3,
                4,
                "Message",
                "Help",
                "SenderName");

            Roundtrip(args,
                e => e.Code,
                e => e.ColumnNumber.ToString(),
                e => e.EndColumnNumber.ToString(),
                e => e.EndLineNumber.ToString(),
                e => e.File,
                e => e.LineNumber.ToString(),
                e => e.Message,
                e => e.ProjectFile,
                e => e.Subcategory);
        }

        [Fact]
        public void RoundtripBuildMessageEventArgs()
        {
            var args = new BuildMessageEventArgs(
                "Subcategory",
                "Code",
                "File",
                1,
                2,
                3,
                4,
                "Message",
                "Help",
                "SenderName",
                MessageImportance.High,
                DateTime.Parse("12/12/2015 06:11:56 PM"));

            Roundtrip(args,
                e => e.Code,
                e => e.ColumnNumber.ToString(),
                e => e.EndColumnNumber.ToString(),
                e => e.EndLineNumber.ToString(),
                e => e.File,
                e => e.LineNumber.ToString(),
                e => e.Message,
                e => e.Importance.ToString(),
                e => e.ProjectFile,
                e => e.Subcategory);
        }

        [Fact]
        public void RoundtripCriticalBuildMessageEventArgs()
        {
            var args = new CriticalBuildMessageEventArgs(
                "Subcategory",
                "Code",
                "File",
                1,
                2,
                3,
                4,
                "Message",
                "Help",
                "SenderName",
                DateTime.Parse("12/12/2015 06:11:56 PM"));

            Roundtrip(args,
                e => e.Code,
                e => e.ColumnNumber.ToString(),
                e => e.EndColumnNumber.ToString(),
                e => e.EndLineNumber.ToString(),
                e => e.File,
                e => e.LineNumber.ToString(),
                e => e.Message,
                e => e.ProjectFile,
                e => e.Subcategory);
        }

        [Fact]
        public void RoundtripTaskCommandLineEventArgs()
        {
            var args = new TaskCommandLineEventArgs(
                "/bl /noconlog /v:diag",
                "Csc",
                MessageImportance.Low,
                DateTime.Parse("12/12/2015 06:11:56 PM"));

            Roundtrip(args,
                e => e.CommandLine,
                e => e.TaskName,
                e => e.Importance.ToString(),
                e => e.EndLineNumber.ToString(),
                e => e.File,
                e => e.LineNumber.ToString(),
                e => e.Message,
                e => e.ProjectFile,
                e => e.Subcategory);
        }

        [Fact]
        public void RoundtripProjectEvaluationStartedEventArgs()
        {
            var args = new ProjectEvaluationStartedEventArgs("Message")
            {
                BuildEventContext = BuildEventContext.Invalid,
                ProjectFile = @"C:\foo\bar.proj",
            };

            Roundtrip(args,
                e => e.Message,
                e => e.ProjectFile);
        }

        [Fact]
        public void RoundtripProjectEvaluationFinishedEventArgs()
        {
            var args = new ProjectEvaluationFinishedEventArgs("Message")
            {
                BuildEventContext = BuildEventContext.Invalid,
                ProjectFile = @"C:\foo\bar.proj",
            };

            Roundtrip(args,
                e => e.Message,
                e => e.ProjectFile);
        }

        [Fact]
        public void RoundtripProjectImportedEventArgs()
        {
            var args = new ProjectImportedEventArgs(
                1,
                2,
                "Message")
            {
                BuildEventContext = BuildEventContext.Invalid,
                ImportedProjectFile = "foo.props",
                ProjectFile = "foo.csproj",
                UnexpandedProject = "$(Something)"
            };

            Roundtrip(args,
                e => e.ImportedProjectFile,
                e => e.UnexpandedProject,
                e => e.Importance.ToString(),
                e => e.LineNumber.ToString(),
                e => e.ColumnNumber.ToString(),
                e => e.LineNumber.ToString(),
                e => e.Message,
                e => e.ProjectFile);
        }

        [Fact]
        public void ReadingCorruptedStreamThrows()
        {
            var memoryStream = new MemoryStream();
            var binaryWriter = new BinaryWriter(memoryStream);
            var buildEventArgsWriter = new BuildEventArgsWriter(binaryWriter);

            var args = new BuildStartedEventArgs(
                "Message",
                "HelpKeyword",
                DateTime.Parse("3/1/2017 11:11:56 AM"));

            buildEventArgsWriter.Write(args);

            long length = memoryStream.Length;

            for (long i = length - 1; i >= 0; i--) // try all possible places where a stream might end abruptly
            {
                memoryStream.SetLength(i); // pretend that the stream abruptly ends
                memoryStream.Position = 0;

                var binaryReader = new BinaryReader(memoryStream);
                var buildEventArgsReader = new BuildEventArgsReader(binaryReader);

                Assert.Throws<EndOfStreamException>(() => buildEventArgsReader.Read());
            }
        }

        private string ToString(BuildEventContext context)
        {
            return $"{context.BuildRequestId} {context.NodeId} {context.ProjectContextId} {context.ProjectInstanceId} {context.SubmissionId} {context.TargetId} {context.TaskId}";
        }

        private string ToString(IDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return "null";
            }

            return string.Join(";", dictionary.Select(kvp => kvp.Key + "=" + kvp.Value));
        }

        private string ToString(IEnumerable<ITaskItem> items)
        {
            return string.Join(";", items.Select(i => ToString(i)));
        }

        private string ToString(ITaskItem i)
        {
            return i.ItemSpec + string.Join(";", i.CloneCustomMetadata().Keys.OfType<string>().Select(k => i.GetMetadata(k)));
        }

        private void Roundtrip<T>(T args, params Func<T, string>[] fieldsToCompare)
            where T : BuildEventArgs
        {
            var memoryStream = new MemoryStream();
            var binaryWriter = new BinaryWriter(memoryStream);
            var buildEventArgsWriter = new BuildEventArgsWriter(binaryWriter);

            buildEventArgsWriter.Write(args);

            long length = memoryStream.Length;

            memoryStream.Position = 0;

            var binaryReader = new BinaryReader(memoryStream);
            var buildEventArgsReader = new BuildEventArgsReader(binaryReader);
            var deserializedArgs = (T)buildEventArgsReader.Read();

            Assert.Equal(length, memoryStream.Position);

            Assert.NotNull(deserializedArgs);
            Assert.Equal(args.GetType(), deserializedArgs.GetType());

            foreach (var field in fieldsToCompare)
            {
                var expected = field(args);
                var actual = field(deserializedArgs);
                Assert.Equal(expected, actual);
            }
        }
    }
}
