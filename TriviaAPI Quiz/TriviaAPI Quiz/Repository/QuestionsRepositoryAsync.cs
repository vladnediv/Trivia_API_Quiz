using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaAPI_Quiz.Context;
using TriviaAPI_Quiz.Interface;
using TriviaAPI_Quiz.Model;

namespace TriviaAPI_Quiz.Repository
{
    public class QuestionsRepositoryAsync : IRepositoryAsync<ApiResultDb>
    {
        private readonly QuestionsDbContext _dbContext;
        public QuestionsRepositoryAsync(QuestionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ApiResultDb entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ApiResultDb>> GetAllAsync() => await _dbContext.ApiResults.ToListAsync();

        public async Task<ApiResultDb> GetByIdAsync(int id) => await _dbContext.ApiResults.FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(ApiResultDb entity)
        {
            _dbContext.ApiResults.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await _dbContext.ApiResults.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.ApiResults.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int oldId, ApiResultDb entity)
        {
            var toUpdate = await _dbContext.ApiResults.FirstOrDefaultAsync(x => x.Id == oldId);
            toUpdate.ApiResults = entity.ApiResults;
            toUpdate.ResponseCode = entity.ResponseCode;


            await _dbContext.SaveChangesAsync();
        }
    }
}
