using Devebropers.Data.Entities;

namespace Devebropers.Friendship.Friends.Entities
{
    internal interface IFriendEntity : IUpdateableEntity<string>
    {
        string UserId { get; }
        string Name { get; }
    }
}