using System;
using System.Reactive;

namespace Devebropers.Data.Entities
{
    /// <summary>
    /// Represents a class that knows how to save or delete a <see cref="IUpdateableResource"/>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public interface IEntityPersister <TId, in TModel>
        where TModel : ModelBase<TId>
    {
        /// <summary>
        /// Saves the model
        /// </summary>
        /// <param name="model">The model of the <see cref="IEntity{TId}"/></param>
        IObservable<Unit> Save(TModel model);
        
        /// <summary>
        /// Deletes the model
        /// </summary>
        /// <param name="model">The model of the <see cref="IEntity{TId}"/></param>
        IObservable<Unit> Delete(TModel model);
    }
}