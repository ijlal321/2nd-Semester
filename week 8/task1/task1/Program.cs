using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {


        static void Main(string[] args)
        {
            Cylinder c1 = new Cylinder();
            Cylinder c2 = new Cylinder(10.0f);
            Cylinder c3 = new Cylinder(10.0f, 10.0f);

            Console.WriteLine(c3.getRadius());
            Console.WriteLine(c3.getHeight());
            Console.WriteLine(c3.getArea());
            Console.WriteLine(c3.getVolume());
            Console.ReadKey();

        }
    }
}
