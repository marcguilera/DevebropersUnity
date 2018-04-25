using System;
using System.Collections.Generic;
using Devebropers.Users;

namespace Devebropers.Diagnostics
{
    /// <summary>
    /// Handles events
    /// </summary>
    public interface IEventSender
    {
        /// <summary>
        /// Sends an event by name and arguments
        /// </summary>
        /// <param name="name">The name of the event</param>
        /// <param name="arguments"><see cref="IDictionary"/> of arguments</param>
        /// <exception cref="ArgumentException"><paramref name="name"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="arguments"/></exception>
        void Send(string name, IDictionary<string, object> arguments);
        
        /// <summary>
        /// Sets a user as the current user
        /// </summary>
        /// <param name="user">A <see cref="IUserIdentifier"/></param>
        /// <exception cref="AgumentNullException"><paramref name="user"/></exception>
        void SetUser(IUserIdentifier user);
        
        /// <summary>
        /// Removes the current user if any
        /// </summary>
        void RemoveUser();
    }
}