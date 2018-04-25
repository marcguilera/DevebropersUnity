namespace Devebropers.Diagnostics.Tests.Unit
{
    public class TestableEvent : EventBase
    {
        public TestableEvent(IEventSender eventSender, string name) 
            : base(eventSender, name)
        {
        }
        
        
    }
}