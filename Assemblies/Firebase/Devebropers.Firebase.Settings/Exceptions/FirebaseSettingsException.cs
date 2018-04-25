using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Settings
{
    public class FirebaseSettingsException : Exception
    {
        public FirebaseSettingsException()
        {
        }

        protected FirebaseSettingsException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FirebaseSettingsException(string message) : base(message)
        {
        }

        public FirebaseSettingsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}