using MedOrg.LIB.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MedOrg.LIB.Users
{
    [Serializable]
    public class SaveAndLoadUser : ISaver 
    {
        public SaveAndLoadUser()
        {
            string AdminPath = "Base_Admins.xml";
            string UserPath = "Base_Users.xml";
            Admin = new Admin();
            Admins = new List<Admin>();
            User = new User();
            Users = new List<User>();
        }
        public Admin Admin { get; set; }
        public List<Admin> Admins { get; set; }
        public string AdminPath { get; set; }

        public User User { get; set; }
        public List<User> Users { get; set; }
        public string UserPath { get; set; }

        public void SaveAdmin(Admin Admin)
        {
            //this.Admin = Admin;
            this.Admins.Add(Admin);
            AdminXMLSerialize();
        }

        public void SaveUser(User User)
        {
            this.User = User;
            this.Users.Add(User);
            UserXMLSerialize(Users);
        }


        //----------------------------------------------------------------------------------
        public void AdminXMLSerialize() 
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Admin>));

            using (FileStream fs = new FileStream(AdminPath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Admins);
            }
        }
        
        public void UserXMLSerialize(List<User> List_Users)
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream(UserPath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, List_Users);
            }
        }
        //----------------------------------------------------------------------------------


        public List<Admin> AdminXMLDeSerialize()
        {
            FileInfo fi = new FileInfo(AdminPath);
            if (fi.Exists)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Admin>));

                using (FileStream fs = new FileStream(AdminPath, FileMode.OpenOrCreate))
                {
                    Admins = (List<Admin>)formatter.Deserialize(fs);
                    //Console.WriteLine("DeSerial OK!");
                }
                return Admins;
            }
            else { Admin tempAdmin = new Admin(); Admins.Add(tempAdmin); }
            return Admins;
        }
        public List<User> UserXMLDeSerialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream(UserPath, FileMode.OpenOrCreate))
            {
                Users = (List<User>)formatter.Deserialize(fs);
                //Console.WriteLine("DeSerial OK!");
            }
            return Users;
        }

        //----------------------------------------------------------------------------------
    }
}
