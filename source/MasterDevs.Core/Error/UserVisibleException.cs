using System;

namespace MasterDevs.Core.Error
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