using System;

namespace Devebropers.Nonce.Entities
{
    internal interface INonceEntityFactory
    {
        IObservable<INonceEntity> GetNonce(string token);
        INonceEntity CreateNonce(string token);
    }
}