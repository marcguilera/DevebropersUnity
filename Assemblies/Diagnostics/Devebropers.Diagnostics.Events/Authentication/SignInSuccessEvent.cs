namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignInSuccessEvent : AuthEventBase
    {
        private const string _name = "Authentication:SignIn:Success";

        public SignInSuccessEvent(IEventSender eventSender, string provider, string userId) 
            : base(eventSender, _name, provider)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                PutArgument("UserId", userId);
            }
        }
    }
}