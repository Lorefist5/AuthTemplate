using DefaultCoreLibrary.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTemplate.Application.Features.WeatherForecast.Queries.GetWeatherForecast;

public record GetWeatherForecastQuery(int Amount) : IRequest<Result<IEnumerable<GetWeatherForecastResponse>>>;
