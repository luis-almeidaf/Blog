using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blog.WebUI.Authentication;

public class CustomAuthenticationStateProvider(ILocalStorageService localStorage) : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal _anonymousUser = new(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
                return new AuthenticationState(_anonymousUser);

            var claims = ParseClaimsFromJwt(token);

            var identity = new ClaimsIdentity(claims, "jwt", ClaimTypes.Name, ClaimTypes.Role);
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch
        {
            return new AuthenticationState(_anonymousUser);
        }
    }

    public async Task MarkUserAsAuthenticated(string token)
    {
        await localStorage.SetItemAsync("authToken", token);

        var claims = ParseClaimsFromJwt(token);
        var identity = new ClaimsIdentity(claims, "jwt", ClaimTypes.Name, ClaimTypes.Role);
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        var claims = token.Claims.ToList();

        var nameClaim = claims.FirstOrDefault(c => c.Type == "unique_name");
        if (nameClaim != null && claims.All(c => c.Type != ClaimTypes.Name))
            claims.Add(new Claim(ClaimTypes.Name, nameClaim.Value));

        var roleClaim = claims.FirstOrDefault(c => c.Type == "role");
        if (roleClaim != null && claims.All(c => c.Type != ClaimTypes.Role))
            claims.Add(new Claim(ClaimTypes.Role, roleClaim.Value));

        return claims;
    }
}