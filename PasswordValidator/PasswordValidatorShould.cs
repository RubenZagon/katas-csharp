namespace PasswordValidator.Unit.Tests;

public class PasswordValidatorShould
{
    [Fact]
    public void HaveMoreThan8Characters()
    {
        PasswordValidator.IsInvalid("12345678").Should().BeFalse();
    }
}