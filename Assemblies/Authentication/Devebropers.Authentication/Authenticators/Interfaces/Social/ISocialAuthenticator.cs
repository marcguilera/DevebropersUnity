using System;
using Devebropers.Users;

namespace Devebropers.Authentication.Authenticators
{
    /// <summary>
    /// A social <see cref="IUserAuthenticator"/>
    /// </summary>
    public interface ISocialAuthenticator : IUserAuthenticator
    {
        /// <summary>
        /// Signs in to the <see cref="AuthenticationProvider"/>
        /// </summary>
        /// <returns><see cref="IAuthenticatedUser"/></returns>
        IObservable<IAuthenticatedUser> SignIn(); 
    }
}