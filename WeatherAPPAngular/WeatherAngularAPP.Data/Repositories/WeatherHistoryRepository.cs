using WeatherAPPAngular.Data.Context;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPPAngular.Data.Models;

namespace WeatherAPPAngular.Data.Repositories
{
    public class WeatherHistoryRepository
    {
        private readonly WeatherContext dbContext;

        public WeatherHistoryRepository(WeatherContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(WeatherHistory entity)
        {
            this.dbContext.Add(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<WeatherHistory> FindAll()
        {
            return this.dbContext.WeatherHistories;
        }
    }
}
