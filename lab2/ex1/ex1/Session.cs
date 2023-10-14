using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal class Session
    {
        private int recordBookNumberS;
        public int RecordBookNumberS { get { return recordBookNumberS; } set { recordBookNumberS = value; } }

        private List<string> subjectName;
        public List<string> SubjectName { get { return subjectName; } set { subjectName = value; } }

        private List<int> grade;
        public List<int> Grade { get { return grade; } set { grade = value; } }

        public Session(int recordBookNumberS, List<string> subjectName, List<int> grade)
        {
            RecordBookNumberS = recordBookNumberS;
            SubjectName = subjectName;
            Grade = grade;
        }
    }
}
