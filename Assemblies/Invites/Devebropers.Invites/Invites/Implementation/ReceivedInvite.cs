using System;
using System.Reactive;

namespace Devebropers.Invites
{
    internal class ReceivedInvite : InviteBase, IReceivedInvite
    {
        public ReceivedInvite(InvitesDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }

        public IObservable<Unit> Convert()
        {
            return _domainFactories
                .InviteConverter
                .Convert(this);
        }
    }
}