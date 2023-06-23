namespace PasswordValidator;

public class PasswordValidator
{
    public static bool IsInvalid(string password)
    {
        return password.Length < 8;
    }
}