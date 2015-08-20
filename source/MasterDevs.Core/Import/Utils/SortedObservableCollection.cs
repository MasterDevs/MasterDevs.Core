using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using MasterDevs.Core.Common.Infrastructure;

namespace MasterDevs.Core.Common.Utils
{
    [DebuggerDisplay("Count:  {Count}")]
    public class SortedObservableCollection<T> : ObservableCollection<T>
        where T : class, INotifyPropertyChanged
    {
        private readonly List<int> _itemHashCodes = new List<int>();
        private readonly IComparer<T> _comparer;

        public SortedObservableCollection()
            : this((IEnumerable<T>)null, (IComparer<T>)null)
        {
        }

        public SortedObservableCollection(Func<T, int> comparer)
            : this(new EasyComparer<T>(comparer))
        { }
        public SortedObservableCollection(IComparer<T> comparer)
            : this(null, comparer)
        {
            _comparer = comparer;
        }

        public SortedObservableCollection(IEnumerable<T> items, Func<T, int> comparer)
            : this(items, new EasyComparer<T>(comparer))
        {

        }
        public SortedObservableCollection(IEnumerable<T> items, IComparer<T> comparer)
            : base()
        {
            _comparer = comparer ?? Comparer<T>.Default;
            if (null != items)
                this.AddRange(items);
        }

        protected override void ClearItems()
        {
            _itemHashCodes.Clear();
            base.ClearItems();
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            var itemHashCode = item.GetHashCode();
            _itemHashCodes.Remove(itemHashCode);
            item.PropertyChanged -= OnItemPropertyChanged;
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            var oldItem = this[index];
            var itemHashCode = oldItem.GetHashCode();
            _itemHashCodes.Remove(itemHashCode);
            _itemHashCodes.Add(item.GetHashCode());
            base.SetItem(index, oldItem);
        }

        protected override void InsertItem(int index, T item)
        {
            var itemHashCode = item.GetHashCode();
            if (!_itemHashCodes.Contains(itemHashCode))
            {
                _itemHashCodes.Add(itemHashCode);
                item.PropertyChanged += OnItemPropertyChanged;
            }
            AddSorted(item);
        }

        private void AddSorted(T item)
        {
            var index = FindNewIndex(item);
            base.InsertItem(index, item);
        }

        private int FindNewIndex(T item)
        {
            if (0 == Count) return 0;
            int i = 0;
            for (i = 0; i < Count; i++)
            {
                if (_comparer.Compare(item, this[i]) < 0)
                {
                    return i;
                }
            }
            return i;
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var item = (T)sender;
            int oldIndex = this.IndexOf(item);

            //-- If the item was just removed (and happened to have one of its property changed) simply return.
            if (oldIndex == -1) return;

            // See if item should now be sorted to a different position
            if (Count <= 1 || (oldIndex == 0 || _comparer.Compare(this[oldIndex - 1], item) <= 0)
                && (oldIndex == Count - 1 || _comparer.Compare(item, this[oldIndex + 1]) <= 0))
                return;

            this.RemoveAt(oldIndex);
            AddSorted(item);
        }

    }
}
