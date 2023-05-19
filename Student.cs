using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_time
{
    internal class Student
    {
        public string Name;
        public int age;
        public float ecatMarks;
        public float fscMarks;
        public float Merit = 0;
        public int NumberOfPreferences = 1;
        List<DegreeProgram> preferences;
        public Student(string name, int age, float ecatMarks, float fscMarks, int numberOfPreferences)
        {
            GenerateMerit();
            preferences = new List<DegreeProgram>();
            this.Name = name;
            this.age = age;
            this.ecatMarks = ecatMarks;
            this.fscMarks = fscMarks;
            this.NumberOfPreferences = numberOfPreferences;
        }
        public float GenerateMerit()
        {
            Merit = (fscMarks / 100) * 70 + (ecatMarks / 100) * 30;
            return Merit;
        }
        public bool addPreference(DegreeProgram degree)
        {
            foreach (var OBJ in preferences)
            {
                if (OBJ == degree)
                {
                    return false;
                }
            }
            preferences.Add(degree);
            return true;
        }
    }
}
