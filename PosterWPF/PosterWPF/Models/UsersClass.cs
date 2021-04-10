using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF.Models
{
    class UsersClass
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public UsersClass(int Id, string Mail, string Name, string Password)
        {
            this.Id = Id;
            this.Mail = Mail;
            this.Name = Name;
            this.Password = Password;
        }

        
    }
}
