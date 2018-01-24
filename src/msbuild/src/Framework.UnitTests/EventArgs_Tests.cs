﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//-----------------------------------------------------------------------
// </copyright>
// <summary>Unit tests for EventArgsTests</summary>
//-----------------------------------------------------------------------

using System;
using System.IO;
#if FEATURE_BINARY_SERIALIZATION
using System.Runtime.Serialization.Formatters.Binary;
#endif

using Microsoft.Build.Framework;
using Xunit;

namespace Microsoft.Build.UnitTests
{
    /// <summary>
    /// Unit test the base class BuildEventArgs
    /// </summary>
    public class EventArgs_Tests
    {
        #region BaseClass Equals Tests

        /// <summary>
        /// Base instance of a BuildEventArgs some default data, this is used during the tests
        /// to verify the equals operators.
        /// </summary>
        private static GenericBuildEventArgs s_baseGenericEvent = null;

        /// <summary>
        /// Setup the test, this method is run ONCE for the entire test fixture
        /// </summary>
        public EventArgs_Tests()
        {
            s_baseGenericEvent = new GenericBuildEventArgs("Message", "HelpKeyword", "senderName");
            s_baseGenericEvent.BuildEventContext = new BuildEventContext(9, 8, 7, 6);
        }

        /// <summary>
        /// Trivially exercise getHashCode.
        /// </summary>
        [Fact]
        public void TestGetHashCode()
        {
            s_baseGenericEvent.GetHashCode();
        }

        /// <summary>
        /// Trivially exercise event args default ctors to boost Frameworks code coverage
        /// </summary>
        [Fact]
        public void EventArgsCtors()
        {
            GenericBuildEventArgs genericEventTest = new GenericBuildEventArgs();
        }
        #endregion

#if FEATURE_BINARY_SERIALIZATION
        /// <summary>
        /// Verify a whidbey project started event can be deserialized, the whidbey event is stored in a serialized base64 string.
        /// </summary>
        [Fact]
        public void TestDeserialization()
        {
            string base64OldProjectStarted = "AAEAAAD/////AQAAAAAAAAAMAgAAAFxNaWNyb3NvZnQuQnVpbGQuRnJhbWV3b3JrLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYQUBAAAAMU1pY3Jvc29mdC5CdWlsZC5GcmFtZXdvcmsuUHJvamVjdFN0YXJ0ZWRFdmVudEFyZ3MHAAAAC3Byb2plY3RGaWxlC3RhcmdldE5hbWVzFkJ1aWxkRXZlbnRBcmdzK21lc3NhZ2UaQnVpbGRFdmVudEFyZ3MraGVscEtleXdvcmQZQnVpbGRFdmVudEFyZ3Mrc2VuZGVyTmFtZRhCdWlsZEV2ZW50QXJncyt0aW1lc3RhbXAXQnVpbGRFdmVudEFyZ3MrdGhyZWFkSWQBAQEBAQAADQgCAAAABgMAAAALcHJvamVjdEZpbGUGBAAAAAt0YXJnZXROYW1lcwYFAAAAB21lc3NhZ2UGBgAAAAtoZWxwS2V5d29yZAYHAAAAB01TQnVpbGQBl5vjTYvIiAsAAAAL";
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] binaryObject = Convert.FromBase64String(base64OldProjectStarted);
            ms.Write(binaryObject, 0, binaryObject.Length);
            ms.Position = 0;
            ProjectStartedEventArgs pse = (ProjectStartedEventArgs)bf.Deserialize(ms);
            Assert.Equal(0, string.Compare(pse.Message, "message", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(0, string.Compare(pse.ProjectFile, "projectFile", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(pse.ProjectId, -1);
            Assert.Equal(0, string.Compare(pse.TargetNames, "targetNames", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(pse.BuildEventContext, BuildEventContext.Invalid);
            Assert.Equal(pse.ParentProjectBuildEventContext, BuildEventContext.Invalid);
        }
#endif

        /// <summary>
        /// Verify the BuildEventContext is exercised
        /// </summary>
        [Fact]
        public void ExerciseBuildEventContext()
        {
            BuildEventContext parentBuildEventContext = new BuildEventContext(0, 0, 0, 0, 0, 0, 0);

            BuildEventContext currentBuildEventContext = new BuildEventContext(0, 1, 2, 3, 4, 5, 6);

            BuildEventContext currentBuildEventContextSubmission = new BuildEventContext(1, 0, 0, 0, 0, 0, 0);
            BuildEventContext currentBuildEventContextNode = new BuildEventContext(0, 1, 0, 0, 0, 0, 0);
            BuildEventContext currentBuildEventContextEvaluation = new BuildEventContext(0, 0, 1, 0, 0, 0, 0);
            BuildEventContext currentBuildEventContextProjectInstance = new BuildEventContext(0, 0, 0, 1, 0, 0, 0);
            BuildEventContext currentBuildEventProjectContext = new BuildEventContext(0, 0, 0, 0, 1, 0, 0);
            BuildEventContext currentBuildEventContextTarget = new BuildEventContext(0, 0, 0, 0, 0, 1, 0);
            BuildEventContext currentBuildEventContextTask = new BuildEventContext(0, 0, 0, 0, 0, 0, 1);
            BuildEventContext allDifferent = new BuildEventContext(1, 1, 1, 1, 1, 1, 1);
            BuildEventContext allSame = new BuildEventContext(0, 0, 0, 0, 0, 0, 0);

            ProjectStartedEventArgs startedEvent = new ProjectStartedEventArgs(-1, "Message", "HELP", "File", "Targets", null, null, parentBuildEventContext);
            startedEvent.BuildEventContext = currentBuildEventContext;
            
            // submissison ID does not partake into equality
            Assert.Equal(parentBuildEventContext.GetHashCode(), currentBuildEventContextSubmission.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventContext.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventContextNode.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventContextEvaluation.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventContextProjectInstance.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventProjectContext.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventContextTarget.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), currentBuildEventContextTask.GetHashCode());
            Assert.NotEqual(parentBuildEventContext.GetHashCode(), allDifferent.GetHashCode());
            Assert.Equal(parentBuildEventContext.GetHashCode(), allSame.GetHashCode());

            // submissison ID does not partake into equality
            Assert.Equal(parentBuildEventContext, currentBuildEventContextSubmission);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventContext);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventContextNode);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventContextEvaluation);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventContextProjectInstance);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventProjectContext);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventContextTarget);
            Assert.NotEqual(parentBuildEventContext, currentBuildEventContextTask);
            Assert.NotEqual(parentBuildEventContext, allDifferent);
            Assert.Equal(parentBuildEventContext, allSame);

