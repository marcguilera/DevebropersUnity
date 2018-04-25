
using System;
using System.Reactive;
using System.Reactive.Linq;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    internal class EmailAuthenticator : UserAuthenticatorBase, IEmailAuthenticator
    {
        private string _Email { get; set; }
        private string _Password { get; set; }

        public override AuthenticationProvider Provider { get; } = AuthenticationProvider.Email;
        
        protected override Credential Credential => EmailAuthProvider.GetCredential(_Email, _Password);

        public EmailAuthenticator(AuthenticationDomainFactories domainFactories, IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory) 
            : base(domainFactories, firebaseAuthentication, userFactory)
        {
        }
        
        public IObservable<IAuthenticatedUser> SignIn(string email, string password)
        {
            VerifyCredentials(email, password);

            _Email = email;
            _Password = password;
            
            return base.SignIn();
        }

        public IObservable<IAuthenticatedUser> SignUp(string email, string password)
        {
            VerifyCredentials(email, password);

            _Email = email;
            _Password = password;

            InvokeOnSignUpAttempt();
            
            return _firebaseAuthentication
                    .CreateUser(email, password)
                    .Select(CreateAuthenticatedUser)
                    .Do(InvokeOnSignUpSuccess, InvokeOnSignUpError);
        }
        
        public IObservable<Unit> SendVerification()
        {
            return _firebaseAuthentication.SendVerificationEmail();
        }

        private void VerifyCredentials(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(nameof(email));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(password));
            }
        }
        
    }
}