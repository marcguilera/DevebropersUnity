using System.Collections.Generic;
using System.Reactive.Linq;
using Devebropers.Common.Testing;
using Devebropers.Data.Persistance;
using Devebropers.Nonce.Entities;
using FakeItEasy;
using NUnit.Framework;

namespace Devebropers.Nonce.Tests.Unit
{
    [TestFixture]
    public class NonceRedeemerTests
    {
        private NonceTestObjectFactory _testObject;
        private NonceRedeemer _nonceRedeemer;

        #region SetUp
        
        [SetUp]
        public void SetUp()
        {
            _testObject = new NonceTestObjectFactory();
            _nonceRedeemer = A.Fake<NonceRedeemer>(x => x.WithArgumentsForConstructor(new object[]
            {
                _testObject.DomainFactories
            }));
        }

        #endregion
        
        #region Ctor

        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceRedeemer")]
        public void Ctor_NullDomainFactories_Throws()
        {
            Assert.That(() => new NonceRedeemer(null), Throws.ArgumentNullException);
        }

        #endregion

        #region TryRedeem

        [TestCaseSource(nameof(TryRedeemNullTokenThrowsTestCases))]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceRedeemer")]
        public void TryRedeem_NullToken_Throws(string token)
        {
            Assert.That(() => _nonceRedeemer.TryRedeem(token), Throws.ArgumentException);
        }
        
        private static IEnumerable<TestCaseData> TryRedeemNullTokenThrowsTestCases
        {
            get
            {
                yield return new TestCaseData("");
                yield return new TestCaseData(" ");
                yield return new TestCaseData(null);
            }
        }
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceRedeemer")]
        public void TryRedeem_NonceExists_False()
        {
            var entity = _testObject.CreatNonceEntity();
            A.CallTo(() => _testObject.NonceEntityFactory.GetNonce(_testObject.NonceToken)).Returns(TestObservable.Returns(entity));

            var result = _nonceRedeemer.TryRedeem(_testObject.NonceToken);
            
            ObservableAssert.That(result, Is.False);
        }
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceRedeemer")]
        public void TryRedeem_NonceDoesntExist_True()
        {
            A.CallTo(() => _testObject.NonceEntityFactory.GetNonce(_testObject.NonceToken)).Returns(TestObservable.Throws<INonceEntity, NotFoundException>());

            var result = _nonceRedeemer.TryRedeem(_testObject.NonceToken);
            
           ObservableAssert.That(result, Is.True);
        }
    
        #endregion
    }
}