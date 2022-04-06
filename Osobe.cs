using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagement
{
    public class Osobe
    {

        public string Ime { get; private set; }
        public string Prezime { get; private set; }
        public string Username { get; private set; }
        private string password;
        public string Password {
            get 
            {
                return password;
            }

            private set 
            {
                if (value.ToString().Length >= 4)
                {
                    password = value;
                }
                else 
                {
                   throw new Exception ("-----------Password mora biti duzi od 4 znaka-----------");
                }
            }
        }

        public Osobe(string ime, string prezime, string username, string password)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
        }

        public void change(string ime, string prezime, string username, string password) 
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
        }
    }
}
