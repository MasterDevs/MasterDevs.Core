using System;
using System.Diagnostics;

namespace MasterDevs.Core.Utils
{
    public class DisposeWatch : IDisposable
    {
        private readonly Action<TimeSpan> _onFinished;
        private readonly Stopwatch _watch;
        private bool _isDisposed = false;

        private DisposeWatch(Action<TimeSpan> onFinished)
        {
            _onFinished = onFinished.RequireNotNull("onFinished");
            _watch = Stopwatch.StartNew();
        }

        public static DisposeWatch Start(string message = "Finished")
        {
            return new DisposeWatch(e => Debug.WriteLine($"{message} {e}"));
        }

        public static DisposeWatch Start(Action<TimeSpan> onFinished)
        {
            return new DisposeWatch(onFinished);
        }

        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;

            _watch.Stop();

            _onFinished(_watch.Elapsed);
        }
    }
}