using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class ConcertHallsClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }

        public ConcertHallsClass(int Id, string Name, string Address, byte[] Photo)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.Photo = Photo;
        }
    }
}
