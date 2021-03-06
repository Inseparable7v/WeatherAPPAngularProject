using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAngularAPP.Data.Models;
using WeatherAngularAPP.Data.Repositories;

namespace WeatherAngularAPP.Service.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IBaseRepository<WeatherHistory> _weatherHistoryRepository;
        public WeatherService(IBaseRepository<WeatherHistory> weatherHistoryRepository)
        {
            this._weatherHistoryRepository = weatherHistoryRepository;
        }

        public async Task AddHistory(WeatherHistory entity)
        {
            await this._weatherHistoryRepository.InsertAsync(entity);
            await this._weatherHistoryRepository.SaveAsync();
        }

        public async Task RemoveHistory(int id)
        {
            await this._weatherHistoryRepository.DeleteAsync(id);
            await this._weatherHistoryRepository.SaveAsync();
        }

        public async Task<IEnumerable<WeatherHistory>> GetHistory()
        {
            return await this._weatherHistoryRepository.GetAllAsync();
        }
        public async Task<WeatherHistory> GetByIdAsync(int id)
        {
            try
            {
                 return await this._weatherHistoryRepository.GetByIDAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SaveAllAsync(ICollection<WeatherHistory> weatherHistories)
        {
            if(weatherHistories == null)
            {
                throw new ArgumentNullException();
            }
            await this._weatherHistoryRepository.SaveAllAsync(weatherHistories);
            await this._weatherHistoryRepository.SaveAsync();
        }
    }
}
