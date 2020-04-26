using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace VanderStack.WpfClientHost.Infrastructure.Exceptions
{
    public class DispatcherUnhandledExceptionLoggingHandler : IDispatcherUnhandledExceptionHandler
    {
        private readonly ILogger<IDispatcherUnhandledExceptionHandler> _logger;

        public DispatcherUnhandledExceptionLoggingHandler(ILogger<IDispatcherUnhandledExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
        {
            _logger.LogError(
                new EventId(eventArgs.Exception.HResult)
                , eventArgs.Exception
                , eventArgs.Exception.Message
            );

            eventArgs.Handled = true;
        }
    }
}
