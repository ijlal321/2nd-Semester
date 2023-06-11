using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
using OceanNavigation.UI;
using OceanNavigation.DL;

namespace OceanNavigation.UI
{
    class ShipUI
    {
        public static Ship createShip()
        {
            Console.WriteLine("enter serial number");
            string serial = Console.ReadLine();

            Console.WriteLine("enter Latitude ");
            Angle Latitude = AngleUI.createAngle();
            Console.WriteLine("enter Longitude");
            Angle Longitude = AngleUI.createAngle();

            Ship ship = new Ship(serial, Latitude, Longitude);
            return ship;
        }

        public static void updatePosition()
        {
            Console.WriteLine("Enter Serial");
            string serial = Console.ReadLine();
            Ship ship = ShipDL.foundShipBySerial(serial);
            if (ship != null)
            {
                ShipDL.updatePosition(ship);
            }
            else
            {
                Console.WriteLine("No Ship Found");
            }
        }
        public static void viewShipPosition()
        {
            Console.WriteLine("Enter Serial");
            string serial = Console.ReadLine();
            Ship ship = ShipDL.foundShipBySerial(serial);

            if (ship != null)
            {
                Angle Latitude = ship.returnLatitude();
                Angle Longitude = ship.returnLongitude();

                Console.WriteLine("Ship is at {0} and {1}", Latitude.giveAngle(), Longitude.giveAngle());
            }
            else
            {
                Console.WriteLine("No Ship Found");
            }

        }
        public static void viewShipSerial()
        {
            Console.WriteLine("Enter Latitude");
            string Latitude = Console.ReadLine();
            Console.WriteLine("Enter Longitude");
            string Longitude = Console.ReadLine();
            Ship ship = ShipDL.foundShipByPosition(Latitude, Longitude);

            if (ship != null)
            {
                string serial = ship.returnSerial();

                Console.WriteLine("Ship serial is: " + serial);
            }
            else
            {
                Console.WriteLine("No Ship Found");
            }

        }
    }
}





