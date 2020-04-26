using System;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public interface IGlobalExceptionManager : IDisposable
    {
        public void Start();
        public void Stop();
    }
}
