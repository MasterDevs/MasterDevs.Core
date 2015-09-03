using MasterDevs.Core.Common.Infrastructure;
using MasterDevs.Core.Common.Service;
using System;
using System.Diagnostics;

namespace System
{
    [DebuggerStepThrough]
    public static class ActionExtensions
    {
        public static void SafeCatchInvoke(this Action me, ILogger logger)
        {
            if (null == me) return;
            CodeContract.RequireNotNull(logger, "logger");

            try
            {
                me();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        public static void SafeInvoke(this Action me)
        {
            if (null == me) return;

            me();
        }

        public static void SafeInvoke<T>(this Action<T> me, T arg)
        {
            if (null == me) return;

            me(arg);
        }

        public static void SafeInvoke<T1, T2>(this Action<T1, T2> me, T1 arg1, T2 arg2)
        {
            if (null == me) return;

            me(arg1, arg2);
        }

        public static Action ToSafe(this Action me)
        {
            if (me == null) return () => { };
            return me;
        }

        public static Action<T> ToSafe<T>(this Action<T> me)
        {
            if (me == null) return _ => { };
            return me;
        }
    }
}