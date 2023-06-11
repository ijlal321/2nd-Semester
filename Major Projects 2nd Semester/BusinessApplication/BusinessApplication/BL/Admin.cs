using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.BL
{
    class Admin : User
    {
        public Admin()
        {

        }

        public Admin(string ID, string password) : base (ID, password, "admin")
        {

        }
    }
}
