using System;

namespace Devebropers.Users
{
    /// <summary>
    /// A <see cref="IUserIdentifier"/> factory
    /// </summary>
    public static class UserIdentifierFactory
    {
        /// <summary>
        /// Creates a <see cref="IUserIdentifier"/>
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The <see cref="IUserIdentifier"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/></exception>
        public static IUserIdentifier Create(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            return new UserIdentifier(id);
        }
    }
}