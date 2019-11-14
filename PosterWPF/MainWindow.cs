using System.Windows;
using System.Windows.Media.Animation;

namespace PosterWPF
{
    partial class MainWindow
    {
        private void MoveMenu(double x1, double x2)
        {
            var animation = new ThicknessAnimation();
            animation.From = new Thickness(x1, 10.091, 0, 0);
            animation.To = new Thickness(x2, 10.091, 0, 0);
            animation.SpeedRatio = 2;
            Menu.BeginAnimation(MarginProperty, animation);
        }
    }
}
