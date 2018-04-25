using System;
using System.Collections.Generic;
using Devebropers.Common;
using Devebropers.Data.Entities;
using Devebropers.Data.Persistance;
using Firebase.Database;
using Query = Devebropers.Firebase.Database.Query;

namespace Devebropers.Friendship.Requests.Entities
{
    internal class FriendshipFriendRequestEntityFactory : FirebaseEntityFactoryBase<IFriendRequestEntity,FriendRequestModel>, IFriendRequestEntityFactory
    {
        private DatabaseReference _databaseReference = FriendshipDatabaseReferences.Requests();
        
        public FriendshipFriendRequestEntityFactory(IFirebaseGetter firebaseGetter, IFirebaseUpdater firebaseUpdater) 
            : base(firebaseGetter, firebaseUpdater)
        {
        }
        
        public IObservable<IEnumerable<IFriendRequestEntity>> GetIncomingFriendRequests(string targetUserId)
        {
            if (string.IsNullOrWhiteSpace(targetUserId))
            {
                throw new ArgumentException(nameof(targetUserId));
            }

            var query = Query
                .Create(_databaseReference)
                .EqualTo("TargetUserId", targetUserId);
            
            return GetEnumerable(query);
        }

        public IObservable<IEnumerable<IFriendRequestEntity>> GetOutgoingFriendRequests(string sourceUserId)
        {
            if (string.IsNullOrWhiteSpace(sourceUserId))
            {
                throw new ArgumentException(nameof(sourceUserId));
            }
            
            var query = Query
                .Create(_databaseReference)
                .EqualTo("SourceUserId", sourceUserId);
            
            return GetEnumerable(query);
        }

        public IFriendRequestEntity CreateFriendRequest(string sourceUserId, string sourceUserName, string targetUserId, string targetUserName)
        {
            var model = new FriendRequestModel
            {
                SourceUserId = sourceUserId.AssignOrThrowIfNullOrWhiteSpace(nameof(sourceUserId)),
                SourceUserName = sourceUserName.AssignOrThrowIfNullOrWhiteSpace(nameof(sourceUserName)),
                TargetUserId = targetUserId.AssignOrThrowIfNullOrWhiteSpace(nameof(targetUserId)),
                TargetUserName = targetUserName.AssignOrThrowIfNullOrWhiteSpace(nameof(targetUserName)),
                Status = FriendRequestStatus.Pending
            };

            return CreateChild(_databaseReference, model);
        }

        protected override IFriendRequestEntity NewEntity(IEntityPersister<string, FriendRequestModel> persister, FriendRequestModel model)
        {
            return new FriendRequestEntity(persister, model);
        }
    }
}