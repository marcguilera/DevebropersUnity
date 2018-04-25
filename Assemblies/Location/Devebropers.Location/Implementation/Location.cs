using Devebropers.Common;
using UnityEngine;

namespace Devebropers.Location
{
    internal class Location : ILocation
    {
        private readonly LocationInfo _location;
        public double Latitude => _location.latitude;
        public double Longitude => _location.longitude;
        public double Altitude => _location.altitude;
        
        public Location(LocationInfo locationInfo)
        {
            _location = locationInfo.AssignOrThrowIfNull(nameof(locationInfo));
        }
    }
}