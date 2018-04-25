using System;
using Devebropers.Common;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal class GithubAuthenticator : SocialAuthenticatorBase, IGithubAuthenticator
    {
        public override AuthenticationProvider Provider { get; } = AuthenticationProvider.Github;
        protected override Credential Credential => GitHubAuthProvider.GetCredential(_accessTokenGetter());

        private readonly Func<string> _accessTokenGetter;
        
        public GithubAuthenticator(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, 
            IUserFactory userFactory, Func<string> accessTokenGetter) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
            _accessTokenGetter = accessTokenGetter.AssignOrThrowIfNull(nameof(accessTokenGetter));
        }
    }
}