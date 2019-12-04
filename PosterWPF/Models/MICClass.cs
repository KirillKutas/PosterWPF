using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class MICClass
    {
        public int Id;
        public DateTime Date;
        public string FilmName;
        public string CinemaName;
        public int Price;
        public string Time;
        public int FreeSpaces;
        public int ReservedSpaces;

        public MICClass(int Id, DateTime Date, string FilmName, string CinemaName, int Price, string Time, int FreeSpaces, int ReservedSpaces)
        {
            this.Id = Id;
            this.Date = Date;
            this.FilmName = FilmName;
            this.CinemaName = CinemaName;
            this.Price = Price;
            this.Time = Time;
            this.FreeSpaces = FreeSpaces;
            this.ReservedSpaces = ReservedSpaces;
        }
    }
}
