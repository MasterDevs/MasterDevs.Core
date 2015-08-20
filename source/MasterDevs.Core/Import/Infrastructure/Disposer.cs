using System;

namespace MasterDevs.Core.Common.Infrastructure
{
    public class Disposer : IDisposable
    {
        private readonly Action _onDispose;

        public Disposer(Action onDispose)
        {
            _onDispose = CodeContract.RequireNotNull(onDispose, "onDispose");
        }

        public void Dispose()
        {
            _onDispose.SafeInvoke();
        }
    }
}