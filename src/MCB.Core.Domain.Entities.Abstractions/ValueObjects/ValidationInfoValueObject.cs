using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;

namespace MCB.Core.Domain.Entities.Abstractions.ValueObjects;

public readonly struct ValidationInfoValueObject
{
    // Fields
    private readonly List<ValidationMessage> _validationMessageCollection;

    // Properties
    public IEnumerable<ValidationMessage> ValidationMessageCollection => _validationMessageCollection.AsReadOnly();
    public IEnumerable<ValidationMessage> InformationValidationMessageCollection => _validationMessageCollection.Where(q => q.ValidationMessageType == ValidationMessageType.Information);
    public IEnumerable<ValidationMessage> WarningValidationMessageCollection => _validationMessageCollection.Where(q => q.ValidationMessageType == ValidationMessageType.Warning);
    public IEnumerable<ValidationMessage> ErrorValidationMessageCollection => _validationMessageCollection.Where(q => q.ValidationMessageType == ValidationMessageType.Error);

    public bool HasValidationMessage => _validationMessageCollection.Any();
    public bool HasInformationMessages => InformationValidationMessageCollection.Any();
    public bool HasWariningMessages => WarningValidationMessageCollection.Any();
    public bool HasErrorMessages => ErrorValidationMessageCollection.Any();
    public bool IsValid => !HasValidationMessage || !HasErrorMessages;

    // Constructors
    private ValidationInfoValueObject(IEnumerable<ValidationMessage> validationMessageCollection)
    {
        _validationMessageCollection = validationMessageCollection.ToList();
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
        return new ValidationInfoValueObject(ValidationMessageCollection);
    }
}