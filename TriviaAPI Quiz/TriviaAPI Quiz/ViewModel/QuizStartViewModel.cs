using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Service;

namespace TriviaAPI_Quiz.ViewModel
{
    public class QuizStartViewModel : BaseViewModel
    {
        private readonly QuizQuestionsService _quizQuestionsService;
        public QuizStartViewModel(QuizQuestionsService quizQuestionsService) 
        {
            _quizQuestionsService = quizQuestionsService;
            PreviousQuestionCommand = new AsyncRelayCommand(MoveToPreviousQuestionAsync);
            NextQuestionCommand = new AsyncRelayCommand(MoveToNextQuestionAsync);
            CurrentNumberTask = 1;
        }

        public ApiResultDb ApiResultDb { get; set; }

        private int _CurrentNumberTask;
        public int CurrentNumberTask { get { return _CurrentNumberTask; } set { _CurrentNumberTask = value; OnPropertyChanged(); } }

        private ApiResultElementDb _CurrentQuestion;
        public ApiResultElementDb CurrentQuestion { get { return _CurrentQuestion; } set { _CurrentQuestion = value; OnPropertyChanged(); } }

        public ICommand PreviousQuestionCommand { get; }
        public async Task MoveToPreviousQuestionAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                int counter = 0;
                foreach (var question in ApiResultDb.ApiResults)
                {
                    if (CurrentQuestion == question)
                    {
                        counter--;
                        CurrentNumberTask = counter;
                        break;
                    }
                    else counter++;
                }
                if(counter >= 0 && counter < ApiResultDb.ApiResults.Count)
                {
                    CurrentQuestion = ApiResultDb.ApiResults[counter];
                }
            });
        }



        public ICommand NextQuestionCommand { get; }
        public async Task MoveToNextQuestionAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                int counter = 0;
                foreach (var question in ApiResultDb.ApiResults)
                {
                    if (CurrentQuestion == question)
                    {
                        counter++;
                        CurrentNumberTask = counter;
                        break;
                    }
                    else counter++;
                }
                if (counter >= 0 && counter < ApiResultDb.ApiResults.Count)
                {
                    CurrentQuestion = ApiResultDb.ApiResults[counter];
                }
            });
        }
    }
}
