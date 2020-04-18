using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VanderStack.WpfClientHost
{
    public class WpfAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var uri = new Uri(_httpClient.BaseAddress, "/subdir/api/User");
            //var data = await _httpClient.GetJsonAsync<ClientSideAuthenticationStateData>(uri.AbsoluteUri);
            //ClaimsIdentity identity;
            //if (data.IsAuthenticated)
            //{
            //    var claims = new[] { new Claim(ClaimTypes.Name, data.UserName) }
            //        .Concat(data.ExposedClaims.Select(c => new Claim(c.Type, c.Value)));
            //    identity = new ClaimsIdentity(claims, "Server authentication");
            //}
            //else
            //{
            //    identity = new ClaimsIdentity();
            //}

            //var claims = new[] { new Claim(ClaimTypes.Name, "Test UserName") };
            //var identity = new ClaimsIdentity(claims, "Server authentication");

            //return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }
    }
}