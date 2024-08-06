using DefaultCoreLibrary.Core;
using MediatR;

namespace AuthTemplate.Application.Features.WeatherForecast.Queries.GetWeatherForecast;

public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<Result<GetWeatherForecastResponse>>>
{
    private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    public Task<IEnumerable<Result<GetWeatherForecastResponse>>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        return Enumerable.Range(1, 5).Select(
            index => new GetWeatherForecastResponse(DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            )).ToArray();

    }
}
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = ,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();