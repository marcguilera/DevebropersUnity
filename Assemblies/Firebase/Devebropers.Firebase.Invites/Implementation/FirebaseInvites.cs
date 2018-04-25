using System;
using System.Reactive;
using System.Reactive.Subjects;
using Firebase.Invites;

namespace Devebropers.Firebase.Invites
{
    internal class FirebaseInvites : IFirebaseInvites
    {
        private ReplaySubject<IReceivedFirebaseInvite> _receivedInvites;
        public IObservable<IReceivedFirebaseInvite> ReceivedInvites => _receivedInvites;
        
        public FirebaseInvites()
        {
            _receivedInvites = new ReplaySubject<IReceivedFirebaseInvite>();
            
            global::Firebase.Invites.FirebaseInvites.InviteReceived += (sender, args) =>
            {
                _receivedInvites.OnNext(new ReceivedFirebaseInvite(args.InvitationId, args.DeepLink, args.IsStrongMatch));
            };
        }

        public IObservable<SendInviteResult> Send(Invite invite)
        {
            if (invite == null)
            {
                throw new ArgumentNullException(nameof(invite));
            }
            
            var subject = new ReplaySubject<SendInviteResult>();
            
            global::Firebase.Invites.FirebaseInvites
                .SendInviteAsync(invite)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        subject.OnError(new FirebaseInviteException("Invitation canceled"));
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        subject.OnError(new FirebaseInviteException("Error inviting", task.Exception));
                        return;
                    }
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });
            
            return subject;
        }

        public IObservable<Unit> ConvertInvitation(string invitationId)
        {
            if (string.IsNullOrWhiteSpace(invitationId))
            {
                throw new ArgumentException(nameof(invitationId));
            }
            
            var subject = new ReplaySubject<Unit>();
            
            global::Firebase.Invites.FirebaseInvites
                .ConvertInvitationAsync(invitationId)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        subject.OnError(new FirebaseInviteException("Conversion canceled"));
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        subject.OnError(new FirebaseInviteException("Error converting", task.Exception));
                        return;
                    }
                    subject.OnNext(new Unit());
                    subject.OnCompleted();
                });
            
            return subject;
        }
    }
}