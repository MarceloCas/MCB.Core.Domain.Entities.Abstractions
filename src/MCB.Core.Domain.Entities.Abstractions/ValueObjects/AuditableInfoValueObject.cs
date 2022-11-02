namespace MCB.Core.Domain.Entities.Abstractions.ValueObjects;

public struct AuditableInfoValueObject
{
    // Properties
    public string CreatedBy { get; }
    public DateTimeOffset CreatedAt { get; }
    public string? LastUpdatedBy { get; }
    public DateTimeOffset? LastUpdatedAt { get; }
    public string? LastSourcePlatform { get; }

    // Constructors
    public AuditableInfoValueObject(
        string createdBy,
        DateTimeOffset createdAt,
        string? lastUpdatedBy,
        DateTimeOffset? lastUpdatedAt,
        string lastSourcePlatform
    )
    {
        CreatedBy = createdBy;
        CreatedAt = createdAt;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdatedAt = lastUpdatedAt;
        LastSourcePlatform = lastSourcePlatform;
    }
}