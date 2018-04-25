using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Devebropers.Common
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks if the <see cref="IEnumerable"/> is null or empty
        /// </summary>
        /// <param name="enumerable">The <see cref="IEnumerable"/></param>
        /// <returns>True if the <see cref="IEnumerable"/> is null or empty, false otherwise</returns>
        public static bool IsNullOrEmpty(this IEnumerable enumerable)
        {
            return enumerable == null || enumerable.GetEnumerator().MoveNext();
        }

        /// <summary>
        /// Converts the <see cref="IDictionary{TKey,TValue}"/> to a <see cref="IReadonlyDictionary{TKey,TValue}"/>
        /// </summary>
        /// <param name="dictionary">A <see cref="IDictionary{TKey,TValue}"/></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>The <see cref="IReadonlyDictionary{TKey,TValue}"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="dictionary"/>
        /// </exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            return dictionary.ToDictionary(x => x.Key, x => x.Value);
        }
        
        /// <summary>
        /// Converts the <see cref="IReadonlyDictionary{TKey,TValue}"/> to a <see cref="IDictionary{TKey,TValue}"/>
        /// </summary>
        /// <param name="dictionary">A <see cref="IReadonlyDictionary{TKey,TValue}"/></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>The <see cref="IDictionary{TKey,TValue}"/></returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="dictionary"/>
        /// </exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            return dictionary.ToDictionary(x => x.Key, x => x.Value);
        }

        public static TValue FirstOrDefault<TValue>(this IEnumerable<TValue> enumerable, TValue defaultValue, Func<TValue, bool> predicate = null)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            var value = predicate != null ? enumerable.Where(predicate) : enumerable;
            return value.Any() ? value.FirstOrDefault() : defaultValue;
        }
        
        public static TValue FirstOrDefault<TValue>(this IEnumerable<TValue> enumerable, Func<TValue> defaultValue, Func<TValue, bool> predicate = null)
        {
            return enumerable.FirstOrDefault(defaultValue(), predicate);
        }
    }
}