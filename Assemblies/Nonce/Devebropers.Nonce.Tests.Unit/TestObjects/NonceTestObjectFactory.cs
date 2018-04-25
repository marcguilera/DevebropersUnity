using System.Linq;
using System.Reactive.Linq;
using Devebropers.Common.Testing;
using Devebropers.Nonce.Entities;
using FakeItEasy;

namespace Devebropers.Nonce.Tests.Unit
{
    internal class NonceTestObjectFactory : TestObjectFactoryBase<NonceDomainFactories>
    {
        public readonly string NonceToken = "Token";
        public INonceFactory NonceFactory { get; }
        public INonceTokenGenerator NonceTokenGenerator { get; }
        public INonceEntityFactory NonceEntityFactory { get; }
        public INonceRedeemer NonceRedeemer { get; }

        public NonceTestObjectFactory()
        {
            NonceEntityFactory = DomainFactories.NonceEntityFactory;
            NonceFactory = DomainFactories.NonceFactory;
            NonceTokenGenerator = DomainFactories.NonceTokenGenerator;
            NonceRedeemer = DomainFactories.NonceRedeemer;

            A.CallTo(() => NonceTokenGenerator.NewToken()).Returns(NonceToken);

            A.CallTo(() => NonceEntityFactory.CreateNonce(A<string>._)).ReturnsLazily(call => CreatNonceEntity(call.GetArgument<string>(0)));
            A.CallTo(() => NonceEntityFactory.GetNonce(A<string>._)).ReturnsLazily(call => Observable.Return(CreatNonceEntity(call.GetArgument<string>(0))));
        }

        public INonceEntity CreatNonceEntity(string token = null)
        {
            var nonce = A.Fake<INonceEntity>();
            A.CallTo(() => nonce.Id).Returns(token ?? NonceToken);
            A.CallTo(() => nonce.Save()).Returns(TestObservable.Unit());
            A.CallTo(() => nonce.Delete()).Returns(TestObservable.Unit());
            return nonce;
        }
    }
}