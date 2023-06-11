using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int getArea()
        {
            return (this.radius * this.radius);
        }

        public override void showInfo()
        {
            Console.WriteLine("the shape is circle and its area is " + getArea().ToString());
        }
    }
}
