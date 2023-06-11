using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Student : Person
    {
        private string program;
        private int year;
        private double fee;

        public Student (string name, string address, string program, int year, double fee) : base (name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }

        public void setProgram(string program)
        {
            this.program = program;
        }
        public void setyear(int year)
        {
            this.year = year;
        }
        public void setFee(double fee)
        {
            this.fee = fee;
        }
        public string getProgram()
        {
            return this.program;
        }
        public int getyear()
        {
            return this.year;
        }
        public double getFee()
        {
            return this.fee;
        }

        public override string toString()
        {
            string ans = base.toString()+ " and program is " + this.program + " and year is " + this.year + " and fee is " + this.fee;
            return ans;
        }
    }
}
