using MasterDevs.Core.Import.Service;
using System;

namespace MasterDevs.Core.Common.Service
{
    public class NullLogger : ALogger
    {
        protected override void Log(LogLevel logLevel, Exception exception, string format, object[] args)
        {
            return;
        }

        protected override void Log(LogLevel logLevel, string message)
        {
            return;
        }
    }
}
