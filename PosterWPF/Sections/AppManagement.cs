using PosterWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private byte[] imageByte { get; set; }

        void ChangeGrid(Grid grid)
        {
            for (int i = 1; i < MainGrid.Children.Count; i++)
            {
                MainGrid.Children[i].Visibility = Visibility.Hidden;
            }
            grid.Visibility = Visibility.Visible;
        }

        void refreshFilmsBdGrid()
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
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                filmsClasses.Add(new FilmsClass(Id[iterator], Name[iterator], DescriptionAndActors[iterator], Photo[iterator], Genre[iterator], Country[iterator], Duration[iterator]));
            }

            FilmsBdFrid.ItemsSource = filmsClasses;
        }
        void refreshCinemasBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();

            bdClassGet.GetAllCinemas(Id, Name, Address, Photo);

            List<CinemasClass> cinemasClasses = new List<CinemasClass>();
            for(int iterator = 0; iterator < Id.Count; iterator++)
            {
                cinemasClasses.Add(new CinemasClass(Id[iterator], Name[iterator], Address[iterator], Photo[iterator]));
            }

            CinemasBdFrid.ItemsSource = cinemasClasses;
        }

        void refreshMICBdGrid()
        {
            List<int> Id = new List<int>();
            List<DateTime> Date = new List<DateTime>();
            List<string> FilmName = new List<string>();
            List<string> CinemaName = new List<string>();
            List<int> Price = new List<int>();
            List<string> Time = new List<string>();
            List<int> FreeSpaces = new List<int>();
            List<int> ReservedSpaces = new List<int>();

            bdClassGet.GetAllMIC(Id, Date, FilmName, CinemaName, Price, Time, FreeSpaces, ReservedSpaces);

            List<MICClass> mICClasses = new List<MICClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                mICClasses.Add(new MICClass(Id[iterator], Date[iterator], FilmName[iterator], CinemaName[iterator], Price[iterator], Time[iterator], FreeSpaces[iterator], ReservedSpaces[iterator]));
            }

            MICBdFrid.ItemsSource = mICClasses;
        }

        void ImageToBD(ref byte[] imagecode)
        {
            FileStream fs = new FileStream(ImageSource, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagecode = br.ReadBytes((Int32)fs.Length);
        }
    }
}
