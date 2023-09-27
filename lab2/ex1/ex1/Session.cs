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
        public int RecordBookNumberS { get {  return recordBookNumberS; } set {  recordBookNumberS = value; } }

        private List<string> name;
        public List<string> Name { get {  return name; } set { name = value; } }

        private List<int> assessments;
        public List<int> Assessments { get {  return assessments; } set {  assessments = value; } }

        public Session(int recordBookNumberS, List<string> name, List<int> assessments)
        {
            RecordBookNumberS = recordBookNumberS;
            Name = name;
            Assessments = assessments;
        }
    }
}
