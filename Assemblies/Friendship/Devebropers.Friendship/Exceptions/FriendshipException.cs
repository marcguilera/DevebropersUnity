using System;
using System.Runtime.Serialization;

namespace Devebropers.Friendship
{
    public class FriendshipException : Exception
    {
        public FriendshipException()
        {
        }

        protected FriendshipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FriendshipException(string message) : base(message)
        {
        }

        public FriendshipException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}