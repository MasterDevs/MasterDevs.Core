namespace System
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public static implicit operator EventArgs<T>(T t)
        {
            return new EventArgs<T>(t);
        }

        public static implicit operator T(EventArgs<T> e)
        {
            return e.Value;
        }
    }

    public class EventArgs<T1, T2> : EventArgs
    {
        public EventArgs(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public T1 Value1 { get; set; }

        public T2 Value2 { get; set; }
    }
}