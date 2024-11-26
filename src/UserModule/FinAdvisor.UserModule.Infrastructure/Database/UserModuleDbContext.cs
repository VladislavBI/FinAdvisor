using FinAdvisor.UserModule.Domain.Users;
using FinAdvisor.UserModule.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace FinAdvisor.UserModule.Infrastructure.Database;

public class UserModuleDbContext(DbContextOptions<UserModuleDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}