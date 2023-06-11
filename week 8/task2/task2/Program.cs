using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> list = new List<Person>();


            Person s1 = new Staff("Ijlal", "home", "School", 10);
            Person s2 = new Student("Ijlal", "home", "CS", 2023, 20.0f);


            list.Add(s1);
            list.Add(s2);
            foreach(Person p in list)
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine(s1.toString());
            Console.WriteLine(s2.toString());
            Console.ReadKey();
        }
    }
}
