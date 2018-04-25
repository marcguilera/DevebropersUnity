using System;
using System.Collections.Generic;

namespace Devebropers.Messaging.Messages
{
    /// <summary>
    /// Represents a message
    /// </summary>
    public interface IMessage : IDisposable
    {
        /// <summary>
        /// The identifier of the message
        /// </summary>
        string Id { get; }
        
        /// <summary>
        /// The Id of the target
        /// </summary>
        string To { get; }
        
        /// <summary>
        /// The Id of the source
        /// </summary>
        string From { get; }
        
        /// <summary>
        /// The dictionary of parameters
        /// </summary>
        IDictionary<string, string> Data { get; }
    }
}