using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task1
{
    class Cylinder : Circle
    {
        private double height;

        public Cylinder()
        {
            this.height = 1.0f;
        }
        public Cylinder(double radius) : base(radius)
        {
            this.height = 1.0f;
        }
        public Cylinder(double radius, double height) : base(radius)
        {
            this.height = height;
        }
        public Cylinder(double radius, double height, string color) : base(radius, color)
        {
            this.height = height;
        }
        public double getHeight()
        {
            return this.height;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public double getVolume()
        {
            return getArea() * this.height;
        }








    }
}
