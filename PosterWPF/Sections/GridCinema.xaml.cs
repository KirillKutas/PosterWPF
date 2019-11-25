using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PosterWPF.Sections
{
    /// <summary>
    /// Логика взаимодействия для GridCinema.xaml
    /// </summary>
    public partial class GridCinema : UserControl
    {
        public delegate void CinemaDelegate(FilmsPage filmsPage);
        public event CinemaDelegate OpenCinema;

        public GridCinema()
        {
            InitializeComponent();
        }

        private void GridCinema1_Loaded(object sender, RoutedEventArgs e)
        {
            for (int a = 0; a < 10; a++)
            {
                Border border = new Border();
                border.Background = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(1);
                border.Height = 4;

                Grid grid = new Grid();
                grid.Name = "grid1"; // имя потом брать из названия фильма
                grid.Height = 150;

                MainStack.Children.Add(border);
                MainStack.Children.Add(grid);

                Label CinemaName = new Label();
                CinemaName.Content = "Name"; // из бд
                CinemaName.Margin = new Thickness(28, 15, 0, 0);
                CinemaName.FontFamily = new FontFamily("Times New Roman");
                CinemaName.FontSize = 21;
                CinemaName.FontWeight = FontWeights.Bold;

                Label Genre = new Label();
                Genre.Content = "Genre"; // из бд
                Genre.Margin = new Thickness(28, 45, 0, 0);
                Genre.FontFamily = new FontFamily("Times New Roman");
                Genre.FontSize = 16;

                Label Time = new Label();
                Time.Content = "Time"; // из бд
                Time.Margin = new Thickness(28, 75, 0, 0);
                Time.FontFamily = new FontFamily("Times New Roman");
                Time.FontSize = 18;
                Time.FontWeight = FontWeights.Bold;

                Label Price = new Label();
                Price.Content = "Price"; // из бд
                Price.Margin = new Thickness(28, 105, 0, 0);
                Price.FontFamily = new FontFamily("Times New Roman");
                Price.FontSize = 16;

                Button Buy = new Button();
                Buy.Margin = new Thickness(300, 0, 0, 0);
                Buy.Height = 35;
                Buy.Width = 80;
                Buy.Style = (Style)Buy.FindResource("BuyButtonStyle");

                grid.Children.Add(CinemaName);
                grid.Children.Add(Genre);
                grid.Children.Add(Price);
                grid.Children.Add(Time);
                grid.Children.Add(Buy);
            }

            OpenCinema?.Invoke(new FilmsPage());
            OpenCinema += MainWindow.OpenFilm;
            OpenCinema(new FilmsPage());
        }
    }
}
