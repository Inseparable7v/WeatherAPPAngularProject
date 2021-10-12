using System;
using System.Collections.Generic;
using WeatherAPPAngular.Data.Models;

namespace WeatherAPPAngular.Data.Models
{
    public class WeatherHistory
    {
        public int WeatherHistoryId { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public WeatherHistory WeatherLocation { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
