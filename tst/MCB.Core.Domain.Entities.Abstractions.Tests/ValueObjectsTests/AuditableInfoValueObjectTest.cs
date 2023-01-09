using MCB.Core.Domain.Entities.Abstractions.ValueObjects;
using System;
using Xunit;
using FluentAssertions;

namespace MCB.Core.Domain.Entities.Abstractions.Tests.ValueObjectsTests;

public class AuditableInfoValueObjectTest
{
    [Fact]
    public void AuditableInfoValueObject_Should_Be_Created_With_CreationInfo()
    {
        // Arrange
        var createdBy = "marcelo.castelo@outlook.com";
        var createdAt = DateTime.UtcNow;
        var sourcePlatform = "AppDemo";
        var lastCorrelationId = Guid.NewGuid();

        // Act
        var auditableInfoValueObject = new AuditableInfoValueObject(
            createdBy,
            createdAt,
            lastUpdatedBy: null,
            lastUpdatedAt: null,
            sourcePlatform,
            lastCorrelationId
        );

        // Assert
        auditableInfoValueObject.CreatedBy.Should().Be(createdBy);
        auditableInfoValueObject.CreatedAt.Should().Be(createdAt);
        auditableInfoValueObject.LastUpdatedBy.Should().BeNull();
        auditableInfoValueObject.LastUpdatedAt.Should().BeNull();
        auditableInfoValueObject.LastSourcePlatform.Should().Be(sourcePlatform);
        auditableInfoValueObject.LastCorrelationId.Should().Be(lastCorrelationId);
    }

    [Fact]
    public void AuditableInfoValueObject_Should_Be_Created_With_UpdateInfo()
    {
        // Arrange
        var createdBy = "marcelo.castelo@outlook.com";
        var createdAt = DateTime.UtcNow.AddDays(-1);
        var updatedBy = "marcelo.castelo@github.com";
        var updatedAt = DateTime.UtcNow;
        var sourcePlatform = "AppDemo";
        var lastCorrelationId = Guid.NewGuid();

        // Act
        var auditableInfoValueObject = new AuditableInfoValueObject(
            createdBy,
            createdAt,
            updatedBy,
            updatedAt,
            sourcePlatform, 
            lastCorrelationId
        );

        // Assert
        auditableInfoValueObject.CreatedBy.Should().Be(createdBy);
        auditableInfoValueObject.CreatedAt.Should().Be(createdAt);
        auditableInfoValueObject.LastUpdatedBy.Should().Be(updatedBy);
        auditableInfoValueObject.LastUpdatedAt.Should().Be(updatedAt);
        auditableInfoValueObject.LastSourcePlatform.Should().Be(sourcePlatform);
        auditableInfoValueObject.LastCorrelationId.Should().Be(lastCorrelationId);
    }
}