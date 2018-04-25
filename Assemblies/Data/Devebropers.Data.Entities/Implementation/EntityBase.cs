using System;
using System.Reactive;
using Devebropers.Common;

namespace Devebropers.Data.Entities
{
    public abstract class EntityBase<TId, TModel> : ResourceBase, IEntity<TId>
        where TModel : ModelBase<TId>
    {
        protected readonly TModel _model;

        public TId Id => _model.Id;
        public DateTime? Created => _model.Created;

        protected EntityBase(TModel model)
        {
            _model = model.AssignOrThrowIfNull(nameof(model));
        }

        public abstract IObservable<Unit> Delete();
    }
}