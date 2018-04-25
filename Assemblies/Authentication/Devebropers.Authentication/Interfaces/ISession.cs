using Devebropers.Users;

namespace Devebropers.Authentication
{
    public delegate void OnSignOutEventHandler(IUserIdentifier user);
    
    /// <summary>
    /// Represents the current authentication state
    /// </summary>
    public interface ISession : ICurrentUserFactory
    {
        /// <summary>
        /// Occures when the user signs out
        /// </summary>
        event OnSignOutEventHandler OnSignOut;
        
        /// <summary>
        /// Whether there is an authenticated user
        /// </summary>
        bool IsAuthenticated { get; }
        
        /// <summary>
        /// Finishes the current session if any
        /// </summary>
        void SignOut();
    }
}