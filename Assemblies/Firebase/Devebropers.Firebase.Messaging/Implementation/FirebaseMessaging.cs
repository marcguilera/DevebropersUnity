using System;
using System.Reactive.Subjects;
using Devebropers.Domains;
using Firebase.Messaging;

namespace Devebropers.Firebase.Messaging
{
    internal class FirebaseMessaging : DomainObjectBase<FirebaseMessagingDomainFactories>, IFirebaseMessaging
    {
        public event OnTokenRecivedEventHandler OnTokenReceived;
        public event OnMessageReceivedEventHandler OnMessageReceived;
        public event OnMessageSentEventHandler OnMessageSent;
        public event OnSubscribedEventHandler OnSubscribed;
        public event OnUnsubscribedEventHandler OnUnsubscribed;
        
        public IObservable<string> Tokens => _tokenSubject;
        public IObservable<FirebaseMessage> Messages => _messageSubject;

        private readonly ReplaySubject<string> _tokenSubject;
        private readonly ReplaySubject<FirebaseMessage> _messageSubject;
        
        public FirebaseMessaging(FirebaseMessagingDomainFactories domainFactories) 
            : base(domainFactories)
        {
            _tokenSubject = new ReplaySubject<string>();
            _messageSubject = new ReplaySubject<FirebaseMessage>();
            
            global::Firebase.Messaging.FirebaseMessaging.TokenReceived += TokenReceived;
            global::Firebase.Messaging.FirebaseMessaging.MessageReceived += MessageReceived;
        }
        
        public void Send(FirebaseMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            
            global::Firebase.Messaging.FirebaseMessaging.Send(message);
            
            OnMessageSent?.Invoke(message);
        }

        public void Subscribe(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException(nameof(topic));
            }
            
            global::Firebase.Messaging.FirebaseMessaging.Subscribe(topic);
            
            OnSubscribed?.Invoke(topic);
        }
        
        public void Unsubscribe(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException(nameof(topic));
            }
            
            global::Firebase.Messaging.FirebaseMessaging.Unsubscribe(topic);
            
            OnUnsubscribed?.Invoke(topic);
        }

        private void MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            _messageSubject.OnNext(e.Message);
            OnMessageReceived?.Invoke(e.Message);
        }

        private void TokenReceived(object sender, TokenReceivedEventArgs e)
        {
            _tokenSubject.OnNext(e.Token);
            OnTokenReceived?.Invoke(e.Token);
        }
    }
}