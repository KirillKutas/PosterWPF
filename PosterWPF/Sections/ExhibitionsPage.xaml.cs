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
    /// Логика взаимодействия для ExhibitionsPage.xaml
    /// </summary>
    public partial class ExhibitionsPage : UserControl
    {
        public ExhibitionsPage()
        {
            InitializeComponent();
        }

        private void Exhibition_Click(object sender, RoutedEventArgs e)
        {
            Exhibition.BorderThickness = new Thickness(0, 0, 1, 3);
            ExhibitionCenters.BorderThickness = new Thickness(1, 0, 0, 0);
            Output.Children.Clear();
            Output.Children.Add(new AllExhibition());
        }

        private void ExhibitionCenters_Click(object sender, RoutedEventArgs e)
        {
            Exhibition.BorderThickness = new Thickness(0, 0, 1, 0);
            ExhibitionCenters.BorderThickness = new Thickness(1, 0, 0, 3);
            Output.Children.Clear();
            Output.Children.Add(new AllExhibitionCenters());
        }

        private void MainExhibitionPage_Loaded(object sender, RoutedEventArgs e)
        {
            Date.Content = DateTime.Today;
            Output.Children.Add(new AllExhibition());
        }
    }
}
