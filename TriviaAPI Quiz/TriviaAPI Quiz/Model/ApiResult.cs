using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPI_Quiz.Model
{
    public class ApiResult
    {
        [JsonProperty("response_code")]
        public long ResponseCode { get; set; }

        [JsonProperty("results")]
        public List<ApiResultElement> Results { get; set; }
    }

    public class ApiResultElement
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }
    }

    public enum QuestionType { AnyType, multiple, boolean }
    public enum QuestionDifficulty { AnyDifficulty, Easy, Medium, Hard }
    public enum QuestionCategory
    {
        AnyCategory,
        GeneralKnowledge,
        EntertainmentBooks,
        EntertainmentFilm,
        EntertainmentMusic,
        EntertainmentBoardGames,
        ScienceAndNature,
        ScienceComputers,
        ScienceMathematics,
        Mythology,
        Sports,
        Geography,
        History,
        Politics,
        Art,
        Celebrities,
        Animals,
        Vehicles,
        EntertainmentComics,
        ScienceGadgets,
        EntertainmentJapaneseAnimeAndManga,
        EntertainmentCartoonAndAnimations
    }
}