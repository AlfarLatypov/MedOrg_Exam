using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrg.LIB.Users;
using MedOrg.LIB;
using MedOrg.LIB.Classes;
using MedOrg_Exam;
using MedOrg.LIB.Services;

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
        public static bool exit = true;
        public void Dostup()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\t\t\t\tВойти как\n\t\t\t\t1 Админ\n\t\t\t\t2 Пользователь\n\t\t\t\t0 - Для выхода из программы ");
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


                        if (adm.Login == "admin" && adm.Password == "admin")
                        {
                            //  Console.WriteLine("OKOKOKOKOKOK!!!!!!");
                           // Menu menu = new Menu();
                            while (exit)
                            {
                                menu.StartAPP();
                            // return;
                           // break;
                            }

                        }
                        // }

                        break;
                    }
                case 2:
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\t\t\t\tНажмите\n\t\t\t\t1 - Посмотреть список доступных больниц\n\t\t\t\t2 - Создать запрос на прикрепление\n\t\t\t\t" +
                                "0 - Выход в главное меню");
                            Console.Write("\n\t\t\tВаш выбор - ");
                            choice = Int32.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\n\n\n\t\t\t\t\tСписок больниц\n\t\t\t\t\t - Сункар\n\t\t\t\t\t - Евразия\n\t\t\t\t\t - Медекер\n\t\t\t\t\t - Интертич");
                                        Console.ReadLine(); Console.Clear(); exit = true; break;
                                    }

                                case 2:
                                    {
                                        ZaprosNaPrikreplenie z = new ZaprosNaPrikreplenie();
                                        z.CreateZapros(); exit = true;
                                        break;
                                    }
                                case 0:
                                    {
                                        exit = true;  Console.Clear(); return;
                                    }

                            }
                        }

                    }
                case 0:
                    {
                        Program.yes = false; return;
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
