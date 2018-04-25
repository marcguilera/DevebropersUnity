using System;
using System.Linq.Expressions;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Devebropers.Common.Observables;
using FakeItEasy;
using FakeItEasy.Configuration;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Devebropers.Common.Testing
{
    public static class ObservableAssert 
    {
        public static void That<TActual>(IObservable<TActual> actual, Constraint expression, string message = null)
        {
            Assert.That(() => GetAsync(actual), expression, message);
        }

        private static async Task<TActual> GetAsync<TActual>(IObservable<TActual> actual)
        {
            return await actual
                .Timeout(TimeSpan.FromSeconds(3))
                .FirstAsync();
        }
    }
}