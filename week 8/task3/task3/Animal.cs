using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Animal
    {
        protected string name;
         public Animal(string name)
         {
            this.name = name;
         }
        public virtual string toString()
        {
            string ans = "name is " + this.name;
            return ans;
        }

        public virtual void greet()
        {
            Console.WriteLine("animal greet");
        }

    }
}
