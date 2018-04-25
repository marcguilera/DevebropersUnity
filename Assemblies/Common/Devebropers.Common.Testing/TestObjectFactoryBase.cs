using Devebropers.Domains;
using FakeItEasy;

namespace Devebropers.Common.Testing
{
    public abstract class TestObjectFactoryBase <TDomain>
        where TDomain : IDomainFactories
    {
        public TDomain DomainFactories { get; }

        protected TestObjectFactoryBase()
        {
            DomainFactories = A.Fake<TDomain>();
        }
    }
}