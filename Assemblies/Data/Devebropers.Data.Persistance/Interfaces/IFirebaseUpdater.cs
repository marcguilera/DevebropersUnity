using System;
using System.Reactive;
using Devebropers.Data.Entities;
using Firebase.Database;

namespace Devebropers.Data.Persistance
{
    /// <summary>
    /// An updated for Firebase
    /// </summary>
    public interface IFirebaseUpdater
    {
        /// <summary>
        /// Saves the model
        /// </summary>
        /// <param name="parentReference">The parent <see cref="DatabaseReference"/> of the model</param>
        /// <param name="model">The model</param>
        /// <typeparam name="TModel"></typeparam>
        IObservable<Unit> Save<TModel>(DatabaseReference databaseReference, TModel model)
            where TModel : ModelBase<string>;
        
        /// <summary>
        /// Deletes the model
        /// </summary>
        /// <param name="parentReference">The parent <see cref="DatabaseReference"/> of the model</param>
        /// <param name="model">The model</param>
        /// <typeparam name="TModel"></typeparam>
        IObservable<Unit> Delete<TModel>(DatabaseReference databaseReference, TModel model)
            where TModel : ModelBase<string>;
    }
}