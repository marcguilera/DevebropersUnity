using System;
using System.Collections.Generic;
using Devebropers.Common.Testing;
using FakeItEasy;
using NUnit.Framework;

namespace Devebropers.Diagnostics.Tests.Unit
{
    [TestFixture]
    public class EventBaseTests : TestsBase<DiagnosticsDomainFactories, DiagnosticsTestObjectsFactory>
    {
        private EventBase _event;

        [SetUp]
        public void SetUp()
        {
            _event = A.Fake<EventBase>(x => x.WithArgumentsForConstructor(new object[]
            {
                _testObjects.EventSender, _testObjects.EventName
            }));
        }
        
        #region Ctor

        [TestCaseSource(nameof(SendInvalidArgumentsThrowsTestCases))]
        [Category("Diagnostics"), Category("Events"), Category("EventBase")]
        public void Ctor_InvalidArguments_Throws(IEventSender eventSender, string name, Type exceptionType)
        {
            Assert.That(() => new TestableEvent(eventSender, name), Throws.TypeOf(exceptionType));
        }
        
        private static IEnumerable<TestCaseData> SendInvalidArgumentsThrowsTestCases
        {
            get
            {
                var eventSender = A.Fake<IEventSender>();
                var name = "EventName";
                
                yield return new TestCaseData(eventSender, "", typeof(ArgumentException));
                yield return new TestCaseData(eventSender, " ", typeof(ArgumentException));
                yield return new TestCaseData(eventSender, null, typeof(ArgumentException));
                yield return new TestCaseData(null, name, typeof(ArgumentNullException));
            }
        }

        #endregion

        #region Send

        [Test]
        [Category("Diagnostics"), Category("Events"), Category("EventBase")]
        public void Send_Void_SendsEvent()
        {
            _event.Send();
            
            A.CallTo(() => _testObjects.EventSender.Send(_testObjects.EventName, A<Dictionary<string, object>>._))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        #endregion
    }
}