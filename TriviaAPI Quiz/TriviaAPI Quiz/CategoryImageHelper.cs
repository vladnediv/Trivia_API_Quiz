using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CategoryImageHelper
{
    private static readonly Dictionary<string, string> CategoryImages = new Dictionary<string, string>
        {
            { "Any Category", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\any_category.png" },
            { "General Knowlege", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\general_knowledge.png" },
            { "Entertainment: Books", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_books.png" },
            { "Entertainment: Films", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_films.png" },
            { "Entertainment: Music", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_music.png" },
            { "Entertainment: Musicals & Theatres", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_musicals_theatres.png" },
            { "Entertainment: Television", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_television.png" },
            { "Entertainment: Video Games", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_video_games.png" },
            { "Entertainment: Board Games", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_board_games.png" },
            { "Sciense & Nature", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\science_nature.png" },
            { "Sciense: Computers", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\science_computers.png" },
            { "Sciense: Mathematics", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\science_mathematics.png" },
            { "Mythology", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\mythology.png" },
            { "Sports", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\sports.png" },
            { "Geography", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\geography.png" },
            { "Politics", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\politics.png" },
            { "Art", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\art.png" },
            { "Celebrities", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\celebrities.png" },
            { "Animals", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\animals.png" },
            { "Vehicles", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\vehicles.png" },
            { "Entertainment: Comics", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_comics.png" },
            { "Sciense: Gadgets", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\science_gadgets.png" },
            { "Entertainment: Japanese & Manga", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_japanese_manga.png" },
            { "Entertainment: Cartoon & Animations", "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\entertainment_cartoon_animations.png" },
        };

    public static async Task<string> GetImageForCategoryAsync(string category)
    {
        return await Task.Run(() =>
        {
            return CategoryImages.TryGetValue(category, out var imagePath) ? imagePath : "C:\\Users\\sanyk\\Documents\\GitHub\\Trivia_API_Quiz\\TriviaAPI Quiz\\TriviaAPI Quiz\\Resources\\Image\\default.png";
        });
    }
}
