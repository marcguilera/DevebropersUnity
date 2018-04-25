namespace Devebropers.Location
{
    /// <summary>
    /// Represents a location
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// The latitude
        /// </summary>
        double Latitude { get; }
        
        /// <summary>
        /// The longitude
        /// </summary>
        double Longitude { get; }
        
        /// <summary>
        /// The altitude
        /// </summary>
        double Altitude { get; }
    }
}