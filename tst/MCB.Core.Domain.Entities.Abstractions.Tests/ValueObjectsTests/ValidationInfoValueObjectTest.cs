using FluentAssertions;
using MCB.Core.Domain.Entities.Abstractions.ValueObjects;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using System.Linq;
using Xunit;

namespace MCB.Core.Domain.Entities.Abstractions.Tests.ValueObjectsTests;

public class ValidationInfoValueObjectTest
{
    [Fact]
    public void ValidationInfoValueObject_Should_Constructed_Correcly()
    {
        // Arrange and Act
        var validationInfoValueObject = new ValidationInfoValueObject();

        // Assert
        validationInfoValueObject.ValidationMessageCollection.Should().NotBeNull();
        validationInfoValueObject.ValidationMessageCollection.Should().HaveCount(0);
        validationInfoValueObject.HasValidationMessage.Should().BeFalse();
        validationInfoValueObject.HasError.Should().BeFalse();
        validationInfoValueObject.IsValid.Should().BeTrue();
    }

    [Fact]
    public void ValidationInfoValueObject_Should_Be_Valid()
    {
        // Arrange
        var validationInfoValueObject = new ValidationInfoValueObject();

        // Act
        validationInfoValueObject.AddInformationValidationMessage("INFO_1", "INFORMATION");
        validationInfoValueObject.AddWarningValidationMessage("WARN_1", "WARNING");

        // Assert
        validationInfoValueObject.ValidationMessageCollection.Should().NotBeNull();
        validationInfoValueObject.ValidationMessageCollection.Should().HaveCount(2);
        validationInfoValueObject.HasValidationMessage.Should().BeTrue();
        validationInfoValueObject.HasError.Should().BeFalse();
        validationInfoValueObject.IsValid.Should().BeTrue();

        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].ValidationMessageType.Should().Be(ValidationMessageType.Information);
        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].Code.Should().Be("INFO_1");
        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].Description.Should().Be("INFORMATION");

        validationInfoValueObject.ValidationMessageCollection.ToArray()[1].ValidationMessageType.Should().Be(ValidationMessageType.Warning);
        validationInfoValueObject.ValidationMessageCollection.ToArray()[1].Code.Should().Be("WARN_1");
        validationInfoValueObject.ValidationMessageCollection.ToArray()[1].Description.Should().Be("WARNING");
    }

    [Fact]
    public void ValidationInfoValueObject_Should_Be_Invalid()
    {
        // Arrange
        var validationInfoValueObject = new ValidationInfoValueObject();

        // Act
        validationInfoValueObject.AddInformationValidationMessage("INFO_1", "INFORMATION");
        validationInfoValueObject.AddWarningValidationMessage("WARN_1", "WARNING");
        validationInfoValueObject.AddErrorValidationMessage("ERROR_1", "ERROR");

        // Assert
        validationInfoValueObject.ValidationMessageCollection.Should().NotBeNull();
        validationInfoValueObject.ValidationMessageCollection.Should().HaveCount(3);
        validationInfoValueObject.HasValidationMessage.Should().BeTrue();
        validationInfoValueObject.HasError.Should().BeTrue();
        validationInfoValueObject.IsValid.Should().BeFalse();

        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].ValidationMessageType.Should().Be(ValidationMessageType.Information);
        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].Code.Should().Be("INFO_1");
        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].Description.Should().Be("INFORMATION");

        validationInfoValueObject.ValidationMessageCollection.ToArray()[1].ValidationMessageType.Should().Be(ValidationMessageType.Warning);
        validationInfoValueObject.ValidationMessageCollection.ToArray()[1].Code.Should().Be("WARN_1");
        validationInfoValueObject.ValidationMessageCollection.ToArray()[1].Description.Should().Be("WARNING");

        validationInfoValueObject.ValidationMessageCollection.ToArray()[2].ValidationMessageType.Should().Be(ValidationMessageType.Error);
        validationInfoValueObject.ValidationMessageCollection.ToArray()[2].Code.Should().Be("ERROR_1");
        validationInfoValueObject.ValidationMessageCollection.ToArray()[2].Description.Should().Be("ERROR");
    }

    [Fact]
    public void ValidationInfoValueObject_Should_Be_Cloned()
    {
        // Arrange
        var validationInfoValueObject = new ValidationInfoValueObject();
        validationInfoValueObject.AddInformationValidationMessage("INFO_1", "INFORMATION");

        // Act
        var clone = (ValidationInfoValueObject)validationInfoValueObject.Clone();
        clone.AddWarningValidationMessage("WARN_1", "WARNING");

        // Assert
        validationInfoValueObject.ValidationMessageCollection.Should().NotBeNull();
        validationInfoValueObject.ValidationMessageCollection.Should().HaveCount(1);
        validationInfoValueObject.HasValidationMessage.Should().BeTrue();
        validationInfoValueObject.HasError.Should().BeFalse();
        validationInfoValueObject.IsValid.Should().BeTrue();

        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].ValidationMessageType.Should().Be(ValidationMessageType.Information);
        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].Code.Should().Be("INFO_1");
        validationInfoValueObject.ValidationMessageCollection.ToArray()[0].Description.Should().Be("INFORMATION");

        clone.ValidationMessageCollection.Should().NotBeNull();
        clone.ValidationMessageCollection.Should().HaveCount(2);
        clone.HasValidationMessage.Should().BeTrue();
        clone.HasError.Should().BeFalse();
        clone.IsValid.Should().BeTrue();

        clone.ValidationMessageCollection.ToArray()[0].ValidationMessageType.Should().Be(ValidationMessageType.Information);
        clone.ValidationMessageCollection.ToArray()[0].Code.Should().Be("INFO_1");
        clone.ValidationMessageCollection.ToArray()[0].Description.Should().Be("INFORMATION");

        clone.ValidationMessageCollection.ToArray()[1].ValidationMessageType.Should().Be(ValidationMessageType.Warning);
        clone.ValidationMessageCollection.ToArray()[1].Code.Should().Be("WARN_1");
        clone.ValidationMessageCollection.ToArray()[1].Description.Should().Be("WARNING");
    }
}