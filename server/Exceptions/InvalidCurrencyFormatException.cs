namespace server.Exceptions;

/// <summary>
/// Thrown when the input string cannot be parsed into a valid decimal format.
/// </summary>
public class InvalidCurrencyFormatException : Exception
{
    public InvalidCurrencyFormatException(string message) : base(message)
    {
    }
}