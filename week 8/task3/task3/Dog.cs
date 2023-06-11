using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Dog : Mammal
    {
        public Dog(string name) : base(name)
        {
        }

        public override void greet()
        {
            Console.WriteLine("woof");
        }

        public void greet(Dog another)
        {
            Console.WriteLine("wooooof");
        }

        public override string toString()
        {
            return base.toString();
        }
    }
}
