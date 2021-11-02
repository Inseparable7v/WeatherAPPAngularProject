using System;
using System.Collections.Generic;

namespace WeatherAngularAPP.Data.Models
{
    public class WeatherHistory
    {
        public int WeatherHistoryId { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public WeatherLocation WeatherLocation { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public class WeatherHistoryDTO
    {
        public int weatherHistoryId {  get; set; }
        public string date { get; set; }
        public int temperatureC { get; set; }
    }
}
