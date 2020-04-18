using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VanderStack.Shared;
using VanderStack.Shared.Infrastructure.Auth;

namespace VanderStack.WebAssemblyClientHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddMsalAuthentication();
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IAuthenticationPlatformSupportService, WebAssemblyAuthenticationPlatformSupportService>();

            await builder.Build().RunAsync();
        }
    }
}
