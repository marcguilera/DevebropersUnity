using System;
using System.Reactive;
using Firebase.Invites;

namespace Devebropers.Firebase.Invites
{
    public interface IFirebaseInvites
    {

        IObservable<IReceivedFirebaseInvite> ReceivedInvites { get; }
        IObservable<SendInviteResult> Send(Invite invite);
        IObservable<Unit> ConvertInvitation(string invitationId);
    }
}