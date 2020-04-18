using VanderStack.Shared;

namespace VanderStack.WebServerClientHost
{
    public class WebServerAuthService : IAuthService
    {
        public bool IsBrowserLoginEnabled => false;
    }
}
