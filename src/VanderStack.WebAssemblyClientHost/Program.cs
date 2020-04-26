using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using VanderStack.Shared;
using VanderStack.Shared.Infrastructure.DependencyInjection;

namespace VanderStack.WebAssemblyClientHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // TODO: Log from WASM to Http.
            // Errors are already been displayed in browser console.

            //// Configure Logging for Exceptions which occur outside of Blazor
            //Log.Logger =
            //    new LoggerConfiguration()
            //    .MinimumLevel.Verbose()
            //    .Enrich.WithMachineName()
            //    .Enrich.FromLogContext()
            //    .WriteTo.Debug()
            //    // TODO: Support logging to WebServer
            //    //.WriteTo.File(
            //    //    Path.Combine(Path.GetTempPath(), $"{nameof(VanderStack)}.log")
            //    //    , rollingInterval: RollingInterval.Day
            //    //    , retainedFileCountLimit: 7
            //    //)
            //    // TODO: Support Browser Console
            //    // This may only be required to support structured logging as log messages are otherwise showing in console
            //    //.WriteTo.BrowserConsole(jsRuntime)
            //    .CreateLogger()
            //;

            //var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);

            //using var exceptionManager = new WasmGlobalExceptionManager(
            //    new AppDomainUnhandledExceptionLoggingHandler(loggerFactory.CreateLogger<IAppDomainUnhandledExceptionHandler>())
            //);

            //exceptionManager.Start();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.Logging.AddSerilog();

            builder.RootComponents.Add<App>("app");

            builder.Services.AddSharedDependencies();
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IAuthenticationPlatformSupportService, WebAssemblyAuthenticationPlatformSupportService>();

            await builder.Build().RunAsync();
        }
    }
}
