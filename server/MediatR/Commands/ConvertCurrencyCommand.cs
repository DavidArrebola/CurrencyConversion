using MediatR;

namespace server.MediatR.Commands;

public class ConvertCurrencyCommand(decimal value) : IRequest<string>
{
    public decimal Value { get; private set; } = value;
}