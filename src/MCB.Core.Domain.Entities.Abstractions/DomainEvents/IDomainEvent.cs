namespace MCB.Core.Domain.Entities.Abstractions.DomainEvents;

public interface IDomainEvent
{
    Guid Id { get; }
    public Guid TenantId { get; set; }
    DateTime Timestamp { get; }
    string ExecutionUser { get; set; }
    string SourcePlatform { get; set; }
    string DomainEventType { get; }
    IAggregationRoot AggregationRoot { get; }
}