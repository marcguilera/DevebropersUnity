using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine.XR.WSA.Persistence;

namespace Devebropers.Firebase.Database
{
    public class NotFoundGetFirebaseDatabaseException : GetFirebaseDatabaseException
    {
        public NotFoundGetFirebaseDatabaseException(string key) : base(key)
        {
        }

        public NotFoundGetFirebaseDatabaseException([NotNull] SerializationInfo info, StreamingContext context, string key) : base(info, context, key)
        {
        }

        public NotFoundGetFirebaseDatabaseException(string message, string key) : base(message, key)
        {
        }

        public NotFoundGetFirebaseDatabaseException(string message, Exception innerException, string key) : base(message, innerException, key)
        {
        }
    }
}