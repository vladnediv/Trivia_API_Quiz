using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaAPI_Quiz.Model;

namespace TriviaAPI_Quiz.Context
{
    public class QuestionsDbContext : DbContext
    {
        public QuestionsDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Read connection string
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            string connectionString = configuration.GetConnectionString("QuestionsDatabase");

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<ApiResult> Questions { get; set; }
        public DbSet<QuizResult> Results { get; set; }
    }
}
