using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagement
{
    public class User:Osobe
    {
        public bool admin { get { return false; } } 

        public User(string ime, string prezime, string username, string password)
        :base(ime, prezime, username, password)
        {
        }

    }
}
