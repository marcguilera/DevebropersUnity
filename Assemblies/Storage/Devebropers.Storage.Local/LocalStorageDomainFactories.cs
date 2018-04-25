using System;
using Devebropers.Domains;
using Devebropers.Storage.Local.Files;
using Devebropers.Storage.Local.Preferences;

namespace Devebropers.Storage.Local
{
    /// <summary>
    /// The local storage domain
    /// </summary>
    public class LocalStorageDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IPreferenceFactory"/>
        /// </summary>
        public virtual IPreferenceFactory PreferenceFactory { get; }
        
        /// <summary>
        /// Gets a <see cref="IObjectPersister"/>
        /// </summary>
        public virtual IObjectPersister ObjectPersister { get; }

        public LocalStorageDomainFactories()
        {
            PreferenceFactory = new PreferenceFactory(this);
            ObjectPersister = new LocalObjectPersister(this);
        }
    }
}