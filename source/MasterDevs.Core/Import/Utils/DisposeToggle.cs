using System;

namespace MasterDevs.Core.Common.Utils
{
    public class DisposeToggle : IDisposable
    {
        private readonly bool _initialValue;
        private readonly Action<bool> _toggleFunction;

        public DisposeToggle(Action<bool> toggleFunction, bool initialValue = true)
        {
            _toggleFunction = toggleFunction.RequireNotNull("toggleFunction");
            _initialValue = initialValue;

            _toggleFunction(initialValue);
        }

        public void Dispose()
        {
            _toggleFunction(!_initialValue);
        }
    }
}