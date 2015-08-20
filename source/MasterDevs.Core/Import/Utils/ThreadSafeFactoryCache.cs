using MasterDevs.Core.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDevs.Core.Common.Utils
{
    public class ThreadSafeFactoryCache<Tkey, Tvalue>
    {
        private readonly Dictionary<Tkey, Tvalue> _cache = new Dictionary<Tkey, Tvalue>();
        private readonly object _lock = new object();

        public Tvalue Get(Tkey key)
        {
            Tvalue result = default(Tvalue);
            _cache.TryGetValue(key, out result);
            return result;
        }

        public Tvalue Get(Tkey key, Func<Tkey, Tvalue> createIfNotExists, Action<Tvalue> update = null)
        {
            return GetOrAdd(key, createIfNotExists, update);
        }

        public void Remove(Tkey key)
        {
            lock (_lock)
            {
                if (_cache.ContainsKey(key))
                    _cache.Remove(key);
            }
        }

        public Tvalue Set(Tkey key, Tvalue value)
        {
            lock (_lock)
            {
                _cache[key] = value;
            }
            return value;
        }

        private Tvalue GetOrAdd(Tkey key, Func<Tkey, Tvalue> factory, Action<Tvalue> update)
        {
            Tvalue value;
            bool needsUpdate = true;
            if (!_cache.TryGetValue(key, out value))
            {
                lock (_lock)
                {
                    if (!_cache.TryGetValue(key, out value))
                    {
                        value = factory(key);

                        if (null != value)
                        {
                            Set(key, value);
                            needsUpdate = false;
                        }
                    }
                }
            }

            if (needsUpdate)
                update.SafeInvoke(value);
            return value;
        }

        public Tvalue this[Tkey key]
        {
            set
            {
                Set(key, value);
            }
        }

        public Tvalue[] Values
        {
            get { return _cache.Values.ToArray(); }
        }
    }
}
