using System;

namespace Devebropers.Users
{
    /// <summary>
    /// An authenticated <see cref="IUser"/>
    /// </summary>
    public interface IAuthenticatedUser : IUser, IAuthenticatedUserIdentifier
    {
        /// <summary>
        /// Whether the user has a verified email
        /// </summary>
        bool IsEmailVerified { get; }
        
        /// <summary>
        /// The user's profile picture
        /// </summary>
        Uri PhotoUrl { get; }
    }
}