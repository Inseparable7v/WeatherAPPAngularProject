using System.Collections.Generic;
using WeatherAPPAngular.Data.Models;

namespace WeatherAPPAngular.Data.Models
{
    public class Adress
    {
        public int AdressId { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public ICollection<User> Users{ get; set; }
    }
}
