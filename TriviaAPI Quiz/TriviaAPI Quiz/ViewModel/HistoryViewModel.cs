using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Service;

namespace TriviaAPI_Quiz.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        private readonly QuizResultService _quizResultService;
        public HistoryViewModel(QuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
            Initialize();
        }

        public async void Initialize()
        {
            PreviousResults = new List<QuizResult>(await _quizResultService.GetAllQuizResultAsync());
        }

        private List<QuizResult> _PreviousResults;
        public List<QuizResult> PreviousResults { get { return _PreviousResults; } set { _PreviousResults = value; OnPropertyChanged(); } }

    }
}
