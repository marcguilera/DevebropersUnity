using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Database;

namespace Devebropers.Data.Persistance
{
    internal class FirebaseBase : DomainObjectBase<DataPersistanceDomainFactories>
    {
        protected readonly IFirebaseDatabase _firebaseDatabase;
        
        public FirebaseBase(DataPersistanceDomainFactories domainFactories, IFirebaseDatabase firebaseDatabase) 
            : base(domainFactories)
        {
            _firebaseDatabase = firebaseDatabase.AssignOrThrowIfNull(nameof(firebaseDatabase));
        }
        
    }
}