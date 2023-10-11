using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        PrintXMLFile();
        CountGirlsInClass();
        CalculateAverageGradeInClass();
    }

    static void PrintXMLFile()
    {
        XDocument doc = XDocument.Load("C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\lab3\\ex1\\Shkola.xml");
        Console.WriteLine(doc.ToString());
    }

    static void CountGirlsInClass()
    {
        Console.WriteLine("Введіть назву класу для пошуку кількості дівчат (формат: 9А):");
        string className = Console.ReadLine();

        XDocument doc = XDocument.Load("C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\lab3\\ex1\\Shkola.xml");

        var girlCount = doc.Descendants("Student")
                           .Where(x => (string)x.Element("Class").Element("Year") + (string)x.Element("Class").Element("Letter") == className
                                        && (string)x.Element("Gender") == "жін.")
                           .Count();

        Console.WriteLine($"Кількість дівчат у класі {className}: {girlCount}");
    }

    static void CalculateAverageGradeInClass()
    {
        Console.WriteLine("Введіть назву класу для обчислення середньої оцінки (формат: 9А):");
        string className = Console.ReadLine();

        XDocument doc = XDocument.Load("C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\lab3\\ex1\\Shkola.xml");

        var averageGrade = doc.Descendants("Student")
                              .Where(x => (string)x.Element("Class").Element("Year") + (string)x.Element("Class").Element("Letter") == className)
                              .Average(x => (double.Parse(x.Element("Grade1").Value) + double.Parse(x.Element("Grade2").Value)) / 2.0);

        Console.WriteLine($"Середня оцінка у класі {className}: {averageGrade:F2}");
    }
}