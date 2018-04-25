using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Devebropers.Data.Entities;
using Devebropers.Firebase.Database;
using Firebase.Database;
using Query = Devebropers.Firebase.Database.Query;

namespace Devebropers.Data.Persistance
{
    internal class FirebaseGetter : FirebaseBase, IFirebaseGetter
    {
        public FirebaseGetter(DataPersistanceDomainFactories domainFactories, IFirebaseDatabase firebaseDatabase) 
            : base(domainFactories, firebaseDatabase)
        {
        }

        public IObservable<TModel> Get<TModel>(Query query) 
            where TModel : ModelBase<string>
        {
            return GetInternal(query)
                .Select(snapshot => (TModel) snapshot.Value);
        }

        public IObservable<IEnumerable<TModel>> GetEnumerable<TModel>(Query query) 
            where TModel : ModelBase<string>
        {
            return GetInternal(query)
                .Select(snapshot => (TModel[]) snapshot.Value);
        }
        
        private IObservable<DataSnapshot> GetInternal(Query query)
        {
            return _firebaseDatabase
                .Get(query)
                .SelectMany(ToSnapshot);
        }

        private static IObservable<DataSnapshot> ToSnapshot(DataSnapshot snapshot)
        {
            return snapshot.Exists
                ? Observable.Return(snapshot)
                : Observable.Throw<DataSnapshot>(new NotFoundException("Snapshot does not exist"));
        }
    }
}