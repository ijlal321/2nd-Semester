using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Staff : Person
    {
        private string school;
        private double pay;

        public Staff(string name, string address, string school, double pay) : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }

        public string getSchool()
        {
            return this.school;
        }
        public double getPay()
        {
            return this.pay;
        }

        public void setSchool(string school)
        {
            this.school = school;
        }
        public void setPay(double pay)
        {
            this.pay = pay;
        }
        public override string toString()
        {
            string ans = base.toString() + " and school is " + this.school + " and pay is " + this.pay;
            return ans;
        }

    }
}
