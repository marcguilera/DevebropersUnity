using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal class AnonymousAuthenticator : AuthenticatorBase, IAnonymousAuthenticator
    {
        public override AuthenticationProvider Provider { get; } = AuthenticationProvider.Anonymous;
        
        public AnonymousAuthenticator(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
        }

        public IObservable<IAnonymousUser> SignIn()
        {
            InvokeOnSignInAttempt();
            return _firebaseAuthentication
                .SignInAnonimously()
                .Select(CreateAnonymousUser)
                .Do(InvokeOnSignInSuccess, InvokeOnSignInError);
        }
    }
}