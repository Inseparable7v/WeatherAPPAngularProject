using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherAngularAPP.Data.Models;
using WeatherAngularAPP.Service.Services;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WeatherAngularAPP.Controllers
{
    [RoutePrefix("")]
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpPost]
        public async Task AddHistory(WeatherHistory weatherHistory)
        {
            if (weatherHistory == null) { throw new ArgumentNullException(); }

            await this.weatherService.AddHistory(weatherHistory);
        }

        [HttpGet]
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

        [HttpGet]
        [Route("api/weather/GetAll")]
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

        [HttpPost]
        [Route("api/weather/SaveAll")]
        public async Task SaveAll(string save)
        {
            var weatherLocation = new WeatherLocation() { CityName = "Varna" };
            var entity = new WeatherHistory() { Date = new DateTime(), TemperatureC = 15, WeatherLocation = weatherLocation };

            await this.weatherService.AddHistory(entity);
        }
    }
}
