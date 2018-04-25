using System;
using Devebropers.Domains;
using Devebropers.Firebase.Settings;

namespace Devebropers.Settings
{
    /// <summary>
    /// Represents a settings domain
    /// </summary>
    public class SettingsDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="ISettingFactory"/>
        /// </summary>
        public virtual ISettingFactory SettingFactory { get; }
        
        /// <summary>
        /// Gets a <see cref="ISettingsUpdater"/>
        /// </summary>
        public virtual ISettingsUpdater SettingsUpdater { get; }

        /// <summary>
        /// Constructs a <see cref="SettingsDomainFactories"/>
        /// </summary>
        /// <param name="firebaseSettings">A <see cref="IFirebaseSettings"/></param>
        /// <param name="intervalGetter">A function to get the update interval</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseSettings"/>
        ///     <paramref name="interfalGetter"/>
        /// </exception>
        public SettingsDomainFactories(IFirebaseSettings firebaseSettings, Func<TimeSpan> intervalGetter)
        {
            SettingFactory = new SettingFactory(this, firebaseSettings);
            SettingsUpdater = new SettingsUpdater(this, firebaseSettings, intervalGetter);
        }
    }
}
