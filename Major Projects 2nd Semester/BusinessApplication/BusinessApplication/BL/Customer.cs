using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.BL
{
    class Customer : User
    {
        List<BookedFlight> bookedFlights = new List<BookedFlight>();
        List<string> complains = new List<string>();


        public Customer()
        {

        }

        public Customer(string ID, string password) : base(ID, password, "customer")
        {

        }

        public override List<BookedFlight> getBookedFlights()
        {
            return bookedFlights;
        }

        public override List<string> getComplains()
        {
            return complains;
        }

        public override void setComplains(List<string> complains)
        {
            this.complains = complains;
        }

        public override void addBookedFlightIntoList(BookedFlight bookedFlight)
        {
            bookedFlights.Add(bookedFlight);
            bookedFlight.setCustomerID(this.ID);
        }

        public override void removeBookedFlightFromList(int option)
        {
            bookedFlights.RemoveAt(option);
        }

        public override void addComplainIntoList(string complain)
        {
            complains.Add(complain);
        }

        public override void removeComplainFromList(int option)
        {
            complains.RemoveAt(option);
        }

        public override bool isAnyFlightBooked()
        {
            if ( bookedFlights.Count == 0)
            {
                return false;
            }
            return true;
        }

        public override void changeFood(int option, string newFood)
        {
            bookedFlights[option].setFoodType(newFood);
        }

        public override void changeIDInAllBookedFLights(string newName)
        {
            foreach (BookedFlight bookedFlight in bookedFlights)
            {
                bookedFlight.setCustomerID(newName);
            }
        }



    }
}
