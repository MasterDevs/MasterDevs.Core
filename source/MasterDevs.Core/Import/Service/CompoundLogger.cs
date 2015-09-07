using System;
using System.Linq;

namespace MasterDevs.Core.Common.Service
{
    public class CompoundLogger : ILogger
    {
        private readonly ILogger[] _loggers;
        private Type _type;

        public CompoundLogger(params ILogger[] loggers)
        {
            _loggers = loggers.RequireNotNull("loggers");
            _type = this.GetType();
        }

        public bool IsDebugEnabled
        {
            get { return _loggers.Any(l => l.IsDebugEnabled); }
        }

        public bool IsErrorEnabled
        {
            get { return _loggers.Any(l => l.IsErrorEnabled); }
        }

        public bool IsFatalEnabled
        {
            get { return _loggers.Any(l => l.IsFatalEnabled); }
        }

        public bool IsInfoEnabled
        {
            get { return _loggers.Any(l => l.IsInfoEnabled); }
        }

        public bool IsTraceEnabled
        {
            get { return _loggers.Any(l => l.IsTraceEnabled); }
        }

        public bool IsWarnEnabled
        {
            get { return _loggers.Any(l => l.IsWarnEnabled); }
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

        public void Debug(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Debug(message);
            }
        }

        public void Debug(string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Debug(format, args);
            }
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Debug(exception, format, args);
            }
        }

        public void Debug(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.Debug(exception);
            }
        }

        public void Error(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Error(message);
            }
        }

        public void Error(string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Error(format, args);
            }
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Error(exception, format, args);
            }
        }

        public void Error(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.Error(exception);
            }
        }

        public void Fatal(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Fatal(message);
            }
        }

        public void Fatal(string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Fatal(format, args);
            }
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Fatal(exception, format, args);
            }
        }

        public void Fatal(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.Fatal(exception);
            }
        }

        public void Info(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Info(message);
            }
        }

        public void Info(string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Info(format, args);
            }
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Info(exception, format, args);
            }
        }

        public void Info(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.Info(exception);
            }
        }

        public void Trace(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Trace(message);
            }
        }

        public void Trace(string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Trace(format, args);
            }
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Trace(exception, format, args);
            }
        }

        public void Trace(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.Trace(exception);
            }
        }

        public void Warn(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Warn(message);
            }
        }

        public void Warn(string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Warn(format, args);
            }
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.Warn(exception, format, args);
            }
        }

        public void Warn(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.Warn(exception);
            }
        }
    }
}