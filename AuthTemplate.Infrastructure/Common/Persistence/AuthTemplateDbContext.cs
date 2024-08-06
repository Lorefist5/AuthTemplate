using AuthTemplate.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTemplate.Infrastructure.Common.Persistence;

public class AuthTemplateDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AuthTemplateDbContext(DbContextOptions<AuthTemplateDbContext> options) : base(options)
    {
    }
}
