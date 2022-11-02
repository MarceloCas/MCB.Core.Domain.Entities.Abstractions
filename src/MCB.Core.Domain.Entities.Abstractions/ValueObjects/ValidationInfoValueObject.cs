using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;

namespace MCB.Core.Domain.Entities.Abstractions.ValueObjects;

public struct ValidationInfoValueObject
{
    // Fields
    private readonly List<ValidationMessage> _validationMessageCollection;

    // Properties
    public IEnumerable<ValidationMessage> ValidationMessageCollection => _validationMessageCollection.AsReadOnly();
    public bool HasValidationMessage => _validationMessageCollection.Count > 0;
    public bool HasError => _validationMessageCollection.Any(q => q.ValidationMessageType == ValidationMessageType.Error);
    public bool IsValid => !HasValidationMessage || !HasError;

    // Constructors
    private ValidationInfoValueObject(List<ValidationMessage> validationMessageCollection)
    {
        _validationMessageCollection = validationMessageCollection;
    }
    public ValidationInfoValueObject()
    {
        _validationMessageCollection = new List<ValidationMessage>();
    }

    // Public Methods
    public void AddValidationMessage(ValidationMessageType validationMessageType, string code, string description)
    {
        _validationMessageCollection.Add(
            new ValidationMessage(
                validationMessageType,
                code,
                description
            )
        );
    }
    public void AddInformationValidationMessage(string code, string description) => AddValidationMessage(ValidationMessageType.Information, code, description);
    public void AddWarningValidationMessage(string code, string description) => AddValidationMessage(ValidationMessageType.Warning, code, description);
    public void AddErrorValidationMessage(string code, string description) => AddValidationMessage(ValidationMessageType.Error, code, description);

    public ValidationInfoValueObject Clone()
    {
        return new ValidationInfoValueObject(_validationMessageCollection.ToList());
    }
}