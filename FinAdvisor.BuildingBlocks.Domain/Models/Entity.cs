namespace FinAdvisor.BuildingBlocks.Domain.Models;

public class Entity
{
    public Guid Id { get; init; } 
        = Guid.NewGuid();
}