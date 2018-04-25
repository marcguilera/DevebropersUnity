using Devebropers.Users;

namespace Devebropers.Authentication
{
    /// <summary>
    /// Gets the current user
    /// </summary>
    public interface ICurrentUserFactory
    {
        /// <summary>
        /// Gets the current <see cref="IAuthenticatedUser"/>
        /// </summary>
        IAuthenticatedUser CurrentUser { get; }
    }
}