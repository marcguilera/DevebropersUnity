using System;
using System.Reactive;

namespace Devebropers.Storage.Remote.Uploads
{
    /// <summary>
    /// An uploaded <see cref="IFile"/>
    /// </summary>
    public interface IUploadedFile : IFile
    {
        /// <summary>
        /// The download url
        /// </summary>
        Uri DownloadUrl { get; }
        
        /// <summary>
        /// The name of the file
        /// </summary>
        string Name { get; }
    }
}