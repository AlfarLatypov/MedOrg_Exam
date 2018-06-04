using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedOrg.LIB.Users.Interfaces
{
    interface ISaver
    {
      void AdminXMLSerialize();
      void UserXMLSerialize(List<User> List_Users);
    }
}
