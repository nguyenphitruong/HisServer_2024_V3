using System.Threading;
using System.Threading.Tasks;
using Emr.Application.Common.Interfaces;
using Emr.Application.Common.Mapping;
using Emr.Application.Common.Models;
using Emr.Application.ExternalServices.OpenWeather.Request;
using Emr.Application.ExternalServices.OpenWeather.Response;
using Emr.Domain.Enums;

namespace Emr.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}