using System;

namespace Devebropers.Users
{
    /// <summary>
    /// A factory of <see cref="IAnonymousUserIdentifier"/>
    /// </summary>
    public static class AnonymousUserIdentifierFactory
    {
        /// <summary>
        /// Creates a <see cref="IAnonymousUserIdentifier"/>
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The <see cref="IAnonymousUserIdentifier"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/></exception>
        public static IAnonymousUserIdentifier Create(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            return new UserIdentifier(id);
        }
    }
}