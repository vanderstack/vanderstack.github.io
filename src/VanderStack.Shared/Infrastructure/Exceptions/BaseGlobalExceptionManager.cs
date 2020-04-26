using Serilog;
using System;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public abstract class BaseGlobalExceptionManager : IGlobalExceptionManager
    {
        public abstract void Start();
        public abstract void Stop();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Log.CloseAndFlush();
            }
        }
    }
}
