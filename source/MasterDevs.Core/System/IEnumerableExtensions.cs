using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence
        /// contains no elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable<T> to return the first element of</param>
        /// <param name="defaultValue">The default value to return if source is empty</param>
        /// <returns>defaultValue if source is empty; otherwise, the first element in source.</returns>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue) where TSource : class
        {
            TSource firstOrDefault = source.FirstOrDefault() ?? defaultValue;

            return firstOrDefault;
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a
        /// default value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source"> An System.Collections.Generic.IEnumerable<T> to return an element from.</param>
        /// <param name="predicate"> A function to test each element for a condition.</param>
        /// <param name="defaultValue">The default value to return if source is empty</param>
        /// <returns>
        ///  defaultValue if source is empty or if no element passes the test specified
        ///  by predicate; otherwise, the first element in source that passes the test
        ///  specified by predicate.
        /// </returns>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TSource : class
        {
            TSource firstOrDefault = source.FirstOrDefault(predicate) ?? defaultValue;

            return firstOrDefault;
        }

        public static IEnumerable<IEnumerable<T>> GetPages<T>(this IEnumerable<T> source, int pageSize)
        {
            if (pageSize < 1) throw new ArgumentOutOfRangeException("pageSize", "pageSize must be greater than zero");
            int count = 0;
            while (true)
            {
                var sub = source.Skip(count * pageSize).Take(pageSize);
                if (sub.Any())
                {
                    count++;
                    yield return sub;
                }
                else
                {
                    break;
                }
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) return true;
            return !source.Any();
        }

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        ///
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable`1 whose elements to apply the predicate to.
        /// </param>
        ///
        /// <returns>
        /// true if any elements in the source sequence pass the test in the specified predicate; otherwise, false.
        /// </returns>
        ///
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        ///
        /// <param name="source">
        /// An System.Collections.Generic.IEnumerable`1 whose elements to apply the predicate to.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        ///
        /// <returns>
        /// true if any elements in the source sequence pass the test in the specified predicate; otherwise, false.
        /// </returns>
        ///
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is null.
        /// </exception>
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return !source.Any(predicate);
        }

        public static int SafeCount<T>(this IEnumerable<T> source)
        {
            if (source == null) return 0;
            return source.Count();
        }
    }
}