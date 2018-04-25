using System;
using Devebropers.Users;

namespace Devebropers.Authentication.Authenticators
{
    /// <summary>
    /// An anonymous <see cref="IAuthenticator"/>
    /// </summary>
    public interface IAnonymousAuthenticator : IAuthenticator
    {
        /// <summary>
        /// Signs in a user anonmously
        /// </summary>
        /// <returns><see cref="IAnonymousUser"/></returns>
        IObservable<IAnonymousUser> SignIn();
    }
}