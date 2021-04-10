using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class MICClass
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FilmName { get; set; }
        public string CinemaName { get; set; }
        public int Price { get; set; }
        public string Time { get; set; }
        public int FreeSpaces { get; set; }
        public int ReservedSpaces { get; set; }

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
