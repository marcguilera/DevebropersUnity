using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Friendship.Requests.Entities;

namespace Devebropers.Friendship.Requests
{
    internal class OutgoingFriendRequest : FriendRequestBase, IOutgoingFriendRequest
    {
        public OutgoingFriendRequest(IFriendRequestEntity entity) 
            : base (entity)
        {
        }
        
        public IObservable<Unit> Cancel()
        {
            return _entity
                .Delete();
        }
    }
}