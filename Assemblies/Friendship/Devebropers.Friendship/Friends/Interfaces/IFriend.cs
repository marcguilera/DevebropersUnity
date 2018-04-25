using System;
using System.Reactive;

namespace Devebropers.Friendship.Friends
{
    /// <summary>
    /// Represents a friend
    /// </summary>
    public interface IFriend
    {
        /// <summary>
        /// The user id
        /// </summary>
        string UserId { get; }
        
        /// <summary>
        /// The user name
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Deletes this friend
        /// </summary>
        /// <returns></returns>
        IObservable<Unit> Delete();
    }
}