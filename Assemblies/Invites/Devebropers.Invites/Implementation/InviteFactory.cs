using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Invites;

namespace Devebropers.Invites
{
    internal class InviteFactory : InvitesBase, IInviteFactory
    {

        public IObservable<IReceivedInvite> ReceivedInvites => _firebaseInvites.ReceivedInvites.Select(ToReceivedInvite);

        public InviteFactory(InvitesDomainFactories domainFactories, IFirebaseInvites firebaseInvites) 
            : base(domainFactories, firebaseInvites)
        {
        }

        public ISendableInvite CreateInvite(string titleText, string messageText, string callToActionText, Uri callToActionUrl)
        {
            return new SendableInvite(_domainFactories)
            {
                TitleText = titleText.AssignOrThrowIfNullOrWhiteSpace(nameof(titleText)),
                MessageText = messageText.AssignOrThrowIfNullOrWhiteSpace(nameof(messageText)),
                CallToActionText = callToActionText.AssignOrThrowIfNullOrWhiteSpace(nameof(callToActionText)),
                CallToActionUrl = callToActionUrl.AssignOrThrowIfNull(nameof(callToActionText))
            };
        }
        
        private IReceivedInvite ToReceivedInvite(IReceivedFirebaseInvite invite)
        {
            return new ReceivedInvite(_domainFactories)
            {
                Id = invite.InvitationId
            };
        }
    }
}