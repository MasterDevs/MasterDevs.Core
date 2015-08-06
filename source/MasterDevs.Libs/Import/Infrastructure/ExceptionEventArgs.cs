using System;

namespace MasterDevs.Lib.Common.Infrastructure
{
    public class ExceptionEventArgs : EventArgs
    {
        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; set; }
    }

    public class ExceptionEventArgs<T> : ExceptionEventArgs
    {
        public T Value { get; set; }

        public ExceptionEventArgs(Exception exception, T value)
            : base(exception)
        {
            Value = value;
        }
    }
}
