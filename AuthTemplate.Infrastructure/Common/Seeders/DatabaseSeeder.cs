
using AuthTemplate.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthTemplate.Infrastructure.Common.Seeders;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly AuthTemplateDbContext _context;

    public DatabaseSeeder(AuthTemplateDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.MigrateAsync();
    }
}
