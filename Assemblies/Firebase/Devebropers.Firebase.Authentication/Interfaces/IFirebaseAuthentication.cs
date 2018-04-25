using System;
using System.Reactive;
using Firebase.Auth;

namespace Devebropers.Firebase.Authentication
{
    public interface IFirebaseAuthentication
    {
        /// <summary>
        /// Gets the current <see cref="FirebaseUser"/>
        /// </summary>
        FirebaseUser CurrentUser { get; }
        
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <returns>A <see cref="FirebaseUser"/></returns>
        IObservable<FirebaseUser> CreateUser(string email, string password);
        
        /// <summary>
        /// Signs in a user anonymousely
        /// </summary>
        /// <returns>A <see cref="FirebaseUser"/></returns>
        IObservable<FirebaseUser> SignInAnonimously(); 
        
        /// <summary>
        /// Signs in with credential
        /// </summary>
        /// <param name="credential">The <see cref="Credential"/></param>
        /// <returns>A <see cref="FirebaseUser"/></returns>
        IObservable<FirebaseUser> SignIn(Credential credential);
        /// <summary>
        /// Sends the verification email to the current user
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> SendVerificationEmail();
        
        /// <summary>
        /// Links the current user with a <see cref="Credential"/>
        /// </summary>
        /// <param name="credential">The <see cref="Credential"/></param>
        /// <returns><see cref="FirebaseUser"/></returns>
        IObservable<FirebaseUser> LinkCurrentUser(Credential credential);
        
        /// <summary>
        /// Unlinks the current user from a provider
        /// </summary>
        /// <param name="provider">The name of the provider to unlink</param>
        /// <returns><see cref="FirebaseUser"/></returns>
        IObservable<FirebaseUser> UnlinkCurrentUser(string provider);
        
        /// <summary>
        /// Reauthenticates the current user with a <see cref="Credential"/>
        /// </summary>
        /// <param name="credential">The <see cref="Credential"/></param>
        /// <returns><see cref="FirebaseUser"/></returns>
        IObservable<FirebaseUser> ReauthenticateCurrentUser(Credential credential);
        
        /// <summary>
        /// Finishes the session and deletes all auth data
        /// </summary>
        void SignOut();
    }
}