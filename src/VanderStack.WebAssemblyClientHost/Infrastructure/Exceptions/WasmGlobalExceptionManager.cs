using Serilog;
using System;
using VanderStack.Shared.Infrastructure.Exceptions;

namespace VanderStack.WebAssemblyClientHost.Infrastructure.Exceptions
{
    public class WasmGlobalExceptionManager : BaseGlobalExceptionManager
    {
        private IAppDomainUnhandledExceptionHandler _appDomainUnhandledExceptionHandler;

        public WasmGlobalExceptionManager(IAppDomainUnhandledExceptionHandler appDomainUnhandledExceptionHandler)
        {
            _appDomainUnhandledExceptionHandler = appDomainUnhandledExceptionHandler;
        }

        public override void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += _appDomainUnhandledExceptionHandler.OnUnhandledException;
        }

        public override void Stop()
        {
            AppDomain.CurrentDomain.UnhandledException += _appDomainUnhandledExceptionHandler.OnUnhandledException;
        }
    }
}
