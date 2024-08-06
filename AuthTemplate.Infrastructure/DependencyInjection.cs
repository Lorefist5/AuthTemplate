using AuthTemplate.Domain.Entities;
using AuthTemplate.Infrastructure.Common.Persistence;
using AuthTemplate.Infrastructure.Common.Seeders;
using AuthTemplate.Infrastructure.Features.Authorization.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AuthTemplateDbContext>(option => option.UseSqlite(connectionString));
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole<Guid>>()
            .AddClaimsPrincipalFactory<AuthTemplateClaimsFactory>()
            .AddEntityFrameworkStores<AuthTemplateDbContext>();
        return services;
    }
}
