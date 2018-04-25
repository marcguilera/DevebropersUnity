using System;

namespace Devebropers.Location
{
    /// <summary>
    /// Authority to control the location services
    /// </summary>
    public interface ILocationAuthority
    {
        /// <summary>
        /// The last location known
        /// </summary>
        ILocation LastLocation { get; }
        
        /// <summary>
        /// A stream of locations
        /// </summary>
        IObservable<ILocation> Locations { get; }
        
        /// <summary>
        /// Whether the user enabled GPS
        /// </summary>
        bool IsEnabled { get; }
        
        /// <summary>
        /// Start tracking location
        /// </summary>
        void Start();
        
        /// <summary>
        /// Stop tracking location
        /// </summary>
        void Stop();
    }
}