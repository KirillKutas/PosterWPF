using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PosterWPF.Sections
{
    partial class AllConcertHalls
    {
        public delegate void ClickGrid(GridConcertHalls gridConcertHalls);
        public event ClickGrid EventClickGrid;
        private void OutputElements()
        {
            Grid grid = new Grid();
            grid.Name = "grid1"; // имя потом брать из названия фильма
            grid.Height = 150;
            grid.MouseDown += Grid_MouseDown;

            Border border = new Border();
            border.Background = Brushes.WhiteSmoke;
            border.BorderThickness = new Thickness(1);
            border.Height = 4;

            MainStack.Children.Add(grid);
            MainStack.Children.Add(border);

            Image image = new Image();
            image.Height = 120;
            image.Width = 134;
            image.Margin = new Thickness(328, 15, 0, 0);
            image.VerticalAlignment = VerticalAlignment.Top;
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Stretch = Stretch.UniformToFill;
            image.Source = new BitmapImage(new Uri("E:/Kirill/Обои/21321.jpg"));
            grid.Children.Add(image);

            Label name = new Label();
            name.Content = "Name"; // имя взять из бд
            name.Margin = new Thickness(10, 15, 0, 0);
            name.FontFamily = new FontFamily("Times New Roman");
            name.FontSize = 28;
            name.Width = 288;
            name.FontWeight = FontWeights.Bold;
            name.VerticalAlignment = VerticalAlignment.Top;
            name.HorizontalAlignment = HorizontalAlignment.Left;
            grid.Children.Add(name);


            Label Address = new Label();
            Address.Content = "Address"; // имя взять из бд
            Address.Margin = new Thickness(10, 65, 0, 0);
            Address.FontFamily = new FontFamily("Times New Roman");
            Address.FontSize = 18;
            Address.Width = 288;
            Address.VerticalAlignment = VerticalAlignment.Top;
            Address.HorizontalAlignment = HorizontalAlignment.Left;
            grid.Children.Add(Address);
        }
        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EventClickGrid?.Invoke(new GridConcertHalls());
            EventClickGrid += MainWindow.EventClickGrid;
        }
    }
}
