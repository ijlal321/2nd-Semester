using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.BL
{
    class User
    {
        protected string ID;
        protected string password;
        protected string role;

        public User()
        {
        }

        public User(string ID, string password, string role)
        {
            this.password = password;
            this.ID = ID;
            this.role = role;
        }

        public string getID()
        {
            return this.ID;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getRole()
        {
            return this.role;
        }

        public void setID(string ID)
        {
            this.ID = ID;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void setRole(string role)
        {
            this.role = role;
        }



        // CUSTOMER VIRTUAL FUNCTIONS
        public virtual void addBookedFlightIntoList(BookedFlight bookedFlight)
        {

        }

        public virtual List<BookedFlight> getBookedFlights()
        {
            return null;
        }

        public virtual List<string> getComplains()
        {
            return null;
        }

        public virtual void setComplains(List<string> complains)
        {
            
        }

        public virtual void removeBookedFlightFromList(int option)
        {

        }

        public virtual void addComplainIntoList(string complain)
        {

        }

        public virtual void removeComplainFromList(int option)
        {

        }

        public virtual bool isAnyFlightBooked()
        {
            return true;
        }

        public virtual void changeFood(int option, string newFood)
        {

        }

        public virtual void changeIDInAllBookedFLights(string newName)
        {
        }
    }
}
