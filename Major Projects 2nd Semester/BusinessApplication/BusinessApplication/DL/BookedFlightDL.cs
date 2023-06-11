using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessApplication.BL;
using BusinessApplication.DL;
using System.IO;


namespace BusinessApplication.DL
{
    class BookedFlightDL
    {

        public static void storeintoFile(string path)
        {
            StreamWriter f = new StreamWriter(path, append: false);
            foreach (Customer customer in CustomerDL.getList())
            {
                foreach (BookedFlight bookedflight in customer.getBookedFlights())
                {
                    f.WriteLine(customer.getID() + ",;," + bookedflight.getFoodType() + ",;," + bookedflight.getFlight().getId());
                }
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
                    string customerID = splittedRecord[0];
                    string foodType = splittedRecord[1];
                    int flightUniqueID = int.Parse(splittedRecord[2]);

                    Flight flight = FlightDL.returnFlightByID(flightUniqueID);
                    User customer = CustomerDL.returnCustomerByID(customerID);

                    BookedFlight bookedflight = new BookedFlight(flight, foodType, customerID);
                    customer.addBookedFlightIntoList(bookedflight);

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
