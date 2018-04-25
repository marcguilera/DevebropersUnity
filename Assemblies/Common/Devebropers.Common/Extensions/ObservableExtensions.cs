using System;
using System.CodeDom;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Devebropers.Common.Exceptions;

namespace Devebropers.Common.Observables
{
    public static class ObservableExtensions
    {
        public static IObservable<T> SubscribeAndContinue<T>(this IObservable<T> observable, 
            Action<T> onContinue = null, Action<Exception> onError = null, Action onComplete = null)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }

            onContinue = onContinue ?? (t => { });
            onError = onError ?? (ex => ex.Throw());
            onComplete = onComplete ?? (() => { });
            
            var observer = new AnonymousObserver<T>(onContinue, onError, onComplete);
            
            return observable.SubscribeAndContinue(observer);
        }
        
        public static IObservable<T> SubscribeAndContinue<T>(this IObservable<T> observable, IObserver<T> observer)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            var subject = new ReplaySubject<T>();

            observable
                .Do(subject.OnNext, subject.OnError, subject.OnCompleted)
                .WeakSubscribe(observer);
            
            return subject;
        }
        
        public static IDisposable WeakSubscribe<T>(this IObservable<T> observable, IObserver<T> observer)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }
            
            return new WeakSubscription<T>(observable, observer);
        }

        private class WeakSubscription<T> : IDisposable, IObserver<T>
        {
            private readonly WeakReference _reference;
            private readonly IDisposable _subscription;
            private bool _disposed;

            public WeakSubscription(IObservable<T> observable, IObserver<T> observer)
            {
                _reference = new WeakReference(observer);
                _subscription = observable.Subscribe(this);
            }

            void IObserver<T>.OnCompleted()
            {
                var observer = (IObserver<T>) _reference.Target;
                if (observer != null) observer.OnCompleted();
                else Dispose();
            }

            void IObserver<T>.OnError(Exception error)
            {
                var observer = (IObserver<T>) _reference.Target;
                if (observer != null) observer.OnError(error);
                else Dispose();
            }

            void IObserver<T>.OnNext(T value)
            {
                var observer = (IObserver<T>) _reference.Target;
                if (observer != null) observer.OnNext(value);
                else Dispose();
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    _disposed = true;
                    _subscription.Dispose();
                }
            }
        }
        
    }
}