using System;

namespace PlainCQRS.Core.Common
{
    public class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(string message) : base(message)
        {
        }

        public HandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}