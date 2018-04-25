namespace Devebropers.Diagnostics
{
    /// <summary>
    /// An event
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// The name of the event
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Sends this event
        /// </summary>
        void Send();
    }
}