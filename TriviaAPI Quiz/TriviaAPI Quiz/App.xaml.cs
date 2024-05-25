using System.Configuration;
using System.Data;
using System.Windows;

namespace TriviaAPI_Quiz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Створюємо новий ResourceDictionary для вікна main
            ResourceDictionary mainWindow = new ResourceDictionary();
            mainWindow.Source = new Uri("Resources/Style/UIMainStyle.xaml", UriKind.Relative);

            // Створюємо новий ResourceDictionary для вікна category
            ResourceDictionary categoryWindow = new ResourceDictionary();
            categoryWindow.Source = new Uri("Resources/Style/UICategoryStyle.xaml", UriKind.Relative);
            
            // Створюємо новий ResourceDictionary для вікна category
            ResourceDictionary historyWindow = new ResourceDictionary();
            historyWindow.Source = new Uri("Resources/Style/UIHistoryStyle.xaml", UriKind.Relative);

            // Додаємо ці ResourceDictionary до Application рівня ресурсів
            Application.Current.Resources.MergedDictionaries.Add(mainWindow);
            Application.Current.Resources.MergedDictionaries.Add(categoryWindow);
            Application.Current.Resources.MergedDictionaries.Add(historyWindow);
        }
    }
}