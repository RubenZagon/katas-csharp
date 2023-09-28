namespace PasswordValidator.Unit.Tests;

public class PasswordShould
{
    [Fact]
    public void Be_Valid()
    {
        Password.TryCreate("Abc1234_", out _, out _).Should().BeTrue();
    }
    
    [Fact]
    public void Fail_When_Have_Less_Than_8_Characters()
    {
        Password.TryCreate("1234567", out _, out var exception).Should().BeFalse();
        exception.Should().BeOfType(typeof(ArgumentException));
        exception.Message.Should().Be("Password length must be more than 8 characters");
    }
    
    [Fact]
    public void Fail_When_Not_Contains_At_Least_An_Uppercase()
    {
        Password.TryCreate("abc1234_", out _, out var exception).Should().BeFalse();
        exception.Should().BeOfType(typeof(ArgumentException));
        exception.Message.Should().Be("Password must contains at least an uppercase");
    }
    
    
    [Fact]
    public void Fail_When_Not_Contains_At_Least_A_Lowercase()
    {
        Password.TryCreate("ABC1234_", out _, out var exception).Should().BeFalse();
        exception.Should().BeOfType(typeof(ArgumentException));
        exception.Message.Should().Be("Password must contains at least a lowercase");
    }
    
    
    [Fact]
    public void Fail_When_Not_Contains_At_Least_A_Number()
    {
        Password.TryCreate("Abcdefg_", out _, out var exception).Should().BeFalse();
        exception.Should().BeOfType(typeof(ArgumentException));
        exception.Message.Should().Be("Password must contains at least a number");
    }
}