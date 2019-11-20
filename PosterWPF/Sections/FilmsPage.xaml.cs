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
    /// Логика взаимодействия для FilmsPage.xaml
    /// </summary>
    public partial class FilmsPage : UserControl
    {
        public FilmsPage()
        {
            InitializeComponent();
        }

        private void FilmsMenu_Click(object sender, RoutedEventArgs e)
        {
            FilmsMenu.BorderThickness = new Thickness(0, 0, 1, 3);
            CinemasMenu.BorderThickness = new Thickness(1,0,0,0);
        }

        private void CinemasMenu_Click(object sender, RoutedEventArgs e)
        {
            FilmsMenu.BorderThickness = new Thickness(0, 0, 1, 0);
            CinemasMenu.BorderThickness = new Thickness(1, 0, 0, 3);
        }

        private void MainFilmsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Date.Content = DateTime.Today;
            OutputElements();
        }
    }
}
