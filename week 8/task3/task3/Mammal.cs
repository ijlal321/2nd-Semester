using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Mammal : Animal
    { 
        public Mammal(string name): base (name)
        {
        }
        public override string toString()
        {
            return base.toString();
        }

        public override void greet()
        {
            Console.WriteLine("mammal greet");
        }

    }
}
