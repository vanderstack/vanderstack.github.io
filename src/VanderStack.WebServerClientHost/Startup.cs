using VanderStack.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VanderStack.Shared.Infrastructure.Authentication;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Authorization;
using VanderStack.Shared.Infrastructure.DependencyInjection;

namespace VanderStack.WebServerClientHost
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedDependencies();

            services.AddMvc().AddNewtonsoftJson();
            services.AddServerSideBlazor();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IAuthenticationPlatformSupportService, WebServerAuthenticationPlatformSupportService>();
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            app.UseBlazorFrameworkFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
