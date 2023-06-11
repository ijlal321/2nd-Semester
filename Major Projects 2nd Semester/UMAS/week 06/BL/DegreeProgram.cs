using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_06.BL
{
    class DegreeProgram
    {
        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeDuration = degreeDuration;
            this.degreeName = degreeName;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public string degreeName;
        public float degreeDuration;
        public int seats;
        public List<Subject> subjects;

        public bool Addsubjet(Subject s)
        {
            int credithours = calculateCHR();
            if (credithours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isSubjectExists(Subject sub)
        {
            foreach (Subject s in subjects)
            {
                if (s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }
        public int calculateCHR()
        {
            int count = 0;
            for (int x = 0; x < subjects.Count; x++)
            {
                count = count + subjects[x].creditHours;
            }
            return count;
        }

    }
}
