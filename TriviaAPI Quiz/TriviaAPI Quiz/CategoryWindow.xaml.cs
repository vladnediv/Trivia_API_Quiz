using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TriviaAPI_Quiz
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
            //LoadDataAsync();
        }

        //    private async Task LoadDataAsync()
        //    {
        //        // Example data
        //        var response = new ApiResponse
        //        {
        //            ResponseCode = 0,
        //            Results = new List<Result>
        //            {
        //                new Result
        //                {
        //                    Type = "multiple",
        //                    Difficulty = "medium",
        //                    Category = "Entertainment: Video Games",
        //                    Question = "Which of these games takes place in the Irish town of Doolin, with the option to play as one of the characters, Ellen and Keats?",
        //                    CorrectAnswer = "Folklore",
        //                    IncorrectAnswers = new List<string>
        //                    {
        //                        "Shadow of the Colossus",
        //                        "ICO",
        //                        "Beyond Good & Evil"
        //                    },
        //                    ImagePath = await CategoryImageHelper.GetImageForCategoryAsync("Entertainment: Video Games")
        //                },
        //                new Result
        //                {
        //                    Type = "multiple",
        //                    Difficulty = "medium",
        //                    Category = "General Knowledge",
        //                    Question = "Which of these games takes place in the Irish town of Doolin, with the option to play as one of the characters, Ellen and Keats?",
        //                    CorrectAnswer = "Folklore",
        //                    IncorrectAnswers = new List<string>
        //                    {
        //                        "Shadow of the Colossus",
        //                        "ICO",
        //                        "Beyond Good & Evil"
        //                    },
        //                    ImagePath = await CategoryImageHelper.GetImageForCategoryAsync("General Knowledge")
        //                },
        //                new Result
        //                {
        //                    Type = "multiple",
        //                    Difficulty = "medium",
        //                    Category = "Art",
        //                    Question = "Which of these games takes place in the Irish town of Doolin, with the option to play as one of the characters, Ellen and Keats?",
        //                    CorrectAnswer = "Folklore",
        //                    IncorrectAnswers = new List<string>
        //                    {
        //                        "Shadow of the Colossus",
        //                        "ICO",
        //                        "Beyond Good & Evil"
        //                    },
        //                    ImagePath = await CategoryImageHelper.GetImageForCategoryAsync("Art")
        //                },
        //                new Result
        //                {
        //                    Type = "multiple",
        //                    Difficulty = "medium",
        //                    Category = "Entertainment: Cartoon & Animations",
        //                    Question = "Which of these games takes place in the Irish town of Doolin, with the option to play as one of the characters, Ellen and Keats?",
        //                    CorrectAnswer = "Folklore",
        //                    IncorrectAnswers = new List<string>
        //                    {
        //                        "Shadow of the Colossus",
        //                        "ICO",
        //                        "Beyond Good & Evil"
        //                    },
        //                    ImagePath = await CategoryImageHelper.GetImageForCategoryAsync("Entertainment: Cartoon & Animations")
        //                }
        //            }
        //        };

        //        ResultsListBox.ItemsSource = response.Results;
        //    }
        //}

        //public class ApiResponse
        //{
        //    public int ResponseCode { get; set; }
        //    public List<Result> Results { get; set; }
        //}

        //public class Result
        //{
        //    public string Type { get; set; }
        //    public string Difficulty { get; set; }
        //    public string Category { get; set; }
        //    public string Question { get; set; }
        //    public string CorrectAnswer { get; set; }
        //    public List<string> IncorrectAnswers { get; set; }
        //    public string ImagePath { get; set; }
        //}
    }
}