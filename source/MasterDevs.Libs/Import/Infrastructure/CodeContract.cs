using System;

namespace MasterDevs.Lib.Common.Infrastructure
{
    public class CodeContract
    {
        public static T HasValue<T>(T? param, string paramName) where T : struct
        {
            if (param == null || !param.HasValue) throw new ArgumentNullException(paramName);
            return param.Value;
        }

        public static void Require(bool test, string argumentExceptionMessage)
        {
            if (!test)
            {
                throw new ArgumentException(argumentExceptionMessage);
            }
        }

        public static string RequireNotNull(string param, string paramName, bool allowEmpty = false)
        {
            param = RequireNotNull(param, paramName);

            if (!allowEmpty && string.Empty == param)
                throw new ArgumentOutOfRangeException(paramName, "String.Empty is not allowed");

            return param;
        }

        public static T RequireNotNull<T>(T param, string paramName) where T : class
        {
            if (param == null) throw new ArgumentNullException(paramName);
            return param;
        }

        public static long RequireNotNull(long? param, string paramName)
        {
            if (null == param || !param.HasValue) throw new ArgumentException(paramName);
            return param.Value;
        }

        public static string RequireNotNullOrEmpty(string param, string paramName)
        {
            if (string.IsNullOrEmpty(param)) throw new ArgumentException("Parameter must not be null or empty", paramName);

            return param;
        }
    }
}