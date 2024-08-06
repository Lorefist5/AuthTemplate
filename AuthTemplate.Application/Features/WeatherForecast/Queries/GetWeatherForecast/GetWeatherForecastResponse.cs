using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTemplate.Application.Features.WeatherForecast.Queries.GetWeatherForecast;

public record GetWeatherForecastResponse(DateOnly Data, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
};

