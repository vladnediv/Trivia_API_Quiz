using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPI_Quiz.Model
{
    public class QuizResult
    {
        public int Id { get; set; }
        public string CompletionTime { get; set; }
        public int AmountCorrect { get; set; }
        public int AmountIncorrect { get; set; }
    }
}
