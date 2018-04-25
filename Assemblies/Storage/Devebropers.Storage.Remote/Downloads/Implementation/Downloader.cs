using System;
using System.Reactive.Linq;
using Devebropers.Firebase.Storage;

namespace Devebropers.Storage.Remote.Downloads
{
    internal class Downloader : StorageBase, IDownloader
    {
        public Downloader(RemoteStorageDomainFactories domainFactories, IFirebaseStorage storage) 
            : base(domainFactories, storage)
        {
        }
        
        public IObservable<IDownloadedFile> Download(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
            {
                throw new ArgumentException(nameof(route));
            }
            
            var reference = _reference.Child(route);
            return _storage
                .Download(reference)
                .Select(x => ToDownload(route, x));
        }

        private IDownloadedFile ToDownload(string route, byte[] bytes)
        {
            return new DownloadedFile(_domainFactories, bytes, route);
        }
    }
}