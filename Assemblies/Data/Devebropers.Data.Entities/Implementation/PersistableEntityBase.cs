using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Data.Entities;

namespace Devebropers.Data.Entities
{
    public abstract class PersistableEntityBase <TId, TModel> : UpdateableEntityBase<TId, TModel>
        where TModel : ModelBase<TId>
    {
        private readonly IEntityPersister<TId, TModel> _persister;
        
        /// <summary>
        /// Constructs a <see cref="PersistableEntity{TId,Model}"/>
        /// </summary>
        /// <param name="persister">A <see cref="IEntityPersister{TId,TModel}"/></param>
        /// <param name="model">The <see cref="ModelBase{TId}"/></param>
        protected PersistableEntityBase(IEntityPersister<TId, TModel> persister, TModel model) 
            : base(model)
        {
            _persister = persister.AssignOrThrowIfNull(nameof(persister));
        }

        public override IObservable<Unit> Delete()
        {
            return _persister.Save(_model);
        }

        public override IObservable<Unit> Save()
        {
            return _persister.Delete(_model);
        }
    }
}