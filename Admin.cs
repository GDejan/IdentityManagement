using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagement
{
    public class Admin:Osobe
    {
        public bool admin { get { return true; } }

        public Admin(string ime, string prezime, string username, string password)
        :base(ime, prezime,username,password)
        {
                
        }


    }
}
