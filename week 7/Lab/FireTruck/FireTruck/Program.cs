using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruck
{
    class Program
    {
        class Hosepipe
        {
            protected string material;
            protected string shape;
            protected int diameter;
            protected int flowrate;

            public Hosepipe(string material, string shape, int diameter, int flowrate)
            {
                this.material = material;
                this.shape = shape;
                this.diameter = diameter;
                this.flowrate = flowrate;
            }
            public string getMaterial()
            {
                return material;
            }
            public string getShape()
            {
                return shape;
            }

        }
        class FireTruck
        {
            protected int LadderLength;
            protected string color;
            protected Hosepipe pipe;


            public FireTruck(int LadderLength, string color, Hosepipe pipe)
            {
                this.LadderLength = LadderLength;
                this.color = color;
                this.pipe = pipe;
            }

            public void showInfo()
            {
                Console.WriteLine("this truck has ladder length {0} and pipe of material {1} and shape {2} ", LadderLength, pipe.getMaterial(), pipe.getShape());
            }
        }

        class FireFighter
        {
            protected FireTruck truck;
            protected string name;

            public FireFighter(FireTruck truck, string name)
            {
                this.truck = truck;
                this.name = name ;
            }

            public void showInfo()
            {
                Console.WriteLine("the fighter name is {0}", this.name);
                truck.showInfo();
            }
        }

        class Chief : FireFighter
        {
            public Chief(FireTruck truck, string name) : base(truck, name)
            {

            }
        }


        static void Main(string[] args)
        {
            Hosepipe pipe = new Hosepipe("plastic", "oval", 1,2);
            FireTruck newTruck = new FireTruck(4, "red", pipe);
            // FireFighter fighter = new FireFighter(newTruck, "ali");
            Chief chief = new Chief(newTruck, "ali");
            chief.showInfo();
            Console.ReadKey();

        }
    }
}
