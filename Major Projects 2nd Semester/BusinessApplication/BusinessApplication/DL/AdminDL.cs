using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessApplication.BL;
using BusinessApplication.UI;
using System.IO;


namespace BusinessApplication.DL
{
    class AdminDL
    {
        static List<User> admins = new List<User>();

        public static void addIntoList(User admin)
        {
            admins.Add(admin);
            UserDL.addIntoList(admin);
        }


        public static List<User> getAdmins()
        {
            return admins;
        }

        public static bool isAnyAdminAvailable()
        {
            if (admins.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static void storeintoFile(string path)
        {
            StreamWriter f = new StreamWriter(path, append: false);
            foreach (User user in admins)
            {
                f.WriteLine(user.getID() + ",;," + user.getPassword());
            }
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(new string[] { ",;," }, StringSplitOptions.None); ;
                    string ID = splittedRecord[0];
                    string password = splittedRecord[1];
                    User admin = new Admin(ID, password);
                    AdminDL.addIntoList(admin);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }







    }
}
