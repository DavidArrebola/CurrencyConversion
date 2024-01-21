namespace server.Exceptions;
/// <summary>
/// Thrown when the parsed decimal value is out of the acceptable range.
/// </summary>
public class CurrencyValueOutOfRangeException : Exception
{
    public CurrencyValueOutOfRangeException(string message) : base(message)
    {
    }
}