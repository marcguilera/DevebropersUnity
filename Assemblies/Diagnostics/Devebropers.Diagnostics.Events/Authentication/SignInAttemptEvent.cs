namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignInAttemptEvent : AuthEventBase
    {
        private const string _name = "Authentication:SignOut:Attempt";
        public SignInAttemptEvent(IEventSender eventSender, string provider) 
            : base(eventSender, _name, provider)
        {
        }
    }
}