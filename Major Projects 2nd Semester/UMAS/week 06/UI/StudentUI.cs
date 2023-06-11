using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week_06.BL;
using week_06.DL;
using static week_06.DL.DegreeProgramDL;

namespace week_06.UI
{
    class StudentCRUD
    {
        public static void calculatefeeforALl()
        {
            foreach (Student s in StudentList.studentlist)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "  has " + s.calfees() + "  fees");
                }
            }
        }
        public static void printstudents()
        {
            foreach (Student s in StudentList.studentlist)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "  got admission in  " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not got admission ");

                }
            }
        }
        public static void viewstudentindegree(string degname)
        {
            Console.WriteLine("Name \t FSC \t ECAT \t AGE");
            foreach (Student s in StudentList.studentlist)
            {
                if (s.regDegree != null)
                {
                    if (degname == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }
        public static void viewRegisteredstudent()
        {
            Console.WriteLine("Name \t FSC \t ECAT \t AGE");
            foreach (Student s in StudentList.studentlist)
            {
                if (s.regDegree != null)
                {

                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);

                }
            }
        }
        public static Student takeInputforStudent()
        {
            string name;
            int age;
            double fscmarks;
            double eactmarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student name : ");
            name = Console.ReadLine();
            Console.Write("Enter student age : ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Fsc marks  : ");
            fscmarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student eact marks   : ");
            eactmarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available degree programs  : ");
            DegreeProgramCRUD.viewdegreeprograme();
            Console.Write("Enter how many preferences to Enter  : ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                string degreename = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in DegreeProgramList.programlist)
                {
                    if (degreename == dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid degree program Name");
                    x--;
                }
            }
            Student s = new Student(name, age, fscmarks, eactmarks, preferences);
            return s;
        }
    }
}
