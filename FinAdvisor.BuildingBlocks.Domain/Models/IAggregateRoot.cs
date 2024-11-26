namespace FinAdvisor.BuildingBlocks.Domain.Models;

public interface IAggregateRoot
{
    List<IDomainEvent> ClearDomainEvents();
    bool ContainsDomainEvents();
}