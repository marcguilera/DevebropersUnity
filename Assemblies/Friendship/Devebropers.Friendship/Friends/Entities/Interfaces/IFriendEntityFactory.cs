using System;
using System.Collections.Generic;

namespace Devebropers.Friendship.Friends.Entities
{
    internal interface IFriendEntityFactory
    {
        IFriendEntity Create(string sourceUserId, string targetUserId, string targetUserName);
        IObservable<IEnumerable<IFriendEntity>> GetFriends(string userId);
    }
}