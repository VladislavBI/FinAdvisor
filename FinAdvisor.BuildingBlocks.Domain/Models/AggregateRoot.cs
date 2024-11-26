namespace FinAdvisor.BuildingBlocks.Domain.Models;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public List<IDomainEvent> ClearDomainEvents()
    {
        var dequeuedEvents = _domainEvents.ToList();

        _domainEvents.Clear();

        return dequeuedEvents;
    }

    public bool ContainsDomainEvents()
    {
        return _domainEvents.Any();
    }
}