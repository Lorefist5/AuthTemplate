using AuthTemplate.Application.Common.Helpers;
using DefaultCoreLibrary.Core;
using FluentValidation;
using MediatR;

namespace AuthTemplate.Application.Features.WeatherForecast.Queries.GetWeatherForecast;

public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, Result<IEnumerable<GetWeatherForecastResponse>>>
{
    private readonly IValidator<GetWeatherForecastQuery> _queryValidator;


    private readonly (string Summary, int MinTemp, int MaxTemp)[] WeatherRanges = new[]
    {
        ("Freezing", -20, -1),
        ("Bracing", 0, 5),
        ("Chilly", 6, 10),
        ("Cool", 11, 15),
        ("Mild", 16, 20),
        ("Warm", 21, 25),
        ("Balmy", 26, 30),
        ("Hot", 31, 35),
        ("Sweltering", 36, 40),
        ("Scorching", 41, 55)
    };
    public GetWeatherForecastQueryHandler(IValidator<GetWeatherForecastQuery> queryValidator)
    {
        _queryValidator = queryValidator;
    }

    public async Task<Result<IEnumerable<GetWeatherForecastResponse>>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var queryValidationResults = await _queryValidator.ValidateAsync(request);
        if (!queryValidationResults.IsValid)
        {
            return ErrorParserHelper.Parse(queryValidationResults).ToList();
        }
        var random = new Random();
        var results = Enumerable.Range(1, request.Amount).Select(index =>
        {
            var (summary, minTemp, maxTemp) = WeatherRanges[random.Next(WeatherRanges.Length)];
            var date = DateOnly.FromDateTime(DateTime.Now.AddDays(index));
            var temperatureC = random.Next(minTemp, maxTemp + 1);

            var forecast = new GetWeatherForecastResponse(date, temperatureC, summary);
            return forecast;
        });
        
        return results.ToList();
    }
}
