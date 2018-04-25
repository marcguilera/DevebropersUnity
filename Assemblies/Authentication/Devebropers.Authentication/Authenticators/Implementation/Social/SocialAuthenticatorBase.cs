using System;
using System.Reactive.Linq;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal abstract  class SocialAuthenticatorBase : UserAuthenticatorBase, ISocialAuthenticator
    {
        protected abstract override Credential Credential { get; }
        public abstract override AuthenticationProvider Provider { get; }
        
        protected SocialAuthenticatorBase(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory)
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
        }
    }
}