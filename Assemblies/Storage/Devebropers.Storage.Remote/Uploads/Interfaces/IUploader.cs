using System;

namespace Devebropers.Storage.Remote.Uploads
{
    /// <summary>
    /// Utility to upload files
    /// </summary>
    public interface IUploader
    {
        /// <summary>
        /// Uploads bytes to a route
        /// </summary>
        /// <param name="route">The route to upload the file</param>
        /// <param name="bytes">The data to upload</param>
        /// <returns>The <see cref="IUploadedFile"/></returns>
        /// <exception cref="ArgumentException"><paramref name="route"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="bytes"/></exception>
        IObservable<IUploadedFile> Upload(string route, byte[] bytes, string fileType = FileType.Jpeg);
    }
}