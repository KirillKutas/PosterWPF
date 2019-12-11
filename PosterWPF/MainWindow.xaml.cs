﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using PosterWPF.Sections;

namespace PosterWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow LinkToMainWindow;
        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Poster_Loaded(object sender, RoutedEventArgs e)
        {
            SetGridChildren(MainBody, new FilmsPage());
            LinkToMainWindow = this;
            FileInfo fileInfo = new FileInfo("CurrentUser.dat");
            if (fileInfo.Exists)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("CurrentUser.dat", FileMode.OpenOrCreate))
                {
                    User.Name = (string)formatter.Deserialize(fs);
                }
            }
            User.Date = DateTime.Today;
        }

        private void Poster_Closed(object sender, EventArgs e)
        {
            if (User.Name != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("CurrentUser.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, User.Name);
                }
            }
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
            RenameSection(sender as Button);
            MoveMenu(Menu.Margin.Left, -248);
            SetGridChildren(MainBody, new SearchPage());
        }

        private void FilmsButton_Click(object sender, RoutedEventArgs e)
        {
            RenameSection(sender as Button);
            MoveMenu(Menu.Margin.Left, -248);
            SetGridChildren(MainBody, filmsPage);
            
        }

        

        private void ConcertsButton_Click(object sender, RoutedEventArgs e)
        {
            RenameSection(sender as Button);
            MoveMenu(Menu.Margin.Left, -248);
            SetGridChildren(MainBody, new ConcertsPage());
        }

        private void ExhibitionButton_Click(object sender, RoutedEventArgs e)
        {
            RenameSection(sender as Button);
            MoveMenu(Menu.Margin.Left, -248);
            SetGridChildren(MainBody, new ExhibitionsPage());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            RenameSection(sender as Button);
            MoveMenu(Menu.Margin.Left, -248);
            SetGridChildren(MainBody, new SettingsPage());
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            OpenCalendar.Visibility = Visibility.Visible;
            SetGridChildren(OpenCalendar, calendarPage);
            OpenCalendar.MouseLeave += OpenCalendar_MouseLeave;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SetGridChildren(MainBody, BackToFilms);
            AnimationMenu.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Hidden;
            Calendar.Visibility = Visibility.Visible;
        }

        private void OpenCalendar_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenCalendar.Visibility = Visibility.Hidden;
        }

        
    }
}
