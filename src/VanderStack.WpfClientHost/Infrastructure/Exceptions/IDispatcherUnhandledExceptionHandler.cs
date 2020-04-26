using System.Windows.Threading;

namespace VanderStack.WpfClientHost.Infrastructure.Exceptions
{
    public interface IDispatcherUnhandledExceptionHandler
    {
        public void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs);
    }
}
