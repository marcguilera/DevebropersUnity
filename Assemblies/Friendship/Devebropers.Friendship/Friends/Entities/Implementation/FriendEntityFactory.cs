using System;
using System.Collections.Generic;
using Devebropers.Common;
using Devebropers.Data.Entities;
using Devebropers.Data.Persistance;
using Firebase.Database;
using Query = Devebropers.Firebase.Database.Query;

namespace Devebropers.Friendship.Friends.Entities
{
    internal class FriendEntityFactory : FirebaseEntityFactoryBase<IFriendEntity, FriendModel>, IFriendEntityFactory
    {

        private DatabaseReference _databaseReference = FriendshipDatabaseReferences.Friends();
        
        public FriendEntityFactory(IFirebaseGetter firebaseGetter, IFirebaseUpdater firebaseUpdater) : base(firebaseGetter, firebaseUpdater)
        {
        }

        public IFriendEntity Create(string sourceUserId, string targetUserId, string targetUserName)
        {
            var model = new FriendModel
            {
                Name = targetUserName.AssignOrThrowIfNullOrWhiteSpace(nameof(targetUserName)),
                UserId = targetUserId.AssignOrThrowIfNullOrWhiteSpace(nameof(targetUserId))
            };

            var reference = _databaseReference.Child(sourceUserId);
            return CreateChild(reference, model);
        }

        public IObservable<IEnumerable<IFriendEntity>> GetFriends(string userId)
        {
            var reference = _databaseReference.Child(userId);
            var query = Query.Create(reference);
            return GetEnumerable(query);
        }
        
        protected override IFriendEntity NewEntity(IEntityPersister<string, FriendModel> persister, FriendModel model)
        {
            return new FriendEntity(persister, model);
        }
    }
}