namespace MCB.Core.Domain.Entities.Abstractions.DomainEvents;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTime Timestamp { get; }
    string DomainEventType { get; }
    IAggregationRoot AggregationRoot { get; }
}