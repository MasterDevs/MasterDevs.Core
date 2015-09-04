using MasterDevs.Core.Common.Service;
using System;
using System.Diagnostics;

namespace MasterDevs.Core.Common.Utils
{
    public class Disposewatch : IDisposable
    {
        private const string DEFAULT_MESSAGE = @"Finished ";

        private readonly Action<TimeSpan> _onFinished;
        private bool _isDisposed = false;
        private Stopwatch _watch;

        private Disposewatch(Action<TimeSpan> onFinished)
        {
            _onFinished = onFinished.RequireNotNull("onFinished");
            _watch = Stopwatch.StartNew();
        }

        public static Disposewatch Start(string message = DEFAULT_MESSAGE)
        {
            return new Disposewatch(e => Debug.WriteLine("{0 }{1}", message, e));
        }

        public static Disposewatch Start(ILogger logger, string message = DEFAULT_MESSAGE)
        {
            return new Disposewatch(e => logger.Debug("{0 }{1}", message, e));
        }

        public static Disposewatch StartTimeSpan(Action<TimeSpan> onFinished)
        {
            return new Disposewatch(onFinished);
        }

        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;

            _watch.Stop();

            _onFinished.SafeInvoke(_watch.Elapsed);
        }
    }
}