using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4._5
{
    class Square : Shape
    {
        private int side;

        public Square(int side)
        {
            this.side = side;
        }

        public int getArea()
        {
            return (this.side * this.side);
        }

        public override void showInfo()
        {
            Console.WriteLine("the shape is square and its area is " + getArea().ToString());
        }
    }
}
