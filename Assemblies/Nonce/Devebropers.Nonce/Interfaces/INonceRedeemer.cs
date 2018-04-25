using System;
using System.Reactive;

namespace Devebropers.Nonce
{
    internal interface INonceRedeemer
    {
        IObservable<bool> TryRedeem(string token);
    }
}