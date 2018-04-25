using System;

namespace Devebropers.Diagnostics
{
    public class ErrorEventBase : EventBase
    {
        public ErrorEventBase(IEventSender eventSender, string name, Exception exception) 
            : base(eventSender, name)
        {
            if (exception != null)
            {
                PutArgument("Error", exception.Message);
            }
        }
    }
}