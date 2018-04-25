using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Storage
{
    public class FirebaseStorageException : Exception
    {
        public FirebaseStorageException()
        {
        }

        protected FirebaseStorageException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FirebaseStorageException(string message) : base(message)
        {
        }

        public FirebaseStorageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}