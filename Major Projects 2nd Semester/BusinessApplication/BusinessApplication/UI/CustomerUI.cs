using BusinessApplication.BL;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.UI
{
    class CustomerUI
    {
        public static Customer takeInputFromConsole()
        {
            Console.WriteLine("enter name");
            string ID = Console.ReadLine();

            Console.WriteLine("enter password");
            string password = Console.ReadLine();

            Customer customer = new Customer(ID, password);
            return customer;
        }

        public static void cancelFlight(User customer)
        {
            Console.WriteLine("chose a flight from below");

            if (customer.isAnyFlightBooked() == false)
            {
                Console.WriteLine("no flight booked");
            }
            else
            {
                BookedFlightUI.showMyFlights(customer);
                Console.WriteLine("enter flight you want to remove");
                int option = int.Parse(Console.ReadLine());

                customer.removeBookedFlightFromList(option);
                Console.WriteLine("flight removed");
            }
        }

        public static void changeFood(User customer)
        {
            Console.WriteLine("chose a flight from below");

            if (customer.isAnyFlightBooked() == false)
            {
                Console.WriteLine("no flight booked");
            }
            else
            {
                BookedFlightUI.showMyFlights(customer);
                Console.WriteLine("enter flight you want to changeFood");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine("enter new Food type");
                string newFood = Console.ReadLine();

                customer.changeFood(option, newFood);
            }
        }

        public static void fileComplain(User customer)
        {
            string complain;
            Console.WriteLine("enter complain you want to say");
            complain = Console.ReadLine();

            customer.addComplainIntoList(complain); 
        }

        public static void RemoveComplain(User customer)
        {
            List<string> complains = customer.getComplains();
            if (complains.Count == 0)
            {
                Console.WriteLine("no complains found");
            }
            else
            {
                Console.WriteLine("all complains are");

                for (int i = 0; i < complains.Count; i++)
                {
                    Console.Write(i + "  ");
                    printSingleComplain(complains[i]);
                }

                int option;
                Console.WriteLine("select complain you want to remove");
                option = int.Parse(Console.ReadLine());

                customer.removeComplainFromList(option);
            }
        }

        public static void showMyComplain(User customer)
        {
            List<string> complains = customer.getComplains();

            if (complains.Count == 0)
            {
                Console.WriteLine("no complains found");
            }
            else
            {
                for (int i = 0; i < complains.Count; i++)
                {
                    Console.Write(i + "  ");
                    printSingleComplain(complains[i]);
                }
                Console.WriteLine("enter complain you want to see");
                int option = int.Parse(Console.ReadLine());

                Console.WriteLine(complains[option]);
            }

        }
        
        public static void showAllComplains()
        {
            int counter = 0;
            List<User> customers = CustomerDL.getList();
            Console.WriteLine("index     CustomerID     Complain");
            foreach (Customer customer in customers)
            {
                List<string> comaplains = customer.getComplains();

                foreach (string complain in comaplains)
                {
                    Console.Write("{0}.    {1}    ", counter, customer.getID());
                    printSingleComplain(complain);
                    counter += 1;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("no complains found");
            }
            else
            {
                Console.WriteLine("enter complain you want to see");
                int option = int.Parse(Console.ReadLine());

                counter = 0;
                Console.WriteLine("index     CustomerID     Complain");
                foreach (Customer customer in CustomerDL.getList())
                {
                    List<string> comaplains = customer.getComplains();

                    foreach (string complain in comaplains)
                    {
                        if (counter == option)
                            Console.Write("{0}.    {1}    {2}", counter, customer.getID(), complain);
                        counter += 1;
                    }
                }
            }

        }

        public static void printSingleComplain(string complain)
        {

            if (complain.Length < 15)
            {
                Console.WriteLine(complain);
            }
            else
            {
                Console.WriteLine(complain.Substring(0, 15) + "  ...");
            }

        }

        public static void showAllCustomers()
        {
            List<User> customers = CustomerDL.getList();
            Console.WriteLine("Index       Name/ID      Password       Role");
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("{0}   {1}   {2}    {3}", i, customers[i].getID(), customers[i].getPassword(), customers[i].getRole());
            }
        }

    }
}
