using AuthTemplate.Application.Features.WeatherForecast.Queries.GetWeatherForecast;
using DefaultCoreLibrary.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTemplate.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetAsync([FromHeader] int amount)
    {
        _logger.LogInformation("Getting weather forecast");
        var query = new GetWeatherForecastQuery(amount);
        var queryResults = await _mediator.Send(query);
        if(queryResults.IsFailure)
        {
            _logger.LogError("Error while fetching weather forecast.");
            return BadRequest(queryResults.Errors);
        }
        _logger.LogInformation("Successfully fetched weather forecast.");
        return Ok(queryResults.Value);
    }
}
