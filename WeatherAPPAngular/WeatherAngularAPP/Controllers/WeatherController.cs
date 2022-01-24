using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherAngularAPP.Data.Models;
using WeatherAngularAPP.Service.Services;

namespace WeatherAngularAPP.Controllers
{
	public class WeatherController : ApiController
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task AddHistory(WeatherHistory weatherHistory)
        {
            if (weatherHistory == null) { throw new ArgumentNullException(); }

            await this.weatherService.AddHistory(weatherHistory);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/weather/byid/{id}")]
        public async Task<WeatherHistory> GetHistoryById(int id)
        {
            var historyEntity = await this.weatherService.GetByIdAsync(id);

            if (historyEntity == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"There's no history for this ID:{id}!"),
                    ReasonPhrase = $"Not found entity with this ID:{id}"
                };
                throw new HttpResponseException(resp);
            }
            return historyEntity;
        }

        public async Task RemoveHistory(int id)
        {
            await this.weatherService.RemoveHistory(id);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/weather/all")]
        public async Task<IEnumerable<WeatherHistoryDTO>> GetAll()
        {
            var weatherHistories = await this.weatherService.GetHistory();
            var result = new List<WeatherHistoryDTO>();

            foreach (var weatherHistory in weatherHistories)
            {
                result.Add(new WeatherHistoryDTO
                { date = weatherHistory.Date.ToString(), temperatureC = weatherHistory.TemperatureC, weatherHistoryId = weatherHistory.WeatherHistoryId });
            }

            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/weather/save-all")]
        public async Task SaveAll(string data)
        {
            var weatherLocation = new WeatherLocation() { CityName = "Varna" };
            var entity = new WeatherHistory() { Date = new DateTime(), TemperatureC = 15, WeatherLocation = weatherLocation };

            await this.weatherService.AddHistory(entity);
        }
    }
}
