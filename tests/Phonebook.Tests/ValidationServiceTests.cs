using Phonebook.Services;
using Xunit;

namespace Phonebook.Tests;

public class ValidationServiceTests
{
    [Theory]
    [InlineData("alice@example.com", true)]
    [InlineData("bob.smith+tag@sub.example.co.za", true)]
    [InlineData("not-an-email", false)]
    [InlineData("alice@", false)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    public void IsValidEmail_ReturnsExpected(string email, bool expected)
        => Assert.Equal(expected, ValidationService.IsValidEmail(email));

    [Theory]
    [InlineData("+27 82 123 4567", true)]
    [InlineData("0821234567", true)]
    [InlineData("(011) 555-0198", true)]
    [InlineData("555-1234", true)]
    [InlineData("123", false)]       // too few digits
    [InlineData("abc", false)]       // letters not allowed
    [InlineData("", false)]
    public void IsValidPhoneNumber_ReturnsExpected(string phone, bool expected)
        => Assert.Equal(expected, ValidationService.IsValidPhoneNumber(phone));

    [Theory]
    [InlineData("Alice", true)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    public void IsValidName_ReturnsExpected(string name, bool expected)
        => Assert.Equal(expected, ValidationService.IsValidName(name));
}
