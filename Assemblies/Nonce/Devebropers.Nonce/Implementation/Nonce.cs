using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Nonce.Entities;

namespace Devebropers.Nonce
{
    internal class Nonce : DomainObjectBase<NonceDomainFactories>, INonce
    {
        public string Token { get; }
        
        internal virtual bool _IsRedeemed { get; private set; }
        
        public Nonce(NonceDomainFactories domainFactories, string token) 
            : base(domainFactories)
        {
            Token = token.AssignOrThrowIfNullOrWhiteSpace(nameof(token));
        }
        
        public IObservable<Unit> Redeem()
        {
            return _IsRedeemed
                ? GetException()
                : _domainFactories
                    .NonceRedeemer
                    .TryRedeem(Token)
                    .Do(nothing => _IsRedeemed = true)
                    .SelectMany(ToUnit);
        }

        private static IObservable<Unit> ToUnit(bool success)
        {
            return success
                ? Observable.Return(new Unit())
                : GetException();
        }

        private static IObservable<Unit> GetException()
        {
            return Observable.Throw<Unit>(new NonceException("The nonce has already been redeemed"));
        }
    }
}