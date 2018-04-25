using System;

namespace Devebropers.Storage.Remote.Downloads
{
    /// <summary>
    /// Utitlity to download files
    /// </summary>
    public interface IDownloader
    {
        /// <summary>
        /// Downloads a file in the route
        /// </summary>
        /// <param name="route">The route of the file to download</param>
        /// <returns>The <see cref="IDownloadFile"/></returns>
        /// <exception cref="ArgumentException"><paramref name="route"/></exception>
        IObservable<IDownloadedFile> Download(string route);
    }
}