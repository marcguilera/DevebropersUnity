using System;
using System.Collections.Generic;
using Devebropers.Common.Testing;
using Devebropers.Users;
using FakeItEasy;
using NUnit.Framework;

namespace Devebropers.Diagnostics.Tests.Unit
{
    [TestFixture]
    public class EventSenderTests : TestsBase<DiagnosticsDomainFactories, DiagnosticsTestObjectsFactory>
    {
        private readonly string _userId = "UserId";
        
        private EventSender _eventSender;
        private IUserIdentifier _user;
        
        [SetUp]
        public void SetUp()
        {
            _eventSender = A.Fake<EventSender>(x => x.WithArgumentsForConstructor(new object[]
            {
                _testObjects.FirebaseAnalytics
            }));
            
            _user = A.Fake<IUserIdentifier>();
            A.CallTo(() => _user.Id).Returns(_userId);
        }

        #region Ctor

        [Test]
        [Category("Diagnostics"), Category("Events"), Category("EventSender")]
        public void Ctor_NullFirebaseAnalytics_Throws()
        {
            Assert.That(() => new EventSender(null), Throws.ArgumentNullException);
        }

        #endregion

        #region Send

        [TestCaseSource(nameof(SendInvalidArgumentsThrowsTestCases))]
        [Category("Diagnostics"), Category("Events"), Category("EventSender")]
        public void Send_InvalidArguments_Throws(string name, IDictionary<string, object> arguments, Type exceptionType)
        {
            Assert.That(() => _eventSender.Send(name, arguments), Throws.TypeOf(exceptionType));
        }
        
        private static IEnumerable<TestCaseData> SendInvalidArgumentsThrowsTestCases
        {
            get
            {
                var dict = A.Fake<IDictionary<string, object>>();
                var name = "EventName";
                
                yield return new TestCaseData("", dict, typeof(ArgumentException));
                yield return new TestCaseData(" ", dict, typeof(ArgumentException));
                yield return new TestCaseData(null, dict, typeof(ArgumentException));
                yield return new TestCaseData(name, null, typeof(ArgumentNullException));
            }
        }

        [Test]
        [Category("Diagnostics"), Category("Events"), Category("EventSender")]
        public void Send_ValidArguments_LogsEvent()
        {
            _eventSender.Send(_testObjects.EventName, _testObjects.EventArguments);
            
            A.CallTo(() => _testObjects.FirebaseAnalytics.LogEvent(_testObjects.EventName, _testObjects.EventArguments))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
        
        #endregion

        #region SetUser

        [Test]
        [Category("Diagnostics"), Category("Events"), Category("EventSender")]
        public void Send_NullUser_Throws()
        {
            Assert.That(() => _eventSender.SetUser(null), Throws.ArgumentNullException);
            A.CallTo(() => _testObjects.FirebaseAnalytics.SetUserId(A<string>._)).MustNotHaveHappened();
        }
        
        [Test]
        [Category("Diagnostics"), Category("Events"), Category("EventSender")]
        public void Send_ValidUser_SetsUserId()
        {
            _eventSender.SetUser(_user);
            
            A.CallTo(() => _testObjects.FirebaseAnalytics.SetUserId(_userId))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        #endregion

        #region RemoveUser

        [Test]
        [Category("Diagnostics"), Category("Events"), Category("EventSender")]
        public void Send_Void_NullUserId()
        {
            _eventSender.RemoveUser();
            
            A.CallTo(() => _testObjects.FirebaseAnalytics.SetUserId(null))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        #endregion
    }
}