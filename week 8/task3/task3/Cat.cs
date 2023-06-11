using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Cat : Mammal
    {
        public Cat(string name) : base(name)
        {
        }

        public override void greet()
        {
            Console.WriteLine("meow");
        }

        public override string toString()
        {
            return base.toString();
        }

    }
}
