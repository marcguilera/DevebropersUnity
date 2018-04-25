using System;
using Devebropers.Domains;
using Devebropers.Firebase.Analytics;

namespace Devebropers.Diagnostics
{
    /// <summary>
    /// The diagnostics domain
    /// </summary>
    public class DiagnosticsDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IEventSender"/>
        /// </summary>
        public virtual IEventSender EventSender { get; }
        
        /// <summary>
        /// Constructs a <see cref="DiagnosticsDomainFactories"/>
        /// </summary>
        /// <param name="firebaseAnalytics">The <see cref="IFirebaseAnalytics"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="firebaseAnalytics"/></exception>
        public DiagnosticsDomainFactories(IFirebaseAnalytics firebaseAnalytics)
        {
            EventSender = new EventSender(firebaseAnalytics);
        }
    }
}
