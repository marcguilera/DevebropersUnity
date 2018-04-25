using System;
using Firebase.Messaging;

namespace Devebropers.Firebase.Messaging
{
    public delegate void OnTokenRecivedEventHandler(string token);
    public delegate void OnMessageReceivedEventHandler(FirebaseMessage message);
    public delegate void OnMessageSentEventHandler(FirebaseMessage message);
    public delegate void OnSubscribedEventHandler(string token);
    public delegate void OnUnsubscribedEventHandler(string token);
    
    /// <summary>
    /// Represents the firebase messagign system
    /// </summary>
    public interface IFirebaseMessaging
    {
        event OnTokenRecivedEventHandler OnTokenReceived;
        event OnMessageReceivedEventHandler OnMessageReceived;
        event OnMessageSentEventHandler OnMessageSent;
        event OnSubscribedEventHandler OnSubscribed;
        event OnUnsubscribedEventHandler OnUnsubscribed;
        
        /// <summary>
        /// A stream of tokens received
        /// </summary>
        IObservable<string> Tokens { get; }
        
        /// <summary>
        /// A stream of <see cref="FirebaseMessages"/> received
        /// </summary>
        IObservable<FirebaseMessage> Messages { get; }
        
        /// <summary>
        /// Sends a <see cref="FirebaseMessage"/>
        /// </summary>
        /// <param name="message">The <see cref="FirebaseMessage"/></param>
        void Send(FirebaseMessage message);
        
        /// <summary>
        /// Subscribes to a topic
        /// </summary>
        /// <param name="topic">The topic to subscribe</param>
        void Subscribe(string topic);
        
        /// <summary>
        /// Unsubscribes to a topic
        /// </summary>
        /// <param name="topic">The topic to unsubscribe</param>
        void Unsubscribe(string topic);
    }
}