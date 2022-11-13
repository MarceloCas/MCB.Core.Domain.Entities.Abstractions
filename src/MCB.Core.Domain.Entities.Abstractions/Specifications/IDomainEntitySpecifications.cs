namespace MCB.Core.Domain.Entities.Abstractions.Specifications;

public interface IDomainEntitySpecifications
{
    bool IdShouldRequired(Guid id);
    bool TenantIdShouldRequired(Guid tenantId);

    bool CreatedAtShouldRequired(DateTime createdAt);
    bool CreatedAtShouldValid(DateTime createdAt);

    bool CreatedByShouldRequired(string createdBy);
    bool CreatedByShouldValid(string createdBy);

    bool LastUpdatedAtShouldRequired(DateTime? lastUpdatedAt);
    bool LastUpdatedAtShouldValid(DateTime? lastUpdatedAt, DateTime createdAt);

    bool LastUpdatedByShouldRequired(string lastUpdatedBy);
    bool LastUpdatedByShouldValid(string lastUpdatedBy);

    bool LastSourcePlatformShouldRequired(string lastSourcePlatform);
    bool LastSourcePlatformShouldValid(string lastSourcePlatform);

    bool RegistryVersionShouldRequired(DateTime registryVersion);
    bool RegistryVersionShouldValid(DateTime registryVersion);
}