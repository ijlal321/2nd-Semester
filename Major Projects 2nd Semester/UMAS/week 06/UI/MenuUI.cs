using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_06.UI
{
    class Menu
    {
        public static void header()
        {
            Console.WriteLine("******************************************************************");
            Console.WriteLine("******        University Admission Management System        ******               ");
            Console.WriteLine("******************************************************************");

        }

        public static void clearScreen()
        {
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }

        public static string menu()
        {
            clearScreen();
            header();
            string option;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
            option = Console.ReadLine();
            return option;
        }

    }
}
