using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication
{
    internal abstract class AuthBase : DomainObjectBase<AuthenticationDomainFactories>
    {
        protected readonly IFirebaseAuthentication _firebaseAuthentication;
        private readonly IUserFactory _userFactory;
        
        protected AuthBase(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory) : base(domainFactories)
        {
            _firebaseAuthentication = firebaseAuthentication.AssignOrThrowIfNull(nameof(firebaseAuthentication));
            _userFactory = userFactory.AssignOrThrowIfNull(nameof(userFactory));
        }

        protected IAuthenticatedUser CreateAuthenticatedUser(FirebaseUser firebaseUser)
        {
            return firebaseUser == null 
                ? null 
                : _userFactory.CreateAuthenticatedUser(firebaseUser.UserId, firebaseUser.DisplayName, firebaseUser.IsEmailVerified, firebaseUser.PhotoUrl);
        }
        
        protected IAnonymousUser CreateAnonymousUser(FirebaseUser firebaseUser)
        {
            return firebaseUser == null 
                ? null 
                : _userFactory.CreateAnonymousUser(firebaseUser.UserId);
        }
    }
}