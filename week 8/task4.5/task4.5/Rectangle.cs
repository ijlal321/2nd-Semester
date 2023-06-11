using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4._5
{
    class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public int getArea()
        {
            return (this.height * this.width);
        }

        public override void showInfo()
        {
            Console.WriteLine("the shape is rectangle and its area is " + getArea().ToString());
        }
    }
}
