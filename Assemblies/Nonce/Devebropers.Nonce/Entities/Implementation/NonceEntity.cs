using System;
using Devebropers.Data.Entities;

namespace Devebropers.Nonce.Entities
{
    internal class NonceEntity : PersistableEntityBase<string, NonceModel>, INonceEntity
    {
        public NonceEntity(IEntityPersister<string, NonceModel> persister, NonceModel model) 
            : base(persister, model)
        {
        }
    }
}