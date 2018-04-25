using Devebropers.Data.Entities;

namespace Devebropers.Friendship.Friends.Entities
{
    internal class FriendEntity : PersistableEntityBase<string, FriendModel>, IFriendEntity
    {
        public string UserId => _model.UserId;
        public string Name => _model.Name;
        
        public FriendEntity(IEntityPersister<string, FriendModel> persister, FriendModel model) 
            : base(persister, model)
        {
        }
    }
}