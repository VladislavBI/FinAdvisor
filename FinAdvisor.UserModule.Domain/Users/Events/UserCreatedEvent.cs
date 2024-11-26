using FinAdvisor.BuildingBlocks.Domain.Models;

namespace FinAdvisor.UserModule.Domain.Users.Events;

public record UserCreatedEvent(User User) : IDomainEvent;