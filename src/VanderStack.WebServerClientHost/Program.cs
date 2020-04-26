using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using VanderStack.Shared.Infrastructure.Exceptions;
using VanderStack.WebServerClientHost.Infrastructure.Exceptions;

namespace VanderStack.WebServerClientHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Logging for Exceptions which occur outside of Blazor
            Log.Logger =
                new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File(
                    Path.Combine(Path.GetTempPath(), $"{nameof(VanderStack)}.log")
                    , rollingInterval: RollingInterval.Day
                    , retainedFileCountLimit: 7
                )
                // TODO: Support logging from client to server
                // https://nblumhardt.com/2019/11/serilog-blazor/
                .CreateLogger()
            ;

            var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);

            using var exceptionManager = new WebServerGlobalExceptionManager(
                new AppDomainUnhandledExceptionLoggingHandler(loggerFactory.CreateLogger<IAppDomainUnhandledExceptionHandler>())
            );

            exceptionManager.Start();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build()
                )
                .UseStartup<Startup>()
                .Build();
    }
}
