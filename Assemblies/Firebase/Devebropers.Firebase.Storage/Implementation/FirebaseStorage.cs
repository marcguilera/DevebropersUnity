using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Devebropers.Common;
using Firebase.Storage;

namespace Devebropers.Firebase.Storage
{
    internal class FirebaseStorage : IFirebaseStorage
    {
        private readonly Func<long> _maxDownloadSizeGetter;

        public FirebaseStorage(Func<long> maxDownloadSizeGetter)
        {
            _maxDownloadSizeGetter = maxDownloadSizeGetter.AssignOrThrowIfNull(nameof(maxDownloadSizeGetter));
        }

        public IObservable<StorageMetadata> Upload(StorageReference reference, byte[] bytes, MetadataChange metadataChange)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            if (metadataChange == null)
            {
                throw new ArgumentNullException(nameof(metadataChange));
            }
            
            var subject = new ReplaySubject<StorageMetadata>();
            
            reference
                .PutBytesAsync(bytes, metadataChange)
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        subject.OnError(new FirebaseStorageException("Error uploading", task.Exception));
                        return;
                    }
                    if (task.IsCanceled)
                    {
                        subject.OnError(new FirebaseStorageException("Cancelled uploading"));
                        return;
                    }
                    
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });

            return subject;
        }

        public IObservable<byte[]> Download(StorageReference reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }
            
            var subject = new ReplaySubject<byte[]>();           
            
            reference
                .GetBytesAsync(_maxDownloadSizeGetter())
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        subject.OnError(new FirebaseStorageException("Error downloading", task.Exception));
                        return;
                    }
                    if (task.IsCanceled)
                    {
                        subject.OnError(new FirebaseStorageException("Cancelled download"));
                        return;
                    }
                    
                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });

            return subject;
        }

        public IObservable<Unit> Delete(StorageReference reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }
            
            var subject = new ReplaySubject<Unit>();
            
            reference
                .DeleteAsync()
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        subject.OnError(new FirebaseStorageException("Error deleting", task.Exception));
                        return;
                    }
                    if (task.IsCanceled)
                    {
                        subject.OnError(new FirebaseStorageException("Cancelled deletion"));
                        return;
                    }
                    
                    subject.OnNext(new Unit());
                    subject.OnCompleted();
                });
            
            return subject;
        }
    }
}
