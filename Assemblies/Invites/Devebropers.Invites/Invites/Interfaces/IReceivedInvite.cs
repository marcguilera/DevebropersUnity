using System;
using System.Reactive;

namespace Devebropers.Invites
{
    /// <summary>
    /// A received <see cref="IInvite"/>
    /// </summary>
    public interface IReceivedInvite : IInvite
    {
        /// <summary>
        /// The id of the invite
        /// </summary>
        string Id { get; }
        
        /// <summary>
        /// Convert the invitation
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Convert();
    }
}