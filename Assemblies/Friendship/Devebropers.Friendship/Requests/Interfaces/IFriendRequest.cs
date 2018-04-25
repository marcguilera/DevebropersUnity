using System;
using System.Reactive;

namespace Devebropers.Friendship.Requests
{
    /// <summary>
    /// Represents a friend request
    /// </summary>
    public interface IFriendRequest
    {
        /// <summary>
        /// The requester user id
        /// </summary>
        string SourceUserId { get; }
        
        /// <summary>
        /// The requester user name
        /// </summary>
        string SourceUserName { get; }
        
        /// <summary>
        /// The requested user id
        /// </summary>
        string TargetUserId { get; }
        
        /// <summary>
        /// The requested user name
        /// </summary>
        string TargetUserName { get; }
        
        /// <summary>
        /// The time the request was created
        /// </summary>
        DateTime Created { get; }
    }
}