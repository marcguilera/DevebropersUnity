using System;
using System.Reactive;

namespace Devebropers.Storage.Remote.Downloads
{
    /// <summary>
    /// A downloaded <see cref="IFile"/>
    /// </summary>
    public interface IDownloadedFile : IFile
    {
        /// <summary>
        /// The data downloaded
        /// </summary>
        byte[] Bytes { get; }
    }
}