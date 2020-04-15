using Microsoft.Extensions.DependencyInjection;

namespace VanderStack.Shared.Infrastructure.Auth
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMsalAuthentication(this IServiceCollection services)
        {
            services.AddMsalAuthentication(options =>
            {
                var providerOptions = options.ProviderOptions.Authentication;
                providerOptions.Authority = "https://vanderstack.b2clogin.com/vanderstack.onmicrosoft.com/B2C_1_randomreadersignupandsigninpwa";
                providerOptions.ClientId = "81b7552b-3fe2-4e08-b381-055fe203df21";
                providerOptions.ValidateAuthority = false;
            });
        }
    }
}
