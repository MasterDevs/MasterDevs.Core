using System;

namespace MasterDevs.Core
{
    public static class CodeContracts
    {
        public static T RequireNotNull<T>(this T me, string argumentName = "") where T : class
        {
            if (me == null) throw new ArgumentNullException(argumentName);
            return me;
        }

        public static T RequireHasValue<T>(this T? me, string argumentName = "") where T : struct
        {
            if (me == null || !me.HasValue) throw new ArgumentNullException(argumentName);
            return me.Value;
        }

        public static string RequireNotNullOrEmpty(this string me, string argumentName = "")
        {
            if (string.IsNullOrEmpty(me)) throw new ArgumentNullException(argumentName);
            return me;
        }

        public static string RequireNotNullOrWhiteSpace(this string me, string argumentName = "")
        {
            if (string.IsNullOrWhiteSpace(me)) throw new ArgumentNullException(argumentName);
            return me;
        }
    }
}