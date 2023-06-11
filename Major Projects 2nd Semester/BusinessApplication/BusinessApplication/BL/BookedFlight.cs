using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.BL
{
    class BookedFlight
    {
        Flight flight;
        string foodType;
        string customerID;

        public BookedFlight()
        {

        }

        public BookedFlight(Flight flight, string foodType)
        {
            this.flight = flight;
            this.foodType = foodType;
        }

        public BookedFlight(Flight flight, string foodType, string customerID)
        {
            this.flight = flight;
            this.foodType = foodType;
            this.customerID = customerID;
        }

        public Flight getFlight()
        {
            return flight;
        }

        public void setCustomerID(string customerID)
        {
            this.customerID = customerID;
        }
        public string getCustomerID()
        {
            return customerID;
        }

        public List<string> getFlightInfo()
        {
            List<string> flightInfo = new List<string>() {this.flight.getDeparturePoint(), this.flight.getDestination(), this.flight.getFlightDate(), this.flight.getFlightPrice() };
            return flightInfo;
        }

        public string getFoodType()
        {
            return this.foodType;
        }

        public void setFoodType(string newFood)
        {
            this.foodType = newFood;
        }
    }
}
