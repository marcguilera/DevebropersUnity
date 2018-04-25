using System;
using System.Reactive;

namespace Devebropers.Invites
{
    /// <summary>
    /// A sendable <see cref="IInvite"/>
    /// </summary>
    public interface ISendableInvite : IInvite
    {
        /// <summary>
        /// Sends this invite
        /// </summary>
        /// <returns><see cref="ISentInvite"/></returns>
        IObservable<Unit> Send();
    }
}