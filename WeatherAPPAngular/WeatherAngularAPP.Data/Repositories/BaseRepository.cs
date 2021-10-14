using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherAngularAPP.Data.Context;

namespace WeatherAngularAPP.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal WeatherContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(WeatherContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
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

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIDAsync(object id)
        {
            return await this.dbSet.SingleOrDefaultAsync(x => x.Equals(id));
        }

        public async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
