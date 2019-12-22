using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;

namespace PosterWPF.Sections
{
    /// <summary>
    /// Логика взаимодействия для VkLogin.xaml
    /// </summary>
    public partial class VkLogin : Window
    {
        public delegate void ClickGrid(SettingsPage settingsPage);
        public event ClickGrid EventOpenSettings;
        public VkLogin()
        {
            InitializeComponent();
        }

        private void TelephoneOrMail_GotFocus(object sender, RoutedEventArgs e)
        {
            TelephoneOrMail.Text = "";
            TelephoneOrMail.Foreground = Brushes.Black;
        }

        private void TelephoneOrMail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TelephoneOrMail.Text == "")
            {
                TelephoneOrMail.Foreground = Brushes.Gainsboro;
                TelephoneOrMail.Text = "Telephone or E-mail";
            }
                
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);
            try
            {

                api.Authorize(new ApiAuthParams
                {
                    ApplicationId = 123456,
                    Login = TelephoneOrMail.Text,
                    Password = Pass.Password
                });
                var account = api.Account.GetProfileInfo();
                BdClassGet bdClassGet = new BdClassGet();
                List<string> Mail = new List<string>();
                bdClassGet.GetAllUsers(Mail: Mail);
                int count = 0;
                foreach (var item in Mail)
                {
                    if (item == account.FirstName + "VK")
                    {
                        count++;
                    }
                }
                if(count == 0)
                {
                    BdClassAdd bdClassAdd = new BdClassAdd();
                    bdClassAdd.AddUser(1, account.FirstName + "VK", "VK", "VK");
                    User.Name = account.FirstName + "VK";
                    EventOpenSettings?.Invoke(new SettingsPage());
                    EventOpenSettings += MainWindow.EventClickGrid;
                    EventOpenSettings(new SettingsPage());
                }
                else
                {
                    if(bdClassGet.auth(account.FirstName + "VK", "VK"))
                    {
                        User.Name = account.FirstName + "VK";
                        EventOpenSettings?.Invoke(new SettingsPage());
                        EventOpenSettings += MainWindow.EventClickGrid;
                        EventOpenSettings(new SettingsPage());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
           
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
