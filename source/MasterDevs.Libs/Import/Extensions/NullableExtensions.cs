namespace System
{
    public static class NullableExtensions
    {
        public static T SafeGet<T>(this Nullable<T> me, T defaultValue) where T : struct
        {
            if (me.HasValue) return me.Value;

            return defaultValue;
        }
    }
}