using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class CalendarClass
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public CalendarClass(int Id, DateTime Date)
        {
            this.Id = Id;
            this.Date = Date;
        }
    }
}
