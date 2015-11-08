using System.Threading;
using System.Threading.Tasks;

namespace MasterDevs.Core.Tasks
{
    /// <summary>
    /// http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266920.aspx
    /// </summary>
    public class AsyncManualResetEvent
    {
        private volatile TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

        /// <summary>
        /// Closes the event
        /// </summary>
        public void Reset()
        {
            // This warning is safe to ignore in this context as per the documentation for this warning
            // http://msdn.microsoft.com/en-us/library/4bw5ewxy(VS.80).aspx
#pragma warning disable 420
            while (true)
            {
                var tcs = _tcs;
                if (!tcs.Task.IsCompleted ||
                    Interlocked.CompareExchange(ref _tcs, new TaskCompletionSource<bool>(), tcs) == tcs)
                {
                    return;
                }
            }
#pragma warning restore 420
        }

        /// <summary>
        /// Opens the event
        /// </summary>
        public void Set()
        {
            var tcs = _tcs;
            Task.Factory.StartNew(
                s => ((TaskCompletionSource<bool>)s).TrySetResult(true),
                tcs,
                CancellationToken.None,
                TaskCreationOptions.PreferFairness,
                TaskScheduler.Default);
            tcs.Task.Wait();
        }

        public Task WaitAsync()
        {
            return _tcs.Task;
        }
    }
}