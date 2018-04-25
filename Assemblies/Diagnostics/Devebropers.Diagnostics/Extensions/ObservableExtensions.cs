using System;
using System.Reactive.Linq;

namespace Devebropers.Diagnostics
{
    public static class ObservableExtensions
    {
        /// <summary>
        /// Sets a <see cref="IObservableTracker{T}"/> to the <see cref="IObservable{T}"/>
        /// </summary>
        /// <param name="observable">The <see cref="IObservable{T}"/>
        /// <param name="tracker">The <see cref="IObservableTracker{T}"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="IObservable{T}"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="observable"/>
        ///     <paramref name="tracker"/>
        /// </exception>
        public static IObservable<T> Track<T>(this IObservable<T> observable, IObservableTracker<T> tracker)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }

            if (tracker == null)
            {
                throw new ArgumentNullException(nameof(tracker));
            }

            return observable.Do(tracker.Success, tracker.Error, tracker.Complete);
        }
    }
}