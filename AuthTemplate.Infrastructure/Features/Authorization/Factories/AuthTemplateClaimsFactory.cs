using AuthTemplate.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AuthTemplate.Infrastructure.Features.Authorization.Factories;

public class AuthTemplateClaimsFactory : UserClaimsPrincipalFactory<User, IdentityRole<Guid>>
{
    public AuthTemplateClaimsFactory(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
    }

    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var principal = await base.CreateAsync(user);

        // you can add custom claims here
        // principal.AddClaim(new Claim("custom-claim", "value"));
        //
        return new ClaimsPrincipal(principal);
    }
}
