using System;
using Devebropers.Domains;
using Devebropers.Firebase.Storage;
using Devebropers.Storage.Remote.Deletions;
using Devebropers.Storage.Remote.Downloads;
using Devebropers.Storage.Remote.Uploads;

namespace Devebropers.Storage.Remote
{
    /// <summary>
    /// The storage domain
    /// </summary>
    public class RemoteStorageDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IUploader"/>
        /// </summary>
        public virtual IUploader Uploader { get; }
        
        /// <summary>
        /// Gets a <see cref="IDownloader"/>
        /// </summary>
        public virtual IDownloader Downloader { get; }
        
        /// <summary>
        /// Gets a <see cref="IDeleter"/>
        /// </summary>
        public virtual IDeleter Deleter { get; }
        
        /// <summary>
        /// Instantiates a <see cref="RemoteStorageDomainFactories"/>
        /// </summary>
        /// <param name="firebaseStorage">A <see cref="IFirebaseStorage"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="firebaseStorage"/></exception>
        public RemoteStorageDomainFactories(IFirebaseStorage firebaseStorage)
        {
            Uploader = new Uploader(this, firebaseStorage);
            Downloader = new Downloader(this, firebaseStorage);
            Deleter = new Deleter(this, firebaseStorage);
        }
    }
}
