using System;
using Devebropers.Common;
using Devebropers.Friendship.Friends.Entities;
using Devebropers.Friendship.Requests.Entities;

namespace Devebropers.Friendship.Requests
{
    internal abstract class FriendRequestBase : IFriendRequest
    {
        protected readonly IFriendRequestEntity _entity;

        public string SourceUserId => _entity.SourceUserId;
        public string SourceUserName => _entity.SourceUserName;
        public string TargetUserId => _entity.TargetUserId;
        public string TargetUserName => _entity.TargetUserName;
        public DateTime Created => _entity.Created ?? DateTime.UtcNow;

        protected FriendRequestBase(IFriendRequestEntity entity)
        {
            _entity = entity.AssignOrThrowIfNull(nameof(entity));
        }
    }
}