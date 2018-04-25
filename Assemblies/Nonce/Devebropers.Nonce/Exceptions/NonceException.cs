using System;
using System.Runtime.Serialization;

namespace Devebropers.Nonce
{
    public class NonceException : Exception
    {
        public NonceException()
        {
        }

        protected NonceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NonceException(string message) : base(message)
        {
        }

        public NonceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}