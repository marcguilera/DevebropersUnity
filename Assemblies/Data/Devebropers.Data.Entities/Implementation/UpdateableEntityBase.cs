using System;
using System.Reactive;

namespace Devebropers.Data.Entities
{
    public abstract class UpdateableEntityBase <TId, TModel> : EntityBase<TId, TModel>, IUpdateableEntity<TId>
        where TModel : ModelBase<TId>
    {
        public DateTime? Updated => _model.Updated;

        protected UpdateableEntityBase(TModel model) 
            : base(model)
        {
        }

        public abstract override IObservable<Unit> Save();
    }
}