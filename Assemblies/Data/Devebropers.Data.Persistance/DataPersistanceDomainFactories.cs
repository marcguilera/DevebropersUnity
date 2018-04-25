using System;
using Devebropers.Domains;
using Devebropers.Firebase.Database;

namespace Devebropers.Data.Persistance
{
    /// <summary>
    /// The <see cref="DataPersistanceDomainFactories"/>
    /// </summary>
    public class DataPersistanceDomainFactories : IDomainFactories
    {

        /// <summary>
        /// A <see cref="IFirebaseUpdater"/>
        /// </summary>
        public virtual IFirebaseUpdater FirebaseUpdater { get; }
        
        /// <summary>
        /// A <see cref="IFirebaseGetter"/>
        /// </summary>
        public virtual IFirebaseGetter FirebaseGetter { get; }

        /// <summary>
        /// Instantiates a <see cref="DataPersistanceDomainFactories"/> 
        /// </summary>
        /// <param name="firebaseDatabase"><The <see cref="IFirebaseDatabase"/></param>
        /// <param name="eventSender">The <see cref="IEventSender"/></param>
        /// <param name="nowGetter">A function to get the current time</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseDatabase"/>
        ///     <paramref name="eventSender"/>
        ///     <paramref name="nowGetter"/>
        /// </exception>
        public DataPersistanceDomainFactories(IFirebaseDatabase firebaseDatabase, Func<DateTime> nowGetter)
        {
            FirebaseUpdater = new FirebaseUpdater(this, firebaseDatabase, nowGetter);
            FirebaseGetter = new FirebaseGetter(this, firebaseDatabase);
        }
    }
}
