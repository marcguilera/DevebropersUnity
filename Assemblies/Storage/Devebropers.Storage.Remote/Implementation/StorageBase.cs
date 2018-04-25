using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Storage;
using Firebase.Storage;

namespace Devebropers.Storage.Remote
{
    internal abstract class StorageBase : DomainObjectBase<RemoteStorageDomainFactories>
    {
        protected StorageReference _reference;
        protected IFirebaseStorage _storage;
        
        protected StorageBase(RemoteStorageDomainFactories domainFactories, IFirebaseStorage storage)
            : base (domainFactories)
        {
            _reference = FirebaseStorage.DefaultInstance.RootReference;
            _storage = storage.AssignOrThrowIfNull(nameof(storage));
        }
    }
}