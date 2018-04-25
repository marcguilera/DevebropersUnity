using System;

namespace Devebropers.Users
{
    /// <summary>
    /// A <see cref="IUser"/> factory
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// Creates a <see cref="IAnonymousUser"/>
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <returns>The <see cref="IAnonymousUser"/></returns>
        IAnonymousUser CreateAnonymousUser(string id);
        
        /// <summary>
        /// Creates a <see cref="IAuthenticatedUser"/>
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <param name="name">The user's display name</param>
        /// <param name="isEmailVerified">Whether the user has a verified email</param>
        /// <param name="photoUrl">The user's profile photo url</param>
        /// <returns>The <see cref="IAuthenticatedUser"/></returns>
        IAuthenticatedUser CreateAuthenticatedUser(string id, string name, bool isEmailVerified = false, Uri photoUrl = null);
    }
}