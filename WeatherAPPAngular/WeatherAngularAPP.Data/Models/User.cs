namespace WeatherAngularAPP.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
    }
}
