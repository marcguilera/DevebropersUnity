using System;
using Devebropers.Common;

namespace Devebropers.Firebase.Invites
{
    internal class ReceivedFirebaseInvite : IReceivedFirebaseInvite
    {
        public string InvitationId { get; }
        public Uri DeepLink { get; }
        public bool IsStrongMatch { get; }

        public ReceivedFirebaseInvite(string invitationId, Uri deepLink, bool isStrongMatch)
        {
            InvitationId = invitationId.AssignOrThrowIfNullOrWhiteSpace(nameof(invitationId));
            DeepLink = deepLink.AssignOrThrowIfNull(nameof(deepLink));
            IsStrongMatch = isStrongMatch;
        }
    }
}