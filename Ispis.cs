using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagement
{
    public class Ispis
    {
        public void ispis(int Msgid)
        {
            switch (Msgid)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-----------Dodan admin-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-----------Dodan korisnik-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Korisnik uklonjen-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------Korisnik promjenjen------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Username vec postoji. pokusajte ponovno-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Korisnik nije pronadjen-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Pogresan unos. Pokusajte ponovo-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Nije moguce obrisati samoga sebe-----------");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }

        }
    }
}
