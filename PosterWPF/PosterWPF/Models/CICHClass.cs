using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class CICHClass
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ConcertsName { get; set; }
        public string ConcertHallsName { get; set; }
        public int Price { get; set; }
        public int FreeSpaces { get; set; }
        public int ReservedSpaces { get; set; }

        public CICHClass(int Id, DateTime Date, string FilmName, string CinemaName, int Price, int FreeSpaces, int ReservedSpaces)
        {
            this.Id = Id;
            this.Date = Date;
            this.ConcertsName = FilmName;
            this.ConcertHallsName = CinemaName;
            this.Price = Price;
            this.FreeSpaces = FreeSpaces;
            this.ReservedSpaces = ReservedSpaces;
        }
    }
}
