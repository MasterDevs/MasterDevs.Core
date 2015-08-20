using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using MasterDevs.Core.Common.Infrastructure;

namespace MasterDevs.Core.Common.Utils
{
    [DebuggerDisplay("Count:  {Count}")]
    public class FilteredSortedObservableCollection<T> : SortedObservableCollection<T>
        where T : class, INotifyPropertyChanged
    {
        private readonly Func<T, bool> _filter;
        private readonly SortedObservableCollection<T> _filtered;
        private readonly Func<T, bool> _filterInverted;

        public FilteredSortedObservableCollection(Func<T, bool> filter)
            : this(filter, (IEnumerable<T>)null, (IComparer<T>)null)
        {
        }

        public FilteredSortedObservableCollection(Func<T, bool> filter, Func<T, int> comparer)
            : this(filter, new EasyComparer<T>(comparer))
        {
        }

        public FilteredSortedObservableCollection(Func<T, bool> filter, IComparer<T> comparer)
            : this(filter, null, comparer)
        {
        }

        public FilteredSortedObservableCollection(Func<T, bool> filter, IEnumerable<T> items, Func<T, int> comparer)
            : this(filter, items, new EasyComparer<T>(comparer))
        {
        }

        public FilteredSortedObservableCollection(Func<T, bool> filter, IEnumerable<T> items, IComparer<T> comparer)
            : base(items, comparer)
        {
            _filter = CodeContract.RequireNotNull(filter, "filter");

            _filtered = new SortedObservableCollection<T>(comparer);
            _filterInverted = t => !_filter(t);

            ResetFilter();
        }

        public SortedObservableCollection<T> Filtered { get { return _filtered; } }

        public void UpdateFiltered()
        {
            var toAdd = this.Where(_filter).Except(_filtered).ToArray();
            var toRemove = _filtered.Where(_filterInverted).ToArray();

            _filtered.AddRange(toAdd);
            _filtered.RemoveRange(toRemove);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            var oldItems = new Lazy<IEnumerable<T>>(() => e.OldItems.Cast<T>());
            var newItems = new Lazy<IEnumerable<T>>(() => e.NewItems.Cast<T>()
                                                                    .Where(_filter));

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _filtered.AddRange(newItems.Value);
                    break;

                case NotifyCollectionChangedAction.Move:
                    _filtered.RemoveRange(oldItems.Value);
                    _filtered.AddRange(oldItems.Value.Where(_filter));
                    break;

                case NotifyCollectionChangedAction.Remove:
                    _filtered.RemoveRange(oldItems.Value);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    _filtered.RemoveRange(oldItems.Value);
                    _filtered.AddRange(newItems.Value);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    ResetFilter();
                    break;

                default:
                    break;
            }
        }

        private void ResetFilter()
        {
            _filtered.Clear();
            _filtered.AddRange(this.Where(_filter));
            UpdateFiltered();
        }
    }
}