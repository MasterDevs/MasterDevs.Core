using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MasterDevs.Core.Tasks
{
    /// <summary>
    /// http://blogs.msdn.com/b/pfxteam/archive/2011/01/15/asynclazy-lt-t-gt.aspx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<T> valueFactory) :
            base(() => Task.Factory.StartNew(valueFactory))
        { }

        /// <param name="taskFactory">Factory that returns a running task</param>
        public AsyncLazy(Func<Task<T>> taskFactory) :
            base(() => Task.Factory.StartNew(() => taskFactory()).Unwrap())
        { }

        /// <summary>
        /// Called by the compiler, no need to call this manually
        /// </summary>
        public TaskAwaiter<T> GetAwaiter()
        {
            return Value.GetAwaiter();
        }
    }
}