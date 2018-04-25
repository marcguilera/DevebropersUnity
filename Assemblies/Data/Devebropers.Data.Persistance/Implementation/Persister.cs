using System;
using Devebropers.Common;
using Devebropers.Data.Entities;

namespace Devebropers.Data.Persistance
{
    internal class Persister : IPersister
    {
        private readonly Action _save;
        private readonly Action _delete;

        public Persister(Action save, Action delete)
        {
            _save = save.AssignOrThrowIfNull(nameof(save));
            _delete = delete.AssignOrThrowIfNull(nameof(delete));
        }

        public void Save<TId, TModel>(TModel model) where TModel : ModelBase<TId>
        {
            _save();
        }

        public void Delete<TId, TModel>(TModel model) where TModel : ModelBase<TId>
        {
            _delete();
        }
    }
}