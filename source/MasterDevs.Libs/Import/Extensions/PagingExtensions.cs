using System.Collections.Generic;

namespace System.Linq
{
    public static class PagingExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPages<T>(this IEnumerable<T> range, int page)
        {
            int count = 0;
            while (true)
            {
                var sub = range.Skip(count * page).Take(page);
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
    }
}