using System.Linq;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> original, IDictionary<TKey, TValue> newValues)
        {
            if (original == null || newValues == null) return null;

            if (original == null) return new Dictionary<TKey, TValue>(newValues);
            if (newValues == null) return new Dictionary<TKey, TValue>(original);

            TKey[] duplicateKeys = original.Keys
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

            Dictionary<TKey, TValue> merged = new Dictionary<TKey, TValue>(original);
            foreach (var item in newValues)
            {
                merged[item.Key] = item.Value;
            }

            return merged;
        }
    }
}