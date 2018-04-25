using System;
using Devebropers.Users;
using Firebase.Auth;

namespace Devebropers.Authentication.Authenticators
{
    public delegate void OnSignInAttemptEventHandler(AuthenticationProvider provider);
    public delegate void OnSignInSuccessEventHandler(IUserIdentifier user, AuthenticationProvider provider);
    public delegate void OnSignInErrorEventHandler(AuthenticationProvider provider, Exception exception);
    
    public delegate void OnSignUpAttemptEventHandler(AuthenticationProvider provider);
    public delegate void OnSignUpSuccessEventHandler(IUserIdentifier user, AuthenticationProvider provider);
    public delegate void OnSignUpErrorEventHandler(AuthenticationProvider provider, Exception exception);
    
    /// <summary>
    /// An authenticator
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Occurs when the sign in process starts
        /// </summary>
        event OnSignInAttemptEventHandler OnSignInAttempt;
        
        /// <summary>
        /// Occurs when the sign in process completes
        /// </summary>
        event OnSignInSuccessEventHandler OnSignInSuccess;
        
        /// <summary>
        /// Occurs when the sign in process errors out
        /// </summary>
        event OnSignInErrorEventHandler OnSignInError;

        /// <summary>
        /// Occurs when the sign up process starts
        /// </summary>
        event OnSignUpAttemptEventHandler OnSignUpAttempt;
        
        /// <summary>
        /// Occurs when the sign up process completes
        /// </summary>
        event OnSignUpSuccessEventHandler OnSignUpSuccess;
        
        /// <summary>
        /// Occures when the sign up process errors out
        /// </summary>
        event OnSignUpErrorEventHandler OnSignUpError;
        
        /// <summary>
        /// The <see cref="AuthenticationProvider"/> for this <see cref="IAuthenticator"/>
        /// </summary>
        AuthenticationProvider Provider { get; }
    }
}