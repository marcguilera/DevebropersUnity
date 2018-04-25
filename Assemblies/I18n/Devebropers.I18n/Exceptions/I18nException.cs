using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Devebropers.I18n
{
    public class I18nException : AggregateException
    {
        public I18nException()
        {
        }

        protected I18nException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public I18nException(string message) : base(message)
        {
        }

        public I18nException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public I18nException(IEnumerable<Exception> innerExceptions) : base(innerExceptions)
        {
        }

        public I18nException(params Exception[] innerExceptions) : base(innerExceptions)
        {
        }

        public I18nException(string message, IEnumerable<Exception> innerExceptions) : base(message, innerExceptions)
        {
        }

        public I18nException(string message, params Exception[] innerExceptions) : base(message, innerExceptions)
        {
        }
    }
}