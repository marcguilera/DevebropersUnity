using System.Collections.Generic;
using Devebropers.Common.Testing;
using Devebropers.Firebase.Analytics;
using FakeItEasy;

namespace Devebropers.Diagnostics.Tests.Unit
{
    public class DiagnosticsTestObjectsFactory : TestObjectFactoryBase<DiagnosticsDomainFactories>
    {
        public readonly string EventName = "EventName";
        public readonly Dictionary<string, object> EventArguments = new Dictionary<string, object>();
        
        public IEventSender EventSender { get; }
        public IFirebaseAnalytics FirebaseAnalytics { get; }
        
        public DiagnosticsTestObjectsFactory()
        {
            FirebaseAnalytics = A.Fake<IFirebaseAnalytics>();
            
            EventSender = A.Fake<IEventSender>();
            A.CallTo(() => DomainFactories.EventSender).Returns(EventSender);
        }
    }
}