using MasterDevs.Core.Import.Service;
using System;

namespace MasterDevs.Core.Common.Service
{
    public class GenericLogger : ALogger
    {
        private readonly Action<LogLevel, string> _log;
        private readonly Action<Exception> _logError;

        public GenericLogger(Action<LogLevel, string> log, Action<Exception> logError)
        {
            _log = log;
            _logError = logError;
        }

        protected override void Log(LogLevel logLevel, Exception exception, string format, object[] args)
        {
            var msg = String.Format(format, args);
            _log.SafeInvoke(logLevel, msg);
            _logError.SafeInvoke(exception);
        }

        protected override void Log(LogLevel logLevel, string message)
        {
            _log.SafeInvoke(logLevel, message);
        }
    }
}