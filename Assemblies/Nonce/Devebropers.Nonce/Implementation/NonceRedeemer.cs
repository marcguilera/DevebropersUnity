using System;
using System.Reactive.Linq;
using Devebropers.Data.Persistance;
using Devebropers.Domains;
using Devebropers.Nonce.Entities;

namespace Devebropers.Nonce
{
    internal class NonceRedeemer : DomainObjectBase<NonceDomainFactories>, INonceRedeemer
    {
        public NonceRedeemer(NonceDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }
        
        public IObservable<bool> TryRedeem(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException(nameof(token));
            }

            return _domainFactories
                .NonceEntityFactory
                .GetNonce(token)
                .Select(nothing => false)
                .Catch<bool, NotFoundException>(nothing => Redeem(token));
        }
        
        private IObservable<bool> Redeem(string token)
        {
            return _domainFactories
                .NonceEntityFactory
                .CreateNonce(token)
                .Save()
                .Select(nothing => true);
        }
    }
}