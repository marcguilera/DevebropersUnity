using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Database
{
    public class DeleteFirebaseDatabaseException : FirebaseDatabaseException
    {
        public DeleteFirebaseDatabaseException(string key) : base(key)
        {
        }

        protected DeleteFirebaseDatabaseException([NotNull] SerializationInfo info, StreamingContext context, string key) : base(info, context, key)
        {
        }

        public DeleteFirebaseDatabaseException(string message, string key) : base(message, key)
        {
        }

        public DeleteFirebaseDatabaseException(string message, Exception innerException, string key) : base(message, innerException, key)
        {
        }
    }
}