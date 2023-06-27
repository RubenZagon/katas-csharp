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
        PasswordValidator.IsValid("R").Should().BeFalse();
    }
    
    [Fact]
    public void Contains_At_Least_An_Lowercase()
    {
        PasswordValidator.IsValid("r").Should().BeFalse();
    }
}