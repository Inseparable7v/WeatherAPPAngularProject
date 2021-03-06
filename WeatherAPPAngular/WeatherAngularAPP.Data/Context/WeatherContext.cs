using Microsoft.EntityFrameworkCore;
using WeatherAngularAPP.Data.Models;

namespace WeatherAngularAPP.Data.Context
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<TestModel> TestModels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeatherHistory> WeatherHistories { get; set; }
        public virtual DbSet<WeatherLocation> WeatherLocations { get; set; }
        public virtual DbSet<Adress> Adresses { get; set; }
    }
}
