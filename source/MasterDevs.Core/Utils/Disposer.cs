using System;

namespace MasterDevs.Core.Utils
{
    public class Disposer : IDisposable
    {
        private readonly Action _onDispose;

        public Disposer(Action onDispose)
        {
            _onDispose = onDispose.RequireNotNull("onDispose");
        }

        public void Dispose()
        {
            _onDispose.SafeInvoke();
        }
    }
}