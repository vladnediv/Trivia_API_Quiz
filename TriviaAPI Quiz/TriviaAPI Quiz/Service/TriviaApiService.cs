using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TriviaAPI_Quiz.Model;

namespace TriviaAPI_Quiz.Service
{
    internal class TriviaApiService
    {
        public TriviaApiService() { }

        public async Task<ApiResult> BuildAndStartRequest(int amount, QuestionCategory category, QuestionDifficulty difficulty, QuestionType type)
        {
            var result = new ApiResult();
            await Task.Factory.StartNew(async () => 
            {
                string httpRequest = "";
                if (amount > 0 && amount <= 50)
                {
                    httpRequest = $"https://opentdb.com/api.php?amount={amount}";
                }
                if (category != QuestionCategory.AnyCategory)
                {
                    httpRequest += $"&category={((int)category + 8)}";
                }
                if (difficulty != QuestionDifficulty.AnyDifficulty)
                {
                    httpRequest += $"&difficulty={difficulty}";
                }
                if (type != QuestionType.AnyType)
                {
                    httpRequest += $"&type={type}";
                }
                using (var webClient = new WebClient())
                {
                    var apiResult = webClient.DownloadString(httpRequest);
                    result = JsonConvert.DeserializeObject<ApiResult>(apiResult);
                }
            });
            return result;
        }


    }
}
