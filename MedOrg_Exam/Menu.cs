using MedOrg.LIB;
using MedOrg.LIB.Classes;
using MedOrg.LIB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg_Exam
{
    class Menu
    {
        public Menu()
        {
         DataGenerator dg = new DataGenerator();
         this.patients = dg.GenListPatients();
         this.SaveLoad = new SaveOrLoad();
         this.medOrganization = dg.GenListMedOrg();
      
        }

        List<Patient> patients = new List<Patient>();
        List<MedOrganization> medOrganization = new List<MedOrganization>();
        SaveOrLoad SaveLoad = null;

        public void StartAPP()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t************************* M E N U *************************");
            Console.WriteLine("\t\t\tНажмите: \n\t\t\t   1 - База пациентов\n\t\t\t   2 - База медорганизаций" +
                "\n\t\t\t   3 - показать пациента\n\t\t\t   4 - показать медорганизацию\n\t\t\t   5 - Прикрепить пациента\n\t\t\t   0 - для выхода");
            Console.WriteLine("\n\t\t\t***********************************************************");
            int choice = 0;
            Console.Write("\n\t\t\tВаш выбор - ");
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\t\tСписок пациентов:");
                        
                        foreach (Patient item in patients) item.PacientInfo(); Console.ReadLine(); break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\t\t       Список медорганизаций:\n\n");  
                        foreach (MedOrganization item in medOrganization)
                        {
                            item.MedOrganizationInfo();
                        }
                        Console.ReadLine(); break;
                    }
                case 3:
                    {
                        Console.Clear(); FindPatient(); Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.Clear(); FindMedOrg(); Console.ReadLine();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        Prikreplenie();
                        //ZaprosNaPrikreplenie zapros = new ZaprosNaPrikreplenie();
                        //Console.WriteLine("\n\t\t\tСписок Больниц:");

                        break;
                    }
                case 0:
                    {
                        Console.Clear();
                       // SaveLoad = new SaveOrLoad(patients, medOrganization);
                        SaveLoad.PatientXMLSerialize(patients);
                        SaveLoad.MedOrgXMLSerialize(medOrganization);
                        return;
                    }
            }
        }

        #region POISK_PATIENTA
        public void FindPatient()
        {
            Console.WriteLine("\n\t\t\tСписок пациентов:\n\t\t\t---------------------------");
            foreach (Patient item in patients)
            {
                Console.WriteLine("\n\t\t\t" + item.Familiya + " " + item.Imya + " " + item.Otchestvo + " " + item.IIN);
            }
            Console.WriteLine("\n\t\t\t---------------------------\n\t\t\tПоиск пациентов:");
            Console.WriteLine("\t\t\tНажмите: \n\t\t\t   1 - по фамилии\n\t\t\t   2 - по имени" +
               "\n\t\t\t   3 - по отчеству\n\t\t\t   4 - по Фамилии и Имени\n\t\t\t   5 - по ИИН");
            Console.WriteLine("\t\t\t---------------------------");
            Console.Write("\t\t\tВаш выбор - ");
            int choice = Int32.Parse(Console.ReadLine());
            string find = "";

            switch (choice)
            {
                case 1:
                    {
                        bool yes = false;
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("\n\t\t\tВведите фамилию : ");

                            find = Console.ReadLine();
                            foreach (Patient item in patients)
                            {
                                if (item.Familiya == find)
                                {
                                    item.PacientInfo();
                                    yes = true; return;
                                }
                            }

                            if (!yes) { Console.WriteLine("\n\t\t\tПациента с такой фамилией нет! "); Console.ReadLine(); }
                        }

                    }
                case 2:
                    {
                        Console.Clear();
                        Console.Write("\n\t\t\tВведите Имя : ");

                        find = Console.ReadLine();
                        foreach (Patient item in patients)
                        {
                            if (item.Imya == find)
                                item.PacientInfo();
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.Write("\n\t\t\tВведите Отчество : ");

                        find = Console.ReadLine();
                        foreach (Patient item in patients)
                        {
                            if (item.Otchestvo == find)
                                item.PacientInfo();
                        }
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.Write("\n\t\t\tВведите Фамилию : ");
                        find = Console.ReadLine();
                        Console.Write("\n\t\t\tВведите Имя : ");
                        string find2 = Console.ReadLine();

                        foreach (Patient item in patients)
                        {
                            if (item.Familiya == find && item.Imya == find2)
                                item.PacientInfo();
                        }
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        Console.Write("\n\t\t\tВведите ИИН : ");

                        int find3 = Int32.Parse(Console.ReadLine());
                        foreach (Patient item in patients)
                        {
                            if (item.IIN == find3)
                                item.PacientInfo();
                        }
                        break;
                    }
            }


        }
        #endregion POISK_PATIENTA

        #region POISK_ORG
        public void FindMedOrg()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\tСписок Больниц:\n\t\t\t---------------------------\n\t\t\t  ID     Название    Телефон");
            foreach (MedOrganization item in medOrganization)
            {
                Console.WriteLine("\n\t\t\t" + item.Id + " " + item.NameOrgan + " " + item.TelNumber);
            }
            Console.WriteLine("\n\t\t\t---------------------------\n\t\t\tПоиск Организации:");
            Console.WriteLine("\t\t\tНажмите: \n\t\t\t   1 - по ID\n\t\t\t   2 - по Названию" +
               "\n\t\t\t   3 - по Телефону\n");
            Console.WriteLine("\t\t\t---------------------------");
            Console.Write("\t\t\tВаш выбор - ");
            int choice = Int32.Parse(Console.ReadLine());
            int find4;

            switch (choice)
            {
                case 1:
                    {
                        bool yes = false;
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("\n\t\t\tВведите ID Организации : ");

                            find4 = Int32.Parse(Console.ReadLine());
                            foreach (MedOrganization item in medOrganization)
                            {
                                if (item.Id == find4)
                                {
                                    item.MedOrganizationInfo(); Console.ReadLine(); yes = true; return;
                                }
                            }
                            if (!yes) { Console.WriteLine("\n\t\t\tТакой Больницы нет! "); Console.ReadLine(); }

                        }

                    }
                case 2:
                    {
                        Console.Clear();
                        Console.Write("\n\t\t\tВведите Название Организации : ");

                        string find5 = Console.ReadLine();
                        foreach (MedOrganization item in medOrganization)
                        {
                            if (item.NameOrgan == find5)
                            {
                                item.MedOrganizationInfo(); Console.ReadLine(); return;
                            }
                        }
                        break;
                    }
            }
        }

        #endregion POISK_ORG


        public void Prikreplenie()
        {
           
            int IIN = 0;
            bool yes = false;
            int choice = 0; ;


            while (true)
            {
                Console.Clear();
            Console.WriteLine("\n\n\t\t\t************************* M E N U PRIKREPLENIYA *************************");
            Console.WriteLine("\t\t\tНажмите: \n\t\t\t   1 - Список пациентов\n\t\t\t   2 - Список незакрепленных пациентов" +
                "\n\t\t\t   3 - Создать нового пациента\n\t\t\t   4 - показать список пациентов по медорганизациям\n\t\t\t   0 - для выхода");
            Console.WriteLine("\n\t\t\t*************************************************************************");
            Console.Write("\n\t\t\tВаш выбор - ");
            choice = Int32.Parse(Console.ReadLine());
                           
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tСписок пациентов:\n\t\t\tФамилия\t\tИмя\tОтчество\tИИН\tБольница");
                            foreach (Patient item in patients)
                                Console.WriteLine("\t\t\t" + item.Familiya + "\t" + item.Imya + "\t" + item.Otchestvo + "\t" + item.IIN + "\t" + item.MedOrgName);
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tСписок НЕзакрепленных пациентов:\n\t\t\tФамилия\t\tИмя\tОтчество\tИИН\tБольница");
                            foreach (Patient item in patients)
                            {
                                if (item.MedOrgName == "Незакреплен")
                                    Console.WriteLine("\t\t\t" + item.Familiya + "\t" + item.Imya + "\t" + item.Otchestvo + "\t" + item.IIN + "\t" + item.MedOrgName);
                            }
                            Console.Write("\n\t\t\tЗакрепить пациента? y/n - ");
                            string choice1 = (Console.ReadLine()).ToUpper();
                            if(choice1 == "Y")
                            {
                                while (true)
                                {
                                    Console.Write("\n\t\t\tВведите ИИН пациента - ");
                                    IIN = Int32.Parse(Console.ReadLine());
                                    foreach (Patient item in patients)
                                    {
                                        if (item.IIN == IIN)
                                        {
                                            Console.WriteLine("\n\t\t\t===============================================================" +
                                                "\n\t\t\t" + item.Familiya + "\t" + item.Imya + "\t" + item.Otchestvo + "\t" + item.IIN + "\t" + item.MedOrgName+"");
                                            Console.WriteLine("\t\t\t===============================================================");

                                           Console.WriteLine("\t\t\tВыберите больницу по номеру\n\t\t\t1 - Сункар\n\t\t\t2 - Медекер\n\t\t\t3 - Интертич\n\t\t\t4 - Евразия");
                                            Console.Write("\n\t\t\tВаш выбор - ");
                                            choice = Int32.Parse(Console.ReadLine());
                                            switch (choice)
                                            {
                                                case 1:
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\n\n\n\t\t\tПациент " + item.Familiya + " " + item.Imya + " " + item.Otchestvo +
                                                            " успешно закреплен в больнице Сункар");
                                                        item.MedOrgName = "Сункар";
                                                        foreach (MedOrganization item1 in medOrganization)
                                                        {
                                                            item1.PatientList.Add(item);
                                                        }
                                                        //SaveLoad = new SaveOrLoad(patients, medOrganization);
                                                        SaveLoad.PatientXMLSerialize(patients);
                                                        SaveLoad.MedOrgXMLSerialize(medOrganization);
                                                        Console.ReadLine(); return;
                                                    }
                                            }
                                                        yes = true; break; 
                                        }
                                    }
                                       if(!yes) Console.WriteLine("\n\t\t\tНеверный ИИН! Повторите ввод");
                                }
                            }
                            Console.ReadLine();
                            break;
                        }

                    case 3:
                        {
                            Console.Clear();
                            Patient pat = new Patient();
                            Console.Write("\n\n\t\t\t Введите фамилию - ");
                            pat.Familiya = Console.ReadLine();
                            Console.Write("\n\t\t\t Введите Имя - ");
                            pat.Imya = Console.ReadLine();
                            Console.Write("\n\t\t\t Введите ИИН - ");
                            pat.IIN = Int32.Parse(Console.ReadLine());
                            Console.Write("\n\t\t\t Введите номер больницы\n\t\t\t  1 - Сункар\n\t\t\t  2 - Медекер\n\t\t\t  3 - Интертич\n\t\t\t  4 - Евразия");
                            Console.Write("\n\t\t\tВаш выбор - ");
                            choice = Int32.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:{ pat.MedOrgName = "Сункар";
                                        foreach (MedOrganization item in medOrganization)
                                        {
                                            if (item.NameOrgan == "Сункар")
                                            {
                                                item.PatientList.Add(pat);
                                                patients.Add(pat);
                                            } 
                                        }

                                        break; }
                                case 2: { pat.MedOrgName = "Медекер"; break; }
                                case 3: { pat.MedOrgName = "Интертич"; break; }
                                case 4: { pat.MedOrgName = "Евразия"; break; }
                            }

                            
                           

                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            Console.Write("\n\t\t\t Введите номер больницы\n\t\t\t1 - Сункар\n\t\t\t2 - Медекер\n\t\t\t3 - Интертич\n\t\t\t4 - Евразия");
                            Console.Write("\n\t\t\tВаш выбор - ");
                            choice = Int32.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    {
                                        foreach (MedOrganization item in medOrganization)
                                        {
                                            if(item.NameOrgan == "Сункар")
                                            {
                                                foreach (Patient item1 in item.PatientList)
                                                {
                                                    item1.PacientInfo();
                                                }
                                            }
                                    }
                                        Console.ReadLine();  break;
                                        }
                                case 2:
                                    {
                                        foreach (MedOrganization item in medOrganization)
                                        {
                                            if (item.NameOrgan == "Медекер")
                                            {
                                                foreach (Patient item1 in item.PatientList)
                                                {
                                                    item1.PacientInfo();
                                                }
                                            }
                                        }
                                        Console.ReadLine(); break;
                                    }
                                case 3:
                                    {
                                        foreach (MedOrganization item in medOrganization)
                                        {
                                            if (item.NameOrgan == "Интертич")
                                            {
                                                foreach (Patient item1 in item.PatientList)
                                                {
                                                    item1.PacientInfo();
                                                }
                                            }
                                        }
                                        Console.ReadLine(); break;
                                    }
                                case 4:
                                    {
                                        foreach (MedOrganization item in medOrganization)
                                        {
                                            if (item.NameOrgan == "Евразия")
                                            {
                                                foreach (Patient item1 in item.PatientList)
                                                {
                                                    item1.PacientInfo();
                                                }
                                            }
                                        }
                                        Console.ReadLine(); break;
                                    }

                            }

                         
                            break;
                        }
                    case 0: return;

                }
            }
        }





    }
}
