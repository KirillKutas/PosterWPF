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
                case "BookedConcerts": { grid = BookedConcerts; break; }
                case "BookedExhibitions": { grid = BookedExhibitions; break; }
                case "Users": { grid = Users; break; }
            }
            
            ChangeGrid((Grid)grid);
            refreshMICBdGrid();
            refreshFilmsBdGrid();
            refreshCinemasBdGrid();
            refreshCalendarBdGrid();
            refreshUsersBdGrid();
            refreshBKBdGrid();
            refreshConcertsBdGrid();
        }


        //////////////////////////////grids loaded///////////////////////////////////////
        private void Films_Loaded(object sender, RoutedEventArgs e)
        {
            refreshFilmsBdGrid();
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
            try
            {
                if (MICBdFrid.SelectedItem != null)
                {
                    MICClass mic = MICBdFrid.SelectedItem as MICClass;

                    MICDate.SelectedDate = mic.Date;
                    int indexFilm = FilmIdName.Items.IndexOf(mic.FilmName);
                    FilmIdName.SelectedItem = FilmIdName.Items.GetItemAt(indexFilm);
                    int indexCinema = CinemaIdName.Items.IndexOf(mic.CinemaName);
                    CinemaIdName.SelectedItem = CinemaIdName.Items.GetItemAt(indexCinema);
                    MICPrice.Text = mic.Price.ToString();
                    MICTime.Text = mic.Time;
                    MICFreeSpaces.Text = mic.FreeSpaces.ToString();
                    MICReservedSpaces.Text = mic.FreeSpaces.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MICAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                bdClassAdd.AddMIC(1, (DateTime)MICDate.SelectedDate, FilmIdName.SelectedItem.ToString(), CinemaIdName.SelectedItem.ToString(), Int32.Parse(MICPrice.Text), MICTime.Text, Int32.Parse(MICFreeSpaces.Text), Int32.Parse(MICReservedSpaces.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshMICBdGrid();
            }
        }

        private void MICSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MICClass mic = MICBdFrid.SelectedItem as MICClass;
                bdClassUpdate.UpdateMIC(mic.Id, (DateTime)MICDate.SelectedDate, FilmIdName.SelectedItem.ToString(), CinemaIdName.SelectedItem.ToString(), Int32.Parse(MICPrice.Text), MICTime.Text, Int32.Parse(MICFreeSpaces.Text), Int32.Parse(MICReservedSpaces.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshMICBdGrid();
            }
            
        }

        private void MICDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MICBdFrid.SelectedItem != null)
                {
                    MICClass mic = MICBdFrid.SelectedItem as MICClass;

                    bdClassDelete.DeleteMIC(mic.Id);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshMICBdGrid();
            }
            
        }


        /////////////////////////////////////Calendar event/////////////////////////////////////////////////////
        private void CalendarAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddDate(1, (DateTime)CalendarDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCalendarBdGrid();
            }
        }

        private void CalendarSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CalendarClass calendarClass = CalendarBdFrid.SelectedItem as CalendarClass;
                bdClassUpdate.UpdateDate(calendarClass.Id, (DateTime)CalendarDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCalendarBdGrid();
            }
        }

        private void CalendarDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CalendarBdFrid.SelectedItem != null)
                {
                    CalendarClass calendarClass = CalendarBdFrid.SelectedItem as CalendarClass;

                    bdClassDelete.DeleteDate(calendarClass.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshCalendarBdGrid();
            }
        }

        private void CalendarBdFrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CalendarBdFrid.SelectedItem != null)
                {
                    CalendarClass calendarClass = CalendarBdFrid.SelectedItem as CalendarClass;
                    CalendarDate.SelectedDate = calendarClass.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            refreshCalendarBdGrid();
        }

        ///////////////////////////////////////Users event///////////////////////////////////////
        private void Users_Loaded(object sender, RoutedEventArgs e)
        {
            refreshUsersBdGrid();
        }

        private void UsersBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (UsersBdGrid.SelectedItem != null)
                {
                    UsersClass usersClass = UsersBdGrid.SelectedItem as UsersClass;

                    UsersName.Text = usersClass.Name;
                    UsersMail.Text = usersClass.Mail;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsersAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddUser(1, UsersMail.Text, UsersName.Text, User.HashPassword(UsersPassword.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshUsersBdGrid();
            }
        }

        private void UsersSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersClass usersClass = UsersBdGrid.SelectedItem as UsersClass;
                bdClassUpdate.UpdateUser(usersClass.Id, UsersMail.Text, UsersName.Text, User.HashPassword(UsersPassword.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshUsersBdGrid();
            }
        }

        private void UsersDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersBdGrid.SelectedItem != null)
                {
                    UsersClass usersClass = UsersBdGrid.SelectedItem as UsersClass;

                    bdClassDelete.DeleteUser(usersClass.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshUsersBdGrid();
            }
        }

        ////////////////////////////////BookedMovies//////////////////////////////////////////////////
        private void BookedMoviesBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BookedMoviesBdGrid.SelectedItem != null)
                {
                    BKClass bKClass = BookedMoviesBdGrid.SelectedItem as BKClass;

                    BKFilm.Text = bKClass.Film;
                    BKMail.Text = bKClass.UserMail;
                    BKDate.SelectedDate = bKClass.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookedMovies_Loaded(object sender, RoutedEventArgs e)
        {
            refreshBKBdGrid();
        }

        private void BKAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdClassAdd.AddBK(1,BKMail.Text, BKFilm.Text, (DateTime)BKDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBKBdGrid();
            }
        }

        private void BKSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BKClass bkClass = BookedMoviesBdGrid.SelectedItem as BKClass;
                bdClassUpdate.UpdateBK(bkClass.Id, BKMail.Text, BKFilm.Text, (DateTime)BKDate.SelectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBKBdGrid();
            }
        }

        private void BKDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BookedMoviesBdGrid.SelectedItem != null)
                {
                    BKClass bKClass = BookedMoviesBdGrid.SelectedItem as BKClass;

                    bdClassDelete.DeleteBK(bKClass.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshBKBdGrid();
            }
        }

        ///////////////////////////////////Concerts event //////////////////////////////////////////////
        private void ConcertsBdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ConcertsBdGrid.SelectedItem != null)
                {
                    ConcertsClass concertsClass = ConcertsBdGrid.SelectedItem as ConcertsClass;

                    ConcertsName.Text = concertsClass.Name;
                    ConcertsGenre.Text = concertsClass.Genre;
                    ConcertsTime.Text = concertsClass.Time;
                    ConcertsDescription.Text = File.ReadAllText(concertsClass.Description);
                    imageByte = concertsClass.Photo;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(concertsClass.Photo);
                    image.EndInit();

                    ConcertsImage.Source = image;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Concerts_Loaded(object sender, RoutedEventArgs e)
        {
            refreshConcertsBdGrid();
        }

        private void ConcertsAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + ConcertsName.Text + "C" + ".txt";
                File.WriteAllText(pathDescription, ConcertsDescription.Text);
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassAdd.AddConcerts(1, ConcertsName.Text, pathDescription, ConcertsTime.Text, imagecode, ConcertsGenre.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertsBdGrid();
            }
        }

        private void CocnertsSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pathDescription = "../../Description/" + FilmsName.Text + "C" + ".txt";
                File.WriteAllText(pathDescription, ConcertsDescription.Text);
                ConcertsClass concertsClass = ConcertsBdGrid.SelectedItem as ConcertsClass;
                byte[] imagecode = null;
                if (imageByte == null)
                {

                    ImageToBD(ref imagecode);
                }
                else
                {
                    imagecode = imageByte;
                }

                bdClassUpdate.UpdateConcerts(concertsClass.Id, ConcertsName.Text, pathDescription, ConcertsTime.Text, imagecode, ConcertsGenre.Text);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertsBdGrid();
            }
        }

        private void ConcertsDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ConcertsBdGrid.SelectedItem != null)
                {
                    ConcertsClass concerts = ConcertsBdGrid.SelectedItem as ConcertsClass;

                    bdClassDelete.DeleteConcerts(concerts.Id);
                    string pathDescription = "../../Description/" + concerts.Name + "C" + ".txt";
                    File.Delete(pathDescription);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                refreshConcertsBdGrid();
            }
        }

        private void ConcertsChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imageByte = null;
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageSource = openDialog.FileName;
                ConcertsImage.Stretch = Stretch.Fill;
                ConcertsImage.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }
    }
}
