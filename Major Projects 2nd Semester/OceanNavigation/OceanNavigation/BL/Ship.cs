using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.UI;


namespace OceanNavigation.BL
{
    class Ship
    {
        string serial;
        Angle Latitude;
        Angle Longitude;

        public Ship (string serial, Angle Latitude, Angle Longitude )
        {
            this.serial = serial;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

        public string returnSerial()
        {
            return serial;
        }

        public Angle returnLatitude()
        {
            return Latitude;
        }

        public Angle returnLongitude()
        {
            return Longitude;
        }

        public void updatePosition(Angle Latitude, Angle Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }


    }
}
