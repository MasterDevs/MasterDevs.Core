using MasterDevs.Core.Common.Infrastructure;
using MasterDevs.Core.System;
using System;
using Debug = System.Diagnostics.Debug;

namespace MasterDevs.Core.Common.Utils
{
    public class Disposewatch : IDisposable
    {
        private const string DEFAULT_Message = @"Finished ";
        private readonly DateTime _startTime = DateTime.Now;
        private readonly string Message;
        private readonly Action<TimeSpan> OnFinished;
        private readonly Action<string> OnFinishedMessage;
        private bool isDisposed = false;

        private Disposewatch(string message, Action<string> onFinishedMessage, Action<TimeSpan> onFinished = null)
        {
            Message = CodeContract.RequireNotNull(message, "message");
            OnFinishedMessage = CodeContract.RequireNotNull(onFinishedMessage, "onFinishedMessage");
            OnFinished = onFinished;
            Duration = TimeSpan.Zero;
        }

        public TimeSpan Duration { get; private set; }

        private static Action<string> DefaultMessageAction
        {
            get { return (Action<string>)((s) => Debug.WriteLine(s)); }
        }

        public static Disposewatch Start(string message = DEFAULT_Message)
        {
            return new Disposewatch(message, DefaultMessageAction);
        }

        public static Disposewatch Start(Action<string> onFinishedMessage, string message = DEFAULT_Message)
        {
            return new Disposewatch(message, onFinishedMessage);
        }

        public static Disposewatch StartTimeSpan(Action<TimeSpan> onFinished)
        {
            return new Disposewatch(DEFAULT_Message, msg => { }, onFinished);
        }

        public void Dispose()
        {
            if (isDisposed) return;
            isDisposed = true;

            var stopTime = DateTime.Now;
            Duration = stopTime - _startTime;

            OnFinished.SafeInvoke(Duration);
            OnFinishedMessage.SafeInvoke(string.Format(@"{0}{1}", Message, Duration));
        }
    }
}