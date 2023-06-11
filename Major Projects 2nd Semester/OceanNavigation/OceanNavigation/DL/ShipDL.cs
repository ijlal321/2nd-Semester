using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
using OceanNavigation.UI;
using OceanNavigation.DL;

namespace OceanNavigation.DL
{
    class ShipDL
    {
        static List<Ship> ships = new List<Ship>();

        public static void addShipToList(Ship ship)
        {
            ships.Add(ship);
        }

        public static Ship foundShipBySerial(string serial)
        {
            Ship Lost_ship = null;

            foreach (Ship ship in ships)
            {
                if ( ship.returnSerial() == serial )
                {
                    Lost_ship = ship;
                    break;
                }
            }
            return Lost_ship;
        }

        public static Ship foundShipByPosition(string Latitude, string Longitude)
        {
            Ship Lost_ship = null;

            foreach (Ship ship in ships)
            {
                if (ship.returnLatitude().giveAngle() == Latitude && ship.returnLongitude().giveAngle() == Longitude)
                {
                    Lost_ship = ship;
                    break;
                }
            }
            return Lost_ship;
        }

        public static void updatePosition(Ship ship)
        {
            Angle Latitude = AngleUI.createAngle();
            Angle Longitude = AngleUI.createAngle();

            ship.updatePosition(Latitude, Longitude);

        }


    }
}
