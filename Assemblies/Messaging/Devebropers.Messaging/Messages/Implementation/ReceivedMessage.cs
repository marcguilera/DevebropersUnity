using System;
using System.Collections.Generic;
using Devebropers.Common;
using Firebase.Messaging;

namespace Devebropers.Messaging.Messages
{
    internal class ReceivedMessage : MessageBase, IReceivedMessage
    {
        public TimeSpan TimeToLive => _message.TimeToLive;

        private readonly FirebaseMessage _message;

        public ReceivedMessage(FirebaseMessage message)
            : base (message)
        {
        }
    }
}