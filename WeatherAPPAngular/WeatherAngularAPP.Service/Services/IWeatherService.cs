using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAngularAPP.Data.Models;

namespace WeatherAngularAPP.Service.Services
{
    public interface IWeatherService
    {
        Task AddHistory(WeatherHistory entity);
        Task RemoveHistory(int id);
        Task<IEnumerable<WeatherHistory>> GetHistory();
        Task<WeatherHistory> GetByIdAsync(int id);
    }
}
