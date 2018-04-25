using System;

namespace Devebropers.Diagnostics.Events.Authentication
{
    public abstract class AuthEventBase : ErrorEventBase
    {
        protected AuthEventBase(IEventSender eventSender, string name, string provider, Exception exception = null) 
            : base(eventSender, name, exception)
        {
            if (!string.IsNullOrWhiteSpace(provider))
            {
                PutArgument("Provider", provider);
            }
        }
    }
}