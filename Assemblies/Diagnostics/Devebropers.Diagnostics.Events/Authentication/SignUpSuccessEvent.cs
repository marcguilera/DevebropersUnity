namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignUpSuccessEvent : AuthEventBase
    {
        private const string _name = "Authentication:SignUp:Success";

        public SignUpSuccessEvent(IEventSender eventSender, string provider, string userId) 
            : base(eventSender, _name, provider)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                PutArgument("UserId", userId);
            }
        }
    }
}