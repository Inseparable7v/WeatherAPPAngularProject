using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WeatherAngularAPP.Data.Models;
using WeatherAngularAPP.Data.Context;

namespace WeatherAngularAPP.Data.Repositories
{
    public class WeatherHistoryRepository : IBaseRepository<WeatherHistory>
    {
        private readonly WeatherContext _weatherContext;
        private DbSet<WeatherHistory> dbSet;

        public WeatherHistoryRepository(WeatherContext weatherContext) 
        {
            this._weatherContext = weatherContext;
            this.dbSet = _weatherContext.Set<WeatherHistory>();
        }

        public void Delete(WeatherHistory entityToDelete)
        {
            if (_weatherContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task DeleteAsync(object id)
        {
            var entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public async Task<IEnumerable<WeatherHistory>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<WeatherHistory> GetByIDAsync(object id)
        {
            return await this.dbSet.SingleOrDefaultAsync(x => x.Equals(id));
        }

        public async Task InsertAsync(WeatherHistory entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await this._weatherContext.SaveChangesAsync();
        }

        public void Update(WeatherHistory entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _weatherContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
