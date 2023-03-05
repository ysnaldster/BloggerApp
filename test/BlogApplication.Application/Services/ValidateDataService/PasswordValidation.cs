using BlogApplication.Application.Services;
using FluentAssertions;
using tests.Utils;

namespace tests.BlogApplication.Application.Services.ValidateDataService;

public class PasswordValidation : DataValidationService
{
    /// <summary>
    /// CheckPasswordWhenGetAWeakSetup
    /// </summary>
    [Fact]
    public void ValidatePasswordServiceUsingFiveCharactersShouldReturnWeakSetup()
    {
        var passwordToValidate = PasswordSetup.PasswordToValidate[0];
        var result = PasswordValidate(passwordToValidate);
        result.Should().Be(SecurityLevel.Weak);
    }

    /// <summary>
    /// CheckPasswordWhetUsingOnlyLetterToGetWeakSetup
    /// </summary>
    [Fact]
    public void ValidatePasswordServiceOnlyLettersShouldReturnWeakSetup()
    {
        var passwordToValidate = PasswordSetup.PasswordToValidate[1];
        var result = PasswordValidate(passwordToValidate);
        result.Should().Be(SecurityLevel.Weak);
    }

    /// <summary>
    /// CheckPasswordWhetGetAMediumSetup
    /// </summary>
    [Fact]
    public void ValidatePasswordServiceUsingLettersAndNumbersShouldReturnMediumSetup()
    {
        var passwordToValidate = PasswordSetup.PasswordToValidate[2];
        var result = PasswordValidate(passwordToValidate);
        result.Should().Be(SecurityLevel.Medium);
    }

    /// <summary>
    /// CheckPasswordWhetGetAStrongSetup
    /// </summary>
    [Fact]
    public void ValidatePasswordServiceUsingMoreThanTenCharactersLettersAndNumbersShouldReturnStrongSetup()
    {
        var passwordToValidate = PasswordSetup.PasswordToValidate[3];
        var result = PasswordValidate(passwordToValidate);
        result.Should().Be(SecurityLevel.Strong);
    }
}