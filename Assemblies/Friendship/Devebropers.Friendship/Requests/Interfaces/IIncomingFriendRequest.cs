using System;
using System.Reactive;

namespace Devebropers.Friendship.Requests
{
    /// <summary>
    /// Represents an incoming <see cref="IFriendRequest"/>
    /// </summary>
    public interface IIncomingFriendRequest : IFriendRequest
    {
        /// <summary>
        /// Acepts this request
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Accept();
        
        /// <summary>
        /// Declines this request
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Decline();
    }
}