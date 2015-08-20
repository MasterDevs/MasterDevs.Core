using System;
using MasterDevs.Core.Common.Infrastructure;

namespace MasterDevs.Core.Common.Utils
{
    public class DisposeToggle : IDisposable
    {
        private readonly Action<bool> _toggleFunction;
        private readonly bool _initialValue;

        public DisposeToggle(Action<bool> toggleFunction, bool initialValue = true)
        {
            _toggleFunction = CodeContract.RequireNotNull(toggleFunction, "toggleFunction");
            _initialValue = initialValue;

            _toggleFunction(initialValue);
        }

        public void Dispose()
        {
            _toggleFunction(!_initialValue);
        }
    }
}
