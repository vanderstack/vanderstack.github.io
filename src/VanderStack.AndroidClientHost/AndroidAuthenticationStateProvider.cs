namespace VanderStack.AndroidClientHost
{
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Security.Claims;
    using System.Threading.Tasks;

    // add usings here
    public class AndroidAuthenticationStateProvider : AuthenticationStateProvider
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

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }
    }
}