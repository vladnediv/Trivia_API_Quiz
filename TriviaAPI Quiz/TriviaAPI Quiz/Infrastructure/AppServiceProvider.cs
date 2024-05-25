using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaAPI_Quiz.Context;
using TriviaAPI_Quiz.Repository;
using TriviaAPI_Quiz.Service;
using TriviaAPI_Quiz.View;
using TriviaAPI_Quiz.ViewModel;

namespace TriviaAPI_Quiz.Infrastructure
{
    public static class AppServiceProvider
    {

        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Initialize()
        {
            var service = new ServiceCollection();

            //DbContext
            service.AddDbContext<QuestionsDbContext, QuestionsDbContext>();

            //Repository
            service.AddTransient<QuestionsRepositoryAsync, QuestionsRepositoryAsync>();
            service.AddTransient<QuizResultRepositoryAsync, QuizResultRepositoryAsync>();

            //Service
            service.AddTransient<TriviaApiService, TriviaApiService>();
            service.AddTransient<QuizQuestionsService, QuizQuestionsService>();
            service.AddTransient<QuizResultService, QuizResultService>();

            //ViewModel
            service.AddTransient<QuizViewModel,  QuizViewModel>();

            //View
            service.AddTransient<QuizWindow, QuizWindow>();


            ServiceProvider = service.BuildServiceProvider();
        }
    }
}