namespace System
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan AbsoluteValue(this TimeSpan me)
        {
            if (me == TimeSpan.Zero || me.TotalMilliseconds > 0) return me;

            return TimeSpan.FromMilliseconds(me.TotalMilliseconds * -1);
        }
    }
}