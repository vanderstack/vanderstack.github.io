using VanderStack.Shared;

namespace VanderStack.WebServerClientHost
{
    public class WebServerAuthenticationPlatformSupportService : IAuthenticationPlatformSupportService
    {
        public bool IsBrowserAuthenticationEnabled => false;

        public bool IsNativeAuthenticationEnabled => false;

        public bool IsWebServerAuthenticationEnabled => true;
    }
}
