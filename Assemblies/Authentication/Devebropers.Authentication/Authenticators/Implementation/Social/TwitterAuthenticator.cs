using System;
using Devebropers.Common;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal class TwitterAuthenticator : SocialAuthenticatorBase, ITwitterAuthenticator
    {
        
        public override AuthenticationProvider Provider { get; } = AuthenticationProvider.Twitter;

        protected override Credential Credential => TwitterAuthProvider.GetCredential(_accessTokenGetter(), _secretGetter());
        
        private readonly Func<string> _accessTokenGetter;
        private readonly Func<string> _secretGetter;
        
        public TwitterAuthenticator(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, 
            IUserFactory userFactory, Func<string> accessTokenGetter, Func<string> secretGetter) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
            _accessTokenGetter = accessTokenGetter.AssignOrThrowIfNull(nameof(accessTokenGetter));
            _secretGetter = secretGetter.AssignOrThrowIfNull(nameof(secretGetter));
        }
    }
}