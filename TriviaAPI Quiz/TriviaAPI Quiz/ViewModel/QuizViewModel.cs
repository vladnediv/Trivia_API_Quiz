using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Design;
using TriviaAPI_Quiz.Service;

namespace TriviaAPI_Quiz.ViewModel
{
    public class QuizViewModel
    {
        private readonly TriviaApiService _ApiService;
        private readonly QuizQuestionsService _QuestionService;
        private readonly QuizResultService _ResultService;

        public QuizViewModel(TriviaApiService apiService, QuizQuestionsService questionsService, QuizResultService resultService)
        {
            _ApiService = apiService;
            _QuestionService = questionsService;
            _ResultService = resultService;
        }


    }
}
 