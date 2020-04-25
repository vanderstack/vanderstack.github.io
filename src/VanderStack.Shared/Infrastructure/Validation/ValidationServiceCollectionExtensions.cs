using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VanderStack.Shared.Infrastructure.Validation
{
    public static class ValidationServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Assembly hostAssembly)
        {
            services.AddValidatorsFromAssemblies(new[]
            {
                hostAssembly
                , typeof(ValidationServiceCollectionExtensions).Assembly
            });
            
            return services;
        }
    }
}
