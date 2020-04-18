using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using BlazorWebView;
using VanderStack.Shared.Infrastructure.Auth;
using System;
using VanderStack.Shared;
using Microsoft.AspNetCore.Components.Authorization;

namespace VanderStack.WpfClientHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddMsalAuthentication();
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