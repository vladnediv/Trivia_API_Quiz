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
        public static async Task AddEqualsLabelToGridAsync(Grid grid, int row)
        {
            // Створюємо новий Label
            Label equalsLabel = new Label
            {
                Content = new string('=', 28),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            
            await Task.Run(() =>
            {
                Grid.SetRow(equalsLabel, row);
                Grid.SetColumn(equalsLabel, 2);
                Grid.SetColumnSpan(equalsLabel, 2);

                // Додаємо Label до Grid
                grid.Children.Add(equalsLabel);
            });
        }
    }
}
