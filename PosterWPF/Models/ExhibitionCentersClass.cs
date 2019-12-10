using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class ExhibitionCentersClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }

        public ExhibitionCentersClass(int Id, string Name, string Address, byte[] Photo)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.Photo = Photo;
        }
    }
}
