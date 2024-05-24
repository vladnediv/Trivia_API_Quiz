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

            // Створюємо новий ResourceDictionary для стилів Window1
            ResourceDictionary mainWindow = new ResourceDictionary();
            mainWindow.Source = new Uri("Resources/Style/UIMainStyle.xaml", UriKind.Relative);

            // Створюємо новий ResourceDictionary для стилів Window2
            ResourceDictionary window2Styles = new ResourceDictionary();
            //window2Styles.Source = new Uri("Resources/Window2Styles.xaml", UriKind.Relative);

            // Додаємо ці ResourceDictionary до Application рівня ресурсів
            Application.Current.Resources.MergedDictionaries.Add(mainWindow);
            Application.Current.Resources.MergedDictionaries.Add(window2Styles);
        }
    }
}