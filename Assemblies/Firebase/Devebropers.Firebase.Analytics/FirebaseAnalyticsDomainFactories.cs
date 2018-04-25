using Devebropers.Domains;

namespace Devebropers.Firebase.Analytics
{
    /// <summary>
    /// Represents the firebase analytics domain
    /// </summary>
    public class FirebaseAnalyticsDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IFirebaseAnalytics"/>
        /// </summary>
        public virtual IFirebaseAnalytics FirebaseAnalytics { get; }

        /// <summary>
        /// Constructs a <see cref="FirebaseAnalyticsDomainFactories"/>
        /// </summary>
        public FirebaseAnalyticsDomainFactories()
        {
            FirebaseAnalytics = new FirebaseAnalytics();
        }
    }
}