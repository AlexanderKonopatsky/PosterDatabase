using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class BMClass
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string Film { get; set; }
        public DateTime Date { get; set; }

        public BMClass(int Id, string UserMail, string Film, DateTime Date)
        {
            this.Id = Id;
            this.UserMail = UserMail;
            this.Film = Film;
            this.Date = Date;
        }
    }
}
