using System;
using Devebropers.Messaging.Messages;

namespace Devebropers.Messaging
{
    public delegate void OnMessageReceivedEventHandler(IMessage message);
    public delegate void OnSubscribedEventHandler(string topic);
    public delegate void OnUnsubscribedEventHandler(string topic);
    
    /// <summary>
    /// Manages the subscriptions
    /// </summary>
    public interface ISubscriptionManager
    {
        event OnMessageReceivedEventHandler OnMessageReceived;
        event OnSubscribedEventHandler OnSubscribed;
        event OnUnsubscribedEventHandler OnUnsubscribed;
        
        /// <summary>
        /// Stream of incoming messages
        /// </summary>
        IObservable<IReceivedMessage> Messages { get; }
        
        /// <summary>
        /// Subscribes to a topic
        /// </summary>
        /// <param name="topic">The topic to subscribe</param>
        /// <exception cref="ArgumentException"><paramref name="topic"/></exception>
        void Subscribe(string topic);
        
        /// <summary>
        /// Unsubscribes to a topic
        /// </summary>
        /// <param name="topic">The topic to unsubscribe</param>
        /// <exception cref="ArgumentException"><paramref name="topic"/></exception>
        void Unsubscribe(string topic);
    }
}