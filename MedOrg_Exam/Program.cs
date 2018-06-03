using MedOrg.LIB;
using MedOrg.LIB.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrg.LIB.Services;
using MedOrg.LIB.Users;

namespace MedOrg_Exam
{
    class Program
    {
        public static bool yes = true;
        static void Main(string[] args)
        {
               // Menu menu = new Menu();
           while (yes)
            {

                // menu.StartAPP();

                // SaveOrLoad load = new SaveOrLoad();
                // load.PatientXMLDeSerialize();
                // load.MedOrgXMLDeSerialize();
                // Admin ad = new Admin();
                Service s = new Service();
              //  s.CreateAdmin();
                s.Dostup() ;// Console.ReadLine();
               // return;
               if (!yes) return;
            }
        }
    }
}
