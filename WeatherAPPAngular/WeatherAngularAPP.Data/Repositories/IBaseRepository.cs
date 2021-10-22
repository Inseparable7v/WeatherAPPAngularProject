using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherAngularAPP.Data.Repositories
{
    public interface IBaseRepository<TEntity>  where TEntity :class
    {
        void Delete(TEntity entityToDelete);
        Task DeleteAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIDAsync(object id);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task SaveAsync();
        Task SaveAllAsync(ICollection<TEntity> entityCollection);
    }
}
