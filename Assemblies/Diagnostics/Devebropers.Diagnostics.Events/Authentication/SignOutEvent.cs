using System.Collections.Specialized;

namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignOutEvent : EventBase
    {
        private const string _name = "Authentication:SignOut";
        public SignOutEvent(IEventSender eventSender, string userId) 
            : base(eventSender, _name)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                PutArgument("UserId", userId);
            }
        }
    }
}