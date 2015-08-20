using System.Collections.Generic;
using System.Linq;

namespace MasterDevs.Core.System.Linq
{
    public static class Object
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