using System.Threading.Tasks;

namespace VanderStack.Shared.Infrastructure.Exceptions
{
    public interface IUnobservedExceptionHandler
    {
        public void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs eventArgs);
    }
}
