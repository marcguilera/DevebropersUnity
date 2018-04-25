namespace Devebropers.Users
{
    /// <summary>
    /// A user
    /// </summary>
    public interface IUser : IUserIdentifier
    {
        /// <summary>
        /// The display name of the user
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Whether the user is anonymous
        /// </summary>
        bool IsAnonymous { get; }
    }
}