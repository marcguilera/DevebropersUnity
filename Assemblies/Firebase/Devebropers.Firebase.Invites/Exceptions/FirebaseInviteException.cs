using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Devebropers.Firebase.Invites
{
    public class FirebaseInviteException : Exception
    {
        public FirebaseInviteException()
        {
        }

        protected FirebaseInviteException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FirebaseInviteException(string message) : base(message)
        {
        }

        public FirebaseInviteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}