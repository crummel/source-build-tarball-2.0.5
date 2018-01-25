namespace Microsoft.ApplicationInsights.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// This exception is used to notify the user that the set of inner exceptions has been trimmed because it exceeded our allowed send limit.
    /// </summary>
#if !CORE_PCL 
    [Serializable]
#endif
    internal class InnerExceptionCountExceededException : 
        Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class.
        /// </summary>
        public InnerExceptionCountExceededException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public InnerExceptionCountExceededException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public InnerExceptionCountExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
#if !CORE_PCL

        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param><param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param><exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception><exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected InnerExceptionCountExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}