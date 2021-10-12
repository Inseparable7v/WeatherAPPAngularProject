using WeatherAPPAngular.Data.Context;
using WeatherAPPAngular.Data.Models;
using WeatherAPPAngular.Data.Repositories;

namespace WeatherAPPAngular.Service.Services
{
    public class WeatherService : BaseRepository<WeatherHistory>
    {
        public WeatherService(WeatherContext context) : base(context)
        {
        }


    }
}
