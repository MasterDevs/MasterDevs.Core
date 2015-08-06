using System.Threading;
using System.Threading.Tasks;

namespace MasterDevs.Lib.Common.Utils
{
    /// <summary>
    /// http://blogs.msdn.com/b/pfxteam/archive/2012/02/11/10266920.aspx
    /// </summary>
    public class AsyncManualResetEvent
    {
        private volatile TaskCompletionSource<bool> m_tcs = new TaskCompletionSource<bool>();
        public Task WaitAsync() { return m_tcs.Task; }

        public void Set()
        {
            var tcs = m_tcs;
            Task.Factory.StartNew(s => ((TaskCompletionSource<bool>)s).TrySetResult(true),
                tcs, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
            tcs.Task.Wait();
        }

        public void Reset()
        {
            // This warning is safe to ignore as per the documentation for this warning
            // http://msdn.microsoft.com/en-us/library/4bw5ewxy(VS.80).aspx 
#pragma warning disable 420
            while (true)
            {
                var tcs = m_tcs;
                if (!tcs.Task.IsCompleted ||
                    Interlocked.CompareExchange(ref m_tcs, new TaskCompletionSource<bool>(), tcs) == tcs)
                    return;
            }
#pragma warning restore 420
        }
    }
}
