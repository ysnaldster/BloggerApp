using System.Text.RegularExpressions;

namespace BlogApplication.Application.Services;

public abstract class DataValidationService
{
    public enum SecurityLevel
    {
        Weak,
        Medium,
        Strong
    }

    public static SecurityLevel PasswordValidate(string password)
    {
        var hasLetters = new Regex(@"[A-Z]+");
        var hasNumbers = new Regex(@"[0-9]+");
        var hasMinimum10Characters = new Regex(@".{10,}");
        var hasSpecialCharacters = new Regex("[!\"·$%&/()=¿¡?'_:;,|@#€*+.]");
        if (password.Length < 6)
        {
            return SecurityLevel.Weak;
        }

        if (hasLetters.IsMatch(password) && hasNumbers.IsMatch(password) && hasMinimum10Characters.IsMatch(password) &&
            hasSpecialCharacters.IsMatch(password))
        {
            return SecurityLevel.Strong;
        }

        if (hasLetters.IsMatch(password) && hasNumbers.IsMatch(password) && hasMinimum10Characters.IsMatch(password))
        {
            return SecurityLevel.Medium;
        }

        return SecurityLevel.Weak;
    }

    public static string RemoveBlanks(string value)
    {
        return Regex.Replace(value, @"\s+", " ").Trim();
    }
}