using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg.LIB.Classes
{
    /*2.Мед Организация (Наименование)*/
    [Serializable]
    public class MedOrganization
    {
        public MedOrganization():this("","","")	
        {

        }
        public MedOrganization(string nameOrgan, string adres, string telNumber)
        {
            NameOrgan = nameOrgan;
            Adress = adres;
            TelNumber = telNumber;
            PatientList = new List<Patient>();
        }

        //2.	Мед Организация(Наименование, Адрес, Телефон)
        public int Id { get; set; }
        public string NameOrgan { get; set; }
        public string Adress { get; set; }
        public string TelNumber { get; set; }
        public List<Patient> PatientList { get; set; }


        public void MedOrganizationInfo()
        {
            
            Console.WriteLine("\n\t\t\t   ID Больницы: {0} \n\t\t\t   Название больницы: {1}\n\t\t\t   Адрес: " +
                "{2} \n\t\t\t   Контактный телефон: {3} \n\t\t\t", Id, NameOrgan, Adress, TelNumber);
            Console.WriteLine("\n\t\t\t Список пациентов:\n\t\t\t ---------------------------------\n\t\t\t  Фамилия     Имя       ИИН\n\t\t\t ---------------------------------");
            foreach (Patient patient in PatientList)
            {
                Console.WriteLine("\t\t\t  {1,-10} {2, -10} {3}", "    Пациент: {0} {1} ИИН:{2}", patient.Familiya, patient.Imya, patient.IIN);
            }
            Console.WriteLine("\t\t\t===========================================\n\t\t\t*******************************************\n\t\t\t===========================================\n\n");
        }



    }
}
