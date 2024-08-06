using AuthTemplate.Application.Features.WeatherForecast.Queries.GetWeatherForecast;
using FluentValidation;

namespace AuthTemplate.Application.Features.WeatherForecast.Validators;

public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForecastQueryValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0");
        
        RuleFor(x => x.Amount)
            .LessThan(100)
            .WithMessage("Amount must be less than 100");

    }
}
