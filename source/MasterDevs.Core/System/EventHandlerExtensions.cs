using System;

namespace MasterDevs.Core.System
{
    public static class EventHandlerExtensions
    {
        public static void SafeInvoke(this EventHandler ev, object sender)
        {
            ev.SafeInvoke(sender, EventArgs.Empty);
        }

        public static void SafeInvoke(this EventHandler ev, object sender, EventArgs e)
        {
            if (null == ev) return;

            ev(sender, e);
        }

        public static void SafeInvoke<T>(this EventHandler<T> ev, object sender, T e)
        {
            if (null == ev) return;

            ev(sender, e);
        }
    }
}