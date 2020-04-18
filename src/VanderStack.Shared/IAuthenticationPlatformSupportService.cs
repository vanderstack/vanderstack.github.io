using System;
using System.Collections.Generic;
using System.Text;

namespace VanderStack.Shared
{
    public interface IAuthenticationPlatformSupportService
    {
        public bool IsBrowserAuthenticationEnabled { get; }

        public bool IsNativeAuthenticationEnabled { get; }

        public bool IsWebServerAuthenticationEnabled { get; }
    }
}
