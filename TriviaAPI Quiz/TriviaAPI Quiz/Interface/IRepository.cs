using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPI_Quiz.Interface
{
    public interface IRepositoryAsync<T> where T : class
    {
        public Task<ICollection<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);

        public Task AddAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task RemoveByIdAsync(int id);
        public Task UpdateAsync(int oldId, T entity);
    }
}
