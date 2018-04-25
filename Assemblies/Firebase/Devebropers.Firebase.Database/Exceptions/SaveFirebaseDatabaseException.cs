using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Database
{
    public class SaveFirebaseDatabaseException : FirebaseDatabaseException
    {
        public string Json { get; }

        public SaveFirebaseDatabaseException(string key, string json) : base(key)
        {
            Json = json;
        }

        protected SaveFirebaseDatabaseException([NotNull] SerializationInfo info, StreamingContext context, string key, string json) : base(info, context, key)
        {
            Json = json;
        }

        public SaveFirebaseDatabaseException(string message, string key, string json) : base(message, key)
        {
            Json = json;
        }

        public SaveFirebaseDatabaseException(string message, Exception innerException, string key, string json) : base(message, innerException, key)
        {
            Json = json;
        }
    }
}