using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        /// Fluent Validation
        /// MediatR
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IServiceCollection AddSharedDependencies(this IServiceCollection services, Assembly hostAssembly = null)
        {
            hostAssembly ??= Assembly.GetCallingAssembly();
            
            services.AddFluentValidation(hostAssembly);
            services.AddMediatR(hostAssembly);

            return services;
        }
    }
}
