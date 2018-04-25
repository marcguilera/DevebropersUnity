using System;
using Devebropers.Domains;

namespace Devebropers.Firebase.Messaging
{
    /// <summary>
    /// Represents a Firebase messaging domain
    /// </summary>
    public class FirebaseMessagingDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IFirebaseMessaging"/>
        /// </summary>
        public virtual IFirebaseMessaging FirebaseMessaging { get; }

        /// <summary>
        /// Constructs a <see cref="FirebaseMessagingDomainFactories"/>
        /// </summary>
        public FirebaseMessagingDomainFactories()
        {
            FirebaseMessaging = new FirebaseMessaging(this);
        }
    }
}