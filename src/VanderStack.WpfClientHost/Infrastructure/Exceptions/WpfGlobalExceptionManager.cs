using System;
using System.Threading.Tasks;
using System.Windows;
using VanderStack.Shared.Infrastructure.Exceptions;

namespace VanderStack.WpfClientHost.Infrastructure.Exceptions
{
    public class WpfGlobalExceptionManager : BaseGlobalExceptionManager
    {
        private readonly Application _application;
        private readonly IUnobservedExceptionHandler _unobservedExceptionHandler;
        private readonly IDispatcherUnhandledExceptionHandler _dispatcherUnhandledExceptionHandler;
        private readonly IAppDomainUnhandledExceptionHandler _appDomainUnhandledExceptionHandler;

        public WpfGlobalExceptionManager(
            Application application
            , IUnobservedExceptionHandler unobservedExceptionHandler
            , IDispatcherUnhandledExceptionHandler dispatcherUnhandledExceptionHandler
            , IAppDomainUnhandledExceptionHandler appDomainUnhandledExceptionHandler
        )
        {
            _application = application;
            _unobservedExceptionHandler = unobservedExceptionHandler;
            _dispatcherUnhandledExceptionHandler = dispatcherUnhandledExceptionHandler;
            _appDomainUnhandledExceptionHandler = appDomainUnhandledExceptionHandler;
        }

        public override void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += _appDomainUnhandledExceptionHandler.OnUnhandledException;
            _application.DispatcherUnhandledException += _dispatcherUnhandledExceptionHandler.OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += _unobservedExceptionHandler.OnUnobservedTaskException;
        }

        public override void Stop()
        {
            AppDomain.CurrentDomain.UnhandledException += _appDomainUnhandledExceptionHandler.OnUnhandledException;
            _application.DispatcherUnhandledException -= _dispatcherUnhandledExceptionHandler.OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException -= _unobservedExceptionHandler.OnUnobservedTaskException;
        }
    }
}
