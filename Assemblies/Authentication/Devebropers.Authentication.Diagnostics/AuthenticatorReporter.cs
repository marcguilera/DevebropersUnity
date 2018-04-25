using System;
using Devebropers.Authentication.Authenticators;
using Devebropers.Diagnostics;
using Devebropers.Users;
using Devebropers.Diagnostics.Events.Authentication;

namespace Devebropers.Authentication.Diagnostics
{
    /// <summary>
    /// Represents a <see cref="IAuthenticator"/> <see cref="IReporter"/>
    /// </summary>
    public class AuthenticatorReporter : ReporterBase<IAuthenticator>
    {
        public AuthenticatorReporter(IEventSender eventSender, IAuthenticator authenticator) 
            : base(eventSender, authenticator)
        {
        }

        public override void StartReporting()
        {
            _target.OnSignInAttempt += OnSignInAttempt;
            _target.OnSignInError += OnSignInError;
            _target.OnSignInSuccess += OnSignInSucces;
            _target.OnSignUpAttempt += OnSignUpAttempt;
            _target.OnSignUpError += OnSignUpError;
            _target.OnSignUpSuccess += OnSignUpSuccess;
        }

        public override void StopReporting()
        {
            _target.OnSignInAttempt -= OnSignInAttempt;
            _target.OnSignInError -= OnSignInError;
            _target.OnSignInSuccess -= OnSignInSucces;
            _target.OnSignUpAttempt -= OnSignUpAttempt;
            _target.OnSignUpError -= OnSignUpError;
            _target.OnSignUpSuccess -= OnSignUpSuccess;
        }

        private void OnSignInAttempt(AuthenticationProvider provider)
        {
            new SignInAttemptEvent(_eventSender, provider.ToString()).Send();
        }

        private void OnSignInError(AuthenticationProvider provider, Exception exception)
        {
            new SignInErrorEvent(_eventSender, provider.ToString(), exception).Send();
        }

        private void OnSignInSucces(IUserIdentifier user, AuthenticationProvider provider)
        {
            new SignInSuccessEvent(_eventSender, provider.ToString(), user.Id).Send();
        }

        private void OnSignUpAttempt(AuthenticationProvider provider)
        {
            new SignUpAttemptEvent(_eventSender, provider.ToString()).Send();
        }

        private void OnSignUpError(AuthenticationProvider provider, Exception exception)
        {
            new SignUpErrorEvent(_eventSender, provider.ToString(), exception).Send();
        }

        private void OnSignUpSuccess(IUserIdentifier user, AuthenticationProvider provider)
        {
            new SignUpSuccessEvent(_eventSender, provider.ToString(), user.Id).Send();
        }
    }
}