using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class EIECClass
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ExhibitionName { get; set; }
        public string ExhibitionHallsName { get; set; }
        public int Price { get; set; }
        public int FreeSpaces { get; set; }
        public int ReservedSpaces { get; set; }

        public EIECClass(int Id, DateTime Date, string ExhibitionName, string ExhibitionHallsName, int Price, int FreeSpaces, int ReservedSpaces)
        {
            this.Id = Id;
            this.Date = Date;
            this.ExhibitionName = ExhibitionName;
            this.ExhibitionHallsName = ExhibitionHallsName;
            this.Price = Price;
            this.FreeSpaces = FreeSpaces;
            this.ReservedSpaces = ReservedSpaces;
        }
    }
}
