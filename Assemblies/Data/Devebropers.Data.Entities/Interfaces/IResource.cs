using System;
using System.Reactive;

namespace Devebropers.Data.Entities
{
    /// <summary>
    /// A date resource
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Deletes this resource
        /// </summary>
        IObservable<Unit> Delete();
    }
}