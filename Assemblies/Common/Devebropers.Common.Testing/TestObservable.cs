using System;
using System.Reactive;
using System.Reactive.Linq;
using FakeItEasy;
using FakeItEasy.Configuration;
using FakeItEasy.Core;

namespace Devebropers.Common.Testing
{
    public static class TestObservable
    {
        public static IObservable<Unit> Unit()
        {
            return Returns(new Unit());
        }
        
        public static IObservable<T> Returns<T>()
        {
            return Returns(A.Fake<T>());
        }
        
        public static IObservable<T> Returns<T>(T value)
        {
            return Observable.Return(value);
        }

        public static IObservable<T> Throws <T,E> ()
            where E : Exception
        {
            return Throws<T, E>(A.Fake<E>());
        }
        
        public static IObservable<T> Throws <T,E> (E exception)
            where E : Exception
        {
            return Observable.Throw<T>(exception);
        }
    }
}