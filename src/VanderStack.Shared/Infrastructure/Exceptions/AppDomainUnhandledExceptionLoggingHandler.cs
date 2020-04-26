using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public class AppDomainUnhandledExceptionLoggingHandler : IAppDomainUnhandledExceptionHandler
    {
        private readonly ILogger<IAppDomainUnhandledExceptionHandler> _logger;

        public AppDomainUnhandledExceptionLoggingHandler(ILogger<IAppDomainUnhandledExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnUnhandledException(object sender, UnhandledExceptionEventArgs eventArgs)
        {
            if (eventArgs.IsTerminating)
            {
                _logger.LogDebug($"An {nameof(AppDomain.CurrentDomain.UnhandledException)} occurred while terminating.");
            }

            if (eventArgs.ExceptionObject is Exception exception)
            {
                _logger.LogError(
                    new EventId(exception.HResult)
                    , exception
                    , exception.Message
                );
            }
            else
            {
                _logger.LogError($"An {nameof(AppDomain.CurrentDomain.UnhandledException)} which could not be cast to type {nameof(Exception)} occurred: {{error}}", eventArgs.ExceptionObject);
            }
        }
    }
}
