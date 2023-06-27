using System.Runtime.InteropServices.JavaScript;

namespace PasswordValidator;

public class Password
{
    private readonly string password;
    private Password(string password)
    {
        this.password = password;
    }

    public static Password Create(string text)
    {
        if (!TryCreate(text, out _, out var exception))
        {
            throw exception;
        }

        return new Password(text);
    }
    
    public static bool TryCreate(string text, out Password password, out Exception exception)
    {
        password = null!;
        exception = null!;
        if (text.Length < 8)
        {
            exception = new ArgumentException("Password length must be more than 8 characters");
            return false;
        }
        
        if (!text.Any(char.IsUpper))
        {
            exception = new ArgumentException("Password must contains at least an uppercase");
            return false;
        }
        
        if (!text.Any(char.IsLower))
        {
            exception = new ArgumentException("Password must contains at least a lowercase");
            return false;
        }
        
        if (!text.Any(char.IsDigit))
        {
            exception = new ArgumentException("Password must contains at least a number");
            return false;
        }

        return true;
    }
}