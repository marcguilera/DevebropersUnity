using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Devebropers.Common;
using Devebropers.Data.Entities;
using Devebropers.Domains;
using Firebase.Database;
using Query = Devebropers.Firebase.Database.Query;

namespace Devebropers.Data.Persistance
{
    public abstract class FirebaseEntityFactoryBase <TEntity, TModel>
        where TModel : ModelBase<string>
        where TEntity : IEntity<string>
    {
        private readonly IFirebaseGetter _firebaseGetter;
        private readonly IFirebaseUpdater _firebaseUpdater;

        protected FirebaseEntityFactoryBase(IFirebaseGetter firebaseGetter, IFirebaseUpdater firebaseUpdater)
        {
            _firebaseGetter = firebaseGetter.AssignOrThrowIfNull(nameof(firebaseGetter));
            _firebaseUpdater = firebaseUpdater.AssignOrThrowIfNull(nameof(firebaseUpdater));
        }

        protected TEntity CreateChild(DatabaseReference parentDatabaseReference, TModel model, string identifier = null)
        {
            return string.IsNullOrWhiteSpace(identifier) 
                ? Create(parentDatabaseReference.Push(), model)
                : Create(parentDatabaseReference.Child(identifier), model);
        }
        
        protected TEntity Create(DatabaseReference databaseReference, TModel model)
        {
            return NewEntityInternal(databaseReference, model);
        }

        protected IObservable<TEntity> Get(Query query)
        {
            return _firebaseGetter
                .Get<TModel>(query)
                .Select(model => NewEntityInternal(query.FirebaseReference, model));
        }

        protected IObservable<IEnumerable<TEntity>> GetEnumerable(Query query)
        {
            return _firebaseGetter
                .GetEnumerable<TModel>(query)
                .Select(models => models.Select(model => NewEntityInternal(query.FirebaseReference, model)));
        }

        private TEntity NewEntityInternal(DatabaseReference databaseReference, TModel model)
        {
            var persister = new FirebaseEntityPersister<TModel>(_firebaseUpdater, databaseReference);
            return NewEntity(persister, model);
        }

        protected abstract TEntity NewEntity(IEntityPersister<string, TModel> persister, TModel model);
    }
}