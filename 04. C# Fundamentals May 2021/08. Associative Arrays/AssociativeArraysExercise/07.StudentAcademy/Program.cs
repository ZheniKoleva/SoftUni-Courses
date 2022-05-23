using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                FillStudentData(studentsGrades, name, grade);
            }

            PrintData(studentsGrades);


        }

        private static void PrintData(Dictionary<string, List<double>> studentsGrades)
        {

            Dictionary<string, double> filtered = studentsGrades
                .Where(x => x.Value.Average() >= 4.50)                
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value.Average());


            foreach (var student in filtered)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }

        private static void FillStudentData(Dictionary<string, List<double>> studentsGrades, string name, double grade)
        {
            if (!studentsGrades.ContainsKey(name))
            {
                studentsGrades.Add(name, new List<double>());
            }

            studentsGrades[name].Add(grade);
        }
    }
}
