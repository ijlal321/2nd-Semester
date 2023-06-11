using BusinessApplication.BL;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.UI
{
    class FlightUI
    {
        public static Flight takeInputFromConsole()
        {
            string departurePoint;
            string destination;
            string flightDate;
            string flightPrice;

            Console.WriteLine("input departure");
            departurePoint = Console.ReadLine();

            Console.WriteLine("input destination");
            destination = Console.ReadLine();

            Console.WriteLine("input flightDate");
            flightDate = Console.ReadLine();

            Console.WriteLine("input flightPrice");
            flightPrice = Console.ReadLine();

            Flight flight = new Flight(departurePoint, destination, flightDate, flightPrice);

            return flight;
        }


        public static void removeFlight()
        {
            if ( FlightDL.isAnyFlightAvailable() == false)
            {
                Console.WriteLine("no flights available");
            }
            else
            {
                showAllFlight();
                Console.WriteLine("enter Flight you want to remove");
                int option = int.Parse(Console.ReadLine());

                BookedFlightUI.removeBookedFlightsWhenFlightRemoved(FlightDL.getSpecificFlight(option));
                FlightDL.removeFlight(option);
                Console.WriteLine("flight removed");
            }

        }

        public static void showAllFlight()
        {
            List<Flight> flights = FlightDL.getList();

            Console.WriteLine("departure        destination     price       date");
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine("{0}.  {1}    {2}    {3}    {4}", i,  flights[i].getDeparturePoint(), flights[i].getDestination(), flights[i].getFlightPrice() , flights[i].getFlightDate() );
            }

        }

        public static void showSpecificIndexFlight(List<int> indexes)
        {
            List<Flight> flights = FlightDL.getList();

            Console.WriteLine("departure        destination     price       date");
            for (int i = 0; i < indexes.Count; i++) 
            {
                Console.WriteLine("{0}.  {1}    {2}    {3}    {4}", i, flights[indexes[i]].getDeparturePoint(), flights[indexes[i]].getDestination(), flights[indexes[i]].getFlightPrice(), flights[indexes[i]].getFlightDate());
            }

        }

        public static void searchFlight()
        {
            Console.WriteLine("enter what you want, or write any");
            Flight tempFlight = takeInputFromConsole();

            List<int> indexes = FlightDL.searchFlight(tempFlight.getDeparturePoint(), tempFlight.getDestination(), tempFlight.getFlightDate(), tempFlight.getFlightPrice());

            
            if (indexes.Count == 0)
            {
                Console.WriteLine(" no found");
            }
            else
            {
                Console.WriteLine(" available flights are ");
                showSpecificIndexFlight(indexes);
            }

        }

        public static void changePrice()
        {
            if (FlightDL.isAnyFlightAvailable() == false)
            {
                Console.WriteLine("no flights available");
            }
            else
            {
                Console.WriteLine("select what you want to change");
                showAllFlight();

                int option;
                option = int.Parse(Console.ReadLine());

                int newPrice;
                Console.WriteLine("enter new price");
                newPrice = int.Parse(Console.ReadLine());

                FlightDL.changePrice(option, newPrice);
            }
        }



    }
}
