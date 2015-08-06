using System.Collections.Generic;
using MasterDevs.Lib.Common.Infrastructure;

namespace System.Collections.ObjectModel
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> coll, IEnumerable<T> items)
        {
            CodeContract.RequireNotNull(coll, "coll");
            CodeContract.RequireNotNull(items, "items");

            foreach (T item in items)
            {
                coll.Add(item);
            }
        }

        public static void RemoveRange<T>(this ObservableCollection<T> coll, IEnumerable<T> items)
        {
            CodeContract.RequireNotNull(coll, "coll");
            CodeContract.RequireNotNull(items, "items");

            foreach (var item in items)
            {
                coll.Remove(item);
            }
        }
    }
}