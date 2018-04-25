using System;
using Devebropers.Messaging.Messages;

namespace Devebropers.Messaging
{
    public delegate void OnMessageSentEventHandler(IMessage message);
    
    /// <summary>
    /// Utility to send messages
    /// </summary>
    public interface IMessageSender
    {
        event OnMessageSentEventHandler OnMessageSent;
        
        /// <summary>
        /// Sends a message
        /// </summary>
        /// <param name="message">The <see cref="IMessage"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="message"/></exception>
        void Send(IMessage message);
    }
}
