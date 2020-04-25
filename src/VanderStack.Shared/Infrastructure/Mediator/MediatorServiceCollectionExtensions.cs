using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VanderStack.Shared.Infrastructure.Mediator
{
    public static class MediatorServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services, Assembly hostAssembly)
        {
            services.AddMediatR(new[]
            {
                hostAssembly
                , typeof(MediatorServiceCollectionExtensions).Assembly
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            return services;
        }
    }
}
