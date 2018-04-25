using System;
using Devebropers.Domains;
using Devebropers.Firebase.Messaging;

namespace Devebropers.Messaging
{
    /// <summary>
    /// The messaging domain
    /// </summary>
    public class MessagingDomainFactories : IDomainFactories
    {
        public virtual IMessageSender MessageSender { get; }
        
        /// <summary>
        /// Gets a <see cref="ISubscriptionManager"/>
        /// </summary>
        public virtual ISubscriptionManager SubscriptionManager { get; }
        
        /// <summary>
        /// Gets a <see cref="IMessageFactory"/>
        /// </summary>
        public virtual IMessageFactory MessageFactory { get; }

        /// <summary>
        /// Constructs a <see cref="MessagingDomainFactories"/>
        /// </summary>
        /// <param name="firebaseMessaging">The <see cref="IFirebaseMessaging"/></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseMessaging"/>
        /// </exception>
        public MessagingDomainFactories(IFirebaseMessaging firebaseMessaging)
        {
            MessageSender = new MessageSender(this, firebaseMessaging);
            
            SubscriptionManager = new SubscriptionManager(this, firebaseMessaging);
            MessageFactory = new MessageFactory(this);
        }
    }
}
