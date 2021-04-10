using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class ConcertsClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public byte[] Photo { get; set; }
        public string Genre { get; set; }

        public ConcertsClass(int Id, string Name, string Description, string Time, byte[] Photo, string Genre)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Time = Time;
            this.Photo = Photo;
            this.Genre = Genre;
        }
    }
}
