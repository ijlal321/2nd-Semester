using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week_06.DL;
using week_06.UI;

namespace week_06.BL
{
    class Student
    {
        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regsubject = new List<Subject>();
        }
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<DegreeProgram> preferences;
        public List<Subject> regsubject;
        public DegreeProgram regDegree;
        public void calculatemerit()
        {
            this.merit = (((fscMarks / 1100) * 0.4F) + ((ecatMarks / 400) * 0.55F)) * 100;
        }
        public bool redStudentSubject(Subject s)
        {
            int subCH = getCHR();
            if (regDegree != null && regDegree.isSubjectExists(s) && subCH + s.creditHours <= 9)
            {
                regsubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getCHR()
        {
            int count = 0;
            foreach (Subject sub in regsubject)
            {
                count = count + sub.creditHours;
            }
            return count;
        }
        public float calfees()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regsubject)
                {
                    fee = fee + sub.subjectFees;
                }
            }
            return fee;
        }
    }
}
