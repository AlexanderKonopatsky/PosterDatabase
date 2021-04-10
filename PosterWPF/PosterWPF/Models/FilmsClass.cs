using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class FilmsClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionAndActors { get; set; }
        public byte[] Photo { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Duration { get; set; }
        public FilmsClass(int Id, string Name, string DescriptionAndActors, byte[] Photo, string Genre, string Country, string Duration)
        {
            this.Id = Id;
            this.Name = Name;
            this.DescriptionAndActors = DescriptionAndActors;
            this.Photo = Photo;
            this.Genre = Genre;
            this.Country = Country;
            this.Duration = Duration;
        }
    }
}
