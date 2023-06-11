using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.BL
{
    class Flight
    {
        string departurePoint;
        string destination;
        string flightDate;
        string flightPrice;

        int uniqueID;

        public Flight()
        {

        }
        public Flight(string departurePoint, string destination, string flightDate, string flightPrice)
        {
            this.departurePoint = departurePoint;
            this.destination = destination;
            this.flightPrice = flightPrice;
            this.flightDate = flightDate;
        }

        public Flight(string departurePoint, string destination, string flightDate, string flightPrice, int uniqueID)
        {
            this.departurePoint = departurePoint;
            this.destination = destination;
            this.flightPrice = flightPrice;
            this.flightDate = flightDate;
            this.uniqueID = uniqueID;
        }


        public void setId(int uniqueID)
        {
            this.uniqueID = uniqueID;
        }
        public int getId()
        {
            return uniqueID;
        }


        public string getDeparturePoint()
        {
            return this.departurePoint;
        }

        public string getDestination()
        {
            return this.destination;
        }

        public string getFlightDate()
        {
            return this.flightDate;
        }

        public string getFlightPrice()
        {
            return this.flightPrice;
        }

        public void setDeparturePoint(string departurePoint)
        {
            this.departurePoint = departurePoint;
        }

        public void setDestination(string destination)
        {
            this.destination = destination;
        }

        public void setFlightDate(string flightDate)
        {
            this.flightDate = flightDate;
        }

        public void setFlightPrice(string flightPrice)
        {
            this.flightPrice = flightPrice;
        }



    }
}
