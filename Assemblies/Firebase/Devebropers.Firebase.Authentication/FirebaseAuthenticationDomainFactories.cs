using System;
using Devebropers.Domains;

namespace Devebropers.Firebase.Authentication
{
    public class FirebaseAuthenticationDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IFirebaseAuthentication"/>
        /// </summary>
        public IFirebaseAuthentication FirebaseAuthentication { get; }

        /// <summary>
        /// Constructs a <see cref="FirebaseAuthentication"/>
        /// </summary>
        public FirebaseAuthenticationDomainFactories()
        {
            FirebaseAuthentication = new FirebaseAuthentication();
        }
    }
}