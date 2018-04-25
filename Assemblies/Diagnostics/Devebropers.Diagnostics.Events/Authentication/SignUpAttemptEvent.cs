namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignUpAttemptEvent : AuthEventBase
    {
        private const string _name = "Authentication:SignUp:Attempt";
        public SignUpAttemptEvent(IEventSender eventSender, string provider) 
            : base(eventSender, _name, provider)
        {
        }
    }
}