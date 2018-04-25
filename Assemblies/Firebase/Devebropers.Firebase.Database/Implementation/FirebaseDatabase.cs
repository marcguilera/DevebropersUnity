using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Firebase.Database;

namespace Devebropers.Firebase.Database
{
    internal class FirebaseDatabase : IFirebaseDatabase
    {
        public event OnGetSuccessEventHandler OnGetSuccess;
        public event OnGetErrorEventHandler OnGetError;
        public event OnSaveSuccessEventHandler OnSaveSuccess;
        public event OnSaveErrorEventHandler OnSaveError;
        public event OnDeleteSuccessEventHandler OnDeleteSuccess;
        public event OnDeleteErrorEventHandler OnDeleteError;

        public IObservable<DataSnapshot> Get(Query query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            var subject = new ReplaySubject<DataSnapshot>();
            var firebaseQuery = query.FirebaseQuery;
            var firebaseReference = query.FirebaseReference;
            
            firebaseQuery
                .GetValueAsync()
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        subject.OnError(new GetFirebaseDatabaseException($"Cancelled getting for key {firebaseReference.Key}", firebaseReference.Key));
                        return;
                    }

                    if (task.IsFaulted)
                    {
                        subject.OnError(new GetFirebaseDatabaseException($"Error getting for key {firebaseReference.Key}",
                            task.Exception, firebaseReference.Key));
                        return;
                    }

                    if (!task.Result.Exists)
                    {
                        subject.OnError(
                            new NotFoundGetFirebaseDatabaseException($"Not found for key {firebaseReference.Key}", firebaseReference.Key));
                        return;
                    }

                    subject.OnNext(task.Result);
                    subject.OnCompleted();
                });
            
            return subject.Do(x => OnGetSuccess?.Invoke(firebaseReference, x), e => OnGetError?.Invoke(firebaseReference, e));
        }

        public IObservable<Unit> Save(DatabaseReference reference, string jsonValue)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }
            if (string.IsNullOrWhiteSpace(jsonValue))
            {
                throw new ArgumentException(nameof(jsonValue));
            }
            
            var subject = new ReplaySubject<Unit>();

            reference
                .SetValueAsync(jsonValue)
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        subject.OnError(new SaveFirebaseDatabaseException($"Cancelled saving for key {reference.Key} and body {jsonValue}", reference.Key, jsonValue));
                        return;
                    }

                    if (task.IsFaulted)
                    {
                        subject.OnError(new SaveFirebaseDatabaseException($"Error getting for key {reference.Key} and body {jsonValue}", task.Exception, reference.Key, jsonValue));
                        return;
                    }
                    
                    subject.OnNext(new Unit());
                    subject.OnCompleted();
                });

            return subject.Do(x => OnSaveSuccess?.Invoke(reference, jsonValue), e => OnSaveError?.Invoke(reference, jsonValue, e));
        }

        public IObservable<Unit> Delete(DatabaseReference reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }
            
            var subject = new Subject<Unit>();

            reference
                .RemoveValueAsync()
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        subject.OnError(new DeleteFirebaseDatabaseException($"Cancelled deleting for key {reference.Key}", reference.Key));
                        return;
                    }

                    if (task.IsFaulted)
                    {
                        subject.OnError(new DeleteFirebaseDatabaseException($"Error deleting for key {reference.Key}", task.Exception, reference.Key));
                        return;
                    }
                    
                    subject.OnNext(new Unit());
                    subject.OnCompleted();
                });

            return subject.Do(x => OnDeleteSuccess?.Invoke(reference), e => OnDeleteError?.Invoke(reference, e));
        }
    }
}