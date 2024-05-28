using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Service;

namespace TriviaAPI_Quiz.ViewModel
{
    public class QuizStartViewModel : BaseViewModel
    {
        private readonly QuizQuestionsService _quizQuestionsService;
        private readonly QuizResultService _quizResultService;
        public QuizStartViewModel(QuizQuestionsService quizQuestionsService, QuizResultService quizResultService) 
        {
            _quizResultService = quizResultService;
            _quizQuestionsService = quizQuestionsService;
            PreviousQuestionCommand = new AsyncRelayCommand(MoveToPreviousQuestionAsync);
            NextQuestionCommand = new AsyncRelayCommand(MoveToNextQuestionAsync);
            FinishQuizCommand = new AsyncRelayCommand(FinishQuizAsync);
            CurrentNumberTask = 1;
            Task.Factory.StartNew(() => { while (true) OnPropertyChanged("CompletionTime"); });
        }
        public Action CloseWindow { get; set; }
        public ApiResultDb ApiResultDb { get; set; }

        private int _CurrentNumberTask;
        public int CurrentNumberTask { get { return _CurrentNumberTask; } set { _CurrentNumberTask = value; OnPropertyChanged(); } }
        public Stopwatch _CompletionTime { get; set; }
        public string CompletionTime { get { return _CompletionTime.Elapsed.ToString(); } set { CompletionTime = value; OnPropertyChanged(); } }

        private ApiResultElementDb _CurrentQuestion;
        public ApiResultElementDb CurrentQuestion { get { return _CurrentQuestion; } set { _CurrentQuestion = value; OnPropertyChanged(); } }

        private List<string> _PossibleAnswers;
        public List<string> PossibleAnswers { get { return _PossibleAnswers; } set { _PossibleAnswers = value; OnPropertyChanged(); } }

        private string _UserAnswer;
        public string UserAnswer { get { return _UserAnswer; } set { _UserAnswer = value; UserAnswers[CurrentNumberTask - 1] = _UserAnswer; OnPropertyChanged(); } }
        public List<string> UserAnswers { get; set; }

        public ICommand PreviousQuestionCommand { get; }
        public async Task MoveToPreviousQuestionAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                int counter = 0;
                foreach (var question in ApiResultDb.ApiResults)
                {
                    counter++;
                    if(question == CurrentQuestion && counter >= 2)
                    {
                        counter--;
                        CurrentNumberTask = counter;
                        CurrentQuestion = ApiResultDb.ApiResults[counter - 1];
                        PossibleAnswers = ApiResultDb.GetAllPossibleAnswers(CurrentQuestion);
                        UserAnswer = UserAnswers[counter - 1];
                        break;
                    }
                }
            });
        }



        public ICommand NextQuestionCommand { get; }
        public async Task MoveToNextQuestionAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                int counter = 1;
                foreach (var question in ApiResultDb.ApiResults)
                {
                    counter++;
                    if(question == CurrentQuestion && counter <= ApiResultDb.ApiResults.Count)
                    {
                        CurrentNumberTask = counter;
                        CurrentQuestion = ApiResultDb.ApiResults[counter - 1];
                        PossibleAnswers = ApiResultDb.GetAllPossibleAnswers(CurrentQuestion);
                        UserAnswer = UserAnswers[counter - 1];
                        break;
                    }
                }
            });
        }


        public ICommand FinishQuizCommand { get; }
        public async Task FinishQuizAsync()
        {
            await Task.Factory.StartNew(async () =>
            {
                _CompletionTime.Stop();
                bool CanExecute = true;
                foreach (var answer in UserAnswers)
                {
                    if (answer == "")
                    {
                        MessageBox.Show("Cant finish, not all questions answered!");
                        CanExecute = false;
                        break;
                    }
                }
                if(CanExecute)
                {
                    ApiResultDb.UserAnswers = new List<Answer>();
                    foreach (var answer in UserAnswers)
                    {
                        ApiResultDb.UserAnswers.Add(new Answer() { Text = answer });
                    }
                    await _quizQuestionsService.AddQuizAsync(ApiResultDb);
                    var userResult = await CalculateResultAsync();
                    await _quizResultService.AddQuizResultAsync(userResult);
                    CloseWindow.Invoke();
                }
            });
        }
        public async Task<QuizResult> CalculateResultAsync()
        {
            return await Task<QuizResult>.Factory.StartNew(() => 
            {
            int AmountFalse = 0;
            int AmountTrue = 0;
                for (int counter = 0; counter < ApiResultDb.ApiResults.Count; counter++)
                {
                    if (UserAnswers[counter] == ApiResultDb.ApiResults[counter].CorrectAnswer) { AmountTrue++; }
                    else
                    {
                        AmountFalse++;
                    }
                }
                return new QuizResult() { AmountCorrect = AmountTrue, AmountIncorrect = AmountFalse, CompletionTime = CompletionTime };
            });
        }
    }
}
