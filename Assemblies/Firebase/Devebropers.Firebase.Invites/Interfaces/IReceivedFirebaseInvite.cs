using System;

namespace Devebropers.Firebase.Invites
{
    public interface IReceivedFirebaseInvite
    {
        string InvitationId { get; }
        Uri DeepLink { get; }
        bool IsStrongMatch { get; }
    }
}