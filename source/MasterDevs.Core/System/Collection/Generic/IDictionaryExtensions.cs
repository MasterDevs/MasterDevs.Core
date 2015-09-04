using System.Linq;

namespace System.Collections.Generic
{
    public static class IDictionaryExtensions
    {
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(
            this IDictionary<TKey, TValue> source,
            IDictionary<TKey, TValue> newValues,
            bool ignoreDupes = false)
        {
            if (source == null && newValues == null) return null;
            if (source == null) return newValues.ToDictionary();

            if (newValues == null) return new Dictionary<TKey, TValue>(source);

            if (!ignoreDupes)
            {
                TKey[] duplicateKeys = source.Keys
                                               .Where(k => newValues.ContainsKey(k))
                                               .Select(k => k)
                                               .ToArray();

                if (duplicateKeys.Any())
                {
                    string errorMsg = string.Format("The following ({0}) have been duplicated:  {1}",
                        duplicateKeys.Length,
                        string.Join(", ", duplicateKeys));

                    throw new ArgumentException(errorMsg, "additionalPrameterValues");
                }
            }

            Dictionary<TKey, TValue> merged = new Dictionary<TKey, TValue>(source);
            foreach (var item in newValues)
            {
                merged[item.Key] = item.Value;
            }

            return merged;
        }

        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            return new Dictionary<TKey, TValue>(source);
        }
    }
}