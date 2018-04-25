using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Data.Persistance
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        protected NotFoundException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}