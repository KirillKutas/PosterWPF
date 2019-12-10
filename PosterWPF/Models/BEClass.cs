using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class BEClass
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string Exhibition { get; set; }
        public DateTime Date { get; set; }

        public BEClass(int Id, string UserMail, string Exhibition, DateTime Date)
        {
            this.Id = Id;
            this.UserMail = UserMail;
            this.Exhibition = Exhibition;
            this.Date = Date;
        }
    }
}
