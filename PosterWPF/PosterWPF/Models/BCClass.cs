using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class BCClass
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string Concert { get; set; }
        public DateTime Date { get; set; }

        public BCClass(int Id, string UserMail, string Concert, DateTime Date)
        {
            this.Id = Id;
            this.UserMail = UserMail;
            this.Concert = Concert;
            this.Date = Date;
        }
    }
}
