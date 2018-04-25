using System;

namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignUpErrorEvent : AuthEventBase
    {
        private const string _name = "Authentication:SignUp:Error";
        public SignUpErrorEvent(IEventSender eventSender, string provider, Exception exception) 
            : base(eventSender, _name, provider, exception)
        {
        }
    }
}