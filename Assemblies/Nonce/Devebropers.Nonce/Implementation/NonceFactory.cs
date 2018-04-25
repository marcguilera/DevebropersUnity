using System;
using Devebropers.Domains;

namespace Devebropers.Nonce
{
    internal class NonceFactory : DomainObjectBase<NonceDomainFactories>, INonceFactory
    {
        public NonceFactory(NonceDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }
        
        public INonce CreateNonce()
        {
            var token = _domainFactories
                .NonceTokenGenerator
                .NewToken();
            
            return new Nonce(_domainFactories, token);
        }

        public INonce GetNonce(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException(nameof(token));
            }
            
            return new Nonce(_domainFactories, token);
        }
    }
}