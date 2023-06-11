using BusinessApplication.BL;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BusinessApplication.DL
{
    class CustomerDL
    {
        static List<User> customers = new List<User>();

        public static List<User> getList()
        {
            return customers;
        }

        public static void addIntoList(User customer)
        {
            customers.Add(customer);
            UserDL.addIntoList(customer);
        }

        public static void removeFromList(int option)
        {
            customers.RemoveAt(option);
        }
        public static void removeFromList(User customer)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].getID() == customer.getID())
                {
                    customers.RemoveAt(i);
                    break;
                }
            }
        }

        public static bool isAnyCustomerAvailable()
        {
            if (customers.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static void storeintoFile(string path)
        {
            StreamWriter f = new StreamWriter(path, append: false);
            foreach (Customer customer in customers)
            {
                f.WriteLine(customer.getID() + ",;," + customer.getPassword());
                string allComplains = string.Join(",;,", customer.getComplains());
                f.WriteLine(allComplains);
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

                    User customer = new Customer(ID, password); 

                    string complains = f.ReadLine();
                    List<string> complainsList = (complains.Split(new string[] { ",;," }, StringSplitOptions.None)).ToList()  ;

                    customer.setComplains(complainsList);
                    CustomerDL.addIntoList(customer);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static User returnCustomerByID(string ID)
        {
            foreach ( User customer in customers)
            {
                if (customer.getID() == ID)
                {
                    return customer;
                }
            }
            return null;
        }

    }
}
