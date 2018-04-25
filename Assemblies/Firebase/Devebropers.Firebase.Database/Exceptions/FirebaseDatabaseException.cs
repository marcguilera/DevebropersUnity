using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Database
{
    public class FirebaseDatabaseException : Exception
    {
        public string Key { get; }

        public FirebaseDatabaseException(string key)
        {
            Key = key;
        }

        protected FirebaseDatabaseException([NotNull] SerializationInfo info, StreamingContext context, string key) : base(info, context)
        {
            Key = key;
        }

        public FirebaseDatabaseException(string message, string key) : base(message)
        {
            Key = key;
        }

        public FirebaseDatabaseException(string message, Exception innerException, string key) : base(message, innerException)
        {
            Key = key;
        }
    }
}