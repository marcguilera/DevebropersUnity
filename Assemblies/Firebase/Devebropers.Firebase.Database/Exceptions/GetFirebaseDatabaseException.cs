using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Database
{
    public class GetFirebaseDatabaseException : FirebaseDatabaseException
    {
        public GetFirebaseDatabaseException(string key) : base(key)
        {
        }

        protected GetFirebaseDatabaseException([NotNull] SerializationInfo info, StreamingContext context, string key) : base(info, context, key)
        {
        }

        public GetFirebaseDatabaseException(string message, string key) : base(message, key)
        {
        }

        public GetFirebaseDatabaseException(string message, Exception innerException, string key) : base(message, innerException, key)
        {
        }
    }
}