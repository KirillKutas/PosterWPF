using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (User.Name != null)
            {
                if (User.Name == "Admin")
                {
                    Button ApplicationManagement = new Button();
                    ApplicationManagement.Content = "Application management";
                    ApplicationManagement.Background = Brushes.White;
                    ApplicationManagement.Style = (Style)ApplicationManagement.FindResource("ButtonsStyle1");
                    ApplicationManagement.Height = 50;
                    ApplicationManagement.Width = 494;
                    ApplicationManagement.BorderThickness = new Thickness(0, 0, 0, 2);
                    ApplicationManagement.FontSize = 24;
                    ApplicationManagement.Click += ApplicationManagement_Click;
                    MainStack.Children.Add(ApplicationManagement);
                }

                Button PersonalAccount = new Button();
                PersonalAccount.Content = "Personal account";
                PersonalAccount.Background = Brushes.White;
                PersonalAccount.Style = (Style)PersonalAccount.FindResource("ButtonsStyle1");
                PersonalAccount.Height = 50;
                PersonalAccount.Width = 494;
                PersonalAccount.BorderThickness = new Thickness(0, 0, 0, 2);
                PersonalAccount.FontSize = 24;
                MainStack.Children.Add(PersonalAccount);

                Button LogOut = new Button();
                LogOut.Content = "Log out";
                LogOut.Background = Brushes.White;
                LogOut.Style = (Style)LogOut.FindResource("ButtonsStyle1");
                LogOut.Height = 50;
                LogOut.Width = 100;
                LogOut.BorderThickness = new Thickness(0, 0, 0, 2);
                LogOut.FontSize = 24;
                LogOut.Click += LogOut_Click;

                MainStack.Children.Add(LogOut);
            }
            else
            {
                Button SignIn = new Button();
                SignIn.Content = "Sign In";
                SignIn.Background = Brushes.White;
                SignIn.Style = (Style)SignIn.FindResource("ButtonsStyle1");
                SignIn.Height = 50;
                SignIn.Width = 494;
                SignIn.BorderThickness = new Thickness(0, 0, 0, 2);
                SignIn.FontSize = 24;
                SignIn.Click += SignIn_Click;

                MainStack.Children.Add(SignIn);
            }
        }

        private void ApplicationManagement_Click(object sender, RoutedEventArgs e)
        {
            var appM = new AppManagement();
            appM.Show();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage1.Children.Clear();
            SettingsPage1.Children.Add(new SignInForm());
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            User.Name = null;
            MainStack.Children.Clear();
            Button SignIn = new Button();
            SignIn.Content = "Sign In";
            SignIn.Background = Brushes.White;
            SignIn.Style = (Style)SignIn.FindResource("ButtonsStyle1");
            SignIn.Height = 50;
            SignIn.Width = 494;
            SignIn.BorderThickness = new Thickness(0, 0, 0, 2);
            SignIn.FontSize = 24;
            SignIn.Click += SignIn_Click;
            MainStack.Children.Add(SignIn);

            FileInfo fileInf = new FileInfo("CurrentUser.dat");
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }
}
