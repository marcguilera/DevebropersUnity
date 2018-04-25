using Devebropers.Data.Entities;
using Devebropers.Users;

namespace Devebropers.Friendship.Friends.Entities
{
    internal class FriendModel : ModelBase<string>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}