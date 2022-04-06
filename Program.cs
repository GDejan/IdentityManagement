// See https://aka.ms/new-console-template for more information

using IdentityManagement;
using System.Collections;

List<User> korisnici = new List<User>() 
{
    new User("pero", "peric", "ppero","1234"),
    new User("ana", "anic", "aana","1234"),
    new User("nika", "nikic", "nnika","1234"),
};

List<Admin> admins = new List<Admin>() 
{
    new Admin("admin","admin","admin", "1234"),
    new Admin("Masteradmin","Masteradmin","Masteradmin", "1234")
};

Ispis ispis = new Ispis();

do
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------Login-----------");
    Console.Write("Unesite username: ");
    string username = Console.ReadLine();
    Console.Write("Unesite password: " );
    string password=Console.ReadLine();
    
    Console.Clear();
    if (isUser(username, password))
    {
        #region user
        do
        {
            
            Console.WriteLine("-----------korisnik-----------");
            Console.Write("Unesite \n1: Pregled podataka, \n2: logout \n->  ");
            try
            {
                int unos = int.Parse(Console.ReadLine());
                if (unos == 2)
                {
                    break;
                }
                else if (unos == 1)
                {
                    foreach (User item in korisnici)
                    {
                        if (item.Username == username)
                        {
                            Console.WriteLine("Ime korisnika je {0}, prezime {1}, username {2}, password {3}", item.Ime, item.Prezime, item.Username, item.Password);
                        }
                    }
                }
                else 
                {
                    ispis.ispis(7);
                }
            }
            catch (Exception ex)
            {

                ispis.ispis(7);
            }

            
        } while (true);
       
    }
    #endregion
    #region admin
    else if (isAdmin(username, password))
    {
        bool logoutAdmin=false;
        do
        {
            try
            {
                Console.WriteLine("-----------administrator-----------");
                Console.Write("Unseite \n1: Pregled podataka usera \n2: logout \n3: Dodaj korisnika \n4: Izbrisi korisnika \n5: Azuriraj korisnika \n-> ");
                int unos = int.Parse(Console.ReadLine());

                if (unos == 1)
                {
                    Console.Clear();
                    Console.WriteLine("-----------ispis usera-----------");
                    foreach (User item in korisnici)
                    {
                        Console.WriteLine("Ime korisnika: {0}, prezime: {1}, username: {2}, password: {3}", item.Ime, item.Prezime, item.Username, item.Password);
                    }
                    Console.WriteLine("-----------ispis admina-----------");
                    foreach (Admin item in admins)
                    {
                        Console.WriteLine("Ime korisnika: {0}, prezime: {1}, username: {2}, password: {3}", item.Ime, item.Prezime, item.Username, item.Password);
                    }
                    Console.WriteLine("-----------kraj ispisa-----------");
                }
                else if (unos == 2)
                {
                    logoutAdmin = true;
                }
                else if (unos == 3)
                {
                    Console.WriteLine("-----------novi korisnik-----------");
                    Console.Write("unesite ime: ");
                    string Userime = Console.ReadLine();
                    Console.Write("unesite prezime: ");
                    string Userprezime = Console.ReadLine();
                    Console.Write("unesite username: ");
                    string Userusername = Console.ReadLine();
                    Console.Write("unesite pass: ");
                    string Userpass = Console.ReadLine();
                    Console.Write("is admin 1/0: ");
                    try
                    {
                        int ifIsAdmin = int.Parse(Console.ReadLine());

                        if (!checkUsers(Userusername)) //&& (checkAdmins(Userusername)))
                        {
                            if (ifIsAdmin == 1)
                            {
                                admins.Add(new Admin(Userime, Userprezime, Userusername, Userpass));
                                ispis.ispis(1);
                            }
                            else
                            {
                                korisnici.Add(new User(Userime, Userprezime, Userusername, Userpass));
                                ispis.ispis(2);
                            }
                        }
                        else
                        {
                            ispis.ispis(5);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (unos == 4)
                {
                    Console.WriteLine("-----------brisanje korisnika-----------");
                    Console.Write("username korisnika kojeg zelite obrisati: ");
                    string removeKorisnika = Console.ReadLine();


                    if ((removeKorisnika == username))
                    {
                        ispis.ispis(8);
                    }
                    else
                    {
                        if (RemoveUser(removeKorisnika))
                        {
                            ispis.ispis(3);
                        }
                        else
                        {
                            ispis.ispis(6);
                        }
                    }
                }
                else if (unos == 5)
                {
                    bool korisnikAzuriran = false;
                    do
                    {
                        Console.WriteLine("-----------azuriranje korisnika-----------");
                        Console.Write("username korisnika za azuriranje: ");
                        string staroIme = Console.ReadLine();
                        if (checkUsers(staroIme))
                        {
                            Console.Write("Novo ime-> ");
                            string NovoIme = Console.ReadLine();
                            Console.Write("Novo prezime-> ");
                            string NovoPrezime = Console.ReadLine();
                            Console.Write("Novi user-> ");
                            string NoviUser = Console.ReadLine();
                            Console.Write("Novi password-> ");
                            string Novipassword = Console.ReadLine();


                            if (!checkUsers(NoviUser)|| (NoviUser== staroIme))
                            {
                                try
                                {
                                    foreach (User item in korisnici)
                                    {
                                        if (item.Username == staroIme)
                                        {
                                            item.change(NovoIme, NovoPrezime, NoviUser, Novipassword);
                                            ispis.ispis(4);
                                            korisnikAzuriran = true;
                                        }
                                    }
                                    foreach (Admin item in admins)
                                    {
                                        if (item.Username == staroIme)
                                        {
                                            item.change(NovoIme, NovoPrezime, NoviUser, Novipassword);
                                            ispis.ispis(4);
                                            korisnikAzuriran = true;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                ispis.ispis(5);

                            }
                        }
                        else
                        {
                            ispis.ispis(6);
                            Console.Write("Natrag na selekciju opcija D/N:");
                            if (Console.ReadLine().ToLower()=="d")
                            {
                                korisnikAzuriran = true;
                            }

                        }
                    } while (!korisnikAzuriran);
                }
                else
                {
                    ispis.ispis(7);
                }
            }
            catch (Exception ex)
            {
                ispis.ispis(7);
            }
            
        } while (!logoutAdmin);
        #endregion
    }
    else 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Krivi login!!!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    Console.Write("Ponovni login! D/N: ");
    string noviLogin = Console.ReadLine().ToLower();

    if (noviLogin == "d")
    {
        Console.Clear();
        continue;
    }
    else
    {
        break;
    }

} while (true);


Console.WriteLine("izlaz");
Console.ReadLine();

//*****************lokalne metode****************************

bool isAdmin(string username, string password) 
{
    foreach (Admin item in admins)
    {
        if ((item.Username == username) && (item.Password == password))
        {
            return  true;
            break;
        }
    }
    return false;
}

bool isUser(string username, string password)
{
    foreach (Osobe item in korisnici)
    {
        if ((item.Username == username) && (item.Password == password))
        {
            return true;
            break;
        }
    }
    return false;
}

bool checkUsers(string username) 
{
    foreach (User item in korisnici)
    {
        if (item.Username==username)
        {
            return true;
        }
    }
    foreach (Admin item in admins)
    {
        if (item.Username == username)
        {
            return true;
        }
    }
    return false;
}


bool RemoveUser(string removeKorisnika)
{
    foreach (User item in korisnici)
    {
        if (item.Username == removeKorisnika)
        {
            korisnici.Remove(item);
            return true;
        }
    }
    foreach (Admin item in admins)
    {
            if ((item.Username == removeKorisnika))
            {
                admins.Remove(item);
                return true;
            }   
    }
    return false;
}
