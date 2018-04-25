using System;
using System.Collections.Generic;

namespace Devebropers.Friendship.Requests.Entities
{
    internal interface IFriendRequestEntityFactory
    {
        IObservable<IEnumerable<IFriendRequestEntity>> GetIncomingFriendRequests(string targetUserId);
        IObservable<IEnumerable<IFriendRequestEntity>> GetOutgoingFriendRequests(string sourceUserId);
        IFriendRequestEntity CreateFriendRequest(string sourceUserId, string sourceUserName, string targetUserId, string targetUserName);
    }
}