            Assert.Equal(currentBuildEventContext, currentBuildEventContext);
            Assert.NotEqual(parentBuildEventContext, null);
            Assert.NotEqual(currentBuildEventContext, new object());

            Assert.NotNull(startedEvent.BuildEventContext);

            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.SubmissionId);
            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.NodeId);
            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.EvaluationId);
            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.ProjectInstanceId);
            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.ProjectContextId);
            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.TargetId);
            Assert.Equal(0, startedEvent.ParentProjectBuildEventContext.TaskId);

            Assert.Equal(0, startedEvent.BuildEventContext.SubmissionId);
            Assert.Equal(1, startedEvent.BuildEventContext.NodeId);
            Assert.Equal(2, startedEvent.BuildEventContext.EvaluationId);
            Assert.Equal(3, startedEvent.BuildEventContext.ProjectInstanceId);
            Assert.Equal(4, startedEvent.BuildEventContext.ProjectContextId);
            Assert.Equal(5, startedEvent.BuildEventContext.TargetId);
            Assert.Equal(6, startedEvent.BuildEventContext.TaskId);
        }

        /// <summary>
        /// A generic buildEvent arg to test the equals method
        /// </summary>
        internal class GenericBuildEventArgs : BuildEventArgs
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public GenericBuildEventArgs()
                : base()
            {
            }

            /// <summary>
            /// This constructor allows all event data to be initialized
            /// </summary>
            /// <param name="message">text message</param>
            /// <param name="helpKeyword">help keyword </param>
            /// <param name="senderName">name of event sender</param>
            public GenericBuildEventArgs(string message, string helpKeyword, string senderName)
                : base(message, helpKeyword, senderName)
            {
            }

            /// <summary>
            /// This constructor allows all data including timeStamps to be initialized
            /// </summary>
            /// <param name="message">text message</param>
            /// <param name="helpKeyword">help keyword </param>
            /// <param name="senderName">name of event sender</param>
            /// <param name="eventTimeStamp">TimeStamp of when the event was created</param>
            public GenericBuildEventArgs(string message, string helpKeyword, string senderName, DateTime eventTimeStamp)
                : base(message, helpKeyword, senderName, eventTimeStamp)
            {
            }
        }
    }
}