namespace MCB.Core.Domain.Entities.Abstractions.Specifications;

public interface IDomainEntitySpecifications
{
    bool IdShouldRequired(Guid id);
    bool TenantIdShouldRequired(Guid tenantId);

    bool CreatedAtShouldRequired(DateTimeOffset createdAt);
    bool CreatedAtShouldValid(DateTimeOffset createdAt);

    bool CreatedByShouldRequired(string createdBy);
    bool CreatedByShouldValid(string createdBy);

    bool LastUpdatedAtShouldRequired(DateTimeOffset? lastUpdatedAt);
    bool LastUpdatedAtShouldValid(DateTimeOffset? lastUpdatedAt, DateTimeOffset createdAt);

    bool LastUpdatedByShouldRequired(string lastUpdatedBy);
    bool LastUpdatedByShouldValid(string lastUpdatedBy);

    bool LastSourcePlatformShouldRequired(string lastSourcePlatform);
    bool LastSourcePlatformShouldValid(string lastSourcePlatform);

    bool RegistryVersionShouldRequired(DateTimeOffset registryVersion);
    bool RegistryVersionShouldValid(DateTimeOffset registryVersion);
}