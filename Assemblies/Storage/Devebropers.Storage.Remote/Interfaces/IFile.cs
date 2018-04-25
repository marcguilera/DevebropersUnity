using System;
using System.Reactive;

namespace Devebropers.Storage.Remote
{
    /// <summary>
    /// Represents a file
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// The route of the file
        /// </summary>
        string Route { get; }
        
        /// <summary>
        /// The size of the file in bytes
        /// </summary>
        long SizeBytes { get; }
        
        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Delete();
    }
}