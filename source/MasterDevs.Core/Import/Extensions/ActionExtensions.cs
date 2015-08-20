using MasterDevs.Lib.Common.Infrastructure;
using MasterDevs.Lib.Common.Service;
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

        public static void SafeInvoke(this EventHandler ev, object sender)
        {
            ev.SafeInvoke(sender, EventArgs.Empty);
        }

        public static void SafeInvoke(this EventHandler ev, object sender, EventArgs e)
        {
            if (null == ev)
                return;

            ev(sender, e);
        }

        public static void SafeInvoke<T>(this EventHandler<T> ev, object sender, T e)
        {
            if (null == ev)
                return;

            ev(sender, e);
        }

        public static Action Wrap(this Action me)
        {
            return (Action)(() => me.SafeInvoke());
        }

        public static Action<T> Wrap<T>(this Action<T> me)
        {
            return (Action<T>)(val => { me.SafeInvoke(val); });
        }
    }
}