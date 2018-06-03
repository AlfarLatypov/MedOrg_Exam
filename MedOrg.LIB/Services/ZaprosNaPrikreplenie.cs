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

        public ZaprosNaPrikreplenie()
        {
                
        }
        public ZaprosNaPrikreplenie(Patient patient, MedOrganization medOrg)
        {
            Zpatient = patient;
            ZmedOrg = medOrg;
        }

        static int nomerZaprosa = 1001;
        public Patient Zpatient { get; set; }
        public MedOrganization ZmedOrg { get; set; }
        

        public void CreateZapros()
        {
            Console.Clear();
            Zpatient = new Patient();
            Console.Write("\n\n\t\t\tВведите фамилию - ");
            Zpatient.Familiya = Console.ReadLine();
            Console.Write("\n\t\t\tВведите Имя - ");
            Zpatient.Imya = Console.ReadLine();
            Console.Write("\n\t\t\tВведите Отчество - ");
            Zpatient.Otchestvo = Console.ReadLine();
            Console.Write("\n\t\t\tВведите ИИН - ");
            Zpatient.IIN = Int32.Parse(Console.ReadLine());
            Console.Write("\n\t\t\tВведите Название Больницы - ");
            Zpatient.MedOrgName = Console.ReadLine();
            
            PatientQueue.Add(Zpatient); nomerZaprosa++;
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tСоздан запрос {0} на прикрепление к Больнице <<{1}>>\n\t\t\t" +
                "Фамилия: {2}\n\t\t\tИмя:  {3}\n\t\t\tОтчество  {4}\n\t\t\tИИН: {5}", nomerZaprosa, Zpatient.MedOrgName, Zpatient.Familiya, 
                Zpatient.Imya, Zpatient.Otchestvo, Zpatient.IIN);
            Console.WriteLine("\n\n\t\t\tОжидайте с Вами свяжуться! :)");
            Console.ReadLine();
        }

        public List<Patient> getQueueZapros()
        {

            return PatientQueue;
        }



    }
}
