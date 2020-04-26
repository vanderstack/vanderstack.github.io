using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public class UnobservedExceptionHandlerHostedService : IHostedService
    {
        private readonly IUnobservedExceptionHandler _handler;

        public UnobservedExceptionHandlerHostedService(IUnobservedExceptionHandler handler)
        {
            _handler = handler;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            TaskScheduler.UnobservedTaskException += _handler.OnUnobservedTaskException;
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            TaskScheduler.UnobservedTaskException -= _handler.OnUnobservedTaskException;
            return Task.CompletedTask;
        }
    }
}
