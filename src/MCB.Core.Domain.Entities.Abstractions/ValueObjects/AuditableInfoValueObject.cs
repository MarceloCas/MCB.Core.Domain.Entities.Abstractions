namespace MCB.Core.Domain.Entities.Abstractions.ValueObjects;

public struct AuditableInfoValueObject
{
    // Properties
    public string CreatedBy { get; }
    public DateTime CreatedAt { get; }
    public string? LastUpdatedBy { get; }
    public DateTime? LastUpdatedAt { get; }
    public string LastSourcePlatform { get; }

    // Constructors
    public AuditableInfoValueObject(
        string createdBy,
        DateTime createdAt,
        string? lastUpdatedBy,
        DateTime? lastUpdatedAt,
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