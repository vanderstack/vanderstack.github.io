using System;
using System.Threading.Tasks;
using VanderStack.Shared.Infrastructure.Exceptions;

namespace VanderStack.AndroidClientHost.Infrastructure.Exceptions
{
    public class AndroidGlobalExceptionManager : BaseGlobalExceptionManager
    {
        private readonly IUnobservedExceptionHandler _unobservedExceptionHandler;
        private readonly IAppDomainUnhandledExceptionHandler _appDomainUnhandledExceptionHandler;

        public AndroidGlobalExceptionManager(
            IUnobservedExceptionHandler unobservedExceptionHandler
            , IAppDomainUnhandledExceptionHandler appDomainUnhandledExceptionHandler
        )
        {
            _unobservedExceptionHandler = unobservedExceptionHandler;
            _appDomainUnhandledExceptionHandler = appDomainUnhandledExceptionHandler;
        }

        public override void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += _appDomainUnhandledExceptionHandler.OnUnhandledException;
            TaskScheduler.UnobservedTaskException += _unobservedExceptionHandler.OnUnobservedTaskException;
        }

        public override void Stop()
        {
            AppDomain.CurrentDomain.UnhandledException += _appDomainUnhandledExceptionHandler.OnUnhandledException;
            TaskScheduler.UnobservedTaskException -= _unobservedExceptionHandler.OnUnobservedTaskException;
        }
    }
}