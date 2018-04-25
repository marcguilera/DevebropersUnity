using Devebropers.Data.Entities;

namespace Devebropers.Friendship.Requests.Entities
{
    internal class FriendRequestEntity : PersistableEntityBase<string, FriendRequestModel>, IFriendRequestEntity
    {
        public string SourceUserId => _model.SourceUserId;
        public string TargetUserId => _model.TargetUserId;
        public string SourceUserName => _model.SourceUserName;
        public string TargetUserName => _model.TargetUserName;
        public FriendRequestStatus Status
        {
            get { return _model.Status; }
            set { _model.Status = value; }
        }
        
        public FriendRequestEntity(IEntityPersister<string, FriendRequestModel> persister, FriendRequestModel model) 
            : base(persister, model)
        {
        }
    }
}