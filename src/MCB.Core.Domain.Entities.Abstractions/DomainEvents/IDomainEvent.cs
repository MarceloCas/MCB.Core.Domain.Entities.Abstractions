namespace MCB.Core.Domain.Entities.Abstractions.DomainEvents;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTimeOffset Timestamp { get; }
    string DomainEventType { get; }
    IAggregationRoot AggregationRoot { get; }
}