using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Neon.CRM.WebApp.Data.Models;
using System.Security.Claims;

namespace Neon.CRM.WebApp.Providers;

public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Agent>
{
    public CustomUserClaimsPrincipalFactory(
        UserManager<Agent> userManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Agent user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("TenantConnectionString", user?.TenantConnectionString ?? string.Empty));
        return identity;
    }
}
