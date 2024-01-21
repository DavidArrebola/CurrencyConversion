using server.Exceptions;
using server.Utilities;

namespace server.tests.CurrencyValidatorTests;

public class CurrencyValidatorTests
{
    [Theory]
    [InlineData("123.45", 123.45)]
    [InlineData("-123456789012.34", -123456789012.34)]
    public void IsValidCurrencyValue_ValidValues_ReturnsTrue(string input, decimal expected)
    {
        bool result = CurrencyValidator.IsValidCurrencyValue(input, out decimal actualValue);
        Assert.True(result);
        Assert.Equal(expected, actualValue);
    }

    [Theory]
    [InlineData("123.456")] // More than two decimal places
    public void IsValidCurrencyValue_InvalidFormat_ThrowsInvalidCurrencyFormatException(string input)
    {
        Assert.Throws<CurrencyValueOutOfRangeException>(() =>
            CurrencyValidator.IsValidCurrencyValue(input, out _));
    }

    [Theory]
    [InlineData("1000000000000")] // More than 999999999999.99
    [InlineData("-1000000000000")] // Less than -999999999999.99
    public void IsValidCurrencyValue_OutOfRange_ThrowsCurrencyValueOutOfRangeException(string input)
    {
        Assert.Throws<CurrencyValueOutOfRangeException>(() =>
            CurrencyValidator.IsValidCurrencyValue(input, out _));
    }
    
    [Theory]
    [InlineData("not a number")]
    public void IsValidCurrencyValue_NonNumeric_ThrowsInvalidCurrencyFormatException(string input)
    {
        Assert.Throws<InvalidCurrencyFormatException>(() =>
            CurrencyValidator.IsValidCurrencyValue(input, out _));
    }
}