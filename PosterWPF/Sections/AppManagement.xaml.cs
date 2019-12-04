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
        BdClassDelete bdClassDelete = new BdClassDelete();
        BdClassUpdate bdClassUpdate = new BdClassUpdate();

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


        //////////////////////////////grids loaded///////////////////////////////////////
        private void Films_Loaded(object sender, RoutedEventArgs e)
        {
            refreshFilmsBdGrid();
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

        /////////////////////////////////Films event ///////////////////////////////////////////////////////////
        private void FilmsAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + FilmsName.Text + ".txt";
                File.WriteAllText(pathDescription, FilmsDescription.Text);
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddFilm(FilmsBdFrid.Items.Count, FilmsName.Text, pathDescription, imagecode, FilmsGenre.Text, FilmsCountry.Text, FilmsDuration.Text);
                refreshFilmsBdGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FilmsSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + FilmsName.Text + ".txt";
                File.WriteAllText(pathDescription, FilmsDescription.Text);
                FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateFilm(film.Id, FilmsName.Text, pathDescription, imagecode, FilmsGenre.Text, FilmsCountry.Text, FilmsDuration.Text);
                refreshFilmsBdGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FilmsDelete_Click(object sender, RoutedEventArgs e)
        {
            if(FilmsBdFrid.SelectedItem!=null)
            {
                FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;

                bdClassDelete.DeleteFilms(film.Id);
                string pathDescription = "../../Description/" + film.Name + ".txt";
                File.Delete(pathDescription);
                refreshFilmsBdGrid();
            }
        }

        private void FilmsChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
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
            if (FilmsBdFrid.SelectedItem != null)
            {
                FilmsClass film = FilmsBdFrid.SelectedItem as FilmsClass;

                FilmsName.Text = film.Name;
                FilmsGenre.Text = film.Genre;
                FilmsCountry.Text = film.Country;
                FilmsDuration.Text = film.Duration;
                FilmsDescription.Text = File.ReadAllText(film.DescriptionAndActors);
                imageByte = film.Photo;

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(film.Photo);
                image.EndInit();

                FilmsImage.Source = image;
                
            }
            
        }
        ///////////////////////////////////Cinemas event ////////////////////////////////////
        private void CinemasBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CinemasBdFrid.SelectedItem != null)
            {
                CinemasClass cinema = CinemasBdFrid.SelectedItem as CinemasClass;

                CinemasName.Text = cinema.Name;
                CinemasAddress.Text = cinema.Address;
                imageByte = cinema.Photo;

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(cinema.Photo);
                image.EndInit();

                CinemasImage.Source = image;
            }
        }

        private void CinemasAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddCinema(CinemasBdFrid.Items.Count, CinemasName.Text, CinemasAddress.Text, imagecode);
                refreshCinemasBdGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CinemasSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CinemasClass cinema = CinemasBdFrid.SelectedItem as CinemasClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateCinemas(cinema.Id, CinemasName.Text, CinemasAddress.Text, imagecode);
                refreshCinemasBdGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CinemasDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CinemasBdFrid.SelectedItem != null)
            {
                CinemasClass cinema = CinemasBdFrid.SelectedItem as CinemasClass;

                bdClassDelete.DeleteCinema(cinema.Id);
                refreshCinemasBdGrid();
            }
        }

        private void CinemasChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                CinemasImage.Stretch = Stretch.Fill;
                CinemasImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void Cinemas_Loaded(object sender, RoutedEventArgs e)
        {
            refreshCinemasBdGrid();
        }



        /////////////////////////////////////MIC event////////////////////////////////////////////////////
        private void MoviesInCinemas_Loaded(object sender, RoutedEventArgs e)
        {
            refreshMICBdGrid();
        }

        private void MICBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MICAdd_Click(object sender, RoutedEventArgs e)
        {
            refreshMICBdGrid();
        }

        private void MICSave_Click(object sender, RoutedEventArgs e)
        {
            refreshMICBdGrid();
        }

        private void MICDelete_Click(object sender, RoutedEventArgs e)
        {
            refreshMICBdGrid();
        }
    }
}
