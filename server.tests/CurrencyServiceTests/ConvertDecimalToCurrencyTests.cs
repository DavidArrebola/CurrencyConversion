using server.Services;

namespace server.tests.CurrencyServiceTests;

public class ConvertDecimalToCurrencyTests
{
    private readonly CurrencyService _currencyService = new();

    [Fact]
    public void ConvertDecimalToCurrency_WholeNumber_ReturnsCorrectWords()
    {
        var result = _currencyService.ConvertDecimalToCurrency(123M);
        Assert.Equal("one hundred and twenty-three dollars and zero cents", result);
    }

    [Fact]
    public void ConvertDecimalToCurrency_NumberWithCents_ReturnsCorrectWords()
    {
        var result = _currencyService.ConvertDecimalToCurrency(123.45M);
        Assert.Equal("one hundred and twenty-three dollars and forty-five cents", result);
    }

    [Fact]
    public void ConvertDecimalToCurrency_NumberWithZeroDollars_ReturnsCorrectWords()
    {
        var result = _currencyService.ConvertDecimalToCurrency(0.45M);
        Assert.Equal("zero dollars and forty-five cents", result);
    }

    [Fact]
    public void ConvertDecimalToCurrency_LargeNumber_ReturnsCorrectWords()
    {
        var result = _currencyService.ConvertDecimalToCurrency(1_234_567_890.99M);
        Assert.Equal("one billion two hundred and thirty-four million five hundred and sixty-seven thousand eight hundred and ninety dollars and ninety-nine cents", result);
    }
    
    [Theory]
    [InlineData(1, "one dollar and zero cents")]
    [InlineData(1.01, "one dollar and one cent")]
    [InlineData(2, "two dollars and zero cents")]
    [InlineData(2.01, "two dollars and one cent")]
    public void ConvertDecimalToCurrency_ReturnsCorrectPluralization(decimal input, string expectedOutput)
    {
        var service = new CurrencyService();
        var result = service.ConvertDecimalToCurrency(input);
        Assert.Equal(expectedOutput, result);
    }
}