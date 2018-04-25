namespace Devebropers.Messaging.Messages
{
    /// <summary>
    /// A <see cref="IMessage"/> that can be sent
    /// </summary>
    public interface ISendableMessage : IMessage
    {
        /// <summary>
        /// Sends the message
        /// </summary>
        void Send();
    }
}