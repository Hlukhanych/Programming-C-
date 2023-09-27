using ex1;
using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudent s1 = new Sudent(1, "Ivanenko", "Physical", 2, "ochna");
            Sudent s2 = new Sudent(2, "Ovcharenko", "Philological", 3, "ochna");
            Sudent s3 = new Sudent(3, "Stepanenko", "Mathematical", 2, "ochna");
            Sudent s4 = new Sudent(4, "Smirnov", "Mathematical", 1, "ochna");
            Sudent s5 = new Sudent(5, "Ivanov", "Mathematical", 3, "zaochna");

            List<Sudent> students = new List<Sudent>() { s1, s2, s3, s4, s5 };

            foreach (var student in students)
            {
                
            }
        }
    }
}