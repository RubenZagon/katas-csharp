namespace PasswordValidator;

public class PasswordValidator
{
    public static bool IsValid(string password)
    {
        return password.Length < 8 
               && password.Any(char.IsUpper)
               && password.Any(char.IsLower);
    }
}