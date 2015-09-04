using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace System
{
    public static class StringExtensions
    {
        private delegate bool DaConverter<T>(string input, out T output);

        public static string Coalesce(this string me, params string[] backups)
        {
            if (!string.IsNullOrWhiteSpace(me)) return me;
            if (backups == null) return null;

            return backups.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
        }

        public static bool ToBoolSafe(this string me, bool defaultValue = false)
        {
            return SafeParse(me, bool.TryParse, defaultValue);
        }

        public static DateTime ToDateTimeSafe(this string me, DateTime defaultValue = new DateTime())
        {
            return SafeParse(me, DateTime.TryParse, defaultValue);
        }

        public static int ToIntSafe(this string me, int defaultValue = 0)
        {
            return SafeParse(me, int.TryParse, defaultValue);
        }

        public static long ToLongSafe(this string me, long defaultValue = 0)
        {
            return SafeParse(me, long.TryParse, defaultValue);
        }

        public static string ToStringSafe(this object value, string valueIfNull = @"")
        {
            if (null == value)
                return null == valueIfNull ? string.Empty : valueIfNull;

            return value.ToString();
        }

        public static string TrimSafe(this string me)
        {
            if (string.IsNullOrEmpty(me)) return me;
            return me.Trim();
        }

        private static T SafeParse<T>(this string me, DaConverter<T> convert, T defaultValue)
        {
            if (string.IsNullOrEmpty(me)) return defaultValue;

            var v = defaultValue;
            if (convert(me, out v))
            {
                return v;
            }
            return defaultValue;
        }
    }
}