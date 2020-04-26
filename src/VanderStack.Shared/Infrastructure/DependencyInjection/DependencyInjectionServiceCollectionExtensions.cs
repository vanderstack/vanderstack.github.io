using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;
using System.Runtime.CompilerServices;
using VanderStack.Shared.Infrastructure.Authentication;
using VanderStack.Shared.Infrastructure.Exceptions;
using VanderStack.Shared.Infrastructure.Mediator;
using VanderStack.Shared.Infrastructure.Validation;

namespace VanderStack.Shared.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionServiceCollectionExtensions
    {
        /// <summary>
        /// Adds dependencies that are shared regardless of the hosting model
        /// </summary>
        /// <param name="hostAssembly">The client host assembly. The calling assembly will be used when no value is provided.</param>
        /// <remarks>
        /// Configures the following services:
        /// Logging to Existing Global Serilog
        /// UnobservedExceptionHandler
        /// MSAL Authentication
        /// Fluent Validation
        /// MediatR
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IServiceCollection AddSharedDependencies(this IServiceCollection services, Assembly hostAssembly = null)
        {
            hostAssembly ??= Assembly.GetCallingAssembly();

            services
                .AddLogging(builder => builder.AddSerilog())
                .AddUnobservedExceptionHandling()
                .AddMsalAuthentication()
                .AddFluentValidation(hostAssembly)
                .AddMediatR(hostAssembly)
            ;
            
            return services;
        }

        private static IServiceCollection AddUnobservedExceptionHandling(this IServiceCollection services)
        {
            services
                .AddSingleton<IUnobservedExceptionHandler, UnobservedExceptionLoggingHandler>()
                .AddHostedService<UnobservedExceptionHandlerHostedService>()
            ;

            return services;
        }
    }
}
