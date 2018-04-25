using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Data.Entities;
using Firebase.Database;

namespace Devebropers.Data.Persistance
{
    internal class FirebaseEntityPersister <TModel> : IEntityPersister<string, TModel>
        where TModel : ModelBase<string>
    {
        private readonly IFirebaseUpdater _firebaseUpdater;
        private readonly DatabaseReference _databaseReference;
        public FirebaseEntityPersister(IFirebaseUpdater firebaseUpdater, DatabaseReference databaseReference)
        {
            _databaseReference = databaseReference.AssignOrThrowIfNull(nameof(databaseReference));
            _firebaseUpdater = firebaseUpdater.AssignOrThrowIfNull(nameof(firebaseUpdater));
        }
        
        public IObservable<Unit> Save(TModel model)
        {
            return _firebaseUpdater.Save(_databaseReference, model);
        }

        public IObservable<Unit> Delete(TModel model)
        {
            return _firebaseUpdater.Delete(_databaseReference, model);
        }
    }
}