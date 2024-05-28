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
    public class QuizResultRepositoryAsync : IRepositoryAsync<QuizResult>
    {
        private readonly QuestionsDbContext _dbContext;
        public QuizResultRepositoryAsync(QuestionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(QuizResult entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<QuizResult>> GetAllAsync() => await _dbContext.UserResults.ToListAsync();

        public async Task<QuizResult> GetByIdAsync(int id) => await _dbContext.UserResults.FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(QuizResult entity)
        {
            _dbContext.UserResults.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await _dbContext.UserResults.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.UserResults.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int oldId, QuizResult entity)
        {
            var toUpdate = await _dbContext.UserResults.FirstOrDefaultAsync(x => x.Id == oldId);
            toUpdate.CompletionTime = entity.CompletionTime;
            toUpdate.AmountIncorrect = entity.AmountIncorrect;
            toUpdate.AmountCorrect = entity.AmountCorrect;


            await _dbContext.SaveChangesAsync();
        }
    }
}
