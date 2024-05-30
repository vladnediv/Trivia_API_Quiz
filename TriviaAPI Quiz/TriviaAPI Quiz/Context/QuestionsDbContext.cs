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
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Read connection string
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            string connectionString = configuration.GetConnectionString("QuestionsDatabase");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiResultDb>().HasMany(result => result.ApiResults).WithOne(element => element.ApiResult);
        }

        public DbSet<ApiResultElementDb> Questions { get; set; }
        public DbSet<ApiResultDb> ApiResults { get; set; }
        public DbSet<QuizResult> UserResults { get; set; }
    }
}
