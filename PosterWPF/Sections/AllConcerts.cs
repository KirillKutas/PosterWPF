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
    partial class AllConcerts
    {
        public delegate void ClickGrid(GridConcerts gridConcerts);
        public event ClickGrid EventClickGrid;
        public void OutputElements()
        {
            Grid grid = new Grid();
            grid.Name = "grid1"; // имя потом брать из названия фильма
            grid.Height = 178;
            grid.MouseDown += Grid_MouseDown;

            Border border = new Border();
            border.Background = Brushes.WhiteSmoke;
            border.BorderThickness = new Thickness(1);
            border.Height = 4;

            MainStack.Children.Add(grid);
            MainStack.Children.Add(border);

            Image image = new Image();
            image.Height = 158;
            image.Width = 134;
            image.Margin = new Thickness(10, 10, 0, 0);
            image.VerticalAlignment = VerticalAlignment.Top;
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Stretch = Stretch.UniformToFill;
            image.Source = new BitmapImage(new Uri("E:/Kirill/Обои/21321.jpg"));
            grid.Children.Add(image);

            Label name = new Label();
            name.Content = "Name"; // имя взять из бд
            name.Margin = new Thickness(170, 10, 0, 0);
            name.FontFamily = new FontFamily("Times New Roman");
            name.FontSize = 24;
            name.Width = 314;
            name.FontWeight = FontWeights.Bold;
            name.VerticalAlignment = VerticalAlignment.Top;
            name.HorizontalAlignment = HorizontalAlignment.Left;
            grid.Children.Add(name);


            Label genre = new Label();
            genre.Content = "Genre"; // имя взять из бд
            genre.Margin = new Thickness(170, 50, 0, 0);
            genre.FontFamily = new FontFamily("Times New Roman");
            genre.FontSize = 18;
            genre.Width = 314;
            genre.VerticalAlignment = VerticalAlignment.Top;
            genre.HorizontalAlignment = HorizontalAlignment.Left;
            grid.Children.Add(genre);


            Label country = new Label();
            country.Content = "Time"; // имя взять из бд
            country.Margin = new Thickness(170, 80, 0, 0);
            country.FontFamily = new FontFamily("Times New Roman");
            country.FontSize = 18;
            country.Width = 314;
            country.VerticalAlignment = VerticalAlignment.Top;
            country.HorizontalAlignment = HorizontalAlignment.Left;
            grid.Children.Add(country);


        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EventClickGrid?.Invoke(new GridConcerts());
            EventClickGrid += MainWindow.EventClickGrid;
        }
    }
}
