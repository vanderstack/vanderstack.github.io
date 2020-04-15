namespace VanderStack.AndroidClientHost
{
    // add usings here
    using BlazorWebView;
    using Microsoft.Extensions.DependencyInjection;
    using System.Net.Http;
    using VanderStack.Shared;
    using VanderStack.Shared.Infrastructure.Auth;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddMsalAuthentication();
        }

        /// <summary>
        /// Configure the app.
        /// </summary>
        /// <param name="app">The application builder for apps.</param>
        public void Configure(ApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}