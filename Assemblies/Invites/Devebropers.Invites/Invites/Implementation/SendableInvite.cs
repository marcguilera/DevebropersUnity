using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Devebropers.Common;

namespace Devebropers.Invites
{
    internal class SendableInvite : InviteBase, ISendableInvite
    {
        public SendableInvite(InvitesDomainFactories domainFactories)
            : base(domainFactories)
        {
        }

        public IObservable<Unit> Send()
        {
            return _domainFactories
                .InviteSender
                .Send(this)
                .Do(invite => Id = invite.InviteIds.FirstOrDefault())
                .Select(invite => new Unit());
        }
    }
}