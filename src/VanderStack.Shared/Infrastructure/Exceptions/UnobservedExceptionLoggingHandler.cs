using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public class UnobservedExceptionLoggingHandler : IUnobservedExceptionHandler
    {
        private readonly ILogger<IUnobservedExceptionHandler> _logger;

        public UnobservedExceptionLoggingHandler(ILogger<IUnobservedExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs eventArgs)
        {
            _logger.LogError(
                new EventId(eventArgs.Exception.HResult)
                , eventArgs.Exception
                , eventArgs.Exception.Message
            );

            eventArgs.SetObserved();
        }
    }
}
