using System;
using System.Reactive.Linq;
using Devebropers.Authentication;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal abstract class UserAuthenticatorBase : AuthenticatorBase, IUserAuthenticator
    {
        protected abstract Credential Credential { get; }
        
        protected UserAuthenticatorBase(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
        }
        
        public IObservable<IAuthenticatedUser> LinkCurrentUser()
        {
            return _firebaseAuthentication
                .LinkCurrentUser(Credential)
                .Select(CreateAuthenticatedUser);
        }

        public IObservable<IAuthenticatedUser> ReauthenticateCurrentUser()
        {
            return _firebaseAuthentication
                .ReauthenticateCurrentUser(Credential)
                .Select(CreateAuthenticatedUser);
        }

        public IObservable<IAuthenticatedUser> UnlinkCurrentUser()
        {
            return _firebaseAuthentication
                .UnlinkCurrentUser(Provider.ToString())
                .Select(CreateAuthenticatedUser);
        }
        
        public IObservable<IAuthenticatedUser> SignIn()
        {
            InvokeOnSignInAttempt();
            return _firebaseAuthentication
                .SignIn(Credential)
                .Select(CreateAuthenticatedUser)
                .Do(InvokeOnSignInSuccess, InvokeOnSignInError);
        }
    }
}