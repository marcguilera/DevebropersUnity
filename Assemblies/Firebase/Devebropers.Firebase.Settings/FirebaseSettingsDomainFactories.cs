using System;
using Devebropers.Domains;

namespace Devebropers.Firebase.Settings
{
    /// <summary>
    /// Represents a Firebase settings domain
    /// </summary>
    public class FirebaseSettingsDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IFirebaseSettings"/>
        /// </summary>
        public virtual IFirebaseSettings FirebaseSettings { get; }

        /// <summary>
        /// Constructs a <see cref="FirebaseSettingsDomainFactories"/>
        /// </summary>
        public FirebaseSettingsDomainFactories()
        {
            FirebaseSettings = new FirebaseSettings();
        }
    }
}