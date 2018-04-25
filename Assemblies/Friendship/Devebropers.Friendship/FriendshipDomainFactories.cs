using System;
using Devebropers.Data.Persistance;
using Devebropers.Domains;
using Devebropers.Friendship.Friends;
using Devebropers.Friendship.Friends.Entities;
using Devebropers.Friendship.Requests;
using Devebropers.Friendship.Requests.Entities;

namespace Devebropers.Friendship
{
    /// <summary>
    /// The friendship domain
    /// </summary>
    public class FriendshipDomainFactories : IDomainFactories
    {
        internal virtual IFriendRequestEntityFactory FriendRequestEntityFactory { get; }
        internal virtual IFriendEntityFactory FriendEntityFactory { get; }
        
        /// <summary>
        /// Gets a <see cref="IFriendRequestFactory"/>
        /// </summary>
        public virtual IFriendRequestFactory FriendRequestFactory { get; }
        
        /// <summary>
        /// Gets a <see cref="IFriendFactory"/>
        /// </summary>
        public virtual IFriendFactory FriendFactory { get; }

        /// <summary>
        /// Constructs a <see cref="FriendshipDomainFactories"/>
        /// </summary>
        /// <param name="firebaseGetter">A <see cref="IFirebaseGetter"/></param>
        /// <param name="firebaseUpdater">A <see cref="IFirebaseUpdater"/></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseGetter"/>
        ///     <paramref name="firebaseUpdater"/>
        /// </exception>
        public FriendshipDomainFactories(IFirebaseGetter firebaseGetter, IFirebaseUpdater firebaseUpdater)
        {
            FriendRequestEntityFactory = new FriendshipFriendRequestEntityFactory(firebaseGetter, firebaseUpdater);
            FriendRequestFactory = new FriendRequestFactory(this);
            
            FriendEntityFactory = new FriendEntityFactory(firebaseGetter, firebaseUpdater);
            FriendFactory = new FriendFactory(this);
        }
    }
}
