using System;
using System.Reactive;

namespace Devebropers.Invites
{
    internal interface IInviteSender
    {
        IObservable<ISentInvite> Send(IInvite invite);
    }
}