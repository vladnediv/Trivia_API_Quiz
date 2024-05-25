using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TriviaAPI_Quiz.Model;

namespace TriviaAPI_Quiz.Service
{
    public class TriviaApiService
    {
        public TriviaApiService() { }

        public async Task<ApiResultDb> BuildAndStartRequest(int amount, int category, QuestionDifficulty difficulty, string type)
        {
           var result = await Task<ApiResultDb>.Factory.StartNew(() =>
            {

            
                var result = new ApiResult();
                string httpRequest = "";
                if (amount > 0 && amount <= 50)
                {
                    httpRequest = $"https://opentdb.com/api.php?amount={amount}";
                }
                if (category > 8)
                {
                    httpRequest += $"&category={category}";
                }
                if (difficulty != QuestionDifficulty.AnyDifficulty)
                {
                    httpRequest += $"&difficulty={difficulty}";
                }
                if (type != "AnyType")
                {
                    httpRequest += $"&type={type}";
                }
                using (var webClient = new WebClient())
                {
                    try
                    {
                        var apiResult = webClient.DownloadString(httpRequest);
                        result = JsonConvert.DeserializeObject<ApiResult>(apiResult);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\nTry again in a few seconds!");
                        Thread.Sleep(5000);
                        var apiResult = webClient.DownloadString(httpRequest);
                        result = JsonConvert.DeserializeObject<ApiResult>(apiResult);
                    }
                }
                var list = new List<ApiResultElementDb>();
                foreach(var item in result.Results)
                {
                    var incorrectAnswers = new List<Answer>();
                    foreach(var answer in item.IncorrectAnswers)
                    {
                        incorrectAnswers.Add(new Answer() { Text = answer });
                    }   
                list.Add(new ApiResultElementDb() { Category = item.Category, Difficulty = item.Difficulty, Type = item.Type, Question = item.Question, CorrectAnswer = item.CorrectAnswer, IncorrectAnswers = incorrectAnswers });
                }
                var entity = new ApiResultDb() { ResponseCode = (int)result.ResponseCode, ApiResults = list };
                return entity;
            });
            return result;
        }
    }
}
