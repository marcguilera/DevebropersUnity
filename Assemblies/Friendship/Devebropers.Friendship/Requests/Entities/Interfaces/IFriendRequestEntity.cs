using System;
using Devebropers.Data.Entities;

namespace Devebropers.Friendship.Requests.Entities
{
    internal interface IFriendRequestEntity : IUpdateableEntity<string>
    {
        FriendRequestStatus Status { get; set; }
        string SourceUserId { get; }
        string TargetUserId { get; }
        string SourceUserName { get; }
        string TargetUserName { get; }
    }
}