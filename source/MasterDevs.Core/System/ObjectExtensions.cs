using System.Collections.Generic;
using System.Linq;

namespace System
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

        public static string ToStringSafe(this object value, string defaultValue = @"")
        {
            if (null == value)
            {
                return null == defaultValue 
                    ? string.Empty 
                    : defaultValue;
            }

            return value.ToString();
        }
    }
}