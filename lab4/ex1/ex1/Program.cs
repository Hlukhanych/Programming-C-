using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        PrintJSONFile();
        CountGirlsInClass();
        CalculateAverageGradeInClass();
    }

    static void PrintJSONFile()
    {
        string jsonText = File.ReadAllText("C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\lab4\\ex1\\Shkola.json");
        Console.WriteLine(jsonText);
    }

    static void CountGirlsInClass()
    {
        Console.WriteLine("Введіть назву класу для пошуку кількості дівчат (формат: 9А):");
        string className = Console.ReadLine();

        string jsonText = File.ReadAllText("C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\lab4\\ex1\\Shkola.json");
        var students = JsonConvert.DeserializeObject<List<Student>>(jsonText);

        int girlCount = students.Count(student => student.Class.Year + student.Class.Letter == className && student.Gender == "жін.");
        Console.WriteLine($"Кількість дівчат у класі {className}: {girlCount}");
    }

    static void CalculateAverageGradeInClass()
    {
        Console.WriteLine("Введіть назву класу для обчислення середньої оцінки (формат: 9А):");
        string className = Console.ReadLine();

        string jsonText = File.ReadAllText("C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\lab4\\ex1\\Shkola.json");
        var students = JsonConvert.DeserializeObject<List<Student>>(jsonText);

        var classStudents = students.Where(student => student.Class.Year + student.Class.Letter == className).ToList();
        double averageGrade = classStudents.Average(student => (student.Grade1 + student.Grade2) / 2.0);

        Console.WriteLine($"Середня оцінка у класі {className}: {averageGrade:F2}");
    }
}

class Student
{
    public string LastName { get; set; }
    public string Gender { get; set; }
    public Class Class { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
}

class Class
{
    public string Year { get; set; }
    public string Letter { get; set; }
}