namespace MCB.Core.Domain.Entities.Abstractions.DomainEvents;
public interface IDomainEvent
{
    Guid Id { get; }
    public Guid TenantId { get; }
    DateTime Timestamp { get; }
    string ExecutionUser { get; }
    string SourcePlatform { get; }
    string DomainEventType { get; }
    IAggregationRoot AggregationRoot { get; }
}