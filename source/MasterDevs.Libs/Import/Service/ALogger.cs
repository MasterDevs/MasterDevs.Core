using MasterDevs.Lib.Import.Service;
using System;

namespace MasterDevs.Lib.Common.Service
{
    public abstract class ALogger : ILogger
    {
        private readonly LogLevel _logLevel;
        private Type _type;

        protected ALogger()
            : this(LogLevel.Debug) { }

        protected ALogger(LogLevel logLevel)
        {
            _logLevel = logLevel;
            _type = this.GetType();
        }

        public bool IsDebugEnabled
        {
            get { return (int)_logLevel <= (int)LogLevel.Debug; }
        }

        public bool IsErrorEnabled
        {
            get { return (int)_logLevel <= (int)LogLevel.Error; }
        }

        public bool IsFatalEnabled
        {
            get { return (int)_logLevel <= (int)LogLevel.Fatal; }
        }

        public bool IsInfoEnabled
        {
            get { return (int)_logLevel <= (int)LogLevel.Info; }
        }

        public bool IsTraceEnabled
        {
            get { return (int)_logLevel <= (int)LogLevel.Trace; }
        }

        public bool IsWarnEnabled
        {
            get { return (int)_logLevel <= (int)LogLevel.Warn; }
        }

        public string Name
        {
            get;
            set;
        }

        public Type Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                if (null == _type)
                {
                    Name = null;
                }
                else
                {
                    Name = _type.Name;
                }
            }
        }

        public virtual void Debug(string message)
        {
            if (!IsDebugEnabled) return;
            Log(LogLevel.Debug, message);
        }

        public void Debug(string format, params object[] args)
        {
            if (!IsDebugEnabled) return;
            Log(LogLevel.Debug, format, args);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            if (!IsDebugEnabled) return;
            Log(LogLevel.Debug, exception, format, args);
        }

        public void Debug(Exception exception)
        {
            if (!IsDebugEnabled) return;
            Log(LogLevel.Debug, exception, string.Empty, new object[0]);
        }

        public void Error(string message)
        {
            if (!IsErrorEnabled) return;
            Log(LogLevel.Error, message);
        }

        public void Error(string format, params object[] args)
        {
            if (!IsErrorEnabled) return;
            Log(LogLevel.Error, format, args);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            if (!IsErrorEnabled) return;
            Log(LogLevel.Error, exception, format, args);
        }

        public void Error(Exception exception)
        {
            if (!IsErrorEnabled) return;
            Log(LogLevel.Error, exception, string.Empty, new object[0]);
        }

        public void Fatal(string message)
        {
            if (!IsFatalEnabled) return;
            Log(LogLevel.Fatal, message);
        }

        public void Fatal(string format, params object[] args)
        {
            if (!IsFatalEnabled) return;
            Log(LogLevel.Fatal, format, args);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!IsFatalEnabled) return;
            Log(LogLevel.Fatal, exception, format, args);
        }

        public void Fatal(Exception exception)
        {
            if (!IsFatalEnabled) return;
            Log(LogLevel.Fatal, exception, string.Empty, new object[0]);
        }

        public void Info(string message)
        {
            if (!IsInfoEnabled) return;
            Log(LogLevel.Info, message);
        }

        public void Info(string format, params object[] args)
        {
            if (!IsInfoEnabled) return;
            Log(LogLevel.Info, format, args);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            if (!IsInfoEnabled) return;
            Log(LogLevel.Info, exception, format, args);
        }

        public void Info(Exception exception)
        {
            if (!IsInfoEnabled) return;
            Log(LogLevel.Info, exception, string.Empty, new object[0]);
        }

        public void Trace(string message)
        {
            if (!IsTraceEnabled) return;
            Log(LogLevel.Trace, message);
        }

        public void Trace(string format, params object[] args)
        {
            if (!IsTraceEnabled) return;
            Log(LogLevel.Trace, format, args);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            if (!IsTraceEnabled) return;
            Log(LogLevel.Trace, exception, format, args);
        }

        public void Trace(Exception exception)
        {
            if (!IsTraceEnabled) return;
            Log(LogLevel.Trace, exception, string.Empty, new object[0]);
        }

        public void Warn(string message)
        {
            if (!IsWarnEnabled) return;
            Log(LogLevel.Warn, message);
        }

        public void Warn(string format, params object[] args)
        {
            if (!IsWarnEnabled) return;
            Log(LogLevel.Warn, format, args);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            if (!IsWarnEnabled) return;
            Log(LogLevel.Warn, exception, format, args);
        }

        public void Warn(Exception exception)
        {
            if (!IsWarnEnabled) return;
            Log(LogLevel.Warn, exception, string.Empty, new object[0]);
        }

        protected abstract void Log(LogLevel logLevel, Exception exception, string format, object[] args);

        protected abstract void Log(LogLevel logLevel, string message);

        protected void Log(LogLevel logLevel, string format, object[] args)
        {
            Log(logLevel, String.Format(format, args));
        }
    }
}