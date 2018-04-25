using System;
using System.Reactive.Linq;
using Devebropers.Firebase.Messaging;
using Devebropers.Messaging.Messages;
using Firebase.Messaging;

namespace Devebropers.Messaging
{
    internal class SubscriptionManager : MessagingBase, ISubscriptionManager
    {
        public event OnMessageReceivedEventHandler OnMessageReceived;
        public event OnSubscribedEventHandler OnSubscribed;
        public event OnUnsubscribedEventHandler OnUnsubscribed;
        
        public IObservable<IReceivedMessage> Messages => GetMessages();
        
        public SubscriptionManager(MessagingDomainFactories domainFactories, IFirebaseMessaging firebaseMessaging) 
            : base(domainFactories, firebaseMessaging)
        {
        }
        
        public void Subscribe(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException(nameof(topic));
            }
            
            _firebaseMessaging.Subscribe(topic);
            OnSubscribed?.Invoke(topic);
        }

        public void Unsubscribe(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException(nameof(topic));
            }
            
            _firebaseMessaging.Unsubscribe(topic);
            OnUnsubscribed?.Invoke(topic);
        }

        private IObservable<IReceivedMessage> GetMessages()
        {
            return _firebaseMessaging
                .Messages
                .Select(ToMessage)
                .Do(OnReceived);
        }

        private IReceivedMessage ToMessage(FirebaseMessage message)
        {
            return new ReceivedMessage(message);
        }

        private void OnReceived(IMessage message)
        {
            OnMessageReceived?.Invoke(message);
        }
    }
}