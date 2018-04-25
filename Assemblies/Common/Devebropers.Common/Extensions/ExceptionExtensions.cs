using System;

namespace Devebropers.Common.Exceptions
{
    public static class ExceptionExtensions
    {
        public static void Throw(this Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }
            throw exception;
        }
    }
}