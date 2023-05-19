using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_time
{
    internal class Subjects
    {
        public string subjectCode;
        public string subjectType;
        public int creditHours;
        public float FeeOfSubject;
        public Subjects(string subjectCode, string subjectType, int creditHours, float feeOfSubject)
        {
            this.subjectCode = subjectCode;
            this.subjectType = subjectType;
            this.creditHours = creditHours;
            this.FeeOfSubject = feeOfSubject;
        }

    }
}
