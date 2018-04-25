using System;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;

namespace Devebropers.Authentication.Authenticators
{
    internal abstract class AuthenticatorBase : AuthBase, IAuthenticator
    {
        public event OnSignInAttemptEventHandler OnSignInAttempt;
        public event OnSignInSuccessEventHandler OnSignInSuccess;
        public event OnSignInErrorEventHandler OnSignInError;
        
        public event OnSignUpAttemptEventHandler OnSignUpAttempt;
        public event OnSignUpSuccessEventHandler OnSignUpSuccess;
        public event OnSignUpErrorEventHandler OnSignUpError;
        
        public abstract AuthenticationProvider Provider { get; }
        
        protected AuthenticatorBase(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
        }
        
        protected void InvokeOnSignUpSuccess(IUserIdentifier user)
        {
            OnSignUpSuccess?.Invoke(user, Provider);
        }
        protected void InvokeOnSignInSuccess(IUserIdentifier user)
        {
            OnSignInSuccess?.Invoke(user, Provider);
        }
        protected void InvokeOnSignUpAttempt()
        {
            OnSignUpAttempt?.Invoke(Provider);
        }
        protected void InvokeOnSignInAttempt()
        {
            OnSignInAttempt?.Invoke(Provider);
        }
        protected void InvokeOnSignUpError(Exception exception)
        {
            OnSignUpError?.Invoke(Provider, exception);
        }
        protected void InvokeOnSignInError(Exception exception)
        {
            OnSignInError?.Invoke(Provider, exception);
        }
    }
}