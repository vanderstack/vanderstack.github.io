using VanderStack.Shared;

namespace VanderStack.WebAssemblyClientHost
{
    public class WebAssemblyAuthenticationPlatformSupportService : IAuthenticationPlatformSupportService
    {
        public bool IsBrowserAuthenticationEnabled => true;

        public bool IsNativeAuthenticationEnabled => false;

        public bool IsWebServerAuthenticationEnabled => false;
    }
}
