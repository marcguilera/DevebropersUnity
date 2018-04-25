using System;

namespace Devebropers.Users
{
    /// <summary>
    /// A <see cref="IAuthenticatedUserIdentifier"/> factory
    /// </summary>
    public static class AuthenticatedUserIdentifierFactory
    {
        /// <summary>
        /// Creates a <see cref="IAuthenticatedUserIdentifier"/>
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The <see cref="IAuthenticatedUserIdentifier"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/></exception>
        public static IAuthenticatedUserIdentifier Create(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            return new UserIdentifier(id);
        }
    }
}