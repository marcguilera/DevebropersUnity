using System;
using Devebropers.Data.Persistance;
using Devebropers.Domains;
using Devebropers.Nonce.Entities;

namespace Devebropers.Nonce
{
    /// <summary>
    /// The nonce domain
    /// </summary>
    public class NonceDomainFactories : IDomainFactories
    {
        internal virtual INonceEntityFactory NonceEntityFactory { get; }
        internal virtual INonceRedeemer NonceRedeemer { get; }
        internal virtual INonceTokenGenerator NonceTokenGenerator { get; }
        
        /// <summary>
        /// Gets a <see cref="INonceFactory"/>
        /// </summary>
        public virtual INonceFactory NonceFactory { get; }

        /// <summary>
        /// Constructs a <see cref="NonceDomainFactories"/>
        /// </summary>
        /// <param name="firebaseGetter">A <see cref="IFirebaseGetter"/></param>
        /// <param name="firebaseUpdater">A <see cref="IFirebaseUpdater"/></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseGetter"/>
        ///     <paramref name="firebaseUpdater"/>
        /// </exception>
        public NonceDomainFactories(IFirebaseGetter firebaseGetter, IFirebaseUpdater firebaseUpdater)
        {
            NonceEntityFactory = new NonceEntityFactory(firebaseGetter, firebaseUpdater);
            NonceRedeemer = new NonceRedeemer(this);
            NonceTokenGenerator = new NonceTokenGenerator();
            
            NonceFactory = new NonceFactory(this);
        }
    }
}