using MCB.Core.Domain.Entities.Abstractions.ValueObjects;

namespace MCB.Core.Domain.Entities.Abstractions;

public interface IDomainEntity
{
    // Properties
    Guid Id { get; }
    Guid TenantId { get; }
    AuditableInfoValueObject AuditableInfo { get; }
    DateTimeOffset RegistryVersion { get; }
    ValidationInfoValueObject ValidationInfo { get; }
}