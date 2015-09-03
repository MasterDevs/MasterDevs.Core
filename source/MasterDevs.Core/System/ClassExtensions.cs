namespace System
{
    public static class ClassExtensions
    {
        public static U Maybe<T, U>(this T t, Func<T, U> fn) where T : class
        {
            return t.Maybe(fn, default(U));
        }

        public static U Maybe<T, U>(this T t, Func<T, U> fn, U defaultValue) where T : class
        {
            return t != null ? fn(t) : defaultValue;
        }
    }
}