using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Exceptions;
using server.MediatR.Commands;
using server.Models;
using server.Utilities;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyConversionController(IMediator mediator, ILogger<CurrencyConversionController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ConvertCurrency([FromBody] CurrencyConversionDto conversionDto)
    {
        try
        {
            if (!CurrencyValidator.IsValidCurrencyValue(conversionDto.Value, out var decimalValue))
            {
                return BadRequest("Invalid currency value.");
            }

            var result = await mediator.Send(new ConvertCurrencyCommand(decimalValue));

            return Ok(result);
        }
        catch (InvalidCurrencyFormatException ex)
        {
            logger.LogError(ex, "Invalid currency format received.");
            return BadRequest(ex.Message);
        }
        catch (CurrencyValueOutOfRangeException ex)
        {
            logger.LogError(ex, "Currency value out of range.");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while processing the request.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}