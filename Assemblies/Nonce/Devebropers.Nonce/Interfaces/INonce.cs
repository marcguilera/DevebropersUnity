using System;
using System.Reactive;

namespace Devebropers.Nonce
{
    /// <summary>
    /// Represents a nonce
    /// </summary>
    public interface INonce : ITokenable
    {
        /// <summary>
        /// Tries to redeem the nonce. A nonce can only be redeemed once
        /// </summary>
        /// <returns>True if redemption succeeded, false otherwise</returns>
        IObservable<Unit> Redeem();
    }
}