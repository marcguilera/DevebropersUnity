using System.Collections.Generic;
using Devebropers.Common;

namespace Devebropers.Invites
{
    internal class SentInvite : ISentInvite
    {
        public IEnumerable<string> InviteIds { get; }
        
        public SentInvite(IEnumerable<string> invitationIds)
        {
            InviteIds = invitationIds.AssignOrThrowIfNull(nameof(invitationIds));
        }
    }
}