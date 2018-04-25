using System;
using System.Reactive;
using Firebase.Storage;

namespace Devebropers.Firebase.Storage
{
    /// <summary>
    /// Handles I/O with the Firebase storage
    /// </summary>
    public interface IFirebaseStorage
    {
        /// <summary>
        /// Uploads the bytes to a <see cref="StorageReference"/>
        /// </summary>
        /// <param name="reference">The <see cref="StorageReference"/> to upload the file</param>
        /// <param name="bytes">The byte array></param>
        /// <param name="metadataChange">The <see cref="MetadataChange"/></param>
        /// <returns>The <see cref="IFirebaseUpload"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reference"/>
        ///     <paramref name="bytes"/>
        ///     <paramref name="metadataChange"/>
        /// </exception>
        IObservable<StorageMetadata> Upload(StorageReference reference, byte[] bytes, MetadataChange metadataChange);
        
        /// <summary>
        /// Downloads the bytes from a <see cref="StorageReference"/>
        /// </summary>
        /// <param name="reference">The <see cref="StorageReference"/> to download the file</param>
        /// <returns>The <see cref="IFirebaseUpload"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reference"/>
        /// </exception>
        IObservable<byte[]> Download(StorageReference reference);
        
        /// <summary>
        /// Deletes a file from a <see cref="StorageReference"/>
        /// </summary>
        /// <param name="reference">The <see cref="StorageReference"/> to delete the file</param>
        /// <returns>The <see cref="IFirebaseUpload"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reference"/>
        /// </exception>
        IObservable<Unit> Delete(StorageReference reference);
    }
}