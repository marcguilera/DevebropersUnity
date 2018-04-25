using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Storage.Local.Files
{
    public class FileException : Exception
    {
        public FileException()
        {
        }

        protected FileException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FileException(string message) : base(message)
        {
        }

        public FileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}