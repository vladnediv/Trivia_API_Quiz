using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPI_Quiz.Model
{
    public class ApiResultDb
    {
        public int Id { get; set; }
        public int ResponseCode { get; set; }
        public List<ApiResultElementDb> ApiResults { get; set; }
        public List<Answer> UserAnswers { get; set; }
        public List<string> GetAllPossibleAnswers(ApiResultElementDb question)
        {
            var list = new List<string>();
            foreach (var answer in question.IncorrectAnswers)
            {
                list.Add(answer.Text);
            }
            list.Add(question.CorrectAnswer);
            list.OrderBy(x => Random.Shared.Next()).ToList();

            return list;
        }
    }

    public class ApiResultElementDb
    {
        public int Id { get; set; }
        public ApiResultDb ApiResult { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public List<Answer> IncorrectAnswers { get; set; }
    }
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
