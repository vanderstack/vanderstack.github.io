using System;
using System.Collections.Generic;
using System.Text;

namespace VanderStack.Shared
{
    public interface IAuthService
    {
        public bool IsBrowserLoginEnabled { get; }
    }
}
