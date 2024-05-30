using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Service;

namespace TriviaAPI_Quiz.ViewModel
{
    public class ResultsViewModel : BaseViewModel
    {
        private readonly QuizResultService _resultService;

        public ResultsViewModel(QuizResultService quizResultService)
        {
            _resultService = quizResultService;
        }

        public ApiResultDb ApiResultDb { get; set; }

        private List<ApiResultElementDb> _Questions;
        public List<ApiResultElementDb> Questions { get { return _Questions; } set { _Questions = value; OnPropertyChanged(); } }
        public List<Answer> UserAnswers { get; set; }

        public QuizResult Result { get; set; }

        
    }
}
