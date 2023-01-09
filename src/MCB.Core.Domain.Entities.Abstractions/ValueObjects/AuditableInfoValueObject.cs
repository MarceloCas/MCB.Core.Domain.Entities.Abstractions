namespace MCB.Core.Domain.Entities.Abstractions.ValueObjects;

public readonly struct AuditableInfoValueObject
{
    // Properties
    public string CreatedBy { get; }
    public DateTime CreatedAt { get; }
    public string? LastUpdatedBy { get; }
    public DateTime? LastUpdatedAt { get; }
    public string LastSourcePlatform { get; }
    public Guid LastCorrelationId { get; }

    // Constructors
    public AuditableInfoValueObject(
        string createdBy,
        DateTime createdAt,
        string? lastUpdatedBy,
        DateTime? lastUpdatedAt,
        string lastSourcePlatform,
        Guid lastCorrelationId
    )
    {
        CreatedBy = createdBy;
        CreatedAt = createdAt;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdatedAt = lastUpdatedAt;
        LastSourcePlatform = lastSourcePlatform;
        LastCorrelationId = lastCorrelationId;
    }
}