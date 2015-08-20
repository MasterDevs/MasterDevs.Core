using System;
using System.Collections.Generic;

namespace MasterDevs.Lib.Common.Utils
{
    public class InMemoryByteArrayCache<Tkey>
    {
        private readonly ThreadSafeFactoryCache<Tkey, byte[]> _cache = new ThreadSafeFactoryCache<Tkey, byte[]>();
        private readonly LinkedList<MetaInfo<Tkey>> _sortedSizes = new LinkedList<MetaInfo<Tkey>>();
        
        private readonly object _Lock = new object();

        public InMemoryByteArrayCache(long maxLength)
        {
            MaxSize = maxLength;
        }

        public long CurrentSize { get; private set; }

        public long MaxSize { get; private set; }

        public byte[] Get(Tkey key)
        {
            return _cache.Get(key);
        }

        public void Set(Tkey key, byte[] value)
        {
            if (null == value) return;
            
            if (null == key)
                throw new ArgumentException("Key can not be null", "key");

            //-- Can't add objects larger then our MaxSize
            if (value.Length > MaxSize) return;

            lock (_Lock)
            {
                _cache.Set(key, value);

                var length = value.Length;

                CurrentSize += length;
                
                while (CurrentSize > MaxSize)
                {
                    RemoveLargestEntry();
                }

                AddMetaInfo(key, length);
            }
        }

        private void RemoveLargestEntry()
        {
            if (_sortedSizes.Count == 0) return;

            var first = _sortedSizes.First;

            //-- Update current size
            CurrentSize -= first.Value.Length;

            _sortedSizes.Remove(first); //-- Note it's O(1) just as _sortedSizes.RemoveFirst();
        }

        private void AddMetaInfo(Tkey key, long length)
        {
            var meta = MetaInfo<Tkey>.Create(key, length);

            var root = _sortedSizes.First;

            if (null == root)
            {
                _sortedSizes.AddFirst(meta);
            }
            else
            {
                while (null != root)
                {
                    if (length > root.Value.Length)
                    {
                        _sortedSizes.AddBefore(root, meta);
                        return;
                    }
                    root = root.Next;
                }

                //-- It's the smallest value, so add it at the end of the list
                _sortedSizes.AddLast(meta);
            }
        }

        private class MetaInfo<TKey>
        {
            public long Length { get; set; }
            public TKey Key { get; set; }

            public static MetaInfo<TKey> Create(TKey key, long length)
            {
                return new MetaInfo<TKey>
                {
                    Key = key,
                    Length = length
                };
            }
        }
    }
}
