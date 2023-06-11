using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> l1 = new List<Shape>();
            Shape c1 = new Circle(3);
            Shape s1 = new Square(5);
            Shape r1 = new Rectangle(3, 6);

            l1.Add(c1);
            l1.Add(s1);
            l1.Add(r1);

            foreach ( Shape s in l1)
            {

                s.showInfo();
            }
            Console.ReadKey();

        }
    }
}
