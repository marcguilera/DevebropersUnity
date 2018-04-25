using System;
using System.Reactive;

namespace Devebropers.Storage.Remote.Deletions
{
    /// <summary>
    /// A utility to delete files
    /// </summary>
    public interface IDeleter
    {
        /// <summary>
        /// Deletes a file in the given <paramref name="route"/>
        /// </summary>
        /// <param name="route">The route of the file to delete</param>
        /// <returns><see cref="Unit"/></returns>
        /// <exception cref="ArgumentException"><paramref name="route"/></exception>
        IObservable<Unit> Delete(string route);
    }
}