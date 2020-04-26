using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanderStack.Shared.Infrastructure.Exceptions;

namespace VanderStack.WebServerClientHost.Infrastructure.Exceptions
{
    public class WebServerGlobalExceptionManager : BaseGlobalExceptionManager
    {
        private readonly IAppDomainUnhandledExceptionHandler _appDomainUnhandledExceptionHandler;

        public WebServerGlobalExceptionManager(IAppDomainUnhandledExceptionHandler appDomainUnhandledExceptionHandler)
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
