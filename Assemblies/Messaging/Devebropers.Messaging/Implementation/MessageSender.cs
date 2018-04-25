using System;
using Devebropers.Firebase.Messaging;
using Devebropers.Messaging.Messages;
using Firebase.Messaging;

namespace Devebropers.Messaging
{
    internal class MessageSender : MessagingBase, IMessageSender
    {
        public event OnMessageSentEventHandler OnMessageSent;
        
        public MessageSender(MessagingDomainFactories domainFactories, IFirebaseMessaging firebaseMessaging) 
            : base(domainFactories, firebaseMessaging)
        {
        }

        public void Send(IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            
            _firebaseMessaging.Send(ToFirebase(message));
            OnMessageSent?.Invoke(message);
        }

        private static FirebaseMessage ToFirebase(IMessage message)
        {
            return new FirebaseMessage
            {
                MessageId = message.Id,
                To = message.To,
                Data = message.Data
            };
        }
    }
}