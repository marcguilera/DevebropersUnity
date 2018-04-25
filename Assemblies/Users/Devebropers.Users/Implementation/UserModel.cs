using System;
using Devebropers.Data.Entities;

namespace Devebropers.Users
{
    /// <summary>
    /// The model for a <see cref="IUser"/>
    /// </summary>
    public class UserModel : ModelBase<string>
    {
        /// <summary>
        /// Whether the user is anonymous
        /// </summary>
        public bool IsAnonymous { get; set; }
        
        /// <summary>
        /// The display name of the user
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The url of the user's profile picture
        /// </summary>
        public Uri PhotoUrl { get; set; }
        
        /// <summary>
        /// Whether the user has a verified email
        /// </summary>
        public bool IsEmailVerified { get; set; }
    }
}