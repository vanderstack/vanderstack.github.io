namespace VanderStack.AndroidClientHost
{
    // add usings here
    using VanderStack.Shared;

    public class AndroidAuthenticationPlatformSupportService : IAuthenticationPlatformSupportService
    {
        public bool IsBrowserAuthenticationEnabled => false;

        public bool IsNativeAuthenticationEnabled => true;

        public bool IsWebServerAuthenticationEnabled => false;
    }
}