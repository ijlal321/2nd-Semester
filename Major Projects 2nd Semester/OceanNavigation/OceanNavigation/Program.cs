using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
using OceanNavigation.UI;
using OceanNavigation.DL;


namespace OceanNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            while (true)
            {
                Console.WriteLine("input");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Ship ship = ShipUI.createShip();
                    ShipDL.addShipToList(ship);
                }
                if (option == 2)
                {
                    ShipUI.viewShipPosition();
                }
                if (option == 3)
                {
                    ShipUI.viewShipSerial();
                }
                if (option == 4)
                {
                    ShipUI.updatePosition();
                }
                if (option == 5)
                {
                    break;
                }
            }

        }
    }
}
