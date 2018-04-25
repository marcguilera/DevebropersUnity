using System;
using System.Reactive;
using Devebropers.Firebase.Invites;

namespace Devebropers.Invites
{
    internal class InviteConverter : InvitesBase, IInviteConverter
    {
        public InviteConverter(InvitesDomainFactories domainFactories, IFirebaseInvites firebaseInvites) 
            : base(domainFactories, firebaseInvites)
        {
        }
        
        public IObservable<Unit> Convert(IInvite invite)
        {
            return _domainFactories
                .InviteConverter
                .Convert(invite);
        }

        
    }
}