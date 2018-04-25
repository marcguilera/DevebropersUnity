using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication
{
    internal class Session : AuthBase, ISession
    {
        public event OnSignOutEventHandler OnSignOut;
        
        public IAuthenticatedUser CurrentUser => CreateAuthenticatedUser(_firebaseUser);
        public bool IsAuthenticated => _firebaseUser != null;

        private FirebaseUser _firebaseUser => _firebaseAuthentication.CurrentUser;
        
        public Session(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
        }

        public void SignOut()
        {
            if (IsAuthenticated)
            {
                OnSignOut?.Invoke(CurrentUser);
            }
            _firebaseAuthentication.SignOut();
        }
    }
}
