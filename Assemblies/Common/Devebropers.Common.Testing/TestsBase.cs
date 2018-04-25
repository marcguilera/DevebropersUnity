using System;
using Devebropers.Domains;
using NUnit.Framework;

namespace Devebropers.Common.Testing
{
    public abstract class TestsBase <TDomain, TTestObjects>
        where TDomain : IDomainFactories
        where TTestObjects : TestObjectFactoryBase<TDomain>
    {
        protected TTestObjects _testObjects;
        
        [SetUp]
        public void SetUp()
        {
            _testObjects = Activator.CreateInstance<TTestObjects>();
        }
    }
}