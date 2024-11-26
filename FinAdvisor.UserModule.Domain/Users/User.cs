using Ardalis.GuardClauses;
using FinAdvisor.BuildingBlocks.Domain.Models;
using FinAdvisor.UserModule.Domain.Users.Events;

namespace FinAdvisor.UserModule.Domain.Users;

public sealed class User : AggregateRoot
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public static User Create(string name, int age)
    {
        var user = new User
        {
            Name = Guard.Against.NullOrWhiteSpace(name),
            Age = Guard.Against.Negative(age)
        };

        user.AddDomainEvent(new UserCreatedEvent(user));

        return user;
    }
   
}