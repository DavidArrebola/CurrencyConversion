using server.Services;

namespace server.tests.CurrencyServiceTests;

public class ConvertNumberToWordsTests
{
    private readonly CurrencyService _currencyService = new();

    [Fact]
    public void ConvertNumberToWords_Zero_ReturnsZero()
    {
        var result = _currencyService.ConvertNumberToWords(0);
        Assert.Equal("zero", result);
    }

    [Fact]
    public void ConvertNumberToWords_SingleDigit_ReturnsCorrectWord()
    {
        var result = _currencyService.ConvertNumberToWords(7);
        Assert.Equal("seven", result);
    }

    [Fact]
    public void ConvertNumberToWords_Thousands_ReturnsCorrectWord()
    {
        var result = _currencyService.ConvertNumberToWords(1_234);
        Assert.Equal("one thousand two hundred and thirty-four", result);
    }

    [Fact]
    public void ConvertNumberToWords_Millions_ReturnsCorrectWord()
    {
        var result = _currencyService.ConvertNumberToWords(1_234_567);
        Assert.Equal("one million two hundred and thirty-four thousand five hundred and sixty-seven", result);
    }

    [Fact]
    public void ConvertNumberToWords_Billions_ReturnsCorrectWord()
    {
        var result = _currencyService.ConvertNumberToWords(1_234_567_890);
        Assert.Equal("one billion two hundred and thirty-four million five hundred and sixty-seven thousand eight hundred and ninety", result);
    }
    
    [Fact]
    public void ConvertNumberToWords_OneBillionTwoHundredThirtyFourThousand_ReturnsCorrectWords()
    {
        var result = _currencyService.ConvertNumberToWords(1_000_234_000);
        const string expected = "one billion two hundred and thirty-four thousand";
        Assert.Equal(expected, result);
    }
}