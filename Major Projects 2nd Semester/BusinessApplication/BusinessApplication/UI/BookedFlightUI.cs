using BusinessApplication.BL;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.UI
{
    class BookedFlightUI
    {
        public static BookedFlight takeInputFromConsole()
        {
            Console.WriteLine("enter information of flight or type any");
            Flight flight = FlightUI.takeInputFromConsole();


            List<int> indexes = FlightDL.searchFlight(flight.getDeparturePoint(), flight.getDestination(), flight.getFlightDate(), flight.getFlightPrice());

            if ( indexes.Count == 0)
            {
                Console.WriteLine("no flight available");
                return null;
            }
            else
            {
                Console.WriteLine("avavilable flights are  ");
                FlightUI.showSpecificIndexFlight(indexes);

                Console.WriteLine("enter flight you want to book");
                int option = int.Parse(Console.ReadLine());

                Console.WriteLine("enter food type, veg / non-veg");
                string foodType = Console.ReadLine();

                BookedFlight bookedFlight = new BookedFlight(FlightDL.getList()[indexes[option]], foodType );

                return bookedFlight;
            }

        }

        public static void showMyFlights(User customer)   // modify it later so it works on current user
                                                          // instead of passing argument
        {
            List<BookedFlight> bookedFlights = customer.getBookedFlights();

            if (bookedFlights.Count == 0)
            {
                Console.WriteLine("no flights found");
            }
            else
            {
                Console.WriteLine("index     Departure      Destination     Date      Price      FoodType");
                for (int i = 0; i < bookedFlights.Count; i++)
                {

                    List<string> flightInfo = bookedFlights[i].getFlightInfo();
                    Console.WriteLine("{0}    {1}    {2}    {3}    {4}     {5}", i, flightInfo[0], flightInfo[1], flightInfo[2], flightInfo[3], bookedFlights[i].getFoodType());
                }
            }

        }

        public static void showAllFlights()
        {
            int counter = 0;
            List<User> customers = CustomerDL.getList();
            if (customers.Count == 0)
            {
                Console.WriteLine("no flight found");
            }
            else
            {
                Console.WriteLine("index     CustomerID     Departure      Destination     Date      Price      FoodType");
                foreach (Customer customer in customers)
                {

                    List<BookedFlight> bookedFlights = customer.getBookedFlights();
                    foreach (BookedFlight bookedFlight in bookedFlights)
                    {
                        List<string> flightInfo = bookedFlight.getFlightInfo();
                        Console.WriteLine("{0}    {1}    {2}    {3}    {4}   {5}    {6} ", counter, customer.getID(), flightInfo[0], flightInfo[1], flightInfo[2], flightInfo[3], bookedFlight.getFoodType());
                        counter += 1;
                    }
                }
            }
        }

        public static void removeBookedFlightsWhenFlightRemoved(Flight flight)
        {
            List<User> customers = CustomerDL.getList();
            
            foreach ( Customer customer in customers)
            {
                List<BookedFlight> bookedFlights = customer.getBookedFlights();
                bookedFlights.RemoveAll(item => item.getFlight() == flight);
            }
        }


    }
}
