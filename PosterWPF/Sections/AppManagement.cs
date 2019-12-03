using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PosterWPF.Sections
{
    public partial class AppManagement : Window
    {
        private string ImageSource { get; set; }


        void ChangeGrid(Grid grid)
        {
            for (int i = 1; i < MainGrid.Children.Count; i++)
            {
                MainGrid.Children[i].Visibility = Visibility.Hidden;
            }
            grid.Visibility = Visibility.Visible;
        }
    }
}
