using System;
using System.Reactive;

namespace Devebropers.Data.Entities
{
    /// <summary>
    /// A <see cref="IResource"/> that can be updated
    /// </summary>
    public interface IUpdateableResource
    {
        /// <summary>
        /// Saves this <see cref="IResource"/>
        /// </summary>
        IObservable<Unit> Save();
    }
}