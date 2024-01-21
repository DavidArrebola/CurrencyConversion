using MediatR;
using server.MediatR.Commands;
using server.Services.Interfaces;

namespace server.MediatR.Handlers;

public class ConvertCurrencyHandler(ICurrencyService currencyService) : IRequestHandler<ConvertCurrencyCommand, string>
{
    public async Task<string> Handle(ConvertCurrencyCommand request, CancellationToken cancellationToken)
    {
        var convertedNumber = currencyService.ConvertDecimalToCurrency(request.Value);
        return convertedNumber;
    }
}