using MasterDevs.Lib.Import.Service;
using System;

namespace MasterDevs.Lib.Common.Service
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
