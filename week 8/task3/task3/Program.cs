using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> l1 = new List<Animal>();

            Animal d1 = new Dog("d1");
            Animal d2 = new Dog("d2");
            Animal d3 = new Dog("d3");

            Animal c1 = new Cat("c1");
            Animal c2 = new Cat("c2");
            Animal c3 = new Cat("c3");

            l1.Add(d1);
            l1.Add(d2);
            l1.Add(d3);

            l1.Add(c1);
            l1.Add(c2);
            l1.Add(c3);

            foreach ( Animal a in l1)
            {
                Console.WriteLine(a.toString());
            }

            foreach (Animal a in l1)
            {
                a.greet();
            }
            Dog newDog = new Dog("d5");
            Dog newDog2 = new Dog("d6");
            newDog.greet(newDog2);
            Console.ReadKey();
        }
    }
}
