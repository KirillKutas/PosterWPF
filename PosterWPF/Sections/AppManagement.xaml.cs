using Microsoft.Win32;
using PosterWPF.Models;
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
using System.Windows.Shapes;

namespace PosterWPF.Sections
{
    /// <summary>
    /// Логика взаимодействия для AppManagement.xaml
    /// </summary>
    public partial class AppManagement : Window
    {
        BdClassGet bdClassGet = new BdClassGet();
        BdClassAdd bdClassAdd = new BdClassAdd();

        public AppManagement()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            BdList.SelectedItem = ComboBoxFilms;
            ChangeGrid(Films);
        }

        private void BdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object grid = Films;
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            switch (selectedItem.Text)
            {
                case "Films": { grid = Films;  break; }
                case "Cinemas": { grid = Cinemas; break; }
                case "MoviesInCinemas": { grid = MoviesInCinemas; break; }
                case "Concerts": { grid = Concerts; break; }
                case "ConcertHalls": { grid = ConcertHalls; break; }
                case "ConcertsInConcertHalls": { grid = ConcertsInConcertHalls; break; }
                case "Exhibitions": { grid = Exhibitions; break; }
                case "ExhibitionCenters": { grid = ExhibitionCenters; break; }
                case "ExhibitionsInExhibitionCenters": { grid = ExhibitionsInExhibitionCenters; break; }
                case "Calendar": { grid = Calendar; break; }
                case "BookedMovies": { grid = BookedMovies; break; }
                case "Users": { grid = Users; break; }
            }
            
            ChangeGrid((Grid)grid);
        }

        private void Films_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> DescriptionAndActors = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Country = new List<string>();
            List<string> Duration = new List<string>();

            bdClassGet.GetAllFilms(Id, Name, DescriptionAndActors, Photo, Genre, Country, Duration);

            List<FilmsClass> filmsClasses = new List<FilmsClass>();
            for(int iterator = 0; iterator < Id.Count; iterator++)
            {
                filmsClasses.Add(new FilmsClass(Id[iterator], Name[iterator], DescriptionAndActors[iterator], Photo[iterator], Genre[iterator], Country[iterator], Duration[iterator]));
            }

            FilmsBdFrid.ItemsSource = filmsClasses;
        }

        private void Users_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> Id = new List<int>();
            List<string> Mail = new List<string>();
            List<string> Name = new List<string>();
            List<string> Password = new List<string>();

            bdClassGet.GetAllUsers(Mail, Name, Password, Id);

            List<UsersClass> usersClasses = new List<UsersClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                usersClasses.Add(new UsersClass(Id[iterator], Mail[iterator], Name[iterator], Password[iterator]));
            }

            UsersBdGrid.ItemsSource = usersClasses;
        }

        private void FilmsAdd_Click(object sender, RoutedEventArgs e)
        {
            string pathDescription = "../../Description/" + FilmsName.Text + ".txt";
            File.WriteAllText(pathDescription, FilmsDescription.Text);

            FileStream fs = new FileStream(ImageSource, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] imagecode = br.ReadBytes((Int32)fs.Length);

            bdClassAdd.AddFilm(FilmsBdFrid.Items.Count, FilmsName.Text, pathDescription, imagecode, FilmsGenre.Text, FilmsCountry.Text, FilmsDuration.Text);
        }

        private void FilmsSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilmsDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilmsChangeImage_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                FilmsImage.Stretch = Stretch.Fill;
                FilmsImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void FilmsBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;

            FilmsName.Text = film.Name;
            FilmsGenre.Text = film.Genre;
            FilmsCountry.Text = film.Country;
            FilmsDuration.Text = film.Duration;
            FilmsDescription.Text = File.ReadAllText(film.DescriptionAndActors);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(film.Photo);
            image.EndInit();

            FilmsImage.Source = image;
        }
    }
}
