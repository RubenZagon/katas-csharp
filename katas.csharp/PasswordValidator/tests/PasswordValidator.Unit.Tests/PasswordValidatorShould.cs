namespace PasswordValidator.Unit.Tests;

public class PasswordValidatorShould
{
    
    [Fact]
    public void Be_Valid()
    {
        PasswordValidator.IsValid("Abc1234_").Should().BeTrue();
    }
    
    [Fact]
    public void Have_More_Than_8_Characters()
    {
        PasswordValidator.IsValid("12345678").Should().BeFalse();
    }
    
    [Fact]
    public void Contains_At_Least_An_Uppercase()
    {
        PasswordValidator.IsValid("CONTAINS_UPPERCASE_HERE").Should().BeFalse();
    }
    
    [Fact]
    public void Contains_At_Least_A_Lowercase()
    {
        PasswordValidator.IsValid("contains_lowercase_here").Should().BeFalse();
    }
    
    
    [Fact]
    public void Contains_At_Least_A_Number()
    {
        PasswordValidator.IsValid("1").Should().BeFalse();
    }
    
    [Fact]
    public void Contains_At_Least_An_Underscore()
    {
        PasswordValidator.IsValid("_").Should().BeFalse();
    }
}