using VanderStack.Shared;

namespace VanderStack.WpfClientHost
{
    public class WpfAuthenticationPlatformSupportService : IAuthenticationPlatformSupportService
    {
        public bool IsBrowserAuthenticationEnabled => false;

        public bool IsNativeAuthenticationEnabled => true;

        public bool IsWebServerAuthenticationEnabled => false;
    }
}