using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TriviaAPI_Quiz.Services;

namespace TriviaAPI_Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded; // Додати асинхронний завантажувач
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await StyleService.AddEqualsLabelToGridAsync(myGrid, 1);
            await StyleService.AddEqualsLabelToGridAsync(myGrid, 5);

            //DataContext = new MainViewModel();
            //Icon = "pack://application:,,,/Resources/Image/QuizIcon.png"
            //Icon = "Resources/Image/QuizIcon.png"
        }
    }
}