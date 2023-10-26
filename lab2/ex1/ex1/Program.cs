using ex1;
using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sudent> students = new List<Sudent>()
            {
                new Sudent(1, "Ivanenko", "Physical", 2, "ochna"),
                new Sudent(2, "Ovcharenko", "Philological", 3, "ochna"),
                new Sudent(3, "Stepanenko", "Mathematical", 2, "zaochna"),
                new Sudent(4, "Smirnov", "Mathematical", 1, "ochna"),
                new Sudent(5, "Ivanov", "Mathematical", 3, "ochna"),
                new Sudent(6, "Halin", "Physical", 3, "zaochna"),
                new Sudent(7, "Malcev", "Philological", 2, "zaochna"),
                new Sudent(8, "Svin", "Engineering", 1, "zaochna")
            };

            List<Session> sessions = new List<Session>()
            {
                new Session(1, new List<string> {"math", "programming", "physic", "english"}, new List<int> {5, 4, 5, 4}),
                new Session(2, new List<string> {"math", "english", "ukraine"}, new List<int> {3, 4, 5,}),
                new Session(3, new List<string> {"math", "programming", "english"}, new List<int> {4, 5, 4}),
                new Session(4, new List<string> {"math", "programming", "english"}, new List<int> {3, 4, 4}),
                new Session(5, new List<string> {"math", "programming", "english"}, new List<int> {4, 5, 4}),
                new Session(6, new List<string> {"math", "programming", "physic", "english"}, new List<int> {3, 4, 5, 4}),
                new Session(7, new List<string> {"math", "english", "ukraine"}, new List<int> {4, 5, 5,}),
                new Session(8, new List<string> {"math", "programming", "physic", "english", "engineering"}, new List<int> {4, 5, 5, 4, 5})
            };

            // a
            var partTimeStudentsPerFaculty = students
                .Where(s => s.StudyForm == "zaochna")
                .GroupBy(s => new { s.Faculty, s.Course })
                .Select(g => new { g.Key.Faculty, g.Key.Course, Count = g.Count() });

            foreach (var item in partTimeStudentsPerFaculty)
            {
                Console.WriteLine($"Факультет: {item.Faculty}, Курс: {item.Course}, Кількість заочників: {item.Count}");
            }

            // b
            var studentsWithScholarship = students
                .Join(sessions, student => student.RecordBookNumber, session => session.RecordBookNumberS, (student, session) => new { student, session })
                .Where(combined => combined.student.StudyForm == "Денна" && combined.session.Grade.Average() >= 4)
                .OrderBy(combined => combined.student.Faculty)
                .Select(combined => combined.student.Surname);

            foreach (var surname in studentsWithScholarship)
            {
                Console.WriteLine(surname);
            }

            // c
            var facultiesWithLeastHonors = sessions
                .SelectMany(s => s.Grade, (s, grade) => new { s.RecordBookNumberS, Grade = grade })
                .Where(s => s.Grade == 5)
                .Join(students, s => s.RecordBookNumberS, student => student.RecordBookNumber, (s, student) => student.Faculty)
                .GroupBy(f => f)
                .OrderBy(f => f.Count())
                .Take(3)
                .Select(f => f.Key);

            foreach (var faculty in facultiesWithLeastHonors)
            {
                Console.WriteLine(faculty);
            }

        }
    }
}