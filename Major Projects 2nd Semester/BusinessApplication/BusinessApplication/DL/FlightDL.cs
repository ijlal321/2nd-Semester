using BusinessApplication.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessApplication.DL
{
    class FlightDL
    {
        private static int uniqueIdCounter = 0;
        static List<Flight> flights = new List<Flight>();

        public static void addIntoList(Flight flight)
        {
            flight.setId(uniqueIdCounter);
            flights.Add(flight);
            uniqueIdCounter += 1;
        }

        public static List<Flight> getList()
        {
            return flights;
        }

        public static bool isAnyFlightAvailable()
        {
            if (flights.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static void removeFlight(int option)
        {
            flights.RemoveAt(option);
        }

        public static List<int> searchFlight(string departurePoint, string destination, string flightDate, string flightPrice)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < flights.Count; i++)
            {
                if (  ((flights[i].getDeparturePoint() == departurePoint) || departurePoint == "any" ) &&
                      ((flights[i].getDestination() == destination) || destination == "any" ) &&
                      ((flights[i].getFlightDate() == flightDate) || flightDate == "any" ) &&
                      ((flights[i].getFlightPrice() == flightPrice) || flightPrice == "any" )  
                    )
                {
                    indexes.Add(i);
                }
            }
            return indexes;

        }

        public static List<int> searchByDeparture(string departure)
        {
            List<int> indexes = new List<int>();

            for (int  i = 0; i < flights.Count; i++)
            {
                if (flights[i].getDeparturePoint() == departure)
                {
                    indexes.Add(i);
                }
            }
            return indexes;

        }

        public static void changePrice(int index, int newPrice)
        {
            flights[index].setFlightPrice(newPrice.ToString());
        }

        public static Flight getSpecificFlight(int option)
        {
            return flights[option];
        }

        public static void storeintoFile(string path)
        {
            StreamWriter f = new StreamWriter(path, append: false);
            foreach (Flight flight in flights)
            {
                f.WriteLine(flight.getId() + ",;," + flight.getDeparturePoint() + ",;," + flight.getDestination() + ",;," + flight.getFlightDate() + ",;," + flight.getFlightPrice());
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
                    int ID = int.Parse(splittedRecord[0]);
                    string departure = splittedRecord[1];
                    string destination = splittedRecord[2];
                    string date = splittedRecord[3];
                    string price = splittedRecord[4];

                    Flight flight = new Flight(departure, destination, date, price, ID);
                    FlightDL.addIntoList(flight);

                    if (uniqueIdCounter <= ID)
                    {
                        uniqueIdCounter = ID + 1;
                    }
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Flight returnFlightByID(int ID)
        {
            foreach( Flight flight in flights)
            {
                if (flight.getId() == ID)
                {
                    return flight;
                }
            }
            return null;
        }


    }
}
