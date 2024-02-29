using System.Collections.Immutable;
using System.Text;
using FluentValidation;
using MedApplication.Common.Identity.Models;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedDomain.Extentions;
using MedInfrastructure.Common.Identity.Settings;
using Microsoft.Extensions.Options;

namespace MedInfrastructure.Common.Identity;

public class PasswordGeneratorService : IPasswordGeneratorService
{
    public PasswordGeneratorService(
    IOptions<PasswordValidationSettings> passwordValidationSettings,
    IValidator<CredentialDetails> credentialDetailsValidator)
    {
        _passwordValidationSettings = passwordValidationSettings.Value;
        _credentialDetailsValidator = credentialDetailsValidator;
    }
    private IValidator<CredentialDetails> _credentialDetailsValidator { get; set; }
    private readonly PasswordValidationSettings _passwordValidationSettings;
    private readonly Random _random = new();

    private enum PasswordElementType
    {
        Digit = 0,
        Uppercase = 1,
        Lowercase = 2,
        NonAlphanumeric = 3
    }

    public string GeneratePassword()
    {
        var password = new StringBuilder();

        var requiredElements = GetRequiredElements();
        requiredElements.ForEach(element => password.Append(GetPasswordElement(element)));

        while (password.Length < _passwordValidationSettings.MinimumLength)
            password.Append(GetPasswordElement((PasswordElementType)_random.Next(0, requiredElements.Count - 1)));

        var randomizedPassword = password.ToString().ToCharArray();
        //_random.Shuffle(randomizedPassword);
        return new string(randomizedPassword);
    }

    public string GetValidatedPassword(string password, UserModule user)
    {
        var validationContext = new ValidationContext<CredentialDetails>(new CredentialDetails
        {
            Password = password
        })
        {
            RootContextData =
            {
                ["PersonalInformation"] = new[] { user.FullName, user.ShortName, user.EmailAddress }
            }
        };

        var validationResult = _credentialDetailsValidator.Validate(validationContext);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return password;
    }

    private ImmutableList<PasswordElementType> GetRequiredElements()
    {
        var requiredElements = new List<PasswordElementType>();

        if (_passwordValidationSettings.RequireDigit)
            requiredElements.Add(PasswordElementType.Digit);

        if (_passwordValidationSettings.RequireUppercase)
            requiredElements.Add(PasswordElementType.Uppercase);

        if (_passwordValidationSettings.RequireLowercase)
            requiredElements.Add(PasswordElementType.Lowercase);

        if (_passwordValidationSettings.RequireNonAlphanumeric)
            requiredElements.Add(PasswordElementType.NonAlphanumeric);

        return requiredElements.ToImmutableList();
    }

    private char GetPasswordElement(PasswordElementType passwordElementType)
    {
        return passwordElementType switch
        {
            PasswordElementType.Digit => CharExtensions.GetRandomDigit(_random),
            PasswordElementType.Uppercase => CharExtensions.GetRandomUppercase(_random),
            PasswordElementType.Lowercase => CharExtensions.GetRandomLowercase(_random),
            PasswordElementType.NonAlphanumeric => CharExtensions.GetRandomNonAlphanumeric(_random),
            _ => throw new ArgumentOutOfRangeException(nameof(passwordElementType), passwordElementType, null)
        };
    }
}