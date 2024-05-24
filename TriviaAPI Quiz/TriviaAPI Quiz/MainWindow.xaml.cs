﻿using System.Text;
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
            StyleService.AddEqualsLabelToGrid(myGrid, 1);
            StyleService.AddEqualsLabelToGrid(myGrid, 5);
            //DataContext = new MainViewModel();
            //Icon = "pack://application:,,,/Resources/Image/QuizIcon.png"
            //Icon = "Resources/Image/QuizIcon.png"
        }
    }
}