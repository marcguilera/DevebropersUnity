using System;
using Devebropers.Data.Entities;
using Devebropers.Data.Persistance;
using Firebase.Database;
using Query = Devebropers.Firebase.Database.Query;

namespace Devebropers.Nonce.Entities
{
    internal class NonceEntityFactory : FirebaseEntityFactoryBase<INonceEntity, NonceModel>, INonceEntityFactory
    {
        private DatabaseReference _databaseReference => NonceDatabaseReferences.Root();
        
        public NonceEntityFactory(IFirebaseGetter firebaseGetter, IFirebaseUpdater firebaseUpdater) 
            : base(firebaseGetter, firebaseUpdater)
        {
        }
        
        public IObservable<INonceEntity> GetNonce(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException(nameof(token));
            }
            
            var reference = _databaseReference.Child(token);
            var query = Query
                .Create(reference)
                .LimitToFirst(1);
            
            return Get(query);
        }

        public INonceEntity CreateNonce(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException(nameof(token));
            }
            
            return CreateChild(_databaseReference, new NonceModel(), token);
        }
        
        protected override INonceEntity NewEntity(IEntityPersister<string, NonceModel> persister, NonceModel model)
        {
            return new NonceEntity(persister, model);
        }
    }
}