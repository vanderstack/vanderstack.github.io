using System;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public interface IAppDomainUnhandledExceptionHandler
    {
        public void OnUnhandledException(object sender, UnhandledExceptionEventArgs eventArgs);
    }
}
