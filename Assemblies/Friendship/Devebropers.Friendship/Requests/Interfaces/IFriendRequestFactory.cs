using System;
using System.Collections.Generic;
using Devebropers.Users;

namespace Devebropers.Friendship.Requests
{
    public delegate void OnFriendRequestSentEventHandler(IFriendRequest friendRequest);
    
    public interface IFriendRequestFactory
    {
        /// <summary>
        /// Occurs when a friend request is sent
        /// </summary>
        event OnFriendRequestSentEventHandler OnFriendRequestSent;
        
        /// <summary>
        /// Gets the friend requests for a <see cref="IUserIdentfier"/>
        /// </summary>
        /// <param name="user">A <see cref="IUserIdentifier"/></param>
        /// <returns>A <see cref="IEnumerable{IIncomingFriendRequest}"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="IUserIdentifier"/></exception>
        IObservable<IEnumerable<IIncomingFriendRequest>> GetIncomingFriendRequests(IUserIdentifier user);
        
        /// <summary>
        /// Gets the friend requests by a <see cref="IUserIdentfier"/>
        /// </summary>
        /// <param name="user">A <see cref="IUserIdentifier"/></param>
        /// <returns>A <see cref="IEnumerable{IOutgoingFriendRequest}"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="IUserIdentifier"/></exception>
        IObservable<IEnumerable<IOutgoingFriendRequest>> GetOutgoingFriendRequests(IUserIdentifier user);
        
        /// <summary>
        /// Sends a friend request to a <see cref="IUser"/>
        /// </summary>
        /// <param name="source">The sender <see cref="IUser"/></param>
        /// <param name="target">The receiver <see cref="IUser"/></param>
        /// <returns>A <see cref="IEnumerable{IOutgoingFriendRequest}"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/>
        ///     <paramref name="target"/>
        /// </exception>
        IObservable<IOutgoingFriendRequest> SendRequest(IUser source, IUser target);
    }
}