using System;
using Devebropers.Users;

namespace Devebropers.Authentication.Authenticators
{
    /// <summary>
    /// A user <see cref="IAuthenticator"/>
    /// </summary>
    public interface IUserAuthenticator : IAuthenticator
    {
        /// <summary>
        /// Links the current <see cref="IUser"/> with this <see cref="IAuthenticator"/>
        /// </summary>
        /// <returns><see cref="IAuthenticatedUser"/></returns>
        IObservable<IAuthenticatedUser> LinkCurrentUser();
        
        /// <summary>
        /// Reauthenticates the current <see cref="IUser"/> with this <see cref="IAuthenticator"/>
        /// </summary>
        /// <returns><see cref="IAuthenticatedUser"/></returns>
        IObservable<IAuthenticatedUser> ReauthenticateCurrentUser();
        
        /// <summary>
        /// Unlinks the current <see cref="IUser"/> with this <see cref="IAuthenticator"/>
        /// </summary>
        /// <returns><see cref="IAuthenticatedUser"/></returns>
        IObservable<IAuthenticatedUser> UnlinkCurrentUser();
    }
}