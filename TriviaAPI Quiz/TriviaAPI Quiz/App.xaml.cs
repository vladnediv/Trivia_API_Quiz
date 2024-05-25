using System.Configuration;
using System.Data;
using System.Windows;
using TriviaAPI_Quiz.Infrastructure;
using TriviaAPI_Quiz.View;

namespace TriviaAPI_Quiz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      

        private void Application_Startup_1(object sender, StartupEventArgs e)
        {
            AppServiceProvider.Initialize();

            var window = (QuizWindow)AppServiceProvider.ServiceProvider.GetService(typeof(QuizWindow));
            window.Show();
        }
    }
}