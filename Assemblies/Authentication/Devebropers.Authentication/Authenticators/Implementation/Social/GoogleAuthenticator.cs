using System;
using Devebropers.Common;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal class GoogleAuthenticator : SocialAuthenticatorBase, IGoogleAuthenticator
    {
        public override AuthenticationProvider Provider { get; } = AuthenticationProvider.Google;
        protected override Credential Credential => GoogleAuthProvider.GetCredential(_idTokenGetter(), _accessTokenGetter());
        
        private readonly Func<string> _idTokenGetter;
        private readonly Func<string> _accessTokenGetter;
        
        public GoogleAuthenticator(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, 
            IUserFactory userFactory, Func<string> idTokenGetter, Func<string> accessTokenGetter) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
            _accessTokenGetter = accessTokenGetter.AssignOrThrowIfNull(nameof(accessTokenGetter));
            _idTokenGetter = idTokenGetter.AssignOrThrowIfNull(nameof(idTokenGetter));
        }

        
    }
}