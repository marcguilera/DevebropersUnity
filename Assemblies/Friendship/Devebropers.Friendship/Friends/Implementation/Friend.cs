using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Friendship.Friends.Entities;

namespace Devebropers.Friendship.Friends
{
    internal class Friend : IFriend
    {
        private readonly IFriendEntity _entity;

        public string UserId => _entity.UserId;
        public string Name => _entity.Name;

        public Friend(IFriendEntity entity)
        {
            _entity = entity.AssignOrThrowIfNull(nameof(entity));
        }
        
        public IObservable<Unit> Delete()
        {
            return _entity
                .Delete();
        }
    }
}