using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TriviaAPI_Quiz.Services
{
    public static class StyleService
    {
        public static void AddEqualsLabelToGrid(Grid grid, int row)
        {
            // Створюємо новий Label
            Label equalsLabel = new Label
            {
                Content = new string('=', 28),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetRow(equalsLabel, row);
            Grid.SetColumn(equalsLabel, 2);
            Grid.SetColumnSpan(equalsLabel, 2);

            grid.Children.Add(equalsLabel);
        }
    }
}
