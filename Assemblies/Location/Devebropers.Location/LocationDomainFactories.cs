using System;
using Devebropers.Domains;

namespace Devebropers.Location
{
    /// <summary>
    /// The location domain
    /// </summary>
    public class LocationDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="ILocationAuthority"/>
        /// </summary>
        public virtual ILocationAuthority LocationAuthority { get; }

        /// <summary>
        /// Constructs the <see cref="LocationDomainFactories"/>
        /// </summary>
        /// <param name="intervalGetter">A function to get the interval to check locations</param>
        /// <exception cref="ArgumentNullException"><paramref name="intervalGetter"/></exception>
        public LocationDomainFactories(Func<TimeSpan> intervalGetter)
        {
            LocationAuthority = new LocationAuthority(this, intervalGetter);
        }
    }
}
