using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg.LIB.Classes
{
    /*1 Пациент (Фамилия, Имя, Отчество, ИИН)*/
    [Serializable]
    public class Patient
    {
        public Patient() { }
        public Patient(string familiya, string imya, string otchestvo, int iIN, string medOrgName)
        {
            Familiya = familiya;
            Imya = imya;
            Otchestvo = otchestvo;
            IIN = iIN;
            MedOrgName = medOrgName;
        }

        
        public string Familiya { get; set; }
        public string Imya { get; set; }
        public string Otchestvo { get; set; }
        public int IIN { get; set; }
        public string MedOrgName { get; set; }

        public void PacientInfo()
        {
            Console.WriteLine("\n\t\t\tФамилия: {0}\n\t\t\tИмя: {1}\n\t\t\tОтчество: {2}\n\t\t\tИИН: {3}\n\t\t\tБольница: {4}", Familiya, Imya, Otchestvo, IIN, MedOrgName);
            Console.WriteLine("\t\t\t---------------------");
        }
    }

}
