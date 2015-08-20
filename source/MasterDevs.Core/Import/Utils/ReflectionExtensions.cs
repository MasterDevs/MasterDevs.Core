using System;
using System.Linq;
using System.Reflection;

namespace MasterDevs.Lib.Common.Utils
{
    public static class ReflectionExtensions
    {
        public static T GetAttribute<T>(this Type me, bool inherit = true) where T : Attribute
        {
            return me.GetTypeInfo().GetCustomAttributes<T>(inherit).FirstOrDefault();
        }
    }
}
