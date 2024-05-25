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
    public class QuestionsRepositoryAsync : IRepositoryAsync<ApiResult>
    {
        private readonly QuestionsDbContext _dbContext;
        public QuestionsRepositoryAsync(QuestionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ApiResult entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ApiResult>> GetAllAsync() => await _dbContext.Questions.ToListAsync();

        public async Task<ApiResult> GetByIdAsync(int id) => await _dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(ApiResult entity)
        {
            _dbContext.Questions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await _dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Questions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int oldId, ApiResult entity)
        {
            var toUpdate = await _dbContext.Questions.FirstOrDefaultAsync(x => x.Id == oldId);
            toUpdate.Results = entity.Results;
            toUpdate.ResponseCode = entity.ResponseCode;


            await _dbContext.SaveChangesAsync();
        }
    }
}
