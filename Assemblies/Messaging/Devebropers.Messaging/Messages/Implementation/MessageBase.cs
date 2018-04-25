using System;
using System.Collections.Generic;
using Devebropers.Common;
using Firebase.Messaging;

namespace Devebropers.Messaging.Messages
{
    internal abstract class MessageBase : IReceivedMessage
    {
        protected FirebaseMessage _message { get; }
        public string Id => _message.MessageId;
        public TimeSpan TimeToLive => _message.TimeToLive;
        public string To => _message.To;
        public string From => _message.From;
        public MessagePriority Priority => GetPriority();
        public IDictionary<string, string> Data => _message.Data;

        protected MessageBase(FirebaseMessage message)
        {
            _message = message.AssignOrThrowIfNull(nameof(message));
        }

        public void Dispose()
        {
            _message.Dispose();
        }
        
        private MessagePriority GetPriority()
        {
            MessagePriority priority;
            var didParse = MessagePriority.TryParse(_message.Priority, out priority);
            return didParse ? priority : MessagePriority.Normal;
        }
        
        
    }
}