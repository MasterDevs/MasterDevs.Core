namespace System
{
    public static class ParsingExtensions
    {
        public static bool ParseBool(this object me, bool valueIfNullOrInvalid)
        {
            if (null != me)
            {
                bool x = valueIfNullOrInvalid;

                if (bool.TryParse(me.ToString(), out x))
                    return x;
            }

            return valueIfNullOrInvalid;
        }

        public static int ParseInt(this object me, int valueIfNullOrInvalid = 0)
        {
            if (null != me)
            {
                int x = valueIfNullOrInvalid;

                if (int.TryParse(me.ToString(), out x))
                    return x;
            }

            return valueIfNullOrInvalid;
        }
    }
}