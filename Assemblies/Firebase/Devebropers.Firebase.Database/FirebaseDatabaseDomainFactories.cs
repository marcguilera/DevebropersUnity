using System;
using Devebropers.Domains;
using Devebropers.Firebase.Database;

namespace Devebropers.Firebase.Database
{
    /// <summary>
    /// A firebase database domain
    /// </summary>
    public class FirebaseDatabaseDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IFirebaseDatabase"/>
        /// </summary>
        public virtual IFirebaseDatabase FirebaseDatabase { get; }

        /// <summary>
        /// Constructs a <see cref="FirebaseDatabaseDomainFactories"/>
        /// </summary>
        public FirebaseDatabaseDomainFactories()
        {
            FirebaseDatabase = new FirebaseDatabase();
        }
    }
}