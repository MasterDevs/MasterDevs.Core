using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MasterDevs.Lib.Common.Utils
{
    public static class EnumUtils
    {
        private static Dictionary<Type, Dictionary<object, object>> _cache = new Dictionary<Type, Dictionary<object, object>>();

        public static T Parse<T>(object value)
        {
            Dictionary<object, object> typeDict;
            var enumType = typeof(T);
            if (!_cache.TryGetValue(enumType, out typeDict))
            {
                typeDict = new Dictionary<object, object>();
                _cache[enumType] = typeDict;
            }
            object enumValue;
            if (!typeDict.TryGetValue(value, out enumValue))
            {
                enumValue = InternalParse<T>(value);
                typeDict[value] = enumValue;
            }
            return (T)enumValue;
        }

        private static T InternalParse<T>(this object value)
        {
            return InternalParse<T>(value, true);
        }
        private static T InternalParse<T>(this object value, bool ignoreCase)
        {
            bool parsedValue = false;
            string enumName = null;
            try
            {
                enumName = Enum.GetName(typeof(T), value);
                parsedValue = true;
            }
            catch (ArgumentException) { }
            if (!parsedValue && !String.IsNullOrEmpty(value.ToString()))
            {
                return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase);
            }
            else
            {
                return (T)Enum.Parse(typeof(T), enumName, ignoreCase);
            }
        }

    }
}
