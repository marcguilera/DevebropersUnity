using System;

namespace Devebropers.Diagnostics.Events.Authentication
{
    public class SignInErrorEvent : AuthEventBase
    {
        private const string _name = "Authentication:SignIn:Error";
        public SignInErrorEvent(IEventSender eventSender, string provider, Exception exception) 
            : base(eventSender, _name, provider, exception)
        {
        }
    }
}