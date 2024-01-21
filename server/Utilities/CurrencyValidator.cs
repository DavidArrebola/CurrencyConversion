using server.Exceptions;
using static System.Decimal;

namespace server.Utilities;

public class CurrencyValidator
{
    public static bool IsValidCurrencyValue(string value, out decimal decimalValue)
    {
    decimalValue = 0M;
    if (!TryParse(value, out var parsedValue))
        throw new InvalidCurrencyFormatException("Invalid currency format.");

    if (parsedValue is < -999999999999.99M or > 999999999999.99M)
        throw new CurrencyValueOutOfRangeException("Value is out of range.");

    if (Round(parsedValue, 2) != parsedValue)
        throw new CurrencyValueOutOfRangeException("Value has too many decimal places.");

    decimalValue = parsedValue;
    return true;
    }

}