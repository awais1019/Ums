using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_time
{
    internal class DegreeProgram
    {
        public string degreeTitle;
        public string degreeDuration;
        public int NumberOfSubjects;
        public int SubjectsCount = 0 ;
        public float Merit;
        public List<Subjects> subjects;
        public DegreeProgram(string degreeTitle,string degreeDuration, int numberOfSubjects,float Merit)
        {
            subjects = new List<Subjects>();
            this.degreeTitle = degreeTitle;
            this.degreeDuration = degreeDuration;
            this.NumberOfSubjects = numberOfSubjects;
            this.Merit = Merit;

        }
        public void Display()
        {
            Console.WriteLine(degreeTitle + " " + degreeDuration);
        }
        public void addSubject(Subjects subject)
        {
            subjects.Add(subject);
        }
        public bool removeSubject(string code)
        {
            foreach(var  subject in subjects)
            {
                if (subject.subjectCode == code)
                {
                    subjects.Remove(subject);
                    return true;
                }
            }
            return false;
        }
        public void DisplaySubjects()
        {
            foreach (Subjects subject in subjects)
            {
                Console.WriteLine(subject.subjectCode+" "+subject.subjectType+" "+subject.creditHours);
            }
        }
        public int CalculateCreditsHours()
        {
            int sum = 0;
            foreach(Subjects OBJ in subjects)
            {
                sum += OBJ.creditHours;
            }
            return sum;
        }

    }
}
