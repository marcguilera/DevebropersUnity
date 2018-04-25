using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace Devebropers.Nonce.Tests.Unit
{
    [TestFixture]
    public class NonceFactoryTests
    {
        private NonceTestObjectFactory _testObject;
        private NonceFactory _nonceFactory;

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _testObject = new NonceTestObjectFactory();
            _nonceFactory = A.Fake<NonceFactory>(x => x.WithArgumentsForConstructor(new object[]
            {
                _testObject.DomainFactories
            }));
        }
        
        #endregion

        #region Ctor

        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceFactory")]
        public void Ctor_NullDomainFactories_Throws()
        {
            Assert.That(() => new NonceFactory(null), Throws.ArgumentNullException);
        }

        #endregion

        #region CreateNonce

        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceFactory")]
        public void CreateNonce_Void_Returns()
        {
            var nonce = _nonceFactory.CreateNonce();
            
            Assert.That(nonce, Is.Not.Null);
            Assert.That(nonce.Token, Is.EqualTo(_testObject.NonceToken));
        }

        #endregion

        #region GetNonce

        [TestCaseSource(nameof(GetNonceInvalidArgumentThrowsTesCases))]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceFactory")]
        public void GetNonce_InvalidArgument_Throws(string token)
        {
            Assert.That(() => _nonceFactory.GetNonce(token), Throws.ArgumentException);
        }

        private static IEnumerable<TestCaseData> GetNonceInvalidArgumentThrowsTesCases
        {
            get
            {
                yield return new TestCaseData("");
                yield return new TestCaseData(" ");
                yield return new TestCaseData(null);
            }
        }
        
        [Test]
        [Category("Devebropers"), Category("Framework"), Category("Nonce"), Category("NonceFactory")]
        public void GetNonce_ValidToken_Returns()
        {
            var nonce = _nonceFactory.GetNonce(_testObject.NonceToken);
            
            Assert.That(nonce, Is.Not.Null);
            Assert.That(nonce.Token, Is.EqualTo(_testObject.NonceToken));
        }

        #endregion
        
    }
}