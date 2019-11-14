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

namespace PosterWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




        private void AnimationMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Menu.Margin.Left != -248)
            {
                MoveMenu(Menu.Margin.Left, -248);
            }
            else
            {
                MoveMenu(-248, 0);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MoveMenu(Menu.Margin.Left, -248);
        }

        private void FilmsButton_Click(object sender, RoutedEventArgs e)
        {
            MoveMenu(Menu.Margin.Left, -248);
        }

        private void ConcertsButton_Click(object sender, RoutedEventArgs e)
        {
            MoveMenu(Menu.Margin.Left, -248);
        }

        private void ExhibitionButton_Click(object sender, RoutedEventArgs e)
        {
            MoveMenu(Menu.Margin.Left, -248);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MoveMenu(Menu.Margin.Left, -248);
        }
    }
}
