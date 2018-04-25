using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Invites;
using Firebase.Invites;

namespace Devebropers.Invites
{
    internal class InviteSender : InvitesBase, IInviteSender
    {
        public InviteSender(InvitesDomainFactories domainFactories, IFirebaseInvites firebaseInvites) 
            : base(domainFactories, firebaseInvites)
        {
        }
        
        public IObservable<ISentInvite> Send(IInvite invite)
        {
            if (invite == null)
            {
                throw new ArgumentNullException(nameof(invite));
            }
            
            var firebaseInvite = new global::Firebase.Invites.Invite()
            {
                TitleText = invite.TitleText,
                MessageText = invite.MessageText,
                CallToActionText = invite.CallToActionText,
                ReferralParameters = invite.ReferralParams
            };

            return _firebaseInvites
                .Send(firebaseInvite)
                .Select(ToSentInvite);
        }
        
        private ISentInvite ToSentInvite (SendInviteResult sendInviteResult)
        {
            return new SentInvite(sendInviteResult.InvitationIds);
        }
    }
}