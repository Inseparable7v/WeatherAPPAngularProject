using System.Collections.Generic;

namespace WeatherAngularAPP.Data.Models
{
    public class Adress
    {
        public int AdressId { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public ICollection<User> Users{ get; set; }
    }
}
