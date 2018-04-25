using Devebropers.Domains;

namespace Devebropers.Random
{
    internal class Random : DomainObjectBase<RandomDomainFactories>, IRandom
    {
        private readonly System.Random _random;
        
        public Random(RandomDomainFactories domainFactories) 
            : base(domainFactories)
        {
            _random = new System.Random();
        }
        
        public int Get()
        {
            return _random.Next();
        }

        public int Get(int limit)
        {
            return _random.Next(limit);
        }

        public int Get(int start, int limit)
        {
            return _random.Next(start, limit);
        }
        
    }
}