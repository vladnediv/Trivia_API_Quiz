using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Repository;

namespace TriviaAPI_Quiz.Service
{
    public class QuizResultService
    {
        private readonly QuizResultRepositoryAsync _quizResultRepository;

        public QuizResultService(QuizResultRepositoryAsync quizResultRepository)
        {
            _quizResultRepository = quizResultRepository;
        }

        public async Task AddQuizResultAsync(QuizResult result) => await _quizResultRepository.AddAsync(result);

        public async Task<ICollection<QuizResult>> GetAllQuizResultAsync() => await _quizResultRepository.GetAllAsync();

        public async Task<QuizResult> GetQuizResultByIdAsync(int id) => await _quizResultRepository.GetByIdAsync(id);

        public async Task RemoveQuizResultAsync(QuizResult result) => await _quizResultRepository.RemoveAsync(result);

        public async Task RemoveQuizResultByIdAsync(int id) => await _quizResultRepository.RemoveByIdAsync(id);

        public async Task UpdateQuizResultAsync(int oldId, QuizResult result) => await _quizResultRepository.UpdateAsync(oldId, result);
    }
}
