using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal class Sudent
    {
        private int recordBookNumber;
        public int RecordBookNumber { get {  return recordBookNumber; } set {  recordBookNumber = value; } }

        private string surname;
        public string Surname { get {  return surname; } set {  surname = value; } }

        private string faculty;
        public string Faculty { get {  return faculty; } set {  faculty = value; } }

        private int course;
        public int Course { get {  return course; } set { course = value; } }

        private string formOfEducation;
        public string FormOfEducation { get {  return formOfEducation; } set {  formOfEducation = value; } }

        public Sudent(int recordBookNumber, string surname, string faculty, int course, string formOfEducation)
        {
            RecordBookNumber = recordBookNumber;
            Surname = surname;
            Faculty = faculty;
            Course = course;
            FormOfEducation = formOfEducation;
        }
    }
}
