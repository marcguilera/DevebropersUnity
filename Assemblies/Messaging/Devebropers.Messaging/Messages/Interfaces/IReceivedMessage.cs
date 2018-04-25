using System;

namespace Devebropers.Messaging.Messages
{
    /// <summary>
    /// A <see cref="IMessage"/> that was received
    /// </summary>
    public interface IReceivedMessage : IMessage
    {
        /// <summary>
        /// The priority of the message
        /// </summary>
        MessagePriority Priority { get; }
        
        /// <summary>
        /// The time left for this message
        /// </summary>
        TimeSpan TimeToLive { get; }
    }
}