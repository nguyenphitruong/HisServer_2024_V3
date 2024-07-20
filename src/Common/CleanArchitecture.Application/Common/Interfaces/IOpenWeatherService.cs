using System.Threading;
using System.Threading.Tasks;
using Emr.Application.Common.Models;
using Emr.Application.ExternalServices.OpenWeather.Request;
using Emr.Application.ExternalServices.OpenWeather.Response;

namespace Emr.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}