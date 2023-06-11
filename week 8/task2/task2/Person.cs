using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Person
    {
        protected string name;
        protected string address;

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        public string getName()
        {
            return this.name;
        }
        public string getAddress()
        {
            return this.address;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }
        public virtual string toString()
        {
            string ans = "name is " + this.name + " and address is " + this.address;
            return ans;
        }
    }
}
