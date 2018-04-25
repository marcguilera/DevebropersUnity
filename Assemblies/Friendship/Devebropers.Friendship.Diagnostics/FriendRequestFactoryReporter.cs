using System;
using Devebropers.Diagnostics;
using Devebropers.Diagnostics.Events.Friendship;
using Devebropers.Friendship.Friends;
using Devebropers.Friendship.Requests;

namespace Devebropers.Friendship.Diagnostics
{
    public class FriendRequestFactoryReporter : ReporterBase <IFriendRequestFactory>
    {
        public FriendRequestFactoryReporter(IEventSender eventSender, IFriendRequestFactory friendRequestFactory) 
            : base(eventSender, friendRequestFactory)
        {
        }

        public override void StartReporting()
        {
            _target.OnFriendRequestSent += OnFriendRequestSent;
        }

        public override void StopReporting()
        {
            _target.OnFriendRequestSent -= OnFriendRequestSent;
        }
        
        private void OnFriendRequestSent(IFriendRequest friendRequest)
        {
            new FriendRequestSentEvent(_eventSender, friendRequest.SourceUserId, friendRequest.TargetUserId).Send();
        }
    }
}