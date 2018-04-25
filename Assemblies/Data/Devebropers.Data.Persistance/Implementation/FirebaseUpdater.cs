using System;
using System.Reactive;
using System.Reactive.Linq;
using Devebropers.Data.Entities;
using Devebropers.Firebase.Database;
using Firebase.Database;
using UnityEngine;

namespace Devebropers.Data.Persistance
{
    internal class FirebaseUpdater : FirebaseBase, IFirebaseUpdater
    {
        private readonly Func<DateTime> _nowGetter;

        public FirebaseUpdater(DataPersistanceDomainFactories domainFactories, IFirebaseDatabase firebaseDatabase, Func<DateTime> nowGetter)
            : base (domainFactories, firebaseDatabase)
        {
            _nowGetter = nowGetter;
        }

        public IObservable<Unit> Save<TModel>(DatabaseReference databaseReference, TModel model) 
            where TModel : ModelBase<string>
        {
            VerifyArguments(databaseReference, model);
            
            if (model.Id == null)
            {
                model.Id = databaseReference.Key;
                model.Created = _nowGetter();
            }

            model.Updated = _nowGetter();

            return _firebaseDatabase
                .Save(databaseReference, ToJson(model));
        }

        public IObservable<Unit> Delete<TModel>(DatabaseReference parentReference, TModel model) 
            where TModel : ModelBase<string>
        {
            VerifyArguments(parentReference, model);
            
            if (!model.Created.HasValue)
            {
                return Observable.Return(new Unit());
            }

            return _firebaseDatabase
                .Delete(parentReference.Child(model.Id));
        }

        private void VerifyArguments<TModel>(DatabaseReference reference, TModel model)
            where TModel : ModelBase<string>
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }

        private static string ToJson<TModel>(TModel model)
            where TModel : ModelBase<string>
        {
            return JsonUtility.ToJson(model);
        }
    }
}
