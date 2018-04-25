using System;
using System.Reactive;

namespace Devebropers.Invites
{
    internal interface IInviteConverter
    {
        IObservable<Unit> Convert(IInvite invite);
    }
}