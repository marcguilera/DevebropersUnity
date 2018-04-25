using System;
using System.Reactive;
using Devebropers.Users;

namespace Devebropers.Authentication.Authenticators
{
    /// <summary>
    /// An email <see cref="IUserAuthenticator"/>
    /// </summary>
    public interface IEmailAuthenticator : IUserAuthenticator
    {
        /// <summary>
        /// Signs in the user via email and password
        /// </summary>
        /// <param name="email">The entered email</param>
        /// <param name="password">The entered password</param>
        /// <returns><see cref="IAuthenticatedUser"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="email"/>
        ///     <paramref name="password"/>
        /// </exception>
        IObservable<IAuthenticatedUser> SignIn(string email, string password);
        
        /// <summary>
        /// Signs up the user via email and password
        /// </summary>
        /// <param name="email">The entered email</param>
        /// <param name="password">The entered password</param>
        /// <returns><see cref="IAuthenticatedUser"/></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="email"/>
        ///     <paramref name="password"/>
        /// </exception>
        IObservable<IAuthenticatedUser> SignUp(string email, string password);
        
        /// <summary>
        /// Sends the verification email to the current user
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> SendVerification();
    }
}