using System;

namespace MasterDevs.Lib.Common.Service
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsTraceEnabled { get; }
        bool IsWarnEnabled { get; }
        Type Type { get; set; }
        string Name { get; set; }

        void Debug(string message);
        void Debug(string format, params object[] args);
        void Debug(Exception exception, string format, params object[] args);
        void Debug(Exception exception);
        void Error(string message);
        void Error(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
        void Error(Exception exception);
        void Fatal(string message);
        void Fatal(string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);
        void Fatal(Exception exception);
        void Info(string message);
        void Info(string format, params object[] args);
        void Info(Exception exception, string format, params object[] args);
        void Info(Exception exception);
        void Trace(string message);
        void Trace(string format, params object[] args);
        void Trace(Exception exception, string format, params object[] args);
        void Trace(Exception exception);
        void Warn(string message);
        void Warn(string format, params object[] args);
        void Warn(Exception exception, string format, params object[] args);
        void Warn(Exception exception);
    }

}
