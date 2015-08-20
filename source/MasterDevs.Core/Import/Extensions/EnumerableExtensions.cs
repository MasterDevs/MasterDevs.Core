using System.Linq;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> me)
        {
            if (me == null) return true;
            return !me.Any();
        }

        public static int SafeCount<T>(this IEnumerable<T> me)
        {
            if (me == null) return 0;
            return me.Count();
        }
    }
}