namespace Devebropers.Diagnostics.Events.Friendship
{
    public class FriendRequestSentEvent : EventBase
    {
        private const string _name = "Friendship:FriendRequestSent";
        public FriendRequestSentEvent(IEventSender eventSender, string sourceUserId, string targetUserId) 
            : base(eventSender, _name)
        {
            if (!string.IsNullOrWhiteSpace(sourceUserId))
            {
                PutArgument("SourceUserId", sourceUserId);
            }
            if (!string.IsNullOrWhiteSpace(targetUserId))
            {
                PutArgument("TargetUserId", targetUserId);
            }
        }
    }
}