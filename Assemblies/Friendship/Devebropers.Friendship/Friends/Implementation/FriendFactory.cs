using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Devebropers.Domains;
using Devebropers.Friendship.Friends.Entities;
using Devebropers.Users;

namespace Devebropers.Friendship.Friends
{
    internal class FriendFactory : DomainObjectBase<FriendshipDomainFactories>, IFriendFactory
    {
        public FriendFactory(FriendshipDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }

        public IObservable<IEnumerable<IFriend>> GetFriends(IUserIdentifier user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return _domainFactories
                .FriendEntityFactory
                .GetFriends(user.Id)
                .Select(friends => friends.Select(ToFriend));
        }

        private IFriend ToFriend(IFriendEntity entity)
        {
            return new Friend(entity);
        }
    }
}