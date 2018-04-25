using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Devebropers.Common.Observables;
using Devebropers.Common.Testing;
using Devebropers.Data.Persistance;
using FakeItEasy;
using NUnit.Framework;

namespace Devebropers.Nonce.Tests.Unit
{
    [TestFixture]
    public class NonceTests
    {
        private NonceTestObjectFactory _testObject;
        private Nonce _nonce;

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _testObject = new NonceTestObjectFactory();
            _nonce = A.Fake<Nonce>(x => x.WithArgumentsForConstructor(new object[]
            {
                _testObject.DomainFactories, _testObject.NonceToken
            }));
        }
        
        #endregion

        #region Ctor
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce")]
        public void Ctor_NullDomainFactories_Throws()
        {
            Assert.That(() => new Nonce(null, _testObject.NonceToken), Throws.ArgumentNullException);
        }

        [TestCaseSource(nameof(CtorInvalidNonceThrowsTestCases))]
        [Category("Devebropers"), Category("Framework"), Category("Nonce")]
        public void Ctor_InvalidNonce_Throws(string token)
        {
            Assert.That(() => new Nonce(_testObject.DomainFactories, token), Throws.ArgumentException);
        }
        
        private static IEnumerable<TestCaseData> CtorInvalidNonceThrowsTestCases
        {
            get
            {
                yield return new TestCaseData("");
                yield return new TestCaseData(" ");
                yield return new TestCaseData(null);
            }
        }

        #endregion
        
        #region Redeem
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce")]
        public void Redeem_AlreadyRedeemed_Throws()
        {
            A.CallTo(() => _nonce._IsRedeemed).Returns(true);

            var result = _nonce.Redeem();
                
            A.CallTo(() => _testObject.NonceRedeemer.TryRedeem(_testObject.NonceToken)).MustNotHaveHappened();
            ObservableAssert.That(result, Throws.TypeOf<NonceException>());
        }
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce")]
        public void Redeem_RemoteAlreadyRedeemed_Throws()
        {
            A.CallTo(() => _nonce._IsRedeemed).Returns(false);
            A.CallTo(() => _testObject.NonceRedeemer.TryRedeem(_testObject.NonceToken)).Returns(TestObservable.Returns(false));

            var result = _nonce.Redeem();
            
            A.CallTo(() => _testObject.NonceRedeemer.TryRedeem(_testObject.NonceToken)).MustHaveHappened(Repeated.Exactly.Once);
            ObservableAssert.That(result, Throws.TypeOf<NonceException>());
        } 
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce")]
        public void Redeem_NotRedeemed_Returns()
        {
            A.CallTo(() => _nonce._IsRedeemed).Returns(false);
            A.CallTo(() => _testObject.NonceRedeemer.TryRedeem(_testObject.NonceToken)).Returns(TestObservable.Returns(true));
            
            var result = _nonce.Redeem();
            
            A.CallTo(() => _testObject.NonceRedeemer.TryRedeem(_testObject.NonceToken)).MustHaveHappened(Repeated.Exactly.Once);
            ObservableAssert.That(result, Is.Not.Null);
        } 
        
        #endregion

    }
}