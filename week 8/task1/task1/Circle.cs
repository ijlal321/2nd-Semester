using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Circle
    {
        protected double radius;
        protected string color;

        public Circle()
        {
            this.radius = 1.0f;
            this.color = "red";
        }

        public Circle(double radius)
        {
            this.radius = radius;
            this.color = "red";
        }

        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double getRadius()
        {
            return radius;
        }
        public string getColor()
        {
            return color;
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public double getArea()
        {
            double area = Math.Pow(this.radius, 2) * 3.14;
            return area;
        }
        public string toString()
        {
            string ans = "radius is " + this.radius + " and color is " + this.color + "and area is " + (getArea().ToString());
            return ans;
        }


    }
}
