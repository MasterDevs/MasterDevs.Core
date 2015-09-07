using MasterDevs.Core;
using System.Collections.Generic;

namespace System.Collections.ObjectModel
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> coll, IEnumerable<T> items)
        {
            coll.RequireNotNull("coll");
            items.RequireNotNull("items");

            foreach (T item in items)
            {
                coll.Add(item);
            }
        }

        public static void RemoveRange<T>(this ObservableCollection<T> coll, IEnumerable<T> items)
        {
            coll.RequireNotNull("coll");
            items.RequireNotNull("items");

            foreach (var item in items)
            {
                coll.Remove(item);
            }
        }
    }
}