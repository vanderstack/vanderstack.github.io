using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using BlazorWebView;
using VanderStack.Shared.Infrastructure.Authentication;
using VanderStack.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using VanderStack.Shared.Infrastructure.DependencyInjection;

namespace VanderStack.WpfClientHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedDependencies();
            services.AddScoped<HttpClient>();
            services.AddScoped<IAuthenticationPlatformSupportService, WpfAuthenticationPlatformSupportService>();
            services.AddScoped<AuthenticationStateProvider, WpfAuthenticationStateProvider>();
        }

        /// <summary>
        /// Configure the app.
        /// </summary>
        /// <param name="app">The application builder for apps.</param>
        public void Configure(ApplicationBuilder app)
        {
            app.AddComponent<Shared.App>("app");
        }
    }
}