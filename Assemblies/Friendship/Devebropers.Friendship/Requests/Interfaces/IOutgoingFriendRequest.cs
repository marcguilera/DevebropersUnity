using System;
using System.Reactive;

namespace Devebropers.Friendship.Requests
{
    /// <summary>
    /// A outgoing <see cref="IFriendRequest"/>
    /// </summary>
    public interface IOutgoingFriendRequest : IFriendRequest
    {
        /// <summary>
        /// Cancels this request
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Cancel();
    }
}