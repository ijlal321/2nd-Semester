using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using week_06.BL;

namespace week_06.DL
{
    class SubjectList
    {
       public static List<SubjectList> subjects = new List<SubjectList>();

        public static void setSubjectIntoList(SubjectList s)
        {
            subjects.Add(s);
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] spilletedRecord = record.Split(',');
                    string code = spilletedRecord[0];
                    string type = spilletedRecord[1];
                    int creditHours = int.Parse(spilletedRecord[2]);
                    int subjectFees = int.Parse(spilletedRecord[3]);
                    Subject s = new Subject(code, type, creditHours, subjectFees);
                    setSubjectIntoList(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void storeintoFile(string path, Subject s)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFees);
            f.Flush();
            f.Close();

        }
        private static void setSubjectIntoList(Subject s1)
        {
            throw new NotImplementedException();
        }

        internal static Subject setSubjectIntoList(string v)
        {
            throw new NotImplementedException();
        }
    }
}
