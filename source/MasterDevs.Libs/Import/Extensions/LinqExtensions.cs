using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
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
    }
}