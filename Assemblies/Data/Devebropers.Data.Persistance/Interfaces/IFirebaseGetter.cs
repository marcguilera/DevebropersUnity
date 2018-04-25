using System;
using System.Collections.Generic;
using Devebropers.Data.Entities;
using Firebase.Database;
using Query = Devebropers.Firebase.Database.Query;

namespace Devebropers.Data.Persistance
{
    /// <summary>
    /// Utility to get models from Firebase
    /// </summary>
    public interface IFirebaseGetter
    {
        /// <summary>
        /// Gets a model from the database
        /// </summary>
        /// <param name="parentReference">The parent <see cref="DatabaseReference"/> for this model</param>
        /// <param name="id">The id of the model to get</param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns>A model</returns>
        IObservable<TModel> Get<TModel>(Query query)
            where TModel : ModelBase<string>;

        /// <summary>
        /// Gets a list from the database
        /// </summary>
        /// <param name="parentReference">The parent <see cref="DatabaseReference"/> for this list</param>
        /// <param name="id">The id of the list to get</param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns>A list of models</returns>
        IObservable<IEnumerable<TModel>> GetEnumerable<TModel>(Query query)
            where TModel : ModelBase<string>;
    }
}