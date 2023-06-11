using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pointGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameObject g = new GameObject(new Point(20,20));

            while (true)
            {
                g.erase();
                g.move();
                g.draw();
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }
    }
}
