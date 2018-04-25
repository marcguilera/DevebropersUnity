using System;
using System.Reactive.Linq;
using Devebropers.Firebase.Storage;
using Firebase.Storage;

namespace Devebropers.Storage.Remote.Uploads
{
    internal class Uploader : StorageBase, IUploader
    {
        public Uploader(RemoteStorageDomainFactories domainFactories, IFirebaseStorage firebaseStorage)
            : base (domainFactories, firebaseStorage)
        {
        }

        public IObservable<IUploadedFile> Upload(string route, byte[] bytes, string fileType = FileType.Jpeg)
        {
            if (string.IsNullOrWhiteSpace(route))
            {
                throw new ArgumentException(nameof(route));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            
            var reference = _reference.Child(route);
            
            var metadata = new MetadataChange
            {
                ContentType = fileType
            };
            
            return _storage
                .Upload(reference, bytes, metadata)
                .Select(ToUpload);
        }

        private IUploadedFile ToUpload(StorageMetadata meta)
        {
            return new UploadedFile(_domainFactories, meta);
        }
    }
}