using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrg.LIB.Users;
using MedOrg.LIB;
using MedOrg.LIB.Classes;


namespace MedOrg.LIB.Users
{
    public class Service
    {
        int choice = 0;
        public Service()
        {
        }

        Admin adm = new Admin();
        List<Admin> admsss = null;
        SaveAndLoadUser sl = new SaveAndLoadUser();
        Menu menu = new Menu();
        public void Dostup()
        {
            Console.WriteLine("\n\n\n\t\t\t\tВойти как\n\t\t\t\t1 Админ\n\t\t\t\t2 Пользователь ");
            Console.Write("\n\t\t\tВаш выбор - ");
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("\n\n\n\t\t\t\tВведите логин - "); adm.Login = Console.ReadLine();
                        Console.Write("\n\t\t\t\tВведите Пароль - "); adm.Password = Console.ReadLine();
                       // admsss = sl.AdminXMLDeSerialize();
                        //foreach (Admin item in admsss)
                        //{
                        //    if((item.Login == adm.Login && item.Password == adm.Password) || (item.Login == "Alfar" && item.Password == "Admin"))
                         if(adm.Login == "Alfar" && adm.Password == "Admin")
                            {
                                Console.WriteLine("OKOKOKOKOKOK!!!!!!");
                            Menu menu = new Menu();
                        }
                       // }
                        
                        break;
                    }
            }
        }


        //public void CreateAdmin()
        //{
        //    Admin adminnn = new Admin();
        //    adminnn.Login = "Alfar";
        //    adminnn.Password = "Admin";
        //    sl.SaveAdmin(adminnn);
        //}

    }
}
