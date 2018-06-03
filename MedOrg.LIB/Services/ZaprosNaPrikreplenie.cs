using MedOrg.LIB.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg.LIB.Services
{
    public class ZaprosNaPrikreplenie
    {
        static List<Patient> PatientQueue = new List<Patient>();

        public ZaprosNaPrikreplenie(Patient patient, MedOrganization medOrg)
        {
            Zpatient = patient;
            ZmedOrg = medOrg;
        }

        public Patient Zpatient { get; set; }
        public MedOrganization ZmedOrg { get; set; }
        

        public void CreateZapros()
        {
            //foreach (Patient item in medOrg)
            //{
            //    if ()
            //}

        }


    }
}
