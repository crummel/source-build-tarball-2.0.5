﻿namespace Microsoft.VisualStudio.TestPlatform.ObjectModel
{
    //
    // Summary:
    //     Specifies what messages to output for the System.Diagnostics.Debug, System.Diagnostics.Trace
    //     and System.Diagnostics.TraceSwitch classes.
    public enum PlatformTraceLevel
    {
        //
        // Summary:
        //     Output no tracing and debugging messages.
        Off = 0,
        //
        // Summary:
        //     Output error-handling messages.
        Error = 1,
        //
        // Summary:
        //     Output warnings and error-handling messages.
        Warning = 2,
        //
        // Summary:
        //     Output informational messages, warnings, and error-handling messages.
        Info = 3,
        //
        // Summary:
        //     Output all debugging and tracing messages.
        Verbose = 4
    }


    public partial interface IPlatformEqtTrace
    {
        /// <summary>
        /// Adds the message to the trace log.
        /// The line becomes:
        ///     [I, PID, ThreadID, 2003/06/11 11:56:07.445] CallingAssemblyName: message.
        /// </summary>
        /// <param name="level">Trace level.</param>
        /// <param name="message">The message to add to trace.</param>
        void WriteLine(PlatformTraceLevel level, string message);

        /// <summary>
        /// Initializes the verbose tracing with custom log file
        /// And overrides if any trace is set before
        /// </summary>
        /// <param name="customLogFile">A custom log file for trace messages.</param>
        bool InitializeVerboseTrace(string customLogFile);

        /// <summary>
        /// Gets a value indicating if tracing is enabled for a trace level.
        /// </summary>
        /// <param name="traceLevel">Trace level.</param>
        /// <returns>True if tracing is enabled.</returns>
        bool ShouldTrace(PlatformTraceLevel traceLevel);

        /// <summary>
        /// Gets file path for trace log file.
        /// </summary>
        /// <returns>True if tracing is enabled.</returns>
        string GetLogFile();

        /// <summary>
        /// Sets platfrom specific trace value for tracing verbosity.
        /// </summary>
        /// <param name="traceLevel">PlatformTraceLevel.</param>
        void SetTraceLevel(PlatformTraceLevel value);

        /// <summary>
        /// Gets platfrom specific trace value for tracing verbosity.
        /// </summary>
        PlatformTraceLevel GetTraceLevel();
    }
}