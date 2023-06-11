using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;

namespace OceanNavigation.UI
{
    class AngleUI
    {
        public static Angle createAngle()
        {
            Console.WriteLine("Enter Degree");
            int degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minute");
            float minute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Direction");
            char direction = char.Parse(Console.ReadLine());

            Angle angle = new Angle(degree, minute, direction);

            return angle;


        }
    }
}
