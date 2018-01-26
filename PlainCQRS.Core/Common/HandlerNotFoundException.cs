using System;

namespace PlainCQRS.Core.Common
{
    /// <summary>
    ///     The exception that is thrown when handler for object cannot be found.
    /// </summary>
    public class HandlerNotFoundException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">A text that describes error.</param>
        public HandlerNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">A text that describes error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public HandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}