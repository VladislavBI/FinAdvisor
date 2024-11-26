namespace FinAdvisor.UserModule.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<Guid> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
}