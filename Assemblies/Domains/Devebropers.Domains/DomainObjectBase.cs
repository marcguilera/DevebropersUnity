using System;
using Devebropers.Common;

namespace Devebropers.Domains
{
    /// <summary>
    /// Base for any object in a domain
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public abstract class DomainObjectBase <TDomain>
        where TDomain : IDomainFactories
    {
        protected TDomain _domainFactories { get; }
        
        /// <summary>
        /// Constructs a <see cref="DomainObjectBase{TDomain}"/>
        /// </summary>
        /// <param name="domainFactories">The domain factories</param>
        /// <exception cref="ArgumentNullException"><paramref name="domainFactories"/></exception>
        protected DomainObjectBase(TDomain domainFactories)
        {
            _domainFactories = domainFactories.AssignOrThrowIfNull(nameof(domainFactories));
        }
    }
}