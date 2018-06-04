using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg.LIB.Users
{
    public class Admin : User
    {
        
        public Admin()
        {
            Login = "Alfar";
            Password = "admin";
            Status = "Admin";
        }

        public string Status { get; set; }

    }
}
