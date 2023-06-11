using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week_06.BL;

namespace week_06.UI
{
    class SubjectCRUD
    {
        public static Subject takeInputForSubject()
        {
            string code;
            string type;
            int credithours;
            int subjetfees;
            Console.Write("Enter subject code : ");
            code = Console.ReadLine();
            Console.Write("Enter Subject type : ");
            type = Console.ReadLine();
            Console.Write("Enter Subject credit hours  : ");
            credithours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees  : ");
            subjetfees = int.Parse(Console.ReadLine());
            Subject sub = new Subject(code, type, credithours, subjetfees);


            return sub;
        }
        public static void viewsubject(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Sub Code \t Sub Type");
                foreach (Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + " \t " + sub.type);
                }
            }
        }
        public static void registerSubjects(Student s)
        {
            Console.Write("Enter how many subjects you want to Register :");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.Write("Enter the subject Code : ");
                string code = Console.ReadLine();
                bool flag = false;
                foreach (Subject sub in s.regDegree.subjects)
                {
                    if (code == sub.code && !(s.regsubject.Contains(sub)))
                    {

                        if (s.redStudentSubject(sub))
                        {
                            flag = true;
                            break;

                        }
                        else
                        {
                            Console.WriteLine("A student cannot have more than 9 CH");
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter  valid course.");
                    x--;
                }
            }

        }
    }
}
