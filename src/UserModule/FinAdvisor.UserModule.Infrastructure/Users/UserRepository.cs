using FinAdvisor.UserModule.Domain.Users;
using FinAdvisor.UserModule.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FinAdvisor.UserModule.Infrastructure.Users;

public class UserRepository(IDbContextFactory<UserModuleDbContext> factory): IUserRepository
{
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Users.ToListAsync();
    }

    public async Task<Guid> CreateUserAsync(User user)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Users.Add(user);

        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Users.Update(user);

        return await context.SaveChangesAsync() > 1;
    }
}