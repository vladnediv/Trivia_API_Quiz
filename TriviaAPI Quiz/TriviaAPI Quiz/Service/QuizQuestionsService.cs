﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Repository;

namespace TriviaAPI_Quiz.Service
{
    public class QuizQuestionsService
    {
        private readonly QuestionsRepositoryAsync _questionsRepository;

        public QuizQuestionsService(QuestionsRepositoryAsync questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task AddQuizAsync(ApiResultDb result) => await _questionsRepository.AddAsync(result);

        public async Task<ICollection<ApiResultDb>> GetAllQuizAsync() => await _questionsRepository.GetAllAsync();

        public async Task<ApiResultDb> GetQuizByIdAsync(int id) => await _questionsRepository.GetByIdAsync(id);

        public async Task RemoveQuizAsync(ApiResultDb task) => await _questionsRepository.RemoveAsync(task);

        public async Task RemoveQuizByIdAsync(int id) => await _questionsRepository.RemoveByIdAsync(id);

        public async Task UpdateQuizAsync(int oldId, ApiResultDb task) => await _questionsRepository.UpdateAsync(oldId, task);
    }
}
