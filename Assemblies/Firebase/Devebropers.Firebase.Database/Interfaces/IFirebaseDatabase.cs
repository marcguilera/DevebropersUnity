using System;
using System.Reactive;
using Firebase.Database;

namespace Devebropers.Firebase.Database
{
    public delegate void OnGetSuccessEventHandler(DatabaseReference referece, DataSnapshot dataSnapshot);
    public delegate void OnGetErrorEventHandler(DatabaseReference reference, Exception exception);
    public delegate void OnSaveSuccessEventHandler(DatabaseReference reference, string jsonValue);
    public delegate void OnSaveErrorEventHandler(DatabaseReference reference, string jsonValue, Exception exception);
    public delegate void OnDeleteSuccessEventHandler(DatabaseReference reference);
    public delegate void OnDeleteErrorEventHandler(DatabaseReference reference, Exception exception);
    
    /// <summary>
    /// Represents a Firebase realtime database
    /// </summary>
    public interface IFirebaseDatabase
    {
        event OnGetSuccessEventHandler OnGetSuccess;
        event OnGetErrorEventHandler OnGetError;
        event OnSaveSuccessEventHandler OnSaveSuccess;
        event OnSaveErrorEventHandler OnSaveError;
        event OnDeleteSuccessEventHandler OnDeleteSuccess;
        event OnDeleteErrorEventHandler OnDeleteError;
        
        /// <summary>
        /// Gets a <see cref="DataSnapshot"/> for the given <see cref="DatabaseReference"/>
        /// </summary>
        /// <param name="reference">The <see cref="DatabaseReference"/></param>
        /// <returns><see cref="DataSnapshot"/></returns>
        IObservable<DataSnapshot> Get(Query query);
        
        /// <summary>
        /// Saves the <paramref name="jsonValue"/> to the given <see cref="DatabaseReference"/>
        /// </summary>
        /// <param name="reference">The <see cref="DatabaseReference"/></param>
        /// <param name="jsonValue">The value to store</param>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Save(DatabaseReference reference, string jsonValue);
        
        /// <summary>
        /// Deletes the value from the <see cref="DatabaseReference"/>
        /// </summary>
        /// <param name="reference">The <see cref="DatabaseReference"/></param>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Delete(DatabaseReference reference);
    }
}