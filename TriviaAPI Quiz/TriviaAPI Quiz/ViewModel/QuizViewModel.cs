using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Design;
using System.Windows.Input;
using TriviaAPI_Quiz.Infrastructure;
using TriviaAPI_Quiz.Model;
using TriviaAPI_Quiz.Service;
using TriviaAPI_Quiz.View;

namespace TriviaAPI_Quiz.ViewModel
{
    public class QuizViewModel
    {
        private readonly TriviaApiService _ApiService;

        public QuizViewModel(TriviaApiService apiService)
        {
            _ApiService = apiService;
            OpenHistoryCommand = new AsyncRelayCommand(OpenHistoryAsync);
            ChooseEasyCommand = new AsyncRelayCommand(ChooseEasy);
            ChooseMediumCommand = new AsyncRelayCommand(ChooseMedium);
            ChooseHardCommand = new AsyncRelayCommand(ChooseHard);
            StartQuizCommand = new AsyncRelayCommand(StartQuizAsync);
        }

        #region History
        public ICommand OpenHistoryCommand { get; }
        public async Task OpenHistoryAsync()
        {
            var window = (HistoryWindow)AppServiceProvider.ServiceProvider.GetService(typeof(HistoryWindow));
            window.Show();
        }
        #endregion

        #region Difficulty
        public bool IsEasy { get; set; }
        public bool IsMedium { get; set; }
        public bool IsHard { get; set; }
        public ICommand ChooseEasyCommand { get; }
        public ICommand ChooseMediumCommand { get; }
        public ICommand ChooseHardCommand { get; }

        public async Task ChooseEasy()
        {
            IsEasy = true;
        }
        public async Task ChooseMedium()
        {
            IsMedium = true;
        }
        public async Task ChooseHard()
        {
            IsHard = true;
        }
        #endregion

        #region Category
        public List<string> AllCategories { get; set; } = new List<string>() 
        {
        "Any Category",
        "General Knowledge",
        "Entertainment: Books",
        "Entertainment: Film",
        "Entertainment: Music",
        "Entertainment: Musicals & Theatres",
        "Entertainment: Television",
        "Entertainment: Video Games",
        "Entertainment: Board Games",
        "Science & Nature",
        "Science: Computers",
        "Science: Mathematics",
        "Mythology",
        "Sports",
        "Geography",
        "History",
        "Politics",
        "Art",
        "Celebrities",
        "Animals",
        "Vehicles",
        "Entertainment: Comics",
        "Science: Gadgets",
        "Entertainment: JapaneseAnimeAndManga",
        "Entertainment: CartoonAndAnimations"
        };
        public string SelectedCategory { get; set; } = "";

        #endregion

        #region Type
        public List<string> AllTypes { get; set; } = new List<string>()
        {
            "Any Type",
            "Multiple Choice",
            "True/False"
        };
        public string SelectedType { get; set; } = "";
        #endregion

        public async Task<int> GetNumberInCollectionAsync(string property, List<string> collection)
        {
            return await Task<int>.Factory.StartNew(() => 
            {
                int counter = 0;
                foreach (string buf in collection)
                {
                    counter++;
                    if (property == buf) { break; }
                }
                return counter + 7;
            });
        }

        #region Number of Questions
        public int AmountOfQuestions { get; set; } = 10;
        #endregion

        #region Start the Quiz
        public ICommand StartQuizCommand { get; }
        public async Task StartQuizAsync() 
        {
            QuestionDifficulty difficulty = new QuestionDifficulty();


            if(IsEasy)
            {
                difficulty = QuestionDifficulty.easy;
            }
            else if (IsMedium) 
            {
                difficulty = QuestionDifficulty.medium;
            }
            else if(IsHard) 
            {
                difficulty = QuestionDifficulty.hard;
            }
            else
            {
                difficulty = QuestionDifficulty.AnyDifficulty;
            }


            int category = await GetNumberInCollectionAsync(SelectedCategory, AllCategories);


            string type = "";
            if(SelectedType == "Any Type")
            {
                type = "AnyType";
            }
            if(SelectedType == "Multiple Choice")
            {
                type = "multiple";
            }
            if(SelectedType == "True/False")
            {
                type = "boolean";
            }
 
            try
            {
                var result = await _ApiService.BuildAndStartRequest(AmountOfQuestions, category, difficulty, type);
                if (result.ResponseCode == 1)
                {
                    MessageBox.Show("Could not return results. The API doesn't have enough questions for your query.");
                }
                else {
                    var window = (QuizStartWindow)AppServiceProvider.ServiceProvider.GetService(typeof(QuizStartWindow));

                    var viewModel = (QuizStartViewModel)AppServiceProvider.ServiceProvider.GetService(typeof(QuizStartViewModel));
                    viewModel.ApiResultDb = result;
                    viewModel.CurrentQuestion = result.ApiResults.FirstOrDefault();
                    viewModel.PossibleAnswers = new List<string>(result.GetAllPossibleAnswers(viewModel.CurrentQuestion));
                    viewModel.UserAnswers = new List<string>();
                    viewModel.UserAnswers.Capacity = viewModel.ApiResultDb.ApiResults.Count;
                    for(int i = 0; i < viewModel.UserAnswers.Capacity; i++)
                    {
                        viewModel.UserAnswers.Add("");
                    }
                    viewModel.CloseWindow = () => { window.Close(); };
                    viewModel._CompletionTime = new Stopwatch();

                    viewModel._CompletionTime.Start();

                    window.DataContext = viewModel;

                    window.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}