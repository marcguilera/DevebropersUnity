using System;
using System.Collections.Generic;
using Devebropers.Users;

namespace Devebropers.Friendship.Friends
{
    /// <summary>
    /// Friend factory
    /// </summary>
    public interface IFriendFactory
    {
        /// <summary>
        /// Gets the friends for a <see cref="IUserIdentifier"/>
        /// </summary>
        /// <param name="user">The <see cref="IUserIdentifier"/></param>
        /// <returns>A <see cref="IEnumerable{IFriend}"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="user"/></exception>
        IObservable<IEnumerable<IFriend>> GetFriends(IUserIdentifier user);
    }
}