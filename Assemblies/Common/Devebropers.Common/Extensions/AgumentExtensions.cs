using System;
using System.Collections;

namespace Devebropers.Common
{
    public static class AgumentExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <paramref name="value"/> is null
        /// </summary>
        /// <param name="value">The value to evaluate</param>
        /// <param name="name">The name of the argument</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">If the <paramref name="value"/> is null</exception>
        public static T AssignOrThrowIfNull<T> (this T value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
            
            return value;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <paramref name="value"/> is null or whitespace
        /// </summary>
        /// <param name="value">The value to evaluate</param>
        /// <param name="name">The name of the argument</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <paramref name="value"/></returns>
        /// <exception cref="ArgumentException">If the <paramref name="value"/> is null or whitespace</exception>
        public static string AssignOrThrowIfNullOrWhiteSpace(this string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(name);
            }
            
            return value;
        }
    }
}