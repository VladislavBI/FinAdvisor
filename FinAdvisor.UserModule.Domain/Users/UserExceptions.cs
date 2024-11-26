namespace FinAdvisor.UserModule.Domain.Users;

public sealed class UserNotFoundException(Guid id) : Exception($"User with {id} is not found");