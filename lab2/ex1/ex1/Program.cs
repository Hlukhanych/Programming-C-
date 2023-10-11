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

            var newList = students.OrderBy(x => x.Course).Where(x => x.FormOfEducation == "zaochna");
            foreach (var student in newList)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}