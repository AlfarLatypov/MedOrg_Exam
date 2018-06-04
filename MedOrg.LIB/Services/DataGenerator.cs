using MedOrg.LIB.Classes;
using MedOrg.LIB.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg.LIB
{

    public enum OrgName { Сункар = 1, Медекер, Интертич, Евразия, Незакреплен }
    public enum Streets { Абая86 = 1, ТолеБи77, Правда10, Шаляпина8, Ленина298, Моречика137, Розыбакиева12 }
    public enum LastName { Латыпов, Михалков, Игнатьев, Жаров, Васильев, Бабаев, Зайцев, Иванов }
    public enum Name { Сергей, Дмитрий, Ярослав, Олег, Руслан, Роман, Михаил, Антон }
    public enum Otchestvo { Егорович, Александрович, Яковлевич, Олегович, Дмитриевич, Иванович, Палович, Инокетьевич }


    public class DataGenerator
    { 
        private static Random rand = new Random();

        public DataGenerator() { }
        string PatientPath = "Base_patients.xml";
        string MedOrgPath = "Base_MedOrgs.xml";
        public List<Patient> PatientList = new List<Patient>();
       #region SPISOK_PATIENTOV

        public List<Patient> GenListPatients ()
        {
            FileInfo fi = new FileInfo(PatientPath);

            if (fi.Exists)
            {
                SaveOrLoad load = new SaveOrLoad();
                PatientList = (List<Patient>)load.PatientXMLDeSerialize();
               
            }
            else
                for (int i = 0; i < rand.Next(10, 20); i++)
            {
                string Familiya = ((LastName)rand.Next(1, 8)).ToString();
                string Imya = ((Name)rand.Next(1, 8)).ToString();
                string Otchestvo = ((Otchestvo)rand.Next(1, 8)).ToString();
                int IIN = rand.Next(100000000, 999999999);
                string nameOrg = ((OrgName)rand.Next(1, 6)).ToString();
                Patient patient = new Patient(Familiya, Imya, Otchestvo, IIN, nameOrg);
                PatientList.Add(patient);

            }
            return PatientList;

        }
        #endregion SPISOK_PATIENTOV

        public List<MedOrganization> MedOrgList = new List<MedOrganization>();

        #region SPISOK_ORGANIZACHII
        public List<MedOrganization> GenListMedOrg()
        {
            int i = 0;
            string NameOrgan = "";
            string Adres = "";
            string TelNumber = "";

            FileInfo fi = new FileInfo(MedOrgPath);

            if (fi.Exists)
            {
                SaveOrLoad load = new SaveOrLoad();
              MedOrgList = (List<MedOrganization>)load.MedOrgXMLDeSerialize();

            }
            else
            {

                do
                {
                    NameOrgan = ((OrgName)rand.Next(1, 5)).ToString();
                    if (isExist(MedOrgList, NameOrgan))
                        NameOrgan = ((OrgName)rand.Next(1, 5)).ToString();
                    else
                    {
                        Adres = ((Streets)rand.Next(1, 8)).ToString();
                        if (isExist(MedOrgList, NameOrgan, Adres))
                            Adres = ((Streets)rand.Next(1, 8)).ToString();
                        else
                        {
                            TelNumber = "+7" + (rand.Next(701, 708).ToString()) + (rand.Next(1000000, 9999999).ToString());
                            MedOrganization medOrganization = new MedOrganization(NameOrgan, Adres, TelNumber);
                            medOrganization.Id = rand.Next(100000, 999999);
                            foreach (Patient item in PatientList)
                            {
                                if (NameOrgan == item.MedOrgName)
                                {
                                    medOrganization.PatientList.Add(item);
                                }
                            }

                            MedOrgList.Add(medOrganization);
                            i++;
                        }
                    }


                } while (i < 4);
            }
            //foreach (MedOrganization item in MedOrgList)
            //{
            //    item.MedOrganizationInfo();
            //}

            return MedOrgList;
        }

        #endregion SPISOK_ORGANIZACHII

        #region PROVERKA
        public bool isExist(List<MedOrganization> MedOrgList, string NameOrgan)
        {
            foreach (MedOrganization item in MedOrgList)
            {
                if (item.NameOrgan == NameOrgan)
                    return true;
            }
            return false;
        }
        public bool isExist(List<MedOrganization> MedOrgList, string NameOrgan, string Adres)
        {
            foreach (MedOrganization item in MedOrgList)
            {
                if (item.Adress == Adres)
                    return true;
            }
            return false;
        }

        #endregion PROVERKA

    }
}
