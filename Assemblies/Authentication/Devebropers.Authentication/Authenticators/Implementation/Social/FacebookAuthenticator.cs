using System;
using Devebropers.Common;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal class FacebookAuthenticator : SocialAuthenticatorBase, IFacebookAuthenticator
    {
        public override AuthenticationProvider Provider { get; } = AuthenticationProvider.Facebook;
        protected override Credential Credential => FacebookAuthProvider.GetCredential(_accessTokenGetter());
        
        private readonly Func<string> _accessTokenGetter;
        
        public FacebookAuthenticator(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, 
            IUserFactory userFactory, Func<string> accessTokenGetter) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
            _accessTokenGetter = accessTokenGetter.AssignOrThrowIfNull(nameof(accessTokenGetter));
        }
    }
}