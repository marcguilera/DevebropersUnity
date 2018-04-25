using System;

namespace Devebropers.Diagnostics
{
    /// <summary>
    /// Tracker for an IObservable{T}
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObservableTracker<in T>
    {
        /// <summary>
        /// Function to do do onNext
        /// </summary>
        /// <param name="t">The argument</param>
        void Success(T t);
        
        /// <summary>
        /// Function to do onError
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/></param>
        void Error(Exception exception);

        void Complete();
    }
}