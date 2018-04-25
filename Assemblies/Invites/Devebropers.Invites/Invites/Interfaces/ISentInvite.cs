using System.Collections.Generic;

namespace Devebropers.Invites
{
    internal interface ISentInvite
    {
        IEnumerable<string> InviteIds { get; }
    }
}