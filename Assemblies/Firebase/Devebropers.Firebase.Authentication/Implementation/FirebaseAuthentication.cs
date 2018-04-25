using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Firebase.Auth;

namespace Devebropers.Firebase.Authentication
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        private readonly FirebaseAuth _auth;
        private bool _isSignedIn => CurrentUser != null;

        public FirebaseUser CurrentUser => _auth.CurrentUser;
        
        public FirebaseAuthentication()
        {
            _auth = FirebaseAuth.DefaultInstance;
        }

        public IObservable<FirebaseUser> CreateUser(string email, string password)
        {
            var subject = new ReplaySubject<FirebaseUser>();
            _auth
                .CreateUserWithEmailAndPasswordAsync(email, password)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });

            return subject;
        }

        public IObservable<FirebaseUser> SignInAnonimously()
        {
            var subject = new ReplaySubject<FirebaseUser>();
            _auth
                .SignInAnonymouslyAsync()
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });

            return subject;
        }

        public IObservable<FirebaseUser> SignIn(Credential credential)
        {
            var subject = new ReplaySubject<FirebaseUser>();
            _auth
                .SignInWithCredentialAsync(credential)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });

            return subject;
        }

        public IObservable<Unit> SendVerificationEmail()
        {
            var subject = new ReplaySubject<Unit>();
            
            CurrentUser
                .SendEmailVerificationAsync()
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(new Unit());
                    subject.OnCompleted();
                });
            return subject;
        }

        public IObservable<FirebaseUser> LinkCurrentUser(Credential credential)
        {
            if (!_isSignedIn)
            {
                return Observable.Throw<FirebaseUser>(new Exception());
            }
            
            var subject = new ReplaySubject<FirebaseUser>();
            
            CurrentUser
                .LinkWithCredentialAsync(credential)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });
            return subject;
        }

        public IObservable<FirebaseUser> UnlinkCurrentUser(string provider)
        {
            if (!_isSignedIn)
            {
                return Observable.Throw<FirebaseUser>(new Exception());
            }
            
            var subject = new ReplaySubject<FirebaseUser>();
            
            CurrentUser
                .UnlinkAsync(provider)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });

            return subject;
        }

        public IObservable<FirebaseUser> ReauthenticateCurrentUser(Credential credential)
        {
            if (!_isSignedIn)
            {
                return Observable.Throw<FirebaseUser>(new Exception());
            }
            
            var subject = new ReplaySubject<FirebaseUser>();
            
            CurrentUser
                .ReauthenticateAsync(credential)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        return;
                    }
                    subject.OnNext(CurrentUser);
                    subject.OnCompleted();
                });
            
            return subject;
        }

        public void SignOut()
        {
            _auth.SignOut();
        }
        
    }
}