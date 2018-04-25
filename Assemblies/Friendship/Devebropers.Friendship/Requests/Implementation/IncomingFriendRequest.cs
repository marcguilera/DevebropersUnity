using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Friendship.Requests.Entities;

namespace Devebropers.Friendship.Requests
{
    internal class IncomingFriendRequest : FriendRequestBase, IIncomingFriendRequest
    {
        public IncomingFriendRequest(IFriendRequestEntity entity) 
            : base(entity)
        {
        }
        
        public IObservable<Unit> Accept()
        {
            _entity.Status = FriendRequestStatus.Accepted;
            return _entity
                .Save();
        }

        public IObservable<Unit> Decline()
        {
            return _entity
                .Delete();
        }

        
    }
}