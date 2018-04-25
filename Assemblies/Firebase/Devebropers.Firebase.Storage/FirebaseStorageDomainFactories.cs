using System;
using Devebropers.Domains;

namespace Devebropers.Firebase.Storage
{
    public class FirebaseStorageDomainFactories : IDomainFactories
    {
        public virtual IFirebaseStorage FirebaseStorage { get; }

        public FirebaseStorageDomainFactories(Func<long> maxDownloadSizeGetter)
        {
            FirebaseStorage = new FirebaseStorage(maxDownloadSizeGetter);
        }
    }
}