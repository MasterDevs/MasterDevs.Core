using System;

namespace MasterDevs.Lib.Common.Error
{
    public class UserVisibleException : Exception
    {
        public UserVisibleException()
            : base()
        {
        }

        public UserVisibleException(string message)
            : base(message)
        {
        }

        public UserVisibleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}