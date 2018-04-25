using System;
using Devebropers.Messaging.Messages;
using Devebropers.Users;

namespace Devebropers.Messaging
{
    /// <summary>
    /// Used to create <see cref="ISendableMessage"/>
    /// </summary>
    public interface IMessageFactory
    {
        
        /// <summary>
        /// Creates a new <see cref="ISendableMessage"/>
        /// </summary>
        /// <param name="id">The id for the message</param>
        /// <param name="to">The user to send the message to</param>
        /// <returns>The <see cref="ISendableMessage"/></returns>
        /// <exception cref="ArgumentException"><paramref name="id"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/></exception>
        ISendableMessage Create(string id, IUserIdentifier to);
    }
}