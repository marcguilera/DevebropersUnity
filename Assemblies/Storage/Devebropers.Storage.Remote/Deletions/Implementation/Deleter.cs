using System;
using System.Reactive;
using Devebropers.Domains;
using Devebropers.Firebase.Storage;

namespace Devebropers.Storage.Remote.Deletions
{
    internal class Deleter : StorageBase, IDeleter
    {
        public Deleter(RemoteStorageDomainFactories domainFactories, IFirebaseStorage storage) 
            : base(domainFactories, storage)
        {
        }
        
        public IObservable<Unit> Delete(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
            {
                throw new ArgumentException(nameof(route));
            }
            
            var reference = _reference.Child(route);
            return _storage
                .Delete(reference);
        }

        
    }
}