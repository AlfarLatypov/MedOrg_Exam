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
        static void Main(string[] args)
        {
               // Menu menu = new Menu();
            while (true)
            {

                // menu.StartAPP();

                // SaveOrLoad load = new SaveOrLoad();
                // load.PatientXMLDeSerialize();
                // load.MedOrgXMLDeSerialize();
                // Admin ad = new Admin();
                Service s = new Service();
              //  s.CreateAdmin();
                s.Dostup() ; Console.ReadLine();
            }
        }
    }
}
