using System.Collections.Generic;
using System.Threading.Tasks;

namespace VanderStack.Shared
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetAsync();
    }
}
