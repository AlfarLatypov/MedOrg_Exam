using MedOrg.LIB.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MedOrg.LIB.Services
{
    [Serializable]
    public class SaveOrLoad
    {

        public SaveOrLoad()
        {
            Path_Patient = "Base_patients.xml";
            Path_MedOrg = "Base_MedOrgs.xml";
        }
       
            public SaveOrLoad(List<Patient> patients, List<MedOrganization> MedOrgList)
        {
            List_Patients = patients;
            List_MedOrg = MedOrgList;
            Path_Patient = "Base_patients.xml";
            Path_MedOrg = "Base_MedOrgs.xml";
        }
      
        
        private string Path_Patient { get ; set; }
        private string Path_MedOrg { get; set; }
        public List<Patient> List_Patients { get; set; }
        public List<MedOrganization> List_MedOrg { get; set; }

        #region SerializeToXML
        public void PatientXMLSerialize(List<Patient> List_Patients) //List<Patient> List_Patients
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Patient>));

            using (FileStream fs = new FileStream(Path_Patient, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, List_Patients);
            }
        }
        public void MedOrgXMLSerialize(List<MedOrganization> List_MedOrg)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<MedOrganization>));

            using (FileStream fs = new FileStream(Path_MedOrg, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, List_MedOrg);
                //Console.WriteLine("Serialize ok!");
            }
        }
        #endregion SerializeToXML

        #region XMLDeSerialize
        public List<Patient> PatientXMLDeSerialize()
        {
          
            XmlSerializer formatter = new XmlSerializer(typeof(List<Patient>));

            using (FileStream fs = new FileStream(Path_Patient, FileMode.OpenOrCreate))
            {
                List_Patients = (List<Patient>)formatter.Deserialize(fs);
                //Console.WriteLine("DeSerial OK!");
            }
            return List_Patients;
        }

        public List<MedOrganization> MedOrgXMLDeSerialize()
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<MedOrganization>));

            using (FileStream fs = new FileStream(Path_MedOrg, FileMode.OpenOrCreate))
            {
                List_MedOrg = (List<MedOrganization>)formatter.Deserialize(fs);
               // Console.WriteLine("DeSerial OK!");
            }
            return List_MedOrg;
        }

        #endregion XMLDeSerialize

    }
}
