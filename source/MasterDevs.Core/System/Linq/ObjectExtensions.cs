using System.Collections.Generic;
using System.Linq;

namespace System.Linq
{
    public static class ObjectExtensions
    {
        public static bool In<TSource>(this TSource value, IEnumerable<TSource> source)
        {
            return source.Contains(value);
        }

        public static bool In<TSource>(this TSource value, IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return source.Contains(value, comparer);
        }
    }
}