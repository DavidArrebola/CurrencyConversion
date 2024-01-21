using server.Services.Interfaces;

namespace server.Services;

public class CurrencyService : ICurrencyService
{
    public string ConvertDecimalToCurrency(decimal value)
    {
        var sign = value < 0 ? "minus " : "";
        var absValue = Math.Abs(value);
        var dollars = (long)absValue;
        var cents = (int)((absValue - dollars) * 100);

        return $"{sign}{ConvertNumberToWords(dollars)} {Pluralize(dollars, "dollar", "dollars")} and {ConvertNumberToWords(cents)} {Pluralize(cents, "cent", "cents")}";

        string Pluralize(long number, string singular, string plural) =>
            number == 1 ? singular : plural;
    }
    
    public string ConvertNumberToWords(long number)
    {
        if (number == 0) return "zero";

        var words = "";
        const int oneBillion = 1_000_000_000;
        if ((number / oneBillion) > 0)
        {
            words += ConvertNumberToWords(number / oneBillion) + " billion ";
            number %= oneBillion;
        }

        const int oneMillion = 1_000_000;
        if ((number / oneMillion) > 0)
        {
            words += ConvertNumberToWords(number / oneMillion) + " million ";
            number %= oneMillion;
        }

        const int oneThousand = 1_000;
        if ((number / oneThousand) > 0)
        {
            words += ConvertNumberToWords(number / oneThousand) + " thousand ";
            number %= oneThousand;
        }

        const int oneHundred = 100;
        if ((number / oneHundred) > 0)
        {
            words += ConvertNumberToWords(number / oneHundred) + " hundred ";
            number %= oneHundred;
        }

        if (number <= 0) return words.TrimEnd();
        if (!string.IsNullOrEmpty(words))
            words += "and ";

        var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        if (number < 20)
            words += unitsMap[number];
        else
        {
            words += tensMap[number / 10];
            if ((number % 10) > 0)
                words += "-" + unitsMap[number % 10];
        }

        return words.TrimEnd();
    }
}