using Devebropers.Data.Entities;

namespace Devebropers.Friendship.Requests.Entities
{
    internal class FriendRequestModel : ModelBase<string>
    {
        public FriendRequestStatus Status { get; set; }
        public string SourceUserId { get; set; }
        public string TargetUserId { get; set; }
        public string SourceUserName { get; set; }
        public string TargetUserName { get; set; }
    }
